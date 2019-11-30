using Ar.UTN.QMP.Lib.Entidades.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class GestorCaracteristicas
    {
        private static GestorCaracteristicas Instancia { get; set; }

        public List<string> TipoCaracteristicas { get; set; }
        public List<Caracteristica> CategoriaxTipo { get; set; }
        public List<Caracteristica> Caracteristicas { get; set; }
        public List<Caracteristica> Superposiones { get; set; }
        public List<Caracteristica> NivelDeAbrigo { get; set; }
        public List<Caracteristica> Sensibilidad { get; set; }
        

        public static GestorCaracteristicas GetInstance()
        {
            if (Instancia == null) Instancia = new GestorCaracteristicas();
            return Instancia;
        }


        private GestorCaracteristicas()
        {
            this.TipoCaracteristicas = new List<string>();
            this.CategoriaxTipo      = new List<Caracteristica>();
            this.Caracteristicas     = new List<Caracteristica>();
            this.Superposiones       = new List<Caracteristica>();
            this.NivelDeAbrigo       = new List<Caracteristica>();
            this.Sensibilidad        = new List<Caracteristica>();

            using (QueMePongoDB db = new QueMePongoDB())
            {
                // Se cargan los tipos de caracteristicas desde la base
                try
                {
                    this.TipoCaracteristicas.AddRange(db.Caracteristicas.Where(c => c.Nombre.Equals("CARACTERISTICA")).Select(c => c.Clave).Distinct().ToList());
                    this.Caracteristicas.AddRange(db.Caracteristicas.Where(c => c.Nombre.Equals("CARACTERISTICA")).Select(c => c).ToList());
                    this.Superposiones.AddRange(db.Caracteristicas.Where(c => c.Nombre.Equals("SUPERPOSICION")).Select(c => c).ToList());
                    this.CategoriaxTipo.AddRange(db.Caracteristicas.Where(c => c.Nombre.Equals("CATEGORIATIPO")).Select(c => c).ToList());
                    this.NivelDeAbrigo.AddRange(db.Caracteristicas.Where(c => c.Nombre.Equals("NIVELABRIGO")).Select(c => c).ToList());
                    this.Sensibilidad.AddRange(db.Caracteristicas.Where(c => c.Nombre.Equals("SENSIBILIDAD")).Select(c => c).ToList());
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo cargar las caracteristicas");
                }

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

        /// <summary>
        /// En base a un tipo de prenda obtiene el nivel de abrigo
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public string ObtenerAbrigo(string tipo)
        {
            foreach (var c in this.NivelDeAbrigo)
                if (c.EsLaMismaClave(tipo))
                    return c.Valor;
            return null;
        }

        public int ObtenerIndiceSensibilidad(string sensibilidad)
        {
            foreach (var car in this.Sensibilidad)
                if (car.EsLaMismaClave(sensibilidad.ToUpper()))
                    return Int32.Parse(car.Valor);
            throw new Exception("Sensibilidad al clima no válida.");
        }

        public string ObtenerSensibilidad(int sensibilidad)
        {
            foreach (var car in this.Sensibilidad)
                if (Int32.Parse(car.Valor) == sensibilidad)
                    return car.Clave;
            throw new Exception("Sensibilidad al clima no válida.");
        }

        /// <summary>
        /// Se encarga de controlar que no haya multiplicidad de objetos Caracteristica que representen la misma caracteristica.
        /// </summary>
        /// <param name="clave"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public Caracteristica ObtenerCaracteristica(string clave, string valor)
        {
            Caracteristica car;

            car = this.Caracteristicas.Where(c => c.Nombre.Equals("CARACTERISTICA") && c.Clave.Equals(clave.ToUpper()) && c.Valor.Equals(valor.ToUpper())).FirstOrDefault();

            if (car == null)
            {
                throw new Exception(string.Format("La caracteristica [{0}, {1}] solicitada no existe.", clave, valor));
            }

            return car;
        }

    }
}
