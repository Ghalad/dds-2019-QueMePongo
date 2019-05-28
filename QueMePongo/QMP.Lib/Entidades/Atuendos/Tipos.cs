namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Tipos
    {
        public enum TCategoria
        {
            ACCESORIO,
            PARTE_SUPERIOR,
            PARTE_INFERIOR,
            CALZADO
        }

        public enum TTipoAccesorio
        {
            GORRO,
            ARO
        }
        public enum TTipoSuperior
        {
            REMERA_MANGA_CORTA,
            REMERA_MANGA_LARGA,
            CAMPERA_DE_ABRIGO,
            CAMPERA_IMPERMEABLE
        }
        public enum TTipoInferior
        {
            PANTALON_CORTO,
            PANTALON_LARGO,
            POLLERA
        }
        public enum TTipoCalzado
        {
            ZAPATILLA_RUNNING,
            ZAPATILLA_OUTDOOR,
            ZAPATO_MOCASIN,
            ZAPATO_OXFORD
        }


        public enum TMateriales
        {
            ALGODON,
            CUERO,
            HILO,
            CORDEROY,
            JEAN
        }

        public enum TColores
        {
            NEGRO,
            BLANCO,
            ROJO,
            VERDE,
            AZUL,
        }
    }
}
