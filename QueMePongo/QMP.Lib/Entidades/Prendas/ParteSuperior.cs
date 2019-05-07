namespace Ar.UTN.QMP.Lib.Entidades.Prendas
{
    public abstract class ParteSuperior : Prenda
    {
        public enum Tipo
        {
            REMERA_MANGA_CORTA,
            REMERA_MANGA_LARGA,
            CAMPERA_ROMPE_VIENTO,
            CAMPERA_DE_ABRIGO
        }

        public enum eTalle
        {
            XS, S, M, L, XL
        }

        public eTalle Talle { get; set; }

    }
}
