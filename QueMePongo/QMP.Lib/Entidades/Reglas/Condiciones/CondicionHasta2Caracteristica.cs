using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones
{
    public class CondicionHasta2Caracteristica : Condicion
    {
        public Prenda PrendaAux;
        public Caracteristica Caracteristica { get; set; }

        public CondicionHasta2Caracteristica(Caracteristica UnaCaracteristica)
        {
            this.Caracteristica = UnaCaracteristica;
        }


        //Valida el atuendo siempre y cuando tenga hasta 2 de esa característica. Si tiene 3 o más no lo valida.
        //Sirve para prendas con Zona Superior. En el enunciado dice que puede tener más adelante 2 prendas superiores.
        public bool Validar(Atuendo atuendo)
        {
            foreach (Prenda prenda in atuendo.Prendas)
            {
                if (prenda.TieneCaracteristica(this.Caracteristica))
                {
                    foreach (Prenda prenda2 in atuendo.Prendas)
                    {
                        if(prenda2.TieneCaracteristica(this.Caracteristica) && (prenda2!=prenda))
                        {
                            foreach (Prenda prenda3 in atuendo.Prendas)
                            {
                                if(prenda3.TieneCaracteristica(this.Caracteristica) && (prenda3!=prenda) && (prenda3 != prenda2))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
}
