namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Caracteristica
    {
        private string Clave { get; set; }
        private string Valor { get; set; }

        public Caracteristica(string clave, string valor)
        {
            this.Clave = clave.ToUpper();
            this.Valor = valor.ToUpper();
        }

        public bool EsLaMisma(Caracteristica caracteristica)
        {
            if (this.Clave.Equals(caracteristica.Clave) && this.Valor.Equals(caracteristica.Valor))
                return true;
            return false;
        }

        public bool EsLaMisma(string clave, string valor)
        {
            if (this.Clave.Equals(clave) && this.Valor.Equals(valor))
                return true;
            return false;
        }

        public bool EsMismaClave(string clave)
        {
            if (this.Clave.Equals(clave))
                return true;
            return false;
        }
    }
}
