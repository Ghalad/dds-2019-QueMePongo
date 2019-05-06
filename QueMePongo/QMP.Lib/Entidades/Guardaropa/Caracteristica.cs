namespace Ar.UTN.QMP.Lib.Entidades.Guardaropa
{
    public class Caracteristica
    {
        public int Valor { get; set; }
        public int? Magnitud { get; set; }

        public Caracteristica(object valor, int? magnitud)
        {
            this.Valor    = (int)valor;
            this.Magnitud = magnitud;
        }
    }
}
