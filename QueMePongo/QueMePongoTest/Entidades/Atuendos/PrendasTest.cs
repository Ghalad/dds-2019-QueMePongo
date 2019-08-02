using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos.Tests
{
    [TestClass]
    public class PrendasTest
    {
        Prenda prenda1, prenda2;

        [TestInitialize]
        public void Initialize()
        {
            this.prenda1 = new Prenda();
            this.prenda2 = new Prenda();
        }

        [TestMethod]
        public void TieneCaracteristica1()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            Assert.IsTrue(this.prenda1.TieneCaracteristica(new Caracteristica("categoria", "superior")));
        }

        [TestMethod]
        public void TieneCaracteristica2()
        {
            this.prenda1.AgregarCaracteristica("categoria", "superior");
            Assert.IsTrue(this.prenda1.TieneCaracteristica("categoria", "superior"));
        }

        [TestMethod]
        public void TieneCaracteristica3()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            Assert.IsTrue(this.prenda1.TieneCaracteristica("categoria"));
        }

        [TestMethod]
        public void NoTieneCaracteristica1()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            Assert.IsFalse(this.prenda1.TieneCaracteristica(new Caracteristica("material", "hilo")));
        }

        [TestMethod]
        public void NoTieneCaracteristica2()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            Assert.IsFalse(this.prenda1.TieneCaracteristica("material", "hilo"));
        }

        [TestMethod]
        public void NoTieneCaracteristica3()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            Assert.IsFalse(this.prenda1.TieneCaracteristica("material"));
        }

        [TestMethod]
        public void CantidadDeCaracteristicas()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("tipo", "remera"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("material", "cuero"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("color", "azul"));
            
            Assert.IsTrue(this.prenda1.CantidadDeCaracteristicas() == 4);
        }

        [TestMethod]
        public void NoAgregaCaracteristicaRepetida1()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("tipo", "remera"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("material", "cuero"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("color", "azul"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("material", "cuero")); // NO AGREGAGA REPETIDOS

            Assert.IsTrue(this.prenda1.CantidadDeCaracteristicas() == 4);
        }

        [TestMethod]
        public void NoAgregaCaracteristicaRepetida2()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("tipo", "remera"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("material", "cuero"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("color", "azul"));
            this.prenda1.AgregarCaracteristica("material", "cuero"); // NO AGREGAGA REPETIDOS

            Assert.IsTrue(this.prenda1.CantidadDeCaracteristicas() == 4);
        }

        [TestMethod]
        public void TieneLaMismaCaracteristica()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            this.prenda2.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            Assert.IsTrue(this.prenda1.EsLaMisma(this.prenda2));
        }

        [TestMethod]
        public void NoTieneLaMismaCaracteristica()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            this.prenda2.AgregarCaracteristica(new Caracteristica("categoria", "inferior"));
            Assert.IsFalse(this.prenda1.EsLaMisma(this.prenda2));
        }
    }
}
