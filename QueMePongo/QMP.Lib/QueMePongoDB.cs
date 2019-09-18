namespace Ar.UTN.QMP.Lib
{
    using Ar.UTN.QMP.Lib.Entidades.Atuendos;
    using Ar.UTN.QMP.Lib.Entidades.Calificaciones;
    using Ar.UTN.QMP.Lib.Entidades.Core;
    using Ar.UTN.QMP.Lib.Entidades.DBTables;
    using Ar.UTN.QMP.Lib.Entidades.Eventos;
    using Ar.UTN.QMP.Lib.Entidades.Reglas;
    using Ar.UTN.QMP.Lib.Entidades.Usuarios;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class QueMePongoDB : DbContext
    {
        DbSet<PrendaAtuendo> PrendasAtuendos { get; set; }
        DbSet<PrendaGuardarropa> PrendasGuardarropas { get; set; }
        DbSet<PrendaPedido> PrendasPedidos { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Guardarropa> Guardarropas { get; set; }
        DbSet<Prenda> Prendas { get; set; }
        DbSet<Calificacion> Calificaciones { get; set; }
        DbSet<Caracteristica> Caracteristicas { get; set; }
        DbSet<Regla> Reglas { get; set; }
        DbSet<Pedido> Pedidos { get; set; }
        DbSet<Atuendo> Atuendos { get; set; }
        DbSet<Evento> Eventos { get; set; }


        // Your context has been configured to use a 'QueMePongoDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Ar.UTN.QMP.Lib.QueMePongoDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QueMePongoDB' 
        // connection string in the application configuration file.
        public QueMePongoDB()
            : base("name=QueMePongoDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}