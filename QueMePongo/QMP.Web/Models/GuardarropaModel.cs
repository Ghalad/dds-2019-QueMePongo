using System.ComponentModel.DataAnnotations;

namespace Ar.UTN.QMP.Web.Models
{
    public class GuardarropaModel
    {
        [Required, Display(Name = "Nombre")]
        public string Nombre { get; set; }
    }
}