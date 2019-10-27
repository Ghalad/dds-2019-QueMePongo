using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Ar.UTN.QMP.Web.Models.Usuarios
{
    public class UsuarioModel
    {
        [HiddenInput(DisplayValue = false)]
        public int UsuarioId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public string TarjetaCredito { get; set; }

        [Display(Name = "Usuario Primium")]
        public bool EsUsuarioPremium { get; set; }
    }   
}   