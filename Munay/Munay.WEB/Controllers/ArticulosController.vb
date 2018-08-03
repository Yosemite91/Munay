Imports System.Web.Mvc

Namespace Controllers
    Public Class ArticulosController
        Inherits Controller

        ' GET: Articulos
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace