namespace Ar.UTN.QMP.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calificaciones",
                c => new
                    {
                        CalificacionId = c.Int(nullable: false, identity: true),
                        puntajeHistorico = c.Int(nullable: false),
                        tiempoCalificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CalificacionId);
            
            CreateTable(
                "dbo.Caracteristicas",
                c => new
                    {
                        CaracteristicaId = c.Int(nullable: false, identity: true),
                        Clave = c.String(),
                        Valor = c.String(),
                    })
                .PrimaryKey(t => t.CaracteristicaId);
            
            CreateTable(
                "dbo.Prendas",
                c => new
                    {
                        PrendaId = c.Int(nullable: false, identity: true),
                        ImagenEnBytes = c.Binary(),
                        fechaDeUso = c.DateTime(nullable: false),
                        Calificacion_CalificacionId = c.Int(),
                    })
                .PrimaryKey(t => t.PrendaId)
                .ForeignKey("dbo.Calificaciones", t => t.Calificacion_CalificacionId)
                .Index(t => t.Calificacion_CalificacionId);
            
            CreateTable(
                "dbo.Guardarropas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaximoPrendas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Maximo = c.Int(nullable: false),
                        Sensibilidad = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GuardarropaPrendas",
                c => new
                    {
                        Guardarropa_Id = c.Int(nullable: false),
                        Prenda_PrendaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guardarropa_Id, t.Prenda_PrendaId })
                .ForeignKey("dbo.Guardarropas", t => t.Guardarropa_Id, cascadeDelete: true)
                .ForeignKey("dbo.Prendas", t => t.Prenda_PrendaId, cascadeDelete: true)
                .Index(t => t.Guardarropa_Id)
                .Index(t => t.Prenda_PrendaId);
            
            CreateTable(
                "dbo.UsuarioGuardarropas",
                c => new
                    {
                        Usuario_Id = c.Int(nullable: false),
                        Guardarropa_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_Id, t.Guardarropa_Id })
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id, cascadeDelete: true)
                .ForeignKey("dbo.Guardarropas", t => t.Guardarropa_Id, cascadeDelete: true)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Guardarropa_Id);
            
            CreateTable(
                "dbo.CaracteristicasPrendas",
                c => new
                    {
                        CaracteristicaId = c.Int(nullable: false),
                        prenda_PrendaId = c.Int(),
                    })
                .PrimaryKey(t => t.CaracteristicaId)
                .ForeignKey("dbo.Caracteristicas", t => t.CaracteristicaId)
                .ForeignKey("dbo.Prendas", t => t.prenda_PrendaId)
                .Index(t => t.CaracteristicaId)
                .Index(t => t.prenda_PrendaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CaracteristicasPrendas", "prenda_PrendaId", "dbo.Prendas");
            DropForeignKey("dbo.CaracteristicasPrendas", "CaracteristicaId", "dbo.Caracteristicas");
            DropForeignKey("dbo.UsuarioGuardarropas", "Guardarropa_Id", "dbo.Guardarropas");
            DropForeignKey("dbo.UsuarioGuardarropas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.GuardarropaPrendas", "Prenda_PrendaId", "dbo.Prendas");
            DropForeignKey("dbo.GuardarropaPrendas", "Guardarropa_Id", "dbo.Guardarropas");
            DropForeignKey("dbo.Prendas", "Calificacion_CalificacionId", "dbo.Calificaciones");
            DropIndex("dbo.CaracteristicasPrendas", new[] { "prenda_PrendaId" });
            DropIndex("dbo.CaracteristicasPrendas", new[] { "CaracteristicaId" });
            DropIndex("dbo.UsuarioGuardarropas", new[] { "Guardarropa_Id" });
            DropIndex("dbo.UsuarioGuardarropas", new[] { "Usuario_Id" });
            DropIndex("dbo.GuardarropaPrendas", new[] { "Prenda_PrendaId" });
            DropIndex("dbo.GuardarropaPrendas", new[] { "Guardarropa_Id" });
            DropIndex("dbo.Prendas", new[] { "Calificacion_CalificacionId" });
            DropTable("dbo.CaracteristicasPrendas");
            DropTable("dbo.UsuarioGuardarropas");
            DropTable("dbo.GuardarropaPrendas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Guardarropas");
            DropTable("dbo.Prendas");
            DropTable("dbo.Caracteristicas");
            DropTable("dbo.Calificaciones");
        }
    }
}
