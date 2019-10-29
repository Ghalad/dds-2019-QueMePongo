using System.ComponentModel.DataAnnotations;

namespace Ar.UTN.QMP.Web.Models
{
    public class UsuarioModel
    {
        [Required, Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Numero de Tarjeta")]
        public string TarjetaCredito { get; set; }

        [Display(Name = "Usuario Primium")]
        public bool EsUsuarioPremium { get; set; }
    }   
}   