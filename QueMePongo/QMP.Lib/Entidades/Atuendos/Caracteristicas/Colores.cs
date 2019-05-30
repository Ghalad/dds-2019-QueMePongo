using System.Collections.Generic;
using System.Linq;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos.Caracteristicas
{
    public class Colores
    {
        private static Colores instance;
        private Dictionary<int,string> Color { get; set; }

        private Colores()
        {
            this.Color = new Dictionary<int, string>();
        }

        public static Colores GetInstance()
        {
            if (instance == null) instance = new Colores();
            return instance;
        }

        public void CargarColores()
        {
            // LOS VALORES SE VAN A CARGAR POR JSON HASTA QUE INCORPOREMOS LA DB
            this.Color.Clear();
            this.Color.Add(1, "NEGRO");
            this.Color.Add(2, "BLANCO");
            this.Color.Add(3, "ROJO");
            this.Color.Add(4, "VERDE");
            this.Color.Add(5, "AZUL");
        }

        public string ObtenerColor(int id)
        {
            return Color[id];
        }

        public List<string> GetLista()
        {
            return this.Color.Select(c => c.Value).ToList<string>();
        }
    }
}
