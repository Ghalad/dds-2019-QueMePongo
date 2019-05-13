using Ar.UTN.QMP.Lib.Entidades.Atuendos;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    class Regla1Superior /*: Regla *///puede cambiarse luego a 2 superiores anidando un foreach más
    {
        public bool Validar(Atuendo atuendo)
        {
            Prenda prendaAux;
            Caracteristica caractSuperior = new Caracteristica("Zona", "Superior");

            foreach (Prenda p in atuendo.Prendas)
                if (p.TieneCaracteristica(caractSuperior) )
                {
                    prendaAux = p;
                    foreach (Prenda pr in atuendo.Prendas)
                    {
                        if (p.TieneCaracteristica(caractSuperior) /*&& pr.esDistintaA(p)*/)
                        {
                            return false;
                        }
                    }
                }
            return true;
        }
    }
}
