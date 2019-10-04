namespace Ar.UTN.QMP.Lib.Entidades.Usuarios
{
    public class UsrGratis : Usuario
    {
        public UsrGratis(int maximo, string username) : base(maximo, username)
        {
        }
        private UsrGratis() : base() { }
    }
}
