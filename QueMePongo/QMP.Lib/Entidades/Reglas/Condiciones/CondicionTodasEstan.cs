using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones
{
    public class CondicionTodasEstan : Condicion
    {
        public List<Caracteristica> Caracteristicas { get; set; }

        public CondicionTodasEstan(List<Caracteristica> caracteristicas)
        {
            this.Caracteristicas = caracteristicas;
        }

        //Valida si se cumplan todas las caracteristicas en al menos una prenda del atuendo
        public bool Validar(Atuendo atuendo)
        {
            bool matchPrimero = false;
            bool match = false;

            foreach (Caracteristica c in this.Caracteristicas)
            {
                matchPrimero = false;
                foreach (Prenda p in atuendo.Prendas)
                {
                    if (p.TieneCaracteristica(c))
                    {
                        if (!matchPrimero)
                        {
                            matchPrimero = true;
                            match = true;
                        }
                        else
                            return false;

                    }
                }
                if (!match)
                    return false;
                else
                    match = false;
            }

            return true;
        }
    }
}
