using Ar.UTN.QMP.Lib.Entidades.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Tipos
    {
        private static Tipos Instancia { get; set; }

        public List<string> TipoCaracteristicas { get; set; }
        public List<Caracteristica> CategoriaxTipo { get; set; }
        public List<Caracteristica> MaterialxTipo { get; set; }
        public List<Caracteristica> Caracteristicas { get; set; }
        public List<Caracteristica> Superposiones { get; set; }
        public List<Caracteristica> NivelDeAbrigo { get; set; }


        public static Tipos GetInstance()
        {
            if (Instancia == null) Instancia = new Tipos();
            return Instancia;
        }


        private Tipos()
        {
            QueMePongoDB db = new QueMePongoDB();

            this.TipoCaracteristicas = new List<string>();
            this.CategoriaxTipo = new List<Caracteristica>();
            this.MaterialxTipo = new List<Caracteristica>();
            this.Caracteristicas = new List<Caracteristica>();
            this.Superposiones = new List<Caracteristica>();
            this.NivelDeAbrigo = new List<Caracteristica>();

            // Se cargan los tipos de caracteristicas desde la base
            try
            {
                foreach (var str in db.Caracteristicas.Where(c => c.Nombre.Equals("CARACTERISTICA")).Select(c => c.Clave).Distinct().ToList())
                {
                    this.TipoCaracteristicas.Add(str);
                }
            }
            catch (Exception ex)
            {

            }


            // Se cargan las caracteristicas desde la base
            try
            {
                foreach (var car in db.Caracteristicas.Where(c => c.Nombre.Equals("CARACTERISTICA")).Select(c => c).ToList())
                {
                    this.Caracteristicas.Add(car);
                }
            }
            catch (Exception ex)
            {

            }


            // Se cargan las superposiciones desde la base
            try
            {
                foreach (var car in db.Caracteristicas.Where(c => c.Nombre.Equals("SUPERPOSICION")).Select(c => c).ToList())
                {
                    this.Superposiones.Add(car);
                }
            }
            catch (Exception ex)
            {

            }


            // Se cargan las superposiciones desde la base
            try
            {
                foreach (var car in db.Caracteristicas.Where(c => c.Nombre.Equals("CATEGORIATIPO")).Select(c => c).ToList())
                {
                    this.CategoriaxTipo.Add(car);
                }
            }
            catch (Exception ex)
            {

            }


            // Se cargan las superposiciones desde la base
            try
            {
                foreach (var car in db.Caracteristicas.Where(c => c.Nombre.Equals("NIVELABRIGO")).Select(c => c).ToList())
                {
                    this.NivelDeAbrigo.Add(car);
                }
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// Valida que la CATEGORIA se corresponda con el TIPO
        /// </summary>
        /// <param name="categoria"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public bool ValidarCategoria(string categoria, string tipo)
        {
            if (tipo == null) return true;
            foreach (Caracteristica c in this.CategoriaxTipo)
                if (c.EsLaMisma(categoria.ToUpper(), tipo.ToUpper()))
                    return true;
            return false;
        }
        
        /// <summary>
        /// Valida que el TIPO se corresponda con la CATEGORIA
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public bool ValidarTipo(string tipo, string categoria)
        {
            if (categoria == null) return true;
            foreach (Caracteristica c in this.CategoriaxTipo)
                if (c.EsLaMisma(categoria.ToUpper(), tipo.ToUpper()))
                    return true;
            return false;
        }
        
        /// <summary>
        /// Permite validar si el par Clave, Valor es valido
        /// </summary>
        /// <param name="clave"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public bool ExisteCaracteristica(string clave, string valor)
        {
            if (this.TipoCaracteristicas.Contains(clave.ToUpper()))
                foreach (Caracteristica c in this.Caracteristicas)
                    if (c.EsLaMisma(clave.ToUpper(), valor.ToUpper()))
                        return true;
            return false;
        }
        
        /// <summary>
        /// Permite verificar si se corresponde la CATEGORIA (calve) con el TIPO (valor)
        /// </summary>
        /// <param name="clave"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public bool ExisteCaracteristicaXTipo(string clave, string valor)
        {
            foreach (Caracteristica c in this.CategoriaxTipo)
                if (c.EsLaMisma(clave.ToUpper(), valor.ToUpper()))
                    return true;
            return false;
        }
        
        /// <summary>
        /// En base a el tipo de prenda, se obtiene el valor de superposicion que le corresponde
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public string ObtenerSuperposicion(string tipo)
        {
            foreach (var c in this.Superposiones)
                if (c.EsLaMismaClave(tipo))
                    return c.Valor;
            return null;
        }

        public string ObtenerAbrigo(string tipo)
        {
            foreach (var c in this.NivelDeAbrigo)
                if (c.EsLaMismaClave(tipo))
                    return c.Valor;
            return null;
        }

    }
}
