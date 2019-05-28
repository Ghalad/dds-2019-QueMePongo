using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Guardaropa;
using System;
using System.Collections.Generic;
using static Ar.UTN.QMP.Lib.Entidades.Atuendos.Tipos;

namespace Ar.UTN.QMP.Lib.Entidades.Usuarios
{
    public class Usuario
    {
        public List<Guardarropa> Guardarropas { get; set; }

        public Usuario()
        {
            this.Guardarropas = new List<Guardarropa>();
        }

        public void CrearGuardarropa(string id)
        {
            this.Guardarropas.Add(new Guardarropa(id));
        }


        /// <summary>
        /// Solicita un <see cref="Atuendo"/> a un <see cref="Guardarropa"/> determinado
        /// </summary>
        /// <param name="guardarropa"></param>
        /// <returns></returns>
        public Atuendo ObtenerAtuendo(string guardarropa)
        {
            return this.Guardarropas.Find(g => g.Id.Equals(guardarropa)).ObtenerAtuendo();
        }


        private void AgregarPrenda(string guardarropa, Prenda prenda)
        {
            this.Guardarropas.Find(g => g.Id.Equals(guardarropa)).AgregarPrenda(prenda);
        }

        /// <summary>
        /// Crea una <see cref="Prenda"/> y la asigna a un <see cref="Guardarropa"/> determinado
        /// </summary>
        /// <param name="prenda"></param>
        /// <param name="guardarropa"></param>
        public void CrearPrenda(string guardarropa, TCategoria categoria, TTipoAccesorio tipo, TMateriales material, TColores color)
        {
            PrendaBuilder p = new PrendaBuilder();

            Prenda prenda = p.CrerPrenda()
                             .DeCategoria(categoria)
                             .DeTipo(tipo)
                             .DeMaterial(material)
                             .DeColorPrimario(color)
                             .ObtenerPrenda();

            this.AgregarPrenda(guardarropa, prenda);
        }
        public void CrearPrenda(string guardarropa, TCategoria categoria, TTipoSuperior tipo, TMateriales material, TColores color)
        {
            PrendaBuilder p = new PrendaBuilder();

            Prenda prenda = p.CrerPrenda()
                             .DeCategoria(categoria)
                             .DeTipo(tipo)
                             .DeMaterial(material)
                             .DeColorPrimario(color)
                             .ObtenerPrenda();

            this.AgregarPrenda(guardarropa, prenda);
        }
        public void CrearPrenda(string guardarropa, TCategoria categoria, TTipoInferior tipo, TMateriales material, TColores color)
        {
            PrendaBuilder p = new PrendaBuilder();

            Prenda prenda = p.CrerPrenda()
                             .DeCategoria(categoria)
                             .DeTipo(tipo)
                             .DeMaterial(material)
                             .DeColorPrimario(color)
                             .ObtenerPrenda();

            this.AgregarPrenda(guardarropa, prenda);
        }
        public void CrearPrenda(string guardarropa, TCategoria categoria, TTipoCalzado tipo, TMateriales material, TColores color)
        {
            PrendaBuilder p = new PrendaBuilder();

            Prenda prenda = p.CrerPrenda()
                             .DeCategoria(categoria)
                             .DeTipo(tipo)
                             .DeMaterial(material)
                             .DeColorPrimario(color)
                             .ObtenerPrenda();

            this.AgregarPrenda(guardarropa, prenda);
        }




        public void CrearPrenda(string guardarropa, TCategoria categoria, TTipoAccesorio tipo, TMateriales material, TColores colorP, TColores colorS)
        {
            PrendaBuilder p = new PrendaBuilder();

            Prenda prenda = p.CrerPrenda()
                             .DeCategoria(categoria)
                             .DeTipo(tipo)
                             .DeMaterial(material)
                             .DeColorPrimario(colorP)
                             .DeColorSecundario(colorS)
                             .ObtenerPrenda();

            this.AgregarPrenda(guardarropa, prenda);
        }
        public void CrearPrenda(string guardarropa, TCategoria categoria, TTipoSuperior tipo, TMateriales material, TColores colorP, TColores colorS)
        {
            PrendaBuilder p = new PrendaBuilder();

            Prenda prenda = p.CrerPrenda()
                             .DeCategoria(categoria)
                             .DeTipo(tipo)
                             .DeMaterial(material)
                             .DeColorPrimario(colorP)
                             .DeColorSecundario(colorS)
                             .ObtenerPrenda();

            this.AgregarPrenda(guardarropa, prenda);
        }
        public void CrearPrenda(string guardarropa, TCategoria categoria, TTipoInferior tipo, TMateriales material, TColores colorP, TColores colorS)
        {
            PrendaBuilder p = new PrendaBuilder();

            Prenda prenda = p.CrerPrenda()
                             .DeCategoria(categoria)
                             .DeTipo(tipo)
                             .DeMaterial(material)
                             .DeColorPrimario(colorP)
                             .DeColorSecundario(colorS)
                             .ObtenerPrenda();

            this.AgregarPrenda(guardarropa, prenda);
        }
        public void CrearPrenda(string guardarropa, TCategoria categoria, TTipoCalzado tipo, TMateriales material, TColores colorP, TColores colorS)
        {
            PrendaBuilder p = new PrendaBuilder();

            Prenda prenda = p.CrerPrenda()
                             .DeCategoria(categoria)
                             .DeTipo(tipo)
                             .DeMaterial(material)
                             .DeColorPrimario(colorP)
                             .DeColorSecundario(colorS)
                             .ObtenerPrenda();

            this.AgregarPrenda(guardarropa, prenda);
        }
    }
}
