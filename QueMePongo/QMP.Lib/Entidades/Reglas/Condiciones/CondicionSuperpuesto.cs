using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones
{
    public class CondicionSuperpuesto : Condicion
    {
        public CondicionSuperpuesto(){}

        public bool Validar(Atuendo atuendo)
        {
            int c1, c2;

            foreach(Prenda p1 in atuendo.Prendas)
            {
                foreach(Prenda p2 in atuendo.Prendas)
                {
                    if( p2!=p1)
                    {
                        c1 = p1.NumeroSuperposicion();
                        c2 = p2.NumeroSuperposicion();

                        //-1 es si no tienen superposicion
                        //si tienen el mismo numero de superposicion devuelve falso
                        if(c1 == c2 && c1!= -1)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
