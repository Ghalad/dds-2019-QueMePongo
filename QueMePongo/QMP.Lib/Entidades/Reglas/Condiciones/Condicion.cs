using Ar.UTN.QMP.Lib.Entidades.Atuendos;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    public interface Condicion
    {
        bool Validar(Atuendo atuendo);
    }
}
