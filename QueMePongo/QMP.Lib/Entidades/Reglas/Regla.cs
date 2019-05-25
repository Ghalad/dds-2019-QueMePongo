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

            //podríamos usar Singleton para esta instancia 
            
            // |
            // V

        }

        public void agregarCondicion(Condicion unaCondicion)
        {
            Condiciones.Add(unaCondicion);
            return;
        }

        public void quitarCondicion(Condicion unaCondicion)
        {
            Condiciones.Remove(unaCondicion);
            return;
        }

        public bool Validar(Atuendo atuendo)
        {
            foreach(Condicion condicion in this.Condiciones)
            {
                if (!condicion.Validar(atuendo))
                {
                    return false; // ATUENDO VALIDA
                }
            }

            return true; // ATUENDO INVALIDO
        }
    }
}
