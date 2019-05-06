using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ar.UTN.QMP.Lib.Entidades.Prendas.PartesSuperior;
using Ar.UTN.QMP.Lib.Entidades.Guardaropa;

namespace QueMePongoTest
{
    [TestClass]
    public class PrendasTest
    {
        [TestMethod]
        public void CrearRemeraDeSeda()
        {
            Remera r = new Remera(Remera.TMaterial.SEDA);
            Caracteristica c = new Caracteristica(Remera.TMaterial.SEDA, null);

            Assert.IsTrue(r.TieneCaracteristica(c));
        }

        [TestMethod]
        public void CrearRemeraDistintoDeSeda()
        {
            Remera r = new Remera(Remera.TMaterial.HILO);
            Caracteristica c = new Caracteristica(Remera.TMaterial.SEDA, null);

            Assert.IsFalse(r.TieneCaracteristica(c));
        }
    }
}
