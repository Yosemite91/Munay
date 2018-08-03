Imports System.Net
Imports System.Web.Http
Imports Munay.DATA

Namespace Controllers.API
    <RoutePrefix("api/articulos")>
    Public Class ArticulosAPIController
        Inherits ApiController
        <HttpGet>
        <Route("", Name:="GetArticulos")>
        Public Function GetArticulos() As IHttpActionResult
            Dim db As New MunayDBContext
            Try
                Dim listArticulos As List(Of Articulo) = db.Articulos.ToList()
                If listArticulos Is Nothing OrElse listArticulos.Count = 0 Then Return Me.Ok(New List(Of Models.CategoriasDTO))

                Dim listArticuloDto As New List(Of Models.ArticuloDTO)
                For Each arti As Articulo In listArticulos
                    listArticuloDto.Add(New Models.ArticuloDTO With {.ID = arti.ID,
                                                                    .Nombre = arti.Nombre,
                                                                    .Precio = arti.Precio,
                                                                    .Descripcion = arti.Descripcion,
                                                                    .Categoria = arti.Categoria,
                                                                    .FotoStr = Encoding.Default.GetString(arti.Foto)})
                Next
                Return Me.Ok(listArticuloDto)
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, ex.Message)
            Finally
                db.Dispose()
            End Try
        End Function

        <HttpGet>
        <Route("articulos-por-categoria/{id}", Name:="GetArticulosPorCategoria")>
        Public Function GetArticulosPorCategoria(id As Integer) As IHttpActionResult
            Dim db As New MunayDBContext
            Try
                Dim listArticulos As List(Of Articulo) = db.Articulos.Where(Function(a) a.Categoria.ID = id).ToList()
                If listArticulos Is Nothing OrElse listArticulos.Count = 0 Then Return Me.Ok(New List(Of Models.CategoriasDTO))

                Dim listArticuloDto As New List(Of Models.ArticuloDTO)
                For Each arti As Articulo In listArticulos
                    listArticuloDto.Add(New Models.ArticuloDTO With {.ID = arti.ID,
                                                                    .Nombre = arti.Nombre,
                                                                    .Precio = arti.Precio,
                                                                    .Descripcion = arti.Descripcion,
                                                                    .Categoria = arti.Categoria,
                                                                    .FotoStr = Encoding.Default.GetString(arti.Foto)})
                Next
                Return Me.Ok(listArticuloDto)
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, ex.Message)
            Finally
                db.Dispose()
            End Try
        End Function

        <HttpPost>
        <Route("", Name:="PostArticulo")>
        Public Function PostArticulo(<FromBody> model As Models.ArticuloDTO) As IHttpActionResult

            If model Is Nothing Then Return Me.Content(HttpStatusCode.BadRequest, "Error obtener informacion")

            Dim db As New MunayDBContext
            Try

                If model.ID <> 0 Then
                    Dim produExist As Articulo = db.Articulos.Where(Function(t) t.ID = model.ID).SingleOrDefault()

                    With produExist
                        .Nombre = model.Nombre
                        .Precio = model.Precio
                        .Descripcion = model.Descripcion
                        .Categoria = db.Categorias.Where(Function(c) c.ID = model.Categoria.ID).SingleOrDefault()
                    End With
                    db.SaveChanges()
                    Return Me.Ok(model)

                End If

                Dim articulo As New Articulo With {.Nombre = model.Nombre,
                                                    .Precio = model.Precio,
                                                    .Descripcion = model.Descripcion,
                                                    .Foto = Encoding.ASCII.GetBytes(model.FotoStr),
                                                    .Categoria = db.Categorias.Where(Function(c) c.ID = model.Categoria.ID).SingleOrDefault()
                }
                db.Articulos.Add(articulo)
                model.ID = articulo.ID
                db.SaveChanges()
                Return Me.Ok(model)
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, ex.Message)
            Finally
                db.Dispose()
            End Try
        End Function

        <HttpDelete>
        <Route("{id}", Name:="DeleteArticulo")>
        Public Function DeleteArticulo(id As Integer) As IHttpActionResult
            If id = 0 Then
                Return Me.Content(HttpStatusCode.NotFound, "No se puede eliminar Torta")
            End If

            Dim db As New MunayDBContext
            Try
                Dim articulo As Articulo = db.Articulos.Where(Function(u) u.ID = id).SingleOrDefault()
                db.Articulos.Remove(articulo)
                db.SaveChanges()
                Return Me.Content(HttpStatusCode.OK, String.Format("Torta {0} Eliminada", articulo.Nombre))
            Catch ex As Exception
                Return Me.Content(HttpStatusCode.BadRequest, ex.Message)
            Finally
                db.Dispose()
            End Try
        End Function
    End Class
End Namespace