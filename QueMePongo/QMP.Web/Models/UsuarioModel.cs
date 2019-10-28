using System.ComponentModel.DataAnnotations;

namespace Ar.UTN.QMP.Web.Models
{
    public class UsuarioModel
    {
        [Required]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public string TarjetaCredito { get; set; }

        [Display(Name = "Usuario Primium")]
        public bool EsUsuarioPremium { get; set; }
    }   
}   