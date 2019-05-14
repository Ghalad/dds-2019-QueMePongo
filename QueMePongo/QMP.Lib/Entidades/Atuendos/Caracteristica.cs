namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Caracteristica
    {
        public string Nombre { get; set; }
        public string Valor { get; set; }

        public Caracteristica(string nombre, string valor)
        {
            this.Nombre = nombre.ToUpper();
            this.Valor = valor.ToUpper();
        }

        public bool EsLaMisma(Caracteristica caracteristica)
        {
            if (this.Nombre.Equals(caracteristica.Nombre) && this.Valor.Equals(caracteristica.Valor))
                return true;
            return false;
        }

        public void mostrar()
        {
            //mostrar por pantalla Nombre
        }

    }
}
