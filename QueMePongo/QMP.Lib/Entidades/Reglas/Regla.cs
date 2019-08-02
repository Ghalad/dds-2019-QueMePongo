using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    public class Regla
    {
        public string Identificador { get; set; }
        private List<Condicion> Condiciones { get; set; }

        public Regla()
        {
            this.Condiciones = new List<Condicion>();
        }
        public Regla(string id)
        {
            this.Identificador = id;
            this.Condiciones = new List<Condicion>(); 
        }


        public void AgregarCondicion(Condicion condicion)
        {
            if (condicion != null)
            {
                this.Condiciones.Add(condicion);
            }
        }

        /// <summary>
        /// Define que un atuendo es valido cuando NO se cumple ninguna de las condiciones que componen la regla
        /// </summary>
        /// <param name="atuendo"></param>
        /// <returns></returns>
        public bool Validar(Atuendo atuendo)
        {
            foreach(Condicion condicion in this.Condiciones)
            {
                if (condicion.Validar(atuendo))
                {
                    return false; // ATUENDO INVALIDO
                }
            }

            return true; // ATUENDO VALIDO
        }
    }
}
