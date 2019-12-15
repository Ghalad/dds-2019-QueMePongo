using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Calificaciones;
using Ar.UTN.QMP.Lib.Entidades.Core;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Logs;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using System.Data.Entity;

namespace Ar.UTN.QMP.Lib.Entidades.Contexto
{
    public class QueMePongoDB : DbContext
    {
        public DbSet<Caracteristica> Caracteristicas { get; set; }
        public DbSet<Prenda> Prendas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Guardarropa> Guardarropas { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Regla> Reglas { get; set; }
        public DbSet<Condicion> Condiciones { get; set; }
        public DbSet<Operador> Operadores { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Atuendo> Atuendos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Log> Logs { get; set; }


        public QueMePongoDB(): base("name=QueMePongoDB")
        {
            Database.SetInitializer(new QueMePongoDBInitializer());
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    }
}