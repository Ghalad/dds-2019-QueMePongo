namespace Ar.UTN.QMP.Lib
{
    using Ar.UTN.QMP.Lib.Entidades.Atuendos;
    using Ar.UTN.QMP.Lib.Entidades.Calificaciones;
    using Ar.UTN.QMP.Lib.Entidades.Core;
    using Ar.UTN.QMP.Lib.Entidades.Eventos;
    using Ar.UTN.QMP.Lib.Entidades.Reglas;
    using Ar.UTN.QMP.Lib.Entidades.Usuarios;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class QueMePongoDB : DbContext
    {
        //public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Guardarropa> Guardarropas { get; set; }
        public DbSet<Prenda> Prendas { get; set; }
        //public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }
        //public DbSet<Regla> Reglas { get; set; }
        //public DbSet<Pedido> Pedidos { get; set; }
        //public DbSet<Atuendo> Atuendos { get; set; }
        //public DbSet<Evento> Eventos { get; set; }


        // Your context has been configured to use a 'QueMePongoDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Ar.UTN.QMP.Lib.QueMePongoDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QueMePongoDB' 
        // connection string in the application configuration file.
        public QueMePongoDB()
            : base("name=QueMePongoDB")
        {
            Database.SetInitializer<QueMePongoDB>(new CreateDatabaseIfNotExists<QueMePongoDB>());
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