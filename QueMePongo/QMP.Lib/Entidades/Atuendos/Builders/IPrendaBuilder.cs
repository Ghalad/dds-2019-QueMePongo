using static Ar.UTN.QMP.Lib.Entidades.Atuendos.Tipos;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos.Builders
{
    public interface IPrendaBuilder
    {
        IPrendaBuilder CrearPrenda();
        IPrendaBuilder DeTipo(string tipo);
        IPrendaBuilder DeMaterial(string material);
        IPrendaBuilder DeColorPrimario(string color);
        IPrendaBuilder DeColorSecundario(string color);
        Prenda ObtenerPrenda();
    }
}
