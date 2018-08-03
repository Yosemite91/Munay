Imports Munay.DATA
Namespace Models
    Public Class ArticuloDTO
        Public Property ID As Integer
        Public Property Nombre As String
        Public Property FotoByte As Byte()
        Public Property FotoStr As String
        Public Property Precio As Integer
        Public Property Descripcion As String
        Public Overridable Property Categoria As Categoria
    End Class
End Namespace
