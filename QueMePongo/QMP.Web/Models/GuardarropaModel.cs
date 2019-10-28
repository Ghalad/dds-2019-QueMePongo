using System.ComponentModel.DataAnnotations;

namespace Ar.UTN.QMP.Web.Models
{
    public class GuardarropaModel
    {
        [Required]
        public string Nombre { get; set; }
    }
}