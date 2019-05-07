
namespace Ar.UTN.QMP.Lib.Entidades.Prendas
{
    public abstract class Calzado : Prenda
    {
        public enum Tipo
        {
            ZAPATO,
            CROCKS
        }

        public int Talle { get; set; }
        public eMaterialCalzado Material { get; set; }
    }
}
