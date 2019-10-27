namespace Ar.UTN.QMP.Lib.Entidades.Usuarios
{
    public class UsrPremium : Usuario
    {
        public string TarjetaCredito { get; set; }
        private UsrPremium() : base() { }
        public UsrPremium(string username) : base(0, username) { }
    }
}
