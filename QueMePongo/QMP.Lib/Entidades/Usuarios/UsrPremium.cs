namespace Ar.UTN.QMP.Lib.Entidades.Usuarios
{
    public class UsrPremium : Usuario
    {
        public UsrPremium(string username) : base(0, username)
        {
        }

        private UsrPremium() : base() { }
    }
}
