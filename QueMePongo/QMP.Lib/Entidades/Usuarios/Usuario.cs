using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Core;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.UTN.QMP.Lib.Entidades.Usuarios
{
    [Table("Usuarios")]
    public abstract class Usuario
    {
        public List<Guardarropa> Guardarropas { get; set; }
        public List<Regla> Reglas { get; set; }
        private int Maximo { get; set; }
        [Key]
        public int Id { get; set; }
        public Pedido Pedido { get; set; }
        public int Sensibilidad { get; set; }

        protected Usuario(int maximo)
        {
            this.Guardarropas = new List<Guardarropa>();
            this.Reglas = new List<Regla>();
            this.Maximo = maximo;
        }

        /// <summary>
        /// Permite crear nuevos Guardarropas
        /// </summary>
        /// <param name="idGuardarropa"></param>
        [Obsolete] // No tiene que depender del usuario la creacion de guardarropas ya que pueden ser compartidos
        public void CrearGuardarropa(int idGuardarropa)
        {
            if (idGuardarropa != null)
                this.Guardarropas.Add(new Guardarropa(idGuardarropa, this.Maximo));
            else
                throw new Exception("ID de guardarropa requerido.");
        }

        public void AgregarGuardarropa(Guardarropa guardarropa)
        {
            if (guardarropa != null)
                this.Guardarropas.Add(guardarropa);
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
                    this.Guardarropas.Find(g => g.Id.Equals(idGuardarropa)).AgregarPrenda(prenda);
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

        public void NotificarPedidoResuelto(Pedido pedido)
        {
            this.Pedido = pedido;
            //TODO notificar al usuario que el pedido ya esta resuelto
        }
    }
}
