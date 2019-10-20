using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Calificaciones;
using Ar.UTN.QMP.Lib.Entidades.Core;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
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


        public QueMePongoDB(): base("name=QueMePongoDB")
        {
            Database.SetInitializer(new QueMePongoDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Atuendo>()
                        .HasMany(p => p.Prendas);

            modelBuilder.Entity<Usuario>()
                        .HasOptional(s => s.Pedido)
                        .WithRequired(ad => ad.Usuario);

            modelBuilder.Entity<Caracteristica>()
                        .HasIndex(c => new { c.Nombre, c.Clave, c.Valor })
                        .IsUnique();*/
        }
    }
}