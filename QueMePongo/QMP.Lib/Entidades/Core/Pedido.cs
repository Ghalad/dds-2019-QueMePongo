using Ar.UTN.QMP.Lib.Entidades.Usuarios;

namespace Ar.UTN.QMP.Lib.Entidades.Core
{
    public class Pedido
    {
        public string Id { get; set; }
        private Usuario Usuario { get; set; }

        public Pedido(Usuario usr, string id)
        {
            this.Usuario = usr;
            this.Id = id;
        }
    }
}
