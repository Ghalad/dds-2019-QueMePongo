using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ar.UTN.QMP.Web.Models
{
    public class PrendaModel
    {
        [Display(Name = "Guardarropas")]
        public string SelectedGuardarropaId { get; set; }
        public IEnumerable<Guardarropa> Guardarropas { get; set; }


        [Display(Name = "Categoria")]
        public string SelectedCategoria { get; set; }
        public IEnumerable<Caracteristica> Categorias { get; set; }


        [Display(Name = "Tipo de Prenda")]
        public string SelectedTipo { get; set; }
        public IEnumerable<Caracteristica> Tipos { get; set; }


        [Display(Name = "Material")]
        public string SelectedMeterial { get; set; }
        public IEnumerable<Caracteristica> Materiales { get; set; }


        [Display(Name = "Color Primario")]
        public string SelectedColorPrimario { get; set; }

        [Display(Name = "Color Secundario")]
        public string SelectedColorSecundario { get; set; }
        public IEnumerable<Caracteristica> Colores { get; set; }

        [Display(Name = "Tipo de Evento")]  
        public string SelectedEvento { get; set; }
        public IEnumerable<Caracteristica> Eventos { get; set; }

        [Display(Name = "Imagen")]
        public byte[] Imagen { get; set; }

        public ICollection<Prenda> Prendas { get; set; }
    }
}