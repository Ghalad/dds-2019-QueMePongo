using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Ar.UTN.QMP.Web.Models.Usuarios
{
    public class GuardarropaModel
    {
        [HiddenInput(DisplayValue = false)]
        public int UsuarioId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int GuardarropaId { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}