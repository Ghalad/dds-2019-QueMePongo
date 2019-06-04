using System;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Tipos
    {
        private static Tipos Instancia { get; set; }

        private List<string> TipoCaracteristicas { get; set; }
        private List<Caracteristica> CategoriaxTipo { get; set; }
        private List<Caracteristica> Caracteristicas { get; set; }

        public static Tipos GetInstance()
        {
            if (Instancia == null) Instancia = new Tipos();
            return Instancia;
        }


        private Tipos()
        {
            this.TipoCaracteristicas = new List<string>();
            this.CategoriaxTipo = new List<Caracteristica>();
            this.Caracteristicas = new List<Caracteristica>();

            // LOS VALORES SE VAN A CARGAR POR JSON HASTA QUE INCORPOREMOS LA DB (TABLA TIPO_CARACTERISTICAS)
            this.TipoCaracteristicas.Add("CATEGORIA");
            this.TipoCaracteristicas.Add("TIPO");
            this.TipoCaracteristicas.Add("MATERIAL");
            this.TipoCaracteristicas.Add("COLOR");

            // LOS VALORES SE VAN A CARGAR POR JSON HASTA QUE INCORPOREMOS LA DB (TABLA CARACTERISTICAS)
            this.Caracteristicas.Add(new Caracteristica("CATEGORIA", "ACCESORIO"));
            this.Caracteristicas.Add(new Caracteristica("CATEGORIA", "SUPERIOR"));
            this.Caracteristicas.Add(new Caracteristica("CATEGORIA", "INFERIOR"));
            this.Caracteristicas.Add(new Caracteristica("CATEGORIA", "CALZADO"));

            this.CategoriaxTipo.Add(new Caracteristica("ACCESORIO", "GORRA"));
            this.CategoriaxTipo.Add(new Caracteristica("ACCESORIO", "SOMBRERO"));
            this.CategoriaxTipo.Add(new Caracteristica("SUPERIOR", "REMERA_MANGA_CORTA"));
            this.CategoriaxTipo.Add(new Caracteristica("SUPERIOR", "REMERA_MANGA_LARGA"));
            this.CategoriaxTipo.Add(new Caracteristica("SUPERIOR", "MUSCULOSA"));
            this.CategoriaxTipo.Add(new Caracteristica("SUPERIOR", "CAMPERA_DE_ABRIGO"));
            this.CategoriaxTipo.Add(new Caracteristica("SUPERIOR", "CAMPERA_DE_LLUVIA"));
            this.CategoriaxTipo.Add(new Caracteristica("INFERIOR", "PANTALON_CORTO"));
            this.CategoriaxTipo.Add(new Caracteristica("INFERIOR", "PANTALON_LARGO"));
            this.CategoriaxTipo.Add(new Caracteristica("INFERIOR", "POLLERA"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO", "ZAPATO_TACO_ALTO"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO", "ZAPATO_TACO_BAJO"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO", "ZAPATILLA_DE_CORRER"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO", "ZAPATILLA_DE_TREKING"));
            this.CategoriaxTipo.Add(new Caracteristica("CALZADO", "OJOTAS"));

            this.Caracteristicas.Add(new Caracteristica("TIPO", "GORRA"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "SOMBRERO"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "REMERA_MANGA_CORTA"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "REMERA_MANGA_LARGA"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "MUSCULOSA"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "CAMPERA_DE_ABRIGO"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "CAMPERA_DE_LLUVIA"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "PANTALON_CORTO"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "PANTALON_LARGO"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "POLLERA"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "ZAPATO_TACO_ALTO"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "ZAPATO_TACO_BAJO"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "ZAPATILLA_DE_CORRER"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "ZAPATILLA_DE_TREKING"));
            this.Caracteristicas.Add(new Caracteristica("TIPO", "OJOTAS"));
            
            this.Caracteristicas.Add(new Caracteristica("MATERIAL", "ALGODON"));
            this.Caracteristicas.Add(new Caracteristica("MATERIAL", "CUERO"));
            this.Caracteristicas.Add(new Caracteristica("MATERIAL", "HILO"));
            this.Caracteristicas.Add(new Caracteristica("MATERIAL", "CORDEROY"));
            this.Caracteristicas.Add(new Caracteristica("MATERIAL", "JEAN"));
            this.Caracteristicas.Add(new Caracteristica("MATERIAL", "GOMA"));

            this.Caracteristicas.Add(new Caracteristica("COLOR", "NEGRO"));
            this.Caracteristicas.Add(new Caracteristica("COLOR", "BLANCO"));
            this.Caracteristicas.Add(new Caracteristica("COLOR", "ROJO"));
            this.Caracteristicas.Add(new Caracteristica("COLOR", "VERDE"));
            this.Caracteristicas.Add(new Caracteristica("COLOR", "AZUL"));
        }

        internal bool ValidarCategoria(string categoria, string tipo)
        {
            if (tipo == null) return true;
            foreach (Caracteristica c in this.CategoriaxTipo)
                if (c.EsLaMisma(categoria.ToUpper(), tipo.ToUpper()))
                    return true;
            return false;
        }

        internal bool ValidarTipo(string tipo, string categoria)
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
    }
}
