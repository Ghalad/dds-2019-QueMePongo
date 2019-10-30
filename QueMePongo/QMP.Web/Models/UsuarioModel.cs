using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ar.UTN.QMP.Web.Models
{
    public class UsuarioModel
    {
        [Required, Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public string PasswordNuevo { get; set; }

        [Display(Name = "Grado de sensibilidad")]
        public string SelectedSensibilidad { get; set; }
        public IEnumerable<Caracteristica> Sensibilidades { get; set; }

        [Display(Name = "Numero de Tarjeta")]
        public string TarjetaCredito { get; set; }

        [Display(Name = "Usuario Primium")]
        public bool EsUsuarioPremium { get; set; }
    }   
}   