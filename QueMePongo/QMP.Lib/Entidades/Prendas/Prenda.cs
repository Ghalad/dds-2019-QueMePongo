namespace Ar.UTN.QMP.Lib.Entidades.Prendas
{
    public abstract class Prenda
    {
        public enum eColor
        {
            BLANCO,
            NEGRO,
            AZUL,
            VERDE,
            ROJO
        }

        public enum eTelaFina
        {
            ALGODON,
            SEDA
        }

        public enum eTelaGruesa
        {
            CORDEROI,
            CUERO,
            JEAN
        }

        public enum eEstampado
        {
            MICKEY,
            DONALD,
            POWER_RANGER
        }

        public enum eMaterialAccesorio
        {
            METAL,
            PLASTICO,
            TELA
        }

        public enum eMaterialCalzado
        {
            PLASTICO,
            TELA,
            CUERO
        }

        public bool EsFavorita { get; set; }
        public bool EsRegalo { get; set; }
        public eColor ColorPrincipal { get; set; }
        public eColor ColorSecundario { get; set; }

        public Prenda()
        {
            this.EsFavorita = false;
            this.EsRegalo = false;
        }
    }
}
