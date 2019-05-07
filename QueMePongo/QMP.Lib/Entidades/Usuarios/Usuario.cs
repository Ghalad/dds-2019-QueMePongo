using static Ar.UTN.QMP.Lib.Entidades.Prendas.ParteSuperior;

namespace Ar.UTN.QMP.Lib.Entidades.Usuarios
{
    public class Usuario
    {
        public string User { get; set; }
        public string Pass { get; set; }

        public int TalleCalzado { get; set; }
        public int TalleParteInferior { get; set; }
        public eTalle TalleParteSuperior { get; set; }
    }
}
