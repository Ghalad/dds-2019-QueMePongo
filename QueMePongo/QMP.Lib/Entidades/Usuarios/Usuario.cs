using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Guardaropa;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Usuarios
{
    public abstract class Usuario
    {
        public List<Guardarropa> Guardarropas { get; set; }
        private int Maximo { get; set; }
        public string Id { get; set; }

        protected Usuario(int maximo)
        {
            this.Guardarropas = new List<Guardarropa>();
            this.Maximo = maximo;
        }

        public void CrearGuardarropa(string id)
        {
            this.Guardarropas.Add(new Guardarropa(id, this.Maximo));
        }
        
        public Atuendo ObtenerAtuendo(string guardarropa)
        {
            return this.Guardarropas.Find(g => g.Id.Equals(guardarropa)).ObtenerAtuendo();
        }

        public List<Atuendo> ObtenerAtuendosEvento(Evento evento)
        {
            return evento.ObtenerAtuendos(this.Guardarropas);
        }

        public void AgregarPrenda(string guardarropa, Prenda prenda)
        {
            this.Guardarropas.Find(g => g.Id.Equals(guardarropa)).AgregarPrenda(prenda);
        }
    }
}
