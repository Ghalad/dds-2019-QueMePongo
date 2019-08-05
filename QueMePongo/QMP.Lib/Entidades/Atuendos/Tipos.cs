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


        public static Tipos GetInstance()
        {
            if (Instancia == null) Instancia = new Tipos();
            return Instancia;
        }


        private Tipos()
        {
            this.TipoCaracteristicas = new List<string>();
            this.CategoriaxTipo = new List<Caracteristica>();
            this.MaterialxTipo = new List<Caracteristica>();
            this.Caracteristicas = new List<Caracteristica>();
            this.Superposiones = new List<Caracteristica>();

            // LOS VALORES SE VAN A CARGAR POR JSON HASTA QUE INCORPOREMOS LA DB (TABLA TIPO_CARACTERISTICAS)
            this.TipoCaracteristicas.Add("CATEGORIA");
            this.TipoCaracteristicas.Add("TIPO");
            this.TipoCaracteristicas.Add("MATERIAL");
            this.TipoCaracteristicas.Add("COLOR");
            this.TipoCaracteristicas.Add("SUPERPOSICION");
            this.TipoCaracteristicas.Add("ABRIGO");
            this.TipoCaracteristicas.Add("EVENTO");
            
            this.Caracteristicas.Add(new Caracteristica("CATEGORIA", "ACCESORIO"));
            this.Caracteristicas.Add(new Caracteristica("CATEGORIA", "SUPERIOR"));
            this.Caracteristicas.Add(new Caracteristica("CATEGORIA", "INFERIOR"));
            this.Caracteristicas.Add(new Caracteristica("CATEGORIA", "CALZADO"));

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
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO",   "ZAPATO_TACO_ALTO"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO",   "ZAPATO_TACO_BAJO"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO",   "ZAPATILLA_DE_CORRER"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO",   "ZAPATILLA_DE_TREKING"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO",   "SLIP_ON"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO",   "OJOTAS"));

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
            this.Caracteristicas.Add(new Caracteristica("TIPO", "ZAPATO_TACO_ALTO"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "ZAPATO_TACO_BAJO"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "ZAPATILLA_DE_CORRER"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "ZAPATILLA_DE_TREKING"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "SLIP_ON"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "OJOTAS"));

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
            this.Superposiones.Add(new Caracteristica("ZAPATO_TACO_ALTO",     "2"));
            this.Superposiones.Add(new Caracteristica("ZAPATO_TACO_BAJO",     "2"));
            this.Superposiones.Add(new Caracteristica("ZAPATILLA_DE_CORRER",  "2"));
            this.Superposiones.Add(new Caracteristica("ZAPATILLA_DE_TREKING", "2"));
            this.Superposiones.Add(new Caracteristica("SLIP_ON",              "2"));
            this.Superposiones.Add(new Caracteristica("OJOTAS",               "2"));

            this.Caracteristicas.Add(new Caracteristica("SUPERPOSICION", "1"));
            this.Caracteristicas.Add(new Caracteristica("SUPERPOSICION", "2"));
            this.Caracteristicas.Add(new Caracteristica("SUPERPOSICION", "3"));
            this.Caracteristicas.Add(new Caracteristica("SUPERPOSICION", "4"));

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
        }

        public bool ValidarCategoria(string categoria, string tipo)
        {
            if (tipo == null) return true;
            foreach (Caracteristica c in this.CategoriaxTipo)
                if (c.EsLaMisma(categoria.ToUpper(), tipo.ToUpper()))
                    return true;
            return false;
        }

        public bool ValidarTipo(string tipo, string categoria)
        {
            if (categoria == null) return true;
            foreach (Caracteristica c in this.CategoriaxTipo)
                if (c.EsLaMisma(categoria.ToUpper(), tipo.ToUpper()))
                    return true;
            return false;
        }

        public bool ExisteCaracteristica(string clave, string valor)
        {
            if (this.TipoCaracteristicas.Contains(clave.ToUpper()))
                foreach (Caracteristica c in this.Caracteristicas)
                    if (c.EsLaMisma(clave.ToUpper(), valor.ToUpper()))
                        return true;
            return false;
        }

        public bool ExisteCaracteristicaXTipo(string clave, string valor)
        {
            foreach (Caracteristica c in this.CategoriaxTipo)
                if (c.EsLaMisma(clave.ToUpper(), valor.ToUpper()))
                    return true;
            return false;
        }

        public string ObtenerSuperposicion(string tipo)
        {
            foreach (var c in this.Superposiones)
                if (c.EsLaMismaClave(tipo))
                    return c.Valor;
            return null;
        }
    }
}
