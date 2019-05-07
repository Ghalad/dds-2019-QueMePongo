namespace Ar.UTN.QMP.Lib.Entidades.Prendas
{
    public abstract class ParteInferior : Prenda
    {
        public enum Tipo
        {
            PANTALON,
            SHORT
        }

        public int Talle { get; set; }
        public eTelaGruesa Tela { get; set; }
    }
}
