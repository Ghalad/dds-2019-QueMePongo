using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar.UTN.QMP.Lib.Entidades.DBTables
{
    [Table("PrendasPedidos")]
    public class PrendaPedido
    {
        [Key, ForeignKey("Prenda"), Column(Order = 0)]
        public int PrendaId { get; set; }
        [Key, ForeignKey("Pedido"), Column(Order = 1)]
        public int PedidoId { get; set; }
        public Prenda Prenda { get; set; }
        public Pedido Pedido{ get; set; }

    }
}
