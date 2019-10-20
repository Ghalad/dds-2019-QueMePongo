namespace Ar.UTN.QMP.Lib.Entidades.Usuarios
{
    public class UsrGratis : Usuario
    {
        private UsrGratis() : base() { }
        public UsrGratis(int maximo, string username) : base(maximo, username) { }
    }
}
