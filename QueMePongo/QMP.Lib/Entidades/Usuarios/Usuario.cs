using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Calificaciones;
using Ar.UTN.QMP.Lib.Entidades.Comunicacion;
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
        public string Password { get; set; }
        public int MaximoPrendas { get; set; }
        public int Sensibilidad { get; set; }
        public virtual Pedido Pedido { get; set; }
        public ComunicacionAdapter MedioComunicacion { get; set; }
        public ICollection<Regla> Reglas { get; set; }
        public ICollection<Atuendo> AtuendosAceptados { get; set; }
        public ICollection<Guardarropa> Guardarropas { get; set; }
        public ICollection<Calificacion> Calificaciones { get; set; }

        public Usuario() { }

        protected Usuario(int maximo, string username)
        {
            this.Username = username;
            this.Guardarropas = new List<Guardarropa>();
            this.Calificaciones = new List<Calificacion>();
            this.Reglas = new List<Regla>();
            this.MaximoPrendas = maximo;
            this.Sensibilidad = (GestorCaracteristicas.GetInstance()).ObtenerIndiceSensibilidad("NORMAL");
        }

        public void SetMetodoComunicacion(ComunicacionAdapter com)
        {
            this.MedioComunicacion = com;
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

        public void AgregarAtuendoAceptado(Atuendo atuendo)
        {
            if (this.AtuendosAceptados == null)
                this.AtuendosAceptados = new List<Atuendo>();
            
            this.AtuendosAceptados.Add(atuendo);
        }

        public void NotificarPedidoResuelto(Pedido pedido)
        {
            this.Pedido = pedido;
            if (this.MedioComunicacion != null)
                this.Notificar("Pedido Resuelto");
        }

        public void Notificar(string mensaje)
        {
            this.MedioComunicacion.Notificar(mensaje);
        }
    }
}
