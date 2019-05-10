using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    class Regla1Superior : Regla //puede cambiarse luego a 2 superiores anidando un foreach más
    {
        public bool Validar(Atuendo atuendo)
        {
            int prendaAux;
            Caracteristica caractSuperior = new Caracteristica("Zona", "Superior");

            foreach (Prenda p in atuendo.Prendas)
                if (p.tieneCaracteristica(caractSuperior) )
                {
                    prendaAux = p;
                    foreach (Prenda pr in atuendo.Prendas)
                    {
                        if (p.tieneCaracteristica(caractSuperior) && pr.esDistintaA(p))
                        {
                            return false;
                        }
                    }
                }
            return true;
        }
    }
}
