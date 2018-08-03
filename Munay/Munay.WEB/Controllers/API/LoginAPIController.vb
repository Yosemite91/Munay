Imports System.Net
Imports System.Web.Http
Imports Munay.DATA

Namespace Controllers.API
    <RoutePrefix("api/login")>
    Public Class LoginAPIController
        Inherits ApiController

        <HttpPost>
        <Route("", Name:="PostLogin")>
        Public Function PostLogin(<FromBody> model As Models.UsuariosDTO) As IHttpActionResult
            If model Is Nothing Then
                Return Me.Content(HttpStatusCode.BadRequest, "Sin Datos en el formulario")
            End If

            Dim db As New MunayDBContext
            Try

                Dim user As Usuario = db.Usuarios.Where(Function(u) u.Email = model.Email And u.Password = model.Password).SingleOrDefault()
                If user Is Nothing Then Return Me.Content(HttpStatusCode.Unauthorized, "Usuario o Contraseña inválidos")

                Dim tokenActual As String = RandomString(10)

                With model
                    .Email = user.Email
                    .Password = tokenActual
                End With

                Return Me.Ok(model)
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, ex.Message)
            Finally
                db.Dispose()
            End Try
        End Function

        Public Function RandomString(cb As Integer) As String
            Randomize()
            Dim rgch As String
            rgch = "abcdefghijklmnopqrstuvwxyz"
            rgch = rgch & UCase(rgch) & "0123456789"

            Dim i As Long
            Dim result As String = String.Empty
            For i = 1 To cb
                result &= Mid$(rgch, CInt(Int(Rnd() * Len(rgch) + 1)), 1)
            Next
            Return result
        End Function
    End Class
End Namespace