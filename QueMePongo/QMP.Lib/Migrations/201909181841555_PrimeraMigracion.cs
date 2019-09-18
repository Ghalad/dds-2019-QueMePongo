namespace Ar.UTN.QMP.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeraMigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atuendos",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Calificacion_CalificacionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Calificaciones", t => t.Calificacion_CalificacionId)
                .Index(t => t.Calificacion_CalificacionId);
            
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
                "dbo.Prendas",
                c => new
                    {
                        PrendaId = c.Int(nullable: false, identity: true),
                        Calificacion_CalificacionId = c.Int(),
                        Atuendo_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PrendaId)
                .ForeignKey("dbo.Calificaciones", t => t.Calificacion_CalificacionId)
                .ForeignKey("dbo.Atuendos", t => t.Atuendo_Id)
                .Index(t => t.Calificacion_CalificacionId)
                .Index(t => t.Atuendo_Id);
            
            CreateTable(
                "dbo.Caracteristicas",
                c => new
                    {
                        CaracteristicaId = c.String(nullable: false, maxLength: 128),
                        Clave = c.String(),
                        Valor = c.String(),
                    })
                .PrimaryKey(t => t.CaracteristicaId);
            
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        EventoID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        CiudadEvento = c.String(),
                        FechaEvento = c.DateTime(nullable: false),
                        Repeticion = c.String(),
                        TipoEvento_CaracteristicaId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EventoID)
                .ForeignKey("dbo.Caracteristicas", t => t.TipoEvento_CaracteristicaId)
                .Index(t => t.TipoEvento_CaracteristicaId);
            
            CreateTable(
                "dbo.Guardarropas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Evento_EventoID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Eventos", t => t.Evento_EventoID)
                .ForeignKey("dbo.Usuarios", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Evento_EventoID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Sensibilidad = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reglas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidos", "Id", "dbo.Usuarios");
            DropForeignKey("dbo.Reglas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Guardarropas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Pedidos", "Evento_EventoID", "dbo.Eventos");
            DropForeignKey("dbo.Eventos", "TipoEvento_CaracteristicaId", "dbo.Caracteristicas");
            DropForeignKey("dbo.Prendas", "Atuendo_Id", "dbo.Atuendos");
            DropForeignKey("dbo.Prendas", "Calificacion_CalificacionId", "dbo.Calificaciones");
            DropForeignKey("dbo.Atuendos", "Calificacion_CalificacionId", "dbo.Calificaciones");
            DropIndex("dbo.Reglas", new[] { "Usuario_Id" });
            DropIndex("dbo.Pedidos", new[] { "Evento_EventoID" });
            DropIndex("dbo.Pedidos", new[] { "Id" });
            DropIndex("dbo.Guardarropas", new[] { "Usuario_Id" });
            DropIndex("dbo.Eventos", new[] { "TipoEvento_CaracteristicaId" });
            DropIndex("dbo.Prendas", new[] { "Atuendo_Id" });
            DropIndex("dbo.Prendas", new[] { "Calificacion_CalificacionId" });
            DropIndex("dbo.Atuendos", new[] { "Calificacion_CalificacionId" });
            DropTable("dbo.Reglas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Pedidos");
            DropTable("dbo.Guardarropas");
            DropTable("dbo.Eventos");
            DropTable("dbo.Caracteristicas");
            DropTable("dbo.Prendas");
            DropTable("dbo.Calificaciones");
            DropTable("dbo.Atuendos");
        }
    }
}
