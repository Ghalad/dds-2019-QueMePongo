namespace Ar.UTN.QMP.Lib.Entidades.Prendas
{
    public abstract class Prenda
    {
        #region TIPOS
        #region TIPOS_ACCESORIOS
        public enum eTipoSombrero
        {
            SOMBRERO,
            GORRO,
            BOINA
        }
        public enum eTipoAnteOjo
        {
            DE_SOL,
            DE_VER
        }
        public enum eTipoPañuelo
        {
            GRUESO,
            FINO
        }
        #endregion TIPOS_ACCESORIOS

        #region TIPOS_PARTESUPERIOR
        public enum eTipoRemera
        {
            MANGA_CORTA,
            MANGA_LARGA,
            MUSCULOSA
        }
        public enum eTipoCampera
        {
            ROMPE_VIENTO,
            ABRIGO,
            IMPERMEABLE
        }
        public enum eTipoCamisa
        {
            MANGA_CORTA,
            MANGA_LARGA
        }
        #endregion TIPOS_PARTESUPERIOR

        #region TIPOS_PARTEINFERIOR
        public enum eTipoPantalon
        {
            LARGO,
            CORTO
        }
        public enum eTipoPollera
        {
            LARGA,
            CORTA
        }
        #endregion TIPOS_PARTEINFERIOR

        #region TIPOS_CALZADOS
        public enum eTipoZapato
        {
            TACO_ALTO,
            TACO_AGUJA,
            PUNTA_AGUDA,
            PUNTA_REDONDA
        }
        public enum eTipoZapatilla
        {
            CORRER,
            PANCHAS,
            TREKKING
        }
        public enum eTipoOjota
        {
            HAVAIANNA,
            CROCK
        }
        #endregion TIPOS_CALZADOS
        #endregion TIPOS

        #region ATRIBUTOS
        #region COLORES
        public enum eColor
        {
            BLANCO,
            NEGRO,
            PLATEADO,
            AZUL,
            ROJO,
            VERDE,
            AMARILLO
        }
        #endregion COLORES

        #region ESTAMPADOS
        public enum eEstampados
        {
            MICKEY,
            IRONMAN,
            BATMAN
        }
        #endregion ESTAMPADOS

        #region TALLES
        public enum eTalleParteSuperior
        {
            XS, S, M, L, XL
        }
        public enum eTalleParteInferior
        {
            TALLE_38,
            TALLE_40,
            TALLE_42,
            TALLE_44,
            TALLE_46,
            TALLE_48
        }
        public enum eTalleCalzado
        {
            TALLE_36,
            TALLE_37,
            TALLE_38,
            TALLE_39,
            TALLE_40,
            TALLE_41,
            TALLE_42,
            TALLE_43,
            TALLE_44,
            TALLE_45
        }
        #endregion TALLES

        #region MATERIALES
        #region MATERIALES_PARTE_SUPERIOR
        public enum eMaterialesRemera
        {
            ALGODON,
            LYCRA
        }
        public enum eMaterialesCampera
        {
            CUERO,
            CORDEROY
        }
        public enum eMaterialesCamisa
        {
            SEDA,
            POLIESTER,
            ALGODON
        }
        #endregion MATERIALES_PARTE_SUPERIOR

        #region MATERIALES_PARTE_INFERIOR
        public enum eMaterialesPantalon
        {
            JEAN,
            NYLON
        }
        public enum eMaterialesPollera
        {
            JEAN,
            NYLON
        }
        #endregion MATERIALES_PARTE_INFERIOR

        #region MATERIALES_CALZADO
        public enum eMaterialesZapato
        {
            CUERO
        }
        public enum eMaterialesZapatilla
        {
            CUERO,
            GOMA,
            TELA
        }
        public enum eMaterialesOjota
        {
            GOMA
        }
        #endregion MATERIALES_CALZADO

        #region MATERIALES_ACCESORIO
        public enum eMaterialesSombrero
        {
            CUERO,
            TELA
        }
        public enum eMaterialesAnteojos
        {
            METAL,
            PLASTICO
        }
        public enum eMaterialesPañuelos
        {
            HILO,
            SEDA
        }
        #endregion MATERIALES_ACCESORIO
        #endregion MATERIALES
        #endregion ATRIBUTOS

        public bool EsFavorita { get; set; }
        public string EsRegaloPor { get; set; }
        public eColor ColorPrincipal { get; set; }
        public eColor ColorSecundario { get; set; }
    }
}
