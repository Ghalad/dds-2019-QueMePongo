using System;
using System.Collections.Generic;

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
        public List<Caracteristica> TipoPrendaxClima { get; set; }
        public List<Caracteristica> NivelDeAbrigo { get; set; }


        public static Tipos GetInstance()
        {
            if (Instancia == null) Instancia = new Tipos();
            return Instancia;
        }


        private Tipos()
        {
            this.TipoCaracteristicas = new List<string>();
            this.CategoriaxTipo      = new List<Caracteristica>();
            this.MaterialxTipo       = new List<Caracteristica>();
            this.Caracteristicas     = new List<Caracteristica>();
            this.Superposiones       = new List<Caracteristica>();
            this.TipoPrendaxClima    = new List<Caracteristica>();
            this.NivelDeAbrigo       = new List<Caracteristica>();

            // Aca van todos las caracteristicas posibles que puede tener una prenda.
            this.TipoCaracteristicas.Add("CATEGORIA");
            this.TipoCaracteristicas.Add("TIPO");
            this.TipoCaracteristicas.Add("MATERIAL");
            this.TipoCaracteristicas.Add("COLOR");
            this.TipoCaracteristicas.Add("SUPERPOSICION");
            this.TipoCaracteristicas.Add("ABRIGO");
            this.TipoCaracteristicas.Add("CLIMA");
            this.TipoCaracteristicas.Add("EVENTO");
            

            // Estos son todos los valores que puede adoptar cada tipo de caracteristica
            this.Caracteristicas.Add(new Caracteristica("CATEGORIA", "ACCESORIO"));
            this.Caracteristicas.Add(new Caracteristica("CATEGORIA", "SUPERIOR"));
            this.Caracteristicas.Add(new Caracteristica("CATEGORIA", "INFERIOR"));
            this.Caracteristicas.Add(new Caracteristica("CATEGORIA", "CALZADO"));

            this.Caracteristicas.Add(new Caracteristica("TIPO", "GORRA"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "SOMBRERO"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "MUSCULOSA"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "REMERA_MANGA_CORTA"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "REMERA_MANGA_LARGA"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "CAMISA_MANGA_CORTA"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "CAMISA_MANGA_LARGA"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "SWEATER"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "CAMPERA_DE_ABRIGO"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "CAMPERA_DE_LLUVIA"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "PANTALON_CORTO"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "PANTALON_LARGO"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "POLLERA"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "MEDIAS"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "ZAPATO_TACO_ALTO"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "ZAPATO_TACO_BAJO"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "ZAPATILLA_DE_CORRER"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "ZAPATILLA_DE_TREKING"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "PANCHAS"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "OJOTAS"));

            this.Caracteristicas.Add(new Caracteristica("SUPERPOSICION", "1"));
            this.Caracteristicas.Add(new Caracteristica("SUPERPOSICION", "2"));
            this.Caracteristicas.Add(new Caracteristica("SUPERPOSICION", "3"));
            this.Caracteristicas.Add(new Caracteristica("SUPERPOSICION", "4"));

            this.Caracteristicas.Add(new Caracteristica("ABRIGO", "1"));
            this.Caracteristicas.Add(new Caracteristica("ABRIGO", "2"));
            this.Caracteristicas.Add(new Caracteristica("ABRIGO", "3"));
            this.Caracteristicas.Add(new Caracteristica("ABRIGO", "4"));
            this.Caracteristicas.Add(new Caracteristica("ABRIGO", "5"));
            this.Caracteristicas.Add(new Caracteristica("ABRIGO", "6"));

            this.Caracteristicas.Add(new Caracteristica("MATERIAL", "ALGODON"));
            this.Caracteristicas.Add(new Caracteristica("MATERIAL", "CUERO"));
            this.Caracteristicas.Add(new Caracteristica("MATERIAL", "HILO"));
            this.Caracteristicas.Add(new Caracteristica("MATERIAL", "CORDEROY"));
            this.Caracteristicas.Add(new Caracteristica("MATERIAL", "JEAN"));
            this.Caracteristicas.Add(new Caracteristica("MATERIAL", "GOMA"));
            this.Caracteristicas.Add(new Caracteristica("MATERIAL", "LANA"));
            this.Caracteristicas.Add(new Caracteristica("MATERIAL", "POLIESTER"));

            this.Caracteristicas.Add(new Caracteristica("COLOR", "NEGRO"));
            this.Caracteristicas.Add(new Caracteristica("COLOR", "GRIS"));
            this.Caracteristicas.Add(new Caracteristica("COLOR", "AZUL"));
            this.Caracteristicas.Add(new Caracteristica("COLOR", "VERDE"));
            this.Caracteristicas.Add(new Caracteristica("COLOR", "VIOLETA"));
            this.Caracteristicas.Add(new Caracteristica("COLOR", "ROJO"));
            this.Caracteristicas.Add(new Caracteristica("COLOR", "NARANJA"));
            this.Caracteristicas.Add(new Caracteristica("COLOR", "AMARILLO"));
            this.Caracteristicas.Add(new Caracteristica("COLOR", "BLANCO"));

            this.Caracteristicas.Add(new Caracteristica("EVENTO", "TRABAJO"));
            this.Caracteristicas.Add(new Caracteristica("EVENTO", "SALIDA_AMIGOS"));
            this.Caracteristicas.Add(new Caracteristica("EVENTO", "CUMPLEAÑOS"));
            this.Caracteristicas.Add(new Caracteristica("EVENTO", "CASAMIENTO"));
            this.Caracteristicas.Add(new Caracteristica("EVENTO", "CASUAL"));


            // Estos son los valores de nivel de superposicion que puede tener una prenda de un determinado tipo
            this.Superposiones.Add(new Caracteristica("GORRA",                "1"));
            this.Superposiones.Add(new Caracteristica("SOMBRERO",             "1"));
            this.Superposiones.Add(new Caracteristica("MUSCULOSA",            "1"));
            this.Superposiones.Add(new Caracteristica("REMERA_MANGA_CORTA",   "1"));
            this.Superposiones.Add(new Caracteristica("REMERA_MANGA_LARGA",   "1"));
            this.Superposiones.Add(new Caracteristica("CAMISA_MANGA_CORTA",   "2"));
            this.Superposiones.Add(new Caracteristica("CAMISA_MANGA_LARGA",   "2"));
            this.Superposiones.Add(new Caracteristica("SWEATER",              "3"));
            this.Superposiones.Add(new Caracteristica("CAMPERA_DE_ABRIGO",    "4"));
            this.Superposiones.Add(new Caracteristica("CAMPERA_DE_LLUVIA",    "4"));
            this.Superposiones.Add(new Caracteristica("PANTALON_CORTO",       "2"));
            this.Superposiones.Add(new Caracteristica("PANTALON_LARGO",       "2"));
            this.Superposiones.Add(new Caracteristica("POLLERA",              "2"));
            this.Superposiones.Add(new Caracteristica("MEDIAS",               "1"));
            this.Superposiones.Add(new Caracteristica("ZAPATO_TACO_ALTO",     "2"));
            this.Superposiones.Add(new Caracteristica("ZAPATO_TACO_BAJO",     "2"));
            this.Superposiones.Add(new Caracteristica("ZAPATILLA_DE_CORRER",  "2"));
            this.Superposiones.Add(new Caracteristica("ZAPATILLA_DE_TREKING", "2"));
            this.Superposiones.Add(new Caracteristica("PANCHAS",              "2"));
            this.Superposiones.Add(new Caracteristica("OJOTAS",               "2"));


            // Listado de que tipo de prenda pertenece a que categoria
            this.CategoriaxTipo.Add(new Caracteristica("ACCESORIO", "GORRA"));
            this.CategoriaxTipo.Add(new Caracteristica("ACCESORIO", "SOMBRERO"));
            this.CategoriaxTipo.Add(new Caracteristica("SUPERIOR",  "MUSCULOSA"));
            this.CategoriaxTipo.Add(new Caracteristica("SUPERIOR",  "REMERA_MANGA_CORTA"));
            this.CategoriaxTipo.Add(new Caracteristica("SUPERIOR",  "REMERA_MANGA_LARGA"));
            this.CategoriaxTipo.Add(new Caracteristica("SUPERIOR",  "CAMISA_MANGA_CORTA"));
            this.CategoriaxTipo.Add(new Caracteristica("SUPERIOR",  "CAMISA_MANGA_LARGA"));
            this.CategoriaxTipo.Add(new Caracteristica("SUPERIOR",  "SWEATER"));
            this.CategoriaxTipo.Add(new Caracteristica("SUPERIOR",  "CAMPERA_DE_ABRIGO"));
            this.CategoriaxTipo.Add(new Caracteristica("SUPERIOR",  "CAMPERA_DE_LLUVIA"));
            this.CategoriaxTipo.Add(new Caracteristica("INFERIOR",  "PANTALON_CORTO"));
            this.CategoriaxTipo.Add(new Caracteristica("INFERIOR",  "PANTALON_LARGO"));
            this.CategoriaxTipo.Add(new Caracteristica("INFERIOR",  "POLLERA"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO",   "MEDIAS"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO",   "ZAPATO_TACO_ALTO"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO",   "ZAPATO_TACO_BAJO"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO",   "ZAPATILLA_DE_CORRER"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO",   "ZAPATILLA_DE_TREKING"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO",   "PANCHAS"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO",   "OJOTAS"));

            // Estos son los climas que le corresponden a cada tipo de prenda
            this.TipoPrendaxClima.Add(new Caracteristica("GORRA",                "FRIO"));
            this.TipoPrendaxClima.Add(new Caracteristica("SOMBRERO",             "FRIO"));
            this.TipoPrendaxClima.Add(new Caracteristica("REMERA_MANGA_LARGA",   "FRIO"));
            this.TipoPrendaxClima.Add(new Caracteristica("CAMISA_MANGA_LARGA",   "FRIO"));
            this.TipoPrendaxClima.Add(new Caracteristica("SWEATER",              "FRIO"));
            this.TipoPrendaxClima.Add(new Caracteristica("CAMPERA_DE_ABRIGO",    "FRIO"));
            this.TipoPrendaxClima.Add(new Caracteristica("CAMPERA_DE_LLUVIA",    "FRIO"));
            this.TipoPrendaxClima.Add(new Caracteristica("PANTALON_CORTO",       "FRIO"));
            this.TipoPrendaxClima.Add(new Caracteristica("PANTALON_LARGO",       "FRIO"));
            this.TipoPrendaxClima.Add(new Caracteristica("MEDIAS",               "FRIO"));
            this.TipoPrendaxClima.Add(new Caracteristica("ZAPATO_TACO_ALTO",     "FRIO"));
            this.TipoPrendaxClima.Add(new Caracteristica("ZAPATO_TACO_BAJO",     "FRIO"));
            this.TipoPrendaxClima.Add(new Caracteristica("ZAPATILLA_DE_CORRER",  "FRIO"));
            this.TipoPrendaxClima.Add(new Caracteristica("ZAPATILLA_DE_TREKING", "FRIO"));
            this.TipoPrendaxClima.Add(new Caracteristica("PANCHAS",              "FRIO"));

            this.TipoPrendaxClima.Add(new Caracteristica("GORRA",                 "TEMPLADO"));
            this.TipoPrendaxClima.Add(new Caracteristica("SOMBRERO",              "TEMPLADO"));
            this.TipoPrendaxClima.Add(new Caracteristica("REMERA_MANGA_CORTA",    "TEMPLADO"));
            this.TipoPrendaxClima.Add(new Caracteristica("REMERA_MANGA_LARGA",    "TEMPLADO"));
            this.TipoPrendaxClima.Add(new Caracteristica("CAMISA_MANGA_CORTA",    "TEMPLADO"));
            this.TipoPrendaxClima.Add(new Caracteristica("CAMISA_MANGA_LARGA",    "TEMPLADO"));
            this.TipoPrendaxClima.Add(new Caracteristica("SWEATER",               "TEMPLADO"));
            this.TipoPrendaxClima.Add(new Caracteristica("CAMPERA_DE_ABRIGO",     "TEMPLADO"));
            this.TipoPrendaxClima.Add(new Caracteristica("CAMPERA_DE_LLUVIA",     "TEMPLADO"));
            this.TipoPrendaxClima.Add(new Caracteristica("PANTALON_CORTO",        "TEMPLADO"));
            this.TipoPrendaxClima.Add(new Caracteristica("PANTALON_LARGO",        "TEMPLADO"));
            this.TipoPrendaxClima.Add(new Caracteristica("MEDIAS",                "TEMPLADO"));
            this.TipoPrendaxClima.Add(new Caracteristica("ZAPATO_TACO_ALTO",      "TEMPLADO"));
            this.TipoPrendaxClima.Add(new Caracteristica("ZAPATO_TACO_BAJO",      "TEMPLADO"));
            this.TipoPrendaxClima.Add(new Caracteristica("ZAPATILLA_DE_CORRER",   "TEMPLADO"));
            this.TipoPrendaxClima.Add(new Caracteristica("ZAPATILLA_DE_TREKING",  "TEMPLADO"));
            this.TipoPrendaxClima.Add(new Caracteristica("PANCHAS",               "TEMPLADO"));

            this.TipoPrendaxClima.Add(new Caracteristica("GORRA",                "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("SOMBRERO",             "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("MUSCULOSA",            "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("REMERA_MANGA_CORTA",   "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("REMERA_MANGA_LARGA",   "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("CAMISA_MANGA_CORTA",   "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("CAMISA_MANGA_LARGA",   "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("CAMPERA_DE_LLUVIA",    "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("PANTALON_CORTO",       "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("PANTALON_LARGO",       "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("POLLERA",              "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("MEDIAS",               "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("ZAPATO_TACO_ALTO",     "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("ZAPATO_TACO_BAJO",     "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("ZAPATILLA_DE_CORRER",  "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("ZAPATILLA_DE_TREKING", "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("PANCHAS",              "CALIDO"));
            this.TipoPrendaxClima.Add(new Caracteristica("OJOTAS",               "CALIDO"));

            //El nivel de abrigo que le corresponde a cada prenda
            //CADA VEZ QUE SE ACTUALICE, ACTUALIZAR AtuendosGestor.CumpleNivelDeAbrigo()
            this.NivelDeAbrigo.Add(new Caracteristica("GORRA",                "2"));
            this.NivelDeAbrigo.Add(new Caracteristica("SOMBRERO",             "1"));

            this.NivelDeAbrigo.Add(new Caracteristica("MUSCULOSA",            "2"));
            this.NivelDeAbrigo.Add(new Caracteristica("REMERA_MANGA_CORTA",   "3"));
            this.NivelDeAbrigo.Add(new Caracteristica("REMERA_MANGA_LARGA",   "4"));
            this.NivelDeAbrigo.Add(new Caracteristica("CAMISA_MANGA_CORTA",   "3"));
            this.NivelDeAbrigo.Add(new Caracteristica("CAMISA_MANGA_LARGA",   "4"));
            this.NivelDeAbrigo.Add(new Caracteristica("SWEATER",              "5"));
            this.NivelDeAbrigo.Add(new Caracteristica("CAMPERA_DE_ABRIGO",    "6"));
            this.NivelDeAbrigo.Add(new Caracteristica("CAMPERA_DE_LLUVIA",    "4"));

            this.NivelDeAbrigo.Add(new Caracteristica("PANTALON_CORTO",       "3"));
            this.NivelDeAbrigo.Add(new Caracteristica("PANTALON_LARGO",       "4"));
            this.NivelDeAbrigo.Add(new Caracteristica("POLLERA",              "3"));

            this.NivelDeAbrigo.Add(new Caracteristica("MEDIAS",               "1"));
            this.NivelDeAbrigo.Add(new Caracteristica("ZAPATO_TACO_ALTO",     "2"));
            this.NivelDeAbrigo.Add(new Caracteristica("ZAPATO_TACO_BAJO",     "2"));
            this.NivelDeAbrigo.Add(new Caracteristica("ZAPATILLA_DE_CORRER",  "2"));
            this.NivelDeAbrigo.Add(new Caracteristica("ZAPATILLA_DE_TREKING", "2"));
            this.NivelDeAbrigo.Add(new Caracteristica("PANCHAS",              "2"));
            this.NivelDeAbrigo.Add(new Caracteristica("OJOTAS",               "0"));
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

        public int ObtenerNivelDeAbrigo(string tipo)
        {
            foreach (var c in this.NivelDeAbrigo)
                if (c.EsLaMismaClave(tipo))
                    return Convert.ToInt32(c.Valor);
            return 0;
        }


        /// <summary>
        /// Devuelve los climas de un tipo de prenda
        /// </summary>
        /// <param name="tipoPrenda"></param>
        /// <returns></returns>
        public List<string> ObtenerClimas(string tipoPrenda)
        {
            List<string> climas = new List<string>();
            
            foreach(Caracteristica car in this.TipoPrendaxClima.FindAll(c => c.Clave.Equals(tipoPrenda.ToUpper())))
            {
                climas.Add(car.Valor);
            }

            return climas;
        }


        /// <summary>
        /// Convierte un valor de temperatura en el string que lo representa
        /// </summary>
        /// <param name="valorTemperatura"></param>
        /// <returns></returns>
        public string TraducirTemperatura(decimal valorTemperatura)
        {
            if (valorTemperatura <= 10)
            {
                return "FRIO";
            }
            else if (valorTemperatura > 10 && valorTemperatura < 20)
            {
                return "TEMPLADO";
            }
            else if (valorTemperatura >= 20)
            {
                return "CALIDO";
            }
            else
                throw new Exception("Valor de temperatura invalido");
        }
    }
}
