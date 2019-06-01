using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Tipos
    {
        public List<string> TCategorias { get; set; }
        public List<string> TTipos { get; set; }
        public List<string> TMateriales { get; set; }
        public List<string> TColores { get; set; }


        public Tipos()
        {
            this.TCategorias = new List<string>();
            this.TTipos = new List<string>();
            this.TMateriales = new List<string>();
            this.TColores = new List<string>();
        }


        public void CargarDatos()
        {
            // LOS VALORES SE VAN A CARGAR POR JSON HASTA QUE INCORPOREMOS LA DB
            this.TCategorias.Clear();
            this.TCategorias.Add("ACCESORIO");
            this.TCategorias.Add("SUPERIOR");
            this.TCategorias.Add("INFERIOR");
            this.TCategorias.Add("CALZADO");


            // LOS VALORES SE VAN A CARGAR POR JSON HASTA QUE INCORPOREMOS LA DB
            this.TTipos.Clear();
            this.TTipos.Add("GORRA");
            this.TTipos.Add("REMERA");
            this.TTipos.Add("CAMPERA");
            this.TTipos.Add("PANTALON");
            this.TTipos.Add("SHORT");
            this.TTipos.Add("ZAPATO");


            // LOS VALORES SE VAN A CARGAR POR JSON HASTA QUE INCORPOREMOS LA DB
            this.TMateriales.Clear();
            this.TMateriales.Add("ALGODON");
            this.TMateriales.Add("CUERO");
            this.TMateriales.Add("HILO");
            this.TMateriales.Add("CORDEROY");
            this.TMateriales.Add("JEAN");


            // LOS VALORES SE VAN A CARGAR POR JSON HASTA QUE INCORPOREMOS LA DB
            this.TColores.Clear();
            this.TColores.Add("NEGRO");
            this.TColores.Add("BLANCO");
            this.TColores.Add("ROJO");
            this.TColores.Add("VERDE");
            this.TColores.Add("AZUL");
        }
    }
}
