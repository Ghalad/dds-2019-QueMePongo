namespace Ar.UTN.QMP.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
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
                        Calificacion_CalificacionId = c.Int(),
                    })
                .PrimaryKey(t => t.PrendaId)
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
            DropForeignKey("dbo.Prendas", "Calificacion_CalificacionId", "dbo.Calificaciones");
            DropIndex("dbo.CaracteristicasPrendas", new[] { "prenda_PrendaId" });
            DropIndex("dbo.CaracteristicasPrendas", new[] { "CaracteristicaId" });
            DropIndex("dbo.Prendas", new[] { "Calificacion_CalificacionId" });
            DropTable("dbo.CaracteristicasPrendas");
            DropTable("dbo.Calificaciones");
            DropTable("dbo.Prendas");
            DropTable("dbo.Caracteristicas");
        }
    }
}
