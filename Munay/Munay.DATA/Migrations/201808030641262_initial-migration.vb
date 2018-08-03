Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class initialmigration
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Articulo",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Nombre = c.String(),
                        .Foto = c.Binary(),
                        .Precio = c.Int(nullable := False),
                        .Descripcion = c.String(),
                        .Categoria_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Categoria", Function(t) t.Categoria_ID) _
                .Index(Function(t) t.Categoria_ID)
            
            CreateTable(
                "dbo.Categoria",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Nombre = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.DetallePedido",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .FechaRegistro = c.DateTime(nullable := False),
                        .Cantidad = c.Int(nullable := False),
                        .Subtotal = c.Int(nullable := False),
                        .Articulo_ID = c.Int(),
                        .Pedido_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Articulo", Function(t) t.Articulo_ID) _
                .ForeignKey("dbo.Pedido", Function(t) t.Pedido_ID) _
                .Index(Function(t) t.Articulo_ID) _
                .Index(Function(t) t.Pedido_ID)
            
            CreateTable(
                "dbo.Pedido",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Total = c.Int(nullable := False),
                        .Cliente = c.String(),
                        .Email = c.String(),
                        .Mensaje = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Nosotro",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Foto = c.Binary(),
                        .Mision = c.String(),
                        .Vision = c.String(),
                        .Descripcion = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Nota",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Titulo = c.String(),
                        .Descripcion = c.String(),
                        .Foto = c.Binary(),
                        .Enlace = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Redsocial",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Foto = c.Binary(),
                        .Fecha = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Token",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Run = c.String(),
                        .TokenActual = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Usuario",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Nombre = c.String(),
                        .Apellido = c.String(),
                        .Email = c.String(),
                        .Run = c.String(),
                        .Password = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.DetallePedido", "Pedido_ID", "dbo.Pedido")
            DropForeignKey("dbo.DetallePedido", "Articulo_ID", "dbo.Articulo")
            DropForeignKey("dbo.Articulo", "Categoria_ID", "dbo.Categoria")
            DropIndex("dbo.DetallePedido", New String() { "Pedido_ID" })
            DropIndex("dbo.DetallePedido", New String() { "Articulo_ID" })
            DropIndex("dbo.Articulo", New String() { "Categoria_ID" })
            DropTable("dbo.Usuario")
            DropTable("dbo.Token")
            DropTable("dbo.Redsocial")
            DropTable("dbo.Nota")
            DropTable("dbo.Nosotro")
            DropTable("dbo.Pedido")
            DropTable("dbo.DetallePedido")
            DropTable("dbo.Categoria")
            DropTable("dbo.Articulo")
        End Sub
    End Class
End Namespace
