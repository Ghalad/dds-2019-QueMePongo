using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    public class Regla
    {
        public string Id { get; set; }
        private List<Condicion> Condiciones { get; set; }

        public Regla()
        {
            this.Condiciones = new List<Condicion>();
        }

        /// <summary>
        /// Permite agregar una condicion a la regla
        /// </summary>
        /// <param name="condicion"></param>
        public void AgregarCondicion(Condicion condicion)
        {
            if (condicion != null)
                this.Condiciones.Add(condicion);
            else
                throw new Exception("No se puede agregar una condicion nula");
        }

        /// <summary>
        /// Define que un atuendo es valido cuando NO se cumple ninguna de las condiciones que componen la regla
        /// </summary>
        /// <param name="atuendo"></param>
        /// <returns></returns>
        public bool Validar(Atuendo atuendo)
        {
            bool valido = false;

            foreach(Condicion condicion in this.Condiciones)
            {
                if (condicion.Validar(atuendo))
                {
                    valido = true;
                }
                else
                {
                    valido = false;
                    break;
                }
            }

            if (valido) return false; // Atuendo INVALIDO
            return true; // Atuendo VALIDO
        }
    }
}
