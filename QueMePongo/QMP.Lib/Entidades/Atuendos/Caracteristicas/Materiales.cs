using System.Collections.Generic;
using System.Linq;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos.Caracteristicas
{
    public class Materiales
    {
        private static Materiales instance;
        private Dictionary<int, string> Material { get; set; }

        private Materiales()
        {
            this.Material = new Dictionary<int, string>();
        }

        public static Materiales GetInstance()
        {
            if (instance == null) instance = new Materiales();
            return instance;
        }

        public void CargarMateriales()
        {
            // LOS VALORES SE VAN A CARGAR POR JSON HASTA QUE INCORPOREMOS LA DB
            this.Material.Clear();
            this.Material.Add(1, "ALGODON");
            this.Material.Add(2, "CUERO");
            this.Material.Add(3, "HILO");
            this.Material.Add(4, "CORDEROY");
            this.Material.Add(5, "JEAN");
        }

        public string ObtenerMaterial(int id)
        {
            return Material[id];
        }

        public List<string> GetLista()
        {
            return this.Material.Select(m => m.Value).ToList<string>();
        }
    }
}
