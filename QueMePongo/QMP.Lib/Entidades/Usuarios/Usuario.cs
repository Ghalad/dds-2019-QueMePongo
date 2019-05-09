using static Ar.UTN.QMP.Lib.Entidades.Prendas.Prenda;

namespace Ar.UTN.QMP.Lib.Entidades.Usuarios
{
    public class Usuario
    {
        public string User { get; set; }
        public string Pass { get; set; }

        public eTalleCalzado TalleCalzado { get; set; }
        public eTalleParteInferior TalleParteInferior { get; set; }
        public eTalleParteSuperior TalleParteSuperior { get; set; }
    }
}
