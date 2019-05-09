using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;

namespace Ar.UTN.QMP.Test
{
    [TestClass]
    public class PrendasTest
    {
        [TestMethod]
        public void NoPermiteRemeraDeCuero()
        {
            Prenda prenda = new Prenda();
            prenda.AgregarCaracteristica(new Caracteristica("nombre", "remera"));
            prenda.AgregarCaracteristica(new Caracteristica("material", "cuero"));

            Regla regla = new Regla();
            regla.Condiciones.Add(new CondicionAfirmativa(new Caracteristica("nombre", "remerA")));
            regla.Condiciones.Add(new CondicionNegativa(new Caracteristica("material", "cuero")));

            Assert.IsFalse(regla.Validar(prenda));
        }
    }
}
