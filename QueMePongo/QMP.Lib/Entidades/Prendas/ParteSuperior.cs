using Ar.UTN.QMP.Lib.Entidades.Guardaropa;

namespace Ar.UTN.QMP.Lib.Entidades.Prendas
{
    public abstract class ParteSuperior : Prenda
    {
        public ParteSuperior(object material)
        {
            this.AgregarCaracteristicas(new Caracteristica(material, null));
        }
    }
}
