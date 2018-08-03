Imports System.Net
Imports System.Web.Http
Imports Munay.DATA
Imports Munay.WEB.Models

Namespace Controllers.APIControllers
    <RoutePrefix("api/redsociales")>
    Public Class RedsocialesAPIController
        Inherits ApiController

#Region "Get Fotos"
        <Route("get-fotos", Name:="getFotos")>
        <HttpGet>
        Public Function GetFotos() As IHttpActionResult
            Dim db As New MunayDBContext()

            Dim redes As List(Of Redsocial) = Nothing
            Dim redesDto As New List(Of RedsocialModel)


            Try
                redes = db.Redsociales.Take(5).ToList()

                For Each red As Redsocial In redes
                    redesDto.Add(New RedsocialModel With {
                                    .FotoStr = Encoding.Default.GetString(red.Foto)
                                 })
                Next
                Return Me.Ok(redesDto)
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, String.Format("Problemas para retornar información. Error: {0}", ex.Message))
            Finally
                db.Dispose()
            End Try
        End Function
#End Region
    End Class
End Namespace