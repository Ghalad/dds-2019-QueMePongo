using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos.Tests
{
    [TestClass()]
    public class AtuendoTests
    {
        Prenda prenda1, prenda2;
        Atuendo atuendo1;

        [TestInitialize]
        public void Initialize()
        {
            this.prenda1 = new Prenda();
            this.prenda2 = new Prenda();
            this.atuendo1 = new Atuendo();
        }


        [TestMethod()]
        public void TienenLaMismaPrenda()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            this.prenda2.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            this.atuendo1.AgregarPrenda(this.prenda1);
            this.atuendo1.AgregarPrenda(this.prenda2);
            Assert.IsTrue(this.atuendo1.TienePrenda(this.prenda2));
            Assert.IsTrue(this.atuendo1.TienePrenda(this.prenda1)); // ESTE ESTA MAL
        }

        [TestMethod()]
        public void NoTienenLaMismaPrenda()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            this.prenda2.AgregarCaracteristica(new Caracteristica("categoria", "inferior"));
            this.atuendo1.AgregarPrenda(this.prenda1);
            Assert.IsFalse(this.atuendo1.TienePrenda(this.prenda2));
        }

        [TestMethod()]
        public void NoAgregaRepetidos()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            this.prenda2.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            this.atuendo1.AgregarPrenda(this.prenda1);
            this.atuendo1.AgregarPrenda(this.prenda2);
            Assert.IsTrue(this.atuendo1.Prendas.Count == 1);
        }

        [TestMethod()]
        public void AgregarDosPrendas()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            this.prenda2.AgregarCaracteristica(new Caracteristica("categoria", "inferior"));
            this.atuendo1.AgregarPrenda(this.prenda1);
            this.atuendo1.AgregarPrenda(this.prenda2);
            Assert.IsTrue(this.atuendo1.Prendas.Count == 2);
        }
    }
}