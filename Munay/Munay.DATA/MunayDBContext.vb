Imports System
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports System.Linq

Public Class MunayDBContext
    Inherits DbContext

    ' El contexto se ha configurado para usar una cadena de conexión 'MunayDBContext' del archivo 
    ' de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
    ' esta cadena de conexión tiene como destino la base de datos 'Munay.DATA.MunayDBContext' de la instancia LocalDb. 
    ' 
    ' Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
    ' modifique la cadena de conexión 'MunayDBContext'  en el archivo de configuración de la aplicación.
    Public Sub New()
        MyBase.New("name=MunayDBContext")
    End Sub

    ' Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
    ' sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.
    ' Public Overridable Property MyEntities() As DbSet(Of MyEntity)
    Public Overridable Property Articulos As DbSet(Of Articulo)
    Public Overridable Property Categorias As DbSet(Of Categoria)
    Public Overridable Property DetallePedidos As DbSet(Of DetallePedido)
    Public Overridable Property Nosotros As DbSet(Of Nosotro)
    Public Overridable Property Notas As DbSet(Of Nota)
    Public Overridable Property Pedidos As DbSet(Of Pedido)
    Public Overridable Property Redsociales As DbSet(Of Redsocial)
    Public Overridable Property Usuarios As DbSet(Of Usuario)
    Public Overridable Property Token As DbSet(Of Token)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
        modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
        modelBuilder.Conventions.Remove(Of OneToManyCascadeDeleteConvention)()
        modelBuilder.Conventions.Remove(Of ManyToManyCascadeDeleteConvention)()
    End Sub
End Class

'Public Class MyEntity
'    Public Property Id() As Int32
'    Public Property Name() As String
'End Class
