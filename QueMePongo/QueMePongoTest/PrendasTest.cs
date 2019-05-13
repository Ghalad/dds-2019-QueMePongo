using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using System.Collections.Generic;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;

namespace Ar.UTN.QMP.Test
{
    [TestClass]
    public class PrendasTest
    {
        [TestMethod]
        public void NoPermiteRemeraDeCueroUnaPrenda()
        {
            Prenda prenda = new Prenda();
            prenda.AgregarCaracteristica(new Caracteristica("nombre", "remera"));
            prenda.AgregarCaracteristica(new Caracteristica("material", "cuero"));

            Atuendo atuendo = new Atuendo();
            atuendo.Prendas.Add(prenda);

            Regla regla = new Regla();

            List<Caracteristica> listaC = new List<Caracteristica>();
            listaC.Add(new Caracteristica("nombre", "remerA"));
            listaC.Add(new Caracteristica("material", "cuero"));

            CondicionMultiple c = new CondicionMultiple(listaC);

            regla.Condiciones.Add(c);

            Assert.IsTrue(regla.Validar(atuendo));
        }

        [TestMethod]
        public void NoPermiteRemeraDeCueroMuchasPrendas()
        {
            Atuendo atuendo = new Atuendo();

            Prenda prenda = new Prenda();
            prenda.AgregarCaracteristica(new Caracteristica("nombre", "pantalon"));
            prenda.AgregarCaracteristica(new Caracteristica("categoria", "parte_inferior"));
            atuendo.Prendas.Add(prenda);

            prenda = new Prenda();
            prenda.AgregarCaracteristica(new Caracteristica("nombre", "zapato"));
            prenda.AgregarCaracteristica(new Caracteristica("categoria", "calzado"));
            atuendo.Prendas.Add(prenda);

            prenda = new Prenda();
            prenda.AgregarCaracteristica(new Caracteristica("nombre", "remera"));
            prenda.AgregarCaracteristica(new Caracteristica("categoria", "parte_superior"));
            prenda.AgregarCaracteristica(new Caracteristica("material", "cuero"));
            atuendo.Prendas.Add(prenda);

            Regla regla = new Regla();

            List<Caracteristica> listaC = new List<Caracteristica>();
            listaC.Add(new Caracteristica("nombre", "remerA"));
            listaC.Add(new Caracteristica("material", "cuero"));

            CondicionMultiple c = new CondicionMultiple(listaC);

            regla.Condiciones.Add(c);

            Assert.IsTrue(regla.Validar(atuendo));
        }

        [TestMethod]
        public void NoPermiteAtuendoSinCalzado()
        {
            Prenda prenda = new Prenda();
            prenda.AgregarCaracteristica(new Caracteristica("nombre", "remera"));
            prenda.AgregarCaracteristica(new Caracteristica("material", "algodon"));

            Atuendo atuendo = new Atuendo();
            atuendo.Prendas.Add(prenda);

            Regla regla = new Regla();
            CondicionComparacion c = new CondicionComparacion(new OperadorIgual(0), new Caracteristica("categoria", "calzado"));

            regla.Condiciones.Add(c);

            Assert.IsTrue(regla.Validar(atuendo));
        }

        [TestMethod]
        public void NoPermiteAtuendosConMasDeUnCalzado()
        {
            Atuendo atuendo = new Atuendo();
            Prenda prenda = new Prenda();
            prenda.AgregarCaracteristica(new Caracteristica("nombre", "remera"));
            prenda.AgregarCaracteristica(new Caracteristica("material", "algodon"));
            atuendo.Prendas.Add(prenda);
            prenda = new Prenda();
            prenda.AgregarCaracteristica(new Caracteristica("nombre", "zapatillas"));
            prenda.AgregarCaracteristica(new Caracteristica("categoria", "calzado"));
            atuendo.Prendas.Add(prenda);
            prenda = new Prenda();
            prenda.AgregarCaracteristica(new Caracteristica("nombre", "pantalon"));
            prenda.AgregarCaracteristica(new Caracteristica("color", "azul"));
            atuendo.Prendas.Add(prenda);
            prenda = new Prenda();
            prenda.AgregarCaracteristica(new Caracteristica("nombre", "ojotas"));
            prenda.AgregarCaracteristica(new Caracteristica("categoria", "calzado"));
            atuendo.Prendas.Add(prenda);


            Regla regla = new Regla();
            CondicionComparacion c = new CondicionComparacion(new OperadorMayor(1), new Caracteristica("categoria", "calzado"));

            regla.Condiciones.Add(c);

            Assert.IsTrue(regla.Validar(atuendo));
        }

        [TestMethod]
        public void AtuendoValido()
        {
            Atuendo atuendo = new Atuendo();
            Prenda prenda = new Prenda();
            prenda.AgregarCaracteristica(new Caracteristica("nombre", "remera"));
            prenda.AgregarCaracteristica(new Caracteristica("material", "algodon"));
            atuendo.Prendas.Add(prenda);
            prenda = new Prenda();
            prenda.AgregarCaracteristica(new Caracteristica("nombre", "zapatillas"));
            prenda.AgregarCaracteristica(new Caracteristica("categoria", "calzado"));
            atuendo.Prendas.Add(prenda);
            prenda = new Prenda();
            prenda.AgregarCaracteristica(new Caracteristica("nombre", "pantalon"));
            prenda.AgregarCaracteristica(new Caracteristica("color", "azul"));
            atuendo.Prendas.Add(prenda);


            Regla regla = new Regla();
            CondicionComparacion conComp = new CondicionComparacion(new OperadorMayor(1), new Caracteristica("categoria", "calzado"));
            regla.Condiciones.Add(conComp);

            List<Caracteristica> listaC = new List<Caracteristica>();
            listaC.Add(new Caracteristica("nombre", "remerA"));
            listaC.Add(new Caracteristica("material", "cuero"));
            CondicionMultiple conMultiple = new CondicionMultiple(listaC);
            regla.Condiciones.Add(conMultiple);

            Assert.IsFalse(regla.Validar(atuendo));
        }
    }
}
