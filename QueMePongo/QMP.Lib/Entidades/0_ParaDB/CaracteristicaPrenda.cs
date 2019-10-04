using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar.UTN.QMP.Lib.Entidades._0._Para_DB
{
    [Table("CaracteristicasPrendas")]
    public class CaracteristicaPrenda : Caracteristica
    {
        public Prenda prenda { get; set; }

        private CaracteristicaPrenda() : base() { }
        public CaracteristicaPrenda(string clave,string valor, Prenda unaPrenda) : base(clave, valor)
        {
            prenda = unaPrenda;
        }
    }
}
