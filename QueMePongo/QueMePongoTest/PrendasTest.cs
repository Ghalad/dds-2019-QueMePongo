using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using System.Collections.Generic;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;
using Ar.UTN.QMP.Lib.Entidades.Guardaropa;

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

            regla.AgregarCondicion(c);

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

            regla.AgregarCondicion(c);

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

            regla.AgregarCondicion(c);

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

            regla.AgregarCondicion(c);

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
            regla.AgregarCondicion(conComp);

            List<Caracteristica> listaC = new List<Caracteristica>();
            listaC.Add(new Caracteristica("nombre", "remerA"));
            listaC.Add(new Caracteristica("material", "cuero"));
            CondicionMultiple conMultiple = new CondicionMultiple(listaC);
            regla.AgregarCondicion(conMultiple);

            Assert.IsFalse(regla.Validar(atuendo));
        }

        [TestMethod]
        public void NoPermiteDosParteSuperior()
        {
            // Creacion de condiciones

            Regla laRegla = new Regla();

            Operador cantidadSuperior = new OperadorMayor(1);
            Caracteristica caractSuperior = new Caracteristica("Categoria", "Superior");
            Condicion unaPrendaSuperior = new CondicionComparacion(cantidadSuperior, caractSuperior);

            Caracteristica caractInferior = new Caracteristica("Categoria", "Inferior");
            Condicion unaPrendaInferior = new CondicionComparacion(cantidadSuperior, caractInferior);

            Caracteristica caractCalzado = new Caracteristica("Categoria", "Calzado");
            Condicion unCalzado = new CondicionComparacion(cantidadSuperior, caractCalzado);

            laRegla.AgregarCondicion(unaPrendaSuperior);
            laRegla.AgregarCondicion(unaPrendaInferior);
            laRegla.AgregarCondicion(unCalzado);

            //************************
            //Creación de guardarropas

            Prenda prenda1 = new Prenda();
            prenda1.AgregarCaracteristica(new Caracteristica("nombre", "Remera"));
            prenda1.AgregarCaracteristica(new Caracteristica("Categoria", "Superior"));
            prenda1.AgregarCaracteristica(new Caracteristica("mangas", "Cortas"));
            prenda1.AgregarCaracteristica(new Caracteristica("color", "Azul"));

            Prenda prenda2 = new Prenda();
            prenda2.AgregarCaracteristica(new Caracteristica("nombre", "campera"));
            prenda2.AgregarCaracteristica(new Caracteristica("Categoria", "Superior"));
            prenda2.AgregarCaracteristica(new Caracteristica("tela", "cuero"));
            prenda2.AgregarCaracteristica(new Caracteristica("color", "marron"));

            Prenda prenda3 = new Prenda();
            prenda3.AgregarCaracteristica(new Caracteristica("nombre", "pantalon"));
            prenda3.AgregarCaracteristica(new Caracteristica("Categoria", "inferior"));
            prenda3.AgregarCaracteristica(new Caracteristica("tela", "jean"));

            Prenda prenda4 = new Prenda();
            prenda4.AgregarCaracteristica(new Caracteristica("nombre", "botas"));
            prenda4.AgregarCaracteristica(new Caracteristica("Categoria", "calzado"));
            prenda4.AgregarCaracteristica(new Caracteristica("tela", "goma"));

            Atuendo atuendo = new Atuendo();
            atuendo.AgregarPrenda(prenda1);
            atuendo.AgregarPrenda(prenda2);
            atuendo.AgregarPrenda(prenda3);
            atuendo.AgregarPrenda(prenda4);

            Assert.IsFalse(laRegla.Validar(atuendo));
        }


        public void asdasd()
        {

            //Guardarropa unGuardarropas = new Guardarropa();
            //unGuardarropas.agregarPrenda(prenda1);
            //unGuardarropas.agregarPrenda(prenda2);
            //unGuardarropas.agregarPrenda(prenda3);
            //unGuardarropas.agregarPrenda(prenda4);
            //Mostrar atuendos posibles

            //Assert.AreEqual(1, unGuardarropas.atuendosPosibles(laRegla));

            //Prenda prenda5 = new Prenda();
            //Caracteristica c51 = new Caracteristica("Detalle", "Botas de Cuero");
            //prenda4.AgregarCaracteristica(c51);
            //prenda4.AgregarCaracteristica(caractCalzado);
            //
            //unGuardarropas.agregarPrenda(prenda5);
            //
            //Assert.AreEqual(2, unGuardarropas.atuendosPosibles(laRegla));
        }
    }
}
