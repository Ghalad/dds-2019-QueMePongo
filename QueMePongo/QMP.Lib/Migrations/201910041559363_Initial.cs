namespace Ar.UTN.QMP.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atuendos",
                c => new
                    {
                        AtuendoId = c.Int(nullable: false, identity: true),
                        Aceptado = c.Boolean(),
                        Calificacion_CalificacionId = c.Int(),
                        Usuario_UsuarioId = c.Int(),
                        Pedido_PedidoId = c.Int(),
                    })
                .PrimaryKey(t => t.AtuendoId)
                .ForeignKey("dbo.Calificaciones", t => t.Calificacion_CalificacionId)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UsuarioId)
                .ForeignKey("dbo.Pedidos", t => t.Pedido_PedidoId)
                .Index(t => t.Calificacion_CalificacionId)
                .Index(t => t.Usuario_UsuarioId)
                .Index(t => t.Pedido_PedidoId);
            
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
                        ImagenEnBytes = c.Binary(),
                        fechaDeUso = c.DateTime(nullable: false),
                        Calificacion_CalificacionId = c.Int(),
                    })
                .PrimaryKey(t => t.PrendaId)
                .ForeignKey("dbo.Calificaciones", t => t.Calificacion_CalificacionId)
                .Index(t => t.Calificacion_CalificacionId);
            
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
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Maximo = c.Int(nullable: false),
                        Sensibilidad = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        PedidoId = c.Int(nullable: false),
                        Evento_EventoId = c.Int(),
                    })
                .PrimaryKey(t => t.PedidoId)
                .ForeignKey("dbo.Eventos", t => t.Evento_EventoId)
                .ForeignKey("dbo.Usuarios", t => t.PedidoId)
                .Index(t => t.PedidoId)
                .Index(t => t.Evento_EventoId);
            
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        EventoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        CiudadEvento = c.String(),
                        FechaEvento = c.DateTime(nullable: false),
                        Repeticion = c.String(),
                        TipoEvento_CaracteristicaId = c.Int(),
                    })
                .PrimaryKey(t => t.EventoId)
                .ForeignKey("dbo.Caracteristicas", t => t.TipoEvento_CaracteristicaId)
                .Index(t => t.TipoEvento_CaracteristicaId);
            
            CreateTable(
                "dbo.Condiciones",
                c => new
                    {
                        CondicionId = c.Int(nullable: false, identity: true),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Operador_OperadorId = c.Int(),
                        Regla_ReglaId = c.Int(),
                    })
                .PrimaryKey(t => t.CondicionId)
                .ForeignKey("dbo.Operadores", t => t.Operador_OperadorId)
                .ForeignKey("dbo.Reglas", t => t.Regla_ReglaId)
                .Index(t => t.Operador_OperadorId)
                .Index(t => t.Regla_ReglaId);
            
            CreateTable(
                "dbo.Operadores",
                c => new
                    {
                        OperadorId = c.Int(nullable: false, identity: true),
                        ValorReferencia = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.OperadorId);
            
            CreateTable(
                "dbo.Reglas",
                c => new
                    {
                        ReglaId = c.Int(nullable: false, identity: true),
                        Usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.ReglaId)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UsuarioId)
                .Index(t => t.Usuario_UsuarioId);
            
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
                        Usuario_UsuarioId = c.Int(nullable: false),
                        Guardarropa_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_UsuarioId, t.Guardarropa_Id })
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UsuarioId, cascadeDelete: true)
                .ForeignKey("dbo.Guardarropas", t => t.Guardarropa_Id, cascadeDelete: true)
                .Index(t => t.Usuario_UsuarioId)
                .Index(t => t.Guardarropa_Id);
            
            CreateTable(
                "dbo.PrendasAtuendos",
                c => new
                    {
                        AtuendoId = c.Int(nullable: false),
                        PrendaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AtuendoId, t.PrendaId })
                .ForeignKey("dbo.Atuendos", t => t.AtuendoId, cascadeDelete: true)
                .ForeignKey("dbo.Prendas", t => t.PrendaId, cascadeDelete: true)
                .Index(t => t.AtuendoId)
                .Index(t => t.PrendaId);
            
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
            
            CreateTable(
                "dbo.CaracteristicasCondiciones",
                c => new
                    {
                        CaracteristicaId = c.Int(nullable: false),
                        CondicionAfirmativa_CondicionId = c.Int(),
                        CondicionCantidad_CondicionId = c.Int(),
                        CondicionNegativa_CondicionId = c.Int(),
                        condicion_CondicionId = c.Int(),
                    })
                .PrimaryKey(t => t.CaracteristicaId)
                .ForeignKey("dbo.Caracteristicas", t => t.CaracteristicaId)
                .ForeignKey("dbo.Condiciones", t => t.CondicionAfirmativa_CondicionId)
                .ForeignKey("dbo.Condiciones", t => t.CondicionCantidad_CondicionId)
                .ForeignKey("dbo.Condiciones", t => t.CondicionNegativa_CondicionId)
                .ForeignKey("dbo.Condiciones", t => t.condicion_CondicionId)
                .Index(t => t.CaracteristicaId)
                .Index(t => t.CondicionAfirmativa_CondicionId)
                .Index(t => t.CondicionCantidad_CondicionId)
                .Index(t => t.CondicionNegativa_CondicionId)
                .Index(t => t.condicion_CondicionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CaracteristicasCondiciones", "condicion_CondicionId", "dbo.Condiciones");
            DropForeignKey("dbo.CaracteristicasCondiciones", "CondicionNegativa_CondicionId", "dbo.Condiciones");
            DropForeignKey("dbo.CaracteristicasCondiciones", "CondicionCantidad_CondicionId", "dbo.Condiciones");
            DropForeignKey("dbo.CaracteristicasCondiciones", "CondicionAfirmativa_CondicionId", "dbo.Condiciones");
            DropForeignKey("dbo.CaracteristicasCondiciones", "CaracteristicaId", "dbo.Caracteristicas");
            DropForeignKey("dbo.CaracteristicasPrendas", "prenda_PrendaId", "dbo.Prendas");
            DropForeignKey("dbo.CaracteristicasPrendas", "CaracteristicaId", "dbo.Caracteristicas");
            DropForeignKey("dbo.PrendasAtuendos", "PrendaId", "dbo.Prendas");
            DropForeignKey("dbo.PrendasAtuendos", "AtuendoId", "dbo.Atuendos");
            DropForeignKey("dbo.Reglas", "Usuario_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Condiciones", "Regla_ReglaId", "dbo.Reglas");
            DropForeignKey("dbo.Pedidos", "PedidoId", "dbo.Usuarios");
            DropForeignKey("dbo.Pedidos", "Evento_EventoId", "dbo.Eventos");
            DropForeignKey("dbo.Eventos", "TipoEvento_CaracteristicaId", "dbo.Caracteristicas");
            DropForeignKey("dbo.Condiciones", "Operador_OperadorId", "dbo.Operadores");
            DropForeignKey("dbo.Atuendos", "Pedido_PedidoId", "dbo.Pedidos");
            DropForeignKey("dbo.UsuarioGuardarropas", "Guardarropa_Id", "dbo.Guardarropas");
            DropForeignKey("dbo.UsuarioGuardarropas", "Usuario_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Atuendos", "Usuario_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.GuardarropaPrendas", "Prenda_PrendaId", "dbo.Prendas");
            DropForeignKey("dbo.GuardarropaPrendas", "Guardarropa_Id", "dbo.Guardarropas");
            DropForeignKey("dbo.Prendas", "Calificacion_CalificacionId", "dbo.Calificaciones");
            DropForeignKey("dbo.Atuendos", "Calificacion_CalificacionId", "dbo.Calificaciones");
            DropIndex("dbo.CaracteristicasCondiciones", new[] { "condicion_CondicionId" });
            DropIndex("dbo.CaracteristicasCondiciones", new[] { "CondicionNegativa_CondicionId" });
            DropIndex("dbo.CaracteristicasCondiciones", new[] { "CondicionCantidad_CondicionId" });
            DropIndex("dbo.CaracteristicasCondiciones", new[] { "CondicionAfirmativa_CondicionId" });
            DropIndex("dbo.CaracteristicasCondiciones", new[] { "CaracteristicaId" });
            DropIndex("dbo.CaracteristicasPrendas", new[] { "prenda_PrendaId" });
            DropIndex("dbo.CaracteristicasPrendas", new[] { "CaracteristicaId" });
            DropIndex("dbo.PrendasAtuendos", new[] { "PrendaId" });
            DropIndex("dbo.PrendasAtuendos", new[] { "AtuendoId" });
            DropIndex("dbo.UsuarioGuardarropas", new[] { "Guardarropa_Id" });
            DropIndex("dbo.UsuarioGuardarropas", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.GuardarropaPrendas", new[] { "Prenda_PrendaId" });
            DropIndex("dbo.GuardarropaPrendas", new[] { "Guardarropa_Id" });
            DropIndex("dbo.Reglas", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Condiciones", new[] { "Regla_ReglaId" });
            DropIndex("dbo.Condiciones", new[] { "Operador_OperadorId" });
            DropIndex("dbo.Eventos", new[] { "TipoEvento_CaracteristicaId" });
            DropIndex("dbo.Pedidos", new[] { "Evento_EventoId" });
            DropIndex("dbo.Pedidos", new[] { "PedidoId" });
            DropIndex("dbo.Prendas", new[] { "Calificacion_CalificacionId" });
            DropIndex("dbo.Atuendos", new[] { "Pedido_PedidoId" });
            DropIndex("dbo.Atuendos", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Atuendos", new[] { "Calificacion_CalificacionId" });
            DropTable("dbo.CaracteristicasCondiciones");
            DropTable("dbo.CaracteristicasPrendas");
            DropTable("dbo.PrendasAtuendos");
            DropTable("dbo.UsuarioGuardarropas");
            DropTable("dbo.GuardarropaPrendas");
            DropTable("dbo.Reglas");
            DropTable("dbo.Operadores");
            DropTable("dbo.Condiciones");
            DropTable("dbo.Eventos");
            DropTable("dbo.Pedidos");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Guardarropas");
            DropTable("dbo.Caracteristicas");
            DropTable("dbo.Prendas");
            DropTable("dbo.Calificaciones");
            DropTable("dbo.Atuendos");
        }
    }
}
