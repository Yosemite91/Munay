Imports System.Web.Mvc

Namespace Controllers
    Public Class ArticuloController
        Inherits Controller

        ' GET: Articulo
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace