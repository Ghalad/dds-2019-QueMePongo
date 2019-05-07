using Ar.UTN.QMP.Lib.Entidades.Prendas;

namespace Ar.UTN.QMP.Lib.Entidades.Guardaropa
{
    public class Atuendo
    {
        public bool Usada { get; set; }
        public Accesorio Accesorio { get; set; }
        public ParteSuperior ParteSuperior { get; set; }
        public ParteInferior ParteInferior { get; set; }
        public Calzado Calzado { get; set; }
        

        public Atuendo()
        {
            this.Usada = false;
        }
    }
}
