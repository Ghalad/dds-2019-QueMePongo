namespace Ar.UTN.QMP.Lib.Entidades.Prendas.PartesSuperior
{
    public class Remera : ParteSuperior
    {
        public enum TMaterial : int
        {
            SEDA,
            HILO,
            POLIESTER
        }

        public Remera(TMaterial material) : base(material)
        {
        }
    }
}
