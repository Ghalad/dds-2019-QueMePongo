﻿using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using System;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Usuarios
{
    public abstract class Usuario
    {
        public List<Guardarropa> Guardarropas { get; set; }
        public List<Regla> Reglas { get; set; }
        private int Maximo { get; set; }
        public string Id { get; set; }

        protected Usuario(int maximo)
        {
            this.Guardarropas = new List<Guardarropa>();
            this.Maximo = maximo;
        }

        /// <summary>
        /// permite crear nuevos Guardarropas
        /// </summary>
        /// <param name="idGuardarropa"></param>
        public void CrearGuardarropa(string idGuardarropa)
        {
            if (idGuardarropa != null)
                this.Guardarropas.Add(new Guardarropa(idGuardarropa, this.Maximo));
            else
                throw new Exception("ID de guardarropa requerido.");
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

    }
}
