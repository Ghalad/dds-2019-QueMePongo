namespace Ar.UTN.QMP.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegundaMigracion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prendas", "Atuendo_Id", "dbo.Atuendos");
            DropForeignKey("dbo.Guardarropas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Reglas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Pedidos", "Id", "dbo.Usuarios");
            DropIndex("dbo.Prendas", new[] { "Atuendo_Id" });
            DropIndex("dbo.Guardarropas", new[] { "Usuario_Id" });
            DropIndex("dbo.Pedidos", new[] { "Id" });
            DropIndex("dbo.Reglas", new[] { "Usuario_Id" });
            DropPrimaryKey("dbo.Atuendos");
            DropPrimaryKey("dbo.Guardarropas");
            DropPrimaryKey("dbo.Pedidos");
            DropPrimaryKey("dbo.Usuarios");
            CreateTable(
                "dbo.PrendasAtuendos",
                c => new
                    {
                        PrendaId = c.Int(nullable: false),
                        AtuendoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PrendaId, t.AtuendoId })
                .ForeignKey("dbo.Atuendos", t => t.AtuendoId, cascadeDelete: true)
                .ForeignKey("dbo.Prendas", t => t.PrendaId, cascadeDelete: true)
                .Index(t => t.PrendaId)
                .Index(t => t.AtuendoId);
            
            CreateTable(
                "dbo.PrendasGuardarropas",
                c => new
                    {
                        PrendaId = c.Int(nullable: false),
                        GuardarropaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PrendaId, t.GuardarropaId })
                .ForeignKey("dbo.Guardarropas", t => t.GuardarropaId, cascadeDelete: true)
                .ForeignKey("dbo.Prendas", t => t.PrendaId, cascadeDelete: true)
                .Index(t => t.PrendaId)
                .Index(t => t.GuardarropaId);
            
            CreateTable(
                "dbo.PrendasPedidos",
                c => new
                    {
                        PrendaId = c.Int(nullable: false),
                        PedidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PrendaId, t.PedidoId })
                .ForeignKey("dbo.Pedidos", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Prendas", t => t.PrendaId, cascadeDelete: true)
                .Index(t => t.PrendaId)
                .Index(t => t.PedidoId);
            
            AlterColumn("dbo.Atuendos", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Prendas", "Atuendo_Id", c => c.Int());
            AlterColumn("dbo.Guardarropas", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Guardarropas", "Usuario_Id", c => c.Int());
            AlterColumn("dbo.Pedidos", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuarios", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Reglas", "Usuario_Id", c => c.Int());
            AddPrimaryKey("dbo.Atuendos", "Id");
            AddPrimaryKey("dbo.Guardarropas", "Id");
            AddPrimaryKey("dbo.Pedidos", "Id");
            AddPrimaryKey("dbo.Usuarios", "Id");
            CreateIndex("dbo.Prendas", "Atuendo_Id");
            CreateIndex("dbo.Guardarropas", "Usuario_Id");
            CreateIndex("dbo.Pedidos", "Id");
            CreateIndex("dbo.Reglas", "Usuario_Id");
            AddForeignKey("dbo.Prendas", "Atuendo_Id", "dbo.Atuendos", "Id");
            AddForeignKey("dbo.Guardarropas", "Usuario_Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.Reglas", "Usuario_Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.Pedidos", "Id", "dbo.Usuarios", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidos", "Id", "dbo.Usuarios");
            DropForeignKey("dbo.Reglas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Guardarropas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Prendas", "Atuendo_Id", "dbo.Atuendos");
            DropForeignKey("dbo.PrendasPedidos", "PrendaId", "dbo.Prendas");
            DropForeignKey("dbo.PrendasPedidos", "PedidoId", "dbo.Pedidos");
            DropForeignKey("dbo.PrendasGuardarropas", "PrendaId", "dbo.Prendas");
            DropForeignKey("dbo.PrendasGuardarropas", "GuardarropaId", "dbo.Guardarropas");
            DropForeignKey("dbo.PrendasAtuendos", "PrendaId", "dbo.Prendas");
            DropForeignKey("dbo.PrendasAtuendos", "AtuendoId", "dbo.Atuendos");
            DropIndex("dbo.PrendasPedidos", new[] { "PedidoId" });
            DropIndex("dbo.PrendasPedidos", new[] { "PrendaId" });
            DropIndex("dbo.PrendasGuardarropas", new[] { "GuardarropaId" });
            DropIndex("dbo.PrendasGuardarropas", new[] { "PrendaId" });
            DropIndex("dbo.PrendasAtuendos", new[] { "AtuendoId" });
            DropIndex("dbo.PrendasAtuendos", new[] { "PrendaId" });
            DropIndex("dbo.Reglas", new[] { "Usuario_Id" });
            DropIndex("dbo.Pedidos", new[] { "Id" });
            DropIndex("dbo.Guardarropas", new[] { "Usuario_Id" });
            DropIndex("dbo.Prendas", new[] { "Atuendo_Id" });
            DropPrimaryKey("dbo.Usuarios");
            DropPrimaryKey("dbo.Pedidos");
            DropPrimaryKey("dbo.Guardarropas");
            DropPrimaryKey("dbo.Atuendos");
            AlterColumn("dbo.Reglas", "Usuario_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Usuarios", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Pedidos", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Guardarropas", "Usuario_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Guardarropas", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Prendas", "Atuendo_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Atuendos", "Id", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.PrendasPedidos");
            DropTable("dbo.PrendasGuardarropas");
            DropTable("dbo.PrendasAtuendos");
            AddPrimaryKey("dbo.Usuarios", "Id");
            AddPrimaryKey("dbo.Pedidos", "Id");
            AddPrimaryKey("dbo.Guardarropas", "Id");
            AddPrimaryKey("dbo.Atuendos", "Id");
            CreateIndex("dbo.Reglas", "Usuario_Id");
            CreateIndex("dbo.Pedidos", "Id");
            CreateIndex("dbo.Guardarropas", "Usuario_Id");
            CreateIndex("dbo.Prendas", "Atuendo_Id");
            AddForeignKey("dbo.Pedidos", "Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.Reglas", "Usuario_Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.Guardarropas", "Usuario_Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.Prendas", "Atuendo_Id", "dbo.Atuendos", "Id");
        }
    }
}
