namespace Ar.UTN.QMP.Lib.Entidades.Prendas
{
    public abstract class Accesorio : Prenda
    {
        public enum Tipo
        {
            ANTEOJOS_DE_SOL,
            PAÑUELO
        }

        public eMaterialAccesorio Material { get; set; }

        public Accesorio()
        {
        }
    }
}
