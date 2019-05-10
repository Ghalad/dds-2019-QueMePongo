using Ar.UTN.QMP.Lib.Entidades.Atuendos;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    public interface Regla
    {
        bool Validar(Atuendo atuendo);
    }
}
