using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ar.UTN.QMP.Web.Models
{
    public class PedidosModel
    {
        [Display(Name = "Tipo de Evento")]
        public string SelectedEvento { get; set; }
        public IEnumerable<Caracteristica> Eventos { get; set; }

        [Display(Name = "Repeticion")]
        public string SelectedRepeticion { get; set; }
        public List<string> Repeticiones { get; set; }

        [Display(Name = "Fecha de Evento")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime FechaEvento { get; set; }

        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Lista de pedidos")]
        public ICollection<Pedido> Pedidos { get; set; }
    }
}