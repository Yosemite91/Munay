Public Class Articulo
    Public Property ID As String
    Public Property Nombre As String
    Public Property Foto As Byte()
    Public Property Precio As Integer
    Public Property Descripcion As String
    Public Overridable Property Categoria As Categoria
End Class
