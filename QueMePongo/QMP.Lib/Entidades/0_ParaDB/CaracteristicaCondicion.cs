using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar.UTN.QMP.Lib.Entidades._0._Para_DB
{
    [Table("CaracteristicasCondiciones")]
    public class CaracteristicaCondicion : Caracteristica
    {
        public Condicion condicion { get; set; }

        public CaracteristicaCondicion(string clave, string valor, Condicion unaCondicion) : base(clave, valor)
        {
            condicion = unaCondicion;
        }
    }
}
