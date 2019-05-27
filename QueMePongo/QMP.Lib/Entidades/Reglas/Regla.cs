using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    public class Regla
    {
        public List<Condicion> Condiciones { get; set; }

        public Regla()
        {
            this.Condiciones = new List<Condicion>(); 

         
        }

        public void agregarCondicion(Condicion unaCondicion)
        {
            Condiciones.Add(unaCondicion);
            return;
        }


        public bool Validar(Atuendo atuendo)
        {

            foreach(Condicion condicion in this.Condiciones)
            {
                if (!condicion.Validar(atuendo))
                {
                    return false; // ATUENDO INVALIDO
                }
            }

            return true; // ATUENDO VALIDO
        }
    }
}
