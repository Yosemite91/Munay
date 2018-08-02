Public Class Pedido
    Public Property ID As Integer
    Public Property Total As Integer
    Public Property Cliente As String
    Public Property Email As String
    Public Property Mensaje As String
    Public Property Detalle As IList(Of DetallePedido)
End Class