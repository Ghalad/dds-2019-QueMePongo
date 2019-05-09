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
    }
}
