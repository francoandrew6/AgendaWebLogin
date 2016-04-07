namespace AgendaWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB_AgendaWeb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contactoes",
                c => new
                    {
                        idContacto = c.Int(nullable: false, identity: true),
                        nombreContacto = c.String(nullable: false),
                        telefonoCasa = c.Int(nullable: false),
                        telefonoMovil = c.Int(nullable: false),
                        correoContacto = c.String(nullable: false),
                        direccion = c.String(nullable: false),
                        usuario_idUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.idContacto)
                .ForeignKey("dbo.Usuarios", t => t.usuario_idUsuario)
                .Index(t => t.usuario_idUsuario);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        correo = c.String(nullable: false),
                        contraseña = c.String(nullable: false, maxLength: 10),
                        compararContraseña = c.String(nullable: false),
                        rol_idRol = c.Int(),
                    })
                .PrimaryKey(t => t.idUsuario)
                .ForeignKey("dbo.Rols", t => t.rol_idRol)
                .Index(t => t.rol_idRol);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        idRol = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idRol);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "rol_idRol", "dbo.Rols");
            DropForeignKey("dbo.Contactoes", "usuario_idUsuario", "dbo.Usuarios");
            DropIndex("dbo.Usuarios", new[] { "rol_idRol" });
            DropIndex("dbo.Contactoes", new[] { "usuario_idUsuario" });
            DropTable("dbo.Rols");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Contactoes");
        }
    }
}
