using System;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Caracteristica
    {
        private string Clave { get; set; }
        public string Valor { get; private set; }

        public Caracteristica(string clave, string valor)
        {
            if(!string.IsNullOrWhiteSpace(clave) || !string.IsNullOrWhiteSpace(valor))
            {
                this.Clave = clave.ToUpper();
                this.Valor = valor.ToUpper();
            }
            else
            {
                throw new Exception("No se puede instanciar una caracteristica con clave o valor nulos.");
            }
        }

        public bool EsLaMisma(Caracteristica caracteristica)
        {
            if (this.Clave.Equals(caracteristica.Clave) && this.Valor.Equals(caracteristica.Valor))
                return true;
            return false;
        }

        public bool EsLaMisma(string clave, string valor)
        {
            if (!string.IsNullOrWhiteSpace(clave) || !string.IsNullOrWhiteSpace(valor))
                if (this.Clave.Equals(clave.ToUpper()) && this.Valor.Equals(valor.ToUpper()))
                    return true;
            return false;
        }

        public bool EsLaMismaClave(string clave)
        {
            if (!string.IsNullOrWhiteSpace(clave))
                if (this.Clave.Equals(clave.ToUpper()))
                    return true;
            return false;
        }
    }
}
