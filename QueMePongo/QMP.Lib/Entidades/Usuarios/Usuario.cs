using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Core;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Ar.UTN.QMP.Lib.Entidades.Usuarios
{
    [Table("Usuarios")]
    public abstract class Usuario
    {
        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public int MaximoPrendas { get; set; }
        public int Sensibilidad { get; set; }
        public virtual Pedido Pedido { get; set; }
        public ICollection<Regla> Reglas { get; set; }
        public ICollection<Atuendo> AtuendosAceptados { get; set; }
        public ICollection<Guardarropa> Guardarropas { get; set; }

        public Usuario() { }

        protected Usuario(int maximo, string username)
        {
            this.Username = username;
            this.Guardarropas = new List<Guardarropa>();
            this.Reglas = new List<Regla>();
            this.MaximoPrendas = maximo;
        }

        /// <summary>
        /// Devuelve una lista con todas las prendas de todos los guardarropas
        /// </summary>
        /// <returns></returns>
        public List<Prenda> ObtenerPrendas()
        {
            List<Prenda> prendasAux = new List<Prenda>();
            
            foreach (Guardarropa unGuardarropas in Guardarropas)
                foreach (Prenda unaPrenda in unGuardarropas.Prendas)
                    prendasAux.Add(unaPrenda);

            return prendasAux;
        }

        /// <summary>
        /// Permite vincular al usuario un guardarropas
        /// </summary>
        /// <param name="guardarropa"></param>
        public void AgregarGuardarropa(Guardarropa guardarropa)
        {
            if (guardarropa != null)
            {
                if (this.Guardarropas != null)
                {
                    if (!this.Guardarropas.Contains(guardarropa))
                        this.Guardarropas.Add(guardarropa);
                }
                else
                    throw new Exception("Lista de guardarropas del usuario no inicializada.");
            }
            else
                throw new Exception("El guardarropas a vincular no debe ser nulo.");
        }

        /// <summary>
        /// Permite agregar prendas a un guardarropas determinado
        /// </summary>
        /// <param name="idGuardarropa"></param>
        /// <param name="prenda"></param>
        public void AgregarPrenda(int idGuardarropa, Prenda prenda)
        {
            if (idGuardarropa != 0)
                if (prenda != null)
                   this.Guardarropas.ToList().Find(g => g.GuardarropaId == idGuardarropa).AgregarPrenda(prenda);
                else
                    throw new Exception("Prenda requerida.");
            else
                throw new Exception("ID de guardarropa requerido.");
        }

        public bool YaAcepto(int id)
        {
            return this.AtuendosAceptados.Any(a => a.AtuendoId.Equals(id));
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
            switch (sensibilidadClima.ToUpper())
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
