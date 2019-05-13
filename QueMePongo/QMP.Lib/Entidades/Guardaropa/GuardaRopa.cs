using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Guardaropa
{
    public class GuardaRopa
    {
        public List<Atuendo> Atuendos;

        //public List<Prenda> Prendas; 
        //public Atuendo UnAtuendo;
        // Me parece mas apropiado que el guardarropa guarde el conjunto de prendas totales que tiene
        // y que los atuendos sea algo dinámico que se vaya definiendo según la combinación de prendas

    }
}
