using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Core;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Ar.UTN.QMP.Lib.Entidades.Usuarios
{
    [Table("Usuarios")]
    public abstract class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public int Maximo { get; set; }
        public int Sensibilidad { get; set; }
        public Pedido Pedido { get; set; }
        public ICollection<Atuendo> AtuendosAceptados { get; set; }
        public ICollection<Guardarropa> Guardarropas { get; set; }
        public ICollection<Regla> Reglas { get; set; }

        protected Usuario(int maximo, string username)
        {
            this.Username = username;
            this.Guardarropas = new HashSet<Guardarropa>();
            this.Reglas = new List<Regla>();
            this.Maximo = maximo;
        }

        public Usuario() { }

        public List<Prenda> ObtenerPrendas()
        {
            List<Prenda> PrendasAux = new List<Prenda>();

            foreach (Guardarropa g in Guardarropas)
            {
                foreach (Prenda p in g.Prendas)
                {
                    PrendasAux.Add(p);
                }
            }

            return PrendasAux;
        }

        public void AgregarGuardarropa(Guardarropa guardarropa)
        {
            if (guardarropa != null)
            {
                guardarropa.AgregarUsuario(this);
                this.Guardarropas.Add(guardarropa);
            }
            else
                throw new Exception("El guardarropas no debe ser nulo.");
        }

        /// <summary>
        /// Permite agregar prendas a un guardarropas determinado
        /// </summary>
        /// <param name="idGuardarropa"></param>
        /// <param name="prenda"></param>
        public void AgregarPrenda(string idGuardarropa, Prenda prenda)
        {
            if (idGuardarropa != null)
                if (prenda != null)
                {
                    //Esto probablemente no sirva porque "perdemos" la instancia de esta prenda dentro de este método.
                    //Tiene que cambiarse y pasarse por parámetro, la prenda
                   this.Guardarropas.ToList().Find(g => g.Id.Equals(idGuardarropa)).AgregarPrenda(prenda);
                }
                else
                    throw new Exception("Prenda requerida.");
            else
                throw new Exception("ID de guardarropa requerido.");
        }

        /// <summary>
        /// Permite agregar reglas
        /// </summary>
        /// <param name="regla"></param>
        public void AgregarRegla(Regla regla)
        {
            if (regla != null)
                this.Reglas.Add(regla);
            else
                throw new Exception("Regla requerida.");
        }

        public void SetSensibilidad(string sensibilidadClima)
        {
            switch (sensibilidadClima)
            {
                case "MUY FRIOLENTO":
                    Sensibilidad = -2;
                    break;
                case "FRIOLENTO":
                    Sensibilidad = -1;
                    break;
                case "NORMAL":
                    Sensibilidad = 0;
                    break;
                case "CALUROSO":
                    Sensibilidad = 1;
                    break;
                case "MUY CALUROSO":
                    Sensibilidad = 2;
                    break;
                default:
                    throw new Exception("Sensibilidad al clima no válida.");
            }
        }

        public void AgregarAtuendoAceptado(Atuendo atuendo)
        {
            if (AtuendosAceptados == null)
                AtuendosAceptados = new List<Atuendo>();
            AtuendosAceptados.Add(atuendo);
        }

        public void NotificarPedidoResuelto(Pedido pedido)
        {
            this.Pedido = pedido;
            //TODO notificar al usuario que el pedido ya esta resuelto
        }
    }
}
