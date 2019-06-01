using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Guardaropa.Tests
{
    [TestClass]
    public class GuardarropaTest
    {
        Prenda prenda1, prenda2, prenda3, prenda4, prenda5, prenda6, prenda7, prenda8;
        Atuendo atuendo1;
        Regla regla1;
        List<Caracteristica> listaCar;
        Guardarropa guardarropa1;

        [TestInitialize]
        public void Initialize()
        {
            this.prenda1 = new Prenda();
            this.prenda2 = new Prenda();
            this.prenda3 = new Prenda();
            this.prenda4 = new Prenda();
            this.prenda5 = new Prenda();
            this.prenda6 = new Prenda();
            this.prenda7 = new Prenda();
            this.prenda8 = new Prenda();
            this.atuendo1 = new Atuendo();
            this.regla1 = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.guardarropa1 = new Guardarropa("1");
        }

        [TestMethod]
        public void NoPermiteRemeraDeCueroUnaPrenda()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("nombre", "remera"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("material", "cuero"));

            this.atuendo1.Prendas.Add(this.prenda1);

            this.listaCar.Add(new Caracteristica("nombre", "remerA"));
            this.listaCar.Add(new Caracteristica("material", "cuero"));

            CondicionMultiple c = new CondicionMultiple(this.listaCar);

            this.regla1.AgregarCondicion(c);

            Assert.IsFalse(this.regla1.Validar(this.atuendo1));
        }

        [TestMethod]
        public void NoPermiteRemeraDeCueroMuchasPrendas()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("nombre", "pantalon"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "parte_inferior"));
            this.atuendo1.Prendas.Add(this.prenda1);

            this.prenda1 = new Prenda();
            this.prenda1.AgregarCaracteristica(new Caracteristica("nombre", "zapato"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "calzado"));
            this.atuendo1.Prendas.Add(this.prenda1);

            this.prenda1 = new Prenda();
            this.prenda1.AgregarCaracteristica(new Caracteristica("nombre", "remera"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "parte_superior"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("material", "cuero"));
            this.atuendo1.Prendas.Add(this.prenda1);

            this.listaCar.Add(new Caracteristica("nombre", "remerA"));
            this.listaCar.Add(new Caracteristica("material", "cuero"));

            CondicionMultiple c = new CondicionMultiple(this.listaCar);

            this.regla1.AgregarCondicion(c);

            Assert.IsFalse(this.regla1.Validar(this.atuendo1));
        }

        [TestMethod]
        public void NoPermiteAtuendoSinCalzado()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("nombre", "remera"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("material", "algodon"));
            this.atuendo1.Prendas.Add(this.prenda1);

            CondicionComparacion c = new CondicionComparacion(new OperadorIgual(0), new Caracteristica("categoria", "calzado"));

            this.regla1.AgregarCondicion(c);

            Assert.IsFalse(this.regla1.Validar(this.atuendo1));
        }

        [TestMethod]
        public void NoPermiteAtuendosConMasDeUnCalzado()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("nombre", "remera"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("material", "algodon"));
            this.atuendo1.Prendas.Add(this.prenda1);
            this.prenda1 = new Prenda();
            this.prenda1.AgregarCaracteristica(new Caracteristica("nombre", "zapatillas"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "calzado"));
            this.atuendo1.Prendas.Add(this.prenda1);
            this.prenda1 = new Prenda();
            this.prenda1.AgregarCaracteristica(new Caracteristica("nombre", "pantalon"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("color", "azul"));
            this.atuendo1.Prendas.Add(this.prenda1);
            this.prenda1 = new Prenda();
            this.prenda1.AgregarCaracteristica(new Caracteristica("nombre", "ojotas"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "calzado"));
            this.atuendo1.Prendas.Add(this.prenda1);

            CondicionComparacion c = new CondicionComparacion(new OperadorMayor(1), new Caracteristica("categoria", "calzado"));

            this.regla1.AgregarCondicion(c);

            Assert.IsFalse(this.regla1.Validar(this.atuendo1));
        }

        [TestMethod]
        public void AtuendoValido()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("nombre", "remera"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("material", "algodon"));
            this.atuendo1.Prendas.Add(this.prenda1);
            this.prenda1 = new Prenda();
            this.prenda1.AgregarCaracteristica(new Caracteristica("nombre", "zapatillas"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("categoria", "calzado"));
            this.atuendo1.Prendas.Add(this.prenda1);
            this.prenda1 = new Prenda();
            this.prenda1.AgregarCaracteristica(new Caracteristica("nombre", "pantalon"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("color", "azul"));
            this.atuendo1.Prendas.Add(this.prenda1);

            this.regla1.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), new Caracteristica("categoria", "calzado")));

            this.listaCar.Add(new Caracteristica("nombre", "remerA"));
            this.listaCar.Add(new Caracteristica("material", "cuero"));
            this.regla1.AgregarCondicion(new CondicionMultiple(this.listaCar));

            Assert.IsTrue(this.regla1.Validar(this.atuendo1));
        }

        [TestMethod]
        public void NoPermiteDosParteSuperior()
        {
            // Creacion de condiciones
            Operador operador = new OperadorMayor(1);
            Condicion unaPrendaSuperior = new CondicionComparacion(operador, new Caracteristica("Categoria", "Superior"));
            Condicion unaPrendaInferior = new CondicionComparacion(operador, new Caracteristica("Categoria", "Inferior"));
            Condicion unCalzado = new CondicionComparacion(operador, new Caracteristica("Categoria", "Calzado"));

            this.regla1.AgregarCondicion(unaPrendaSuperior);
            this.regla1.AgregarCondicion(unaPrendaInferior);
            this.regla1.AgregarCondicion(unCalzado);

            //Creación de guardarropas
            this.prenda1.AgregarCaracteristica(new Caracteristica("nombre", "Remera"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("Categoria", "Superior"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("mangas", "Cortas"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("color", "Azul"));

            this.prenda2.AgregarCaracteristica(new Caracteristica("nombre", "campera"));
            this.prenda2.AgregarCaracteristica(new Caracteristica("Categoria", "Superior"));
            this.prenda2.AgregarCaracteristica(new Caracteristica("tela", "cuero"));
            this.prenda2.AgregarCaracteristica(new Caracteristica("color", "marron"));

            this.prenda3.AgregarCaracteristica(new Caracteristica("nombre", "pantalon"));
            this.prenda3.AgregarCaracteristica(new Caracteristica("Categoria", "inferior"));
            this.prenda3.AgregarCaracteristica(new Caracteristica("tela", "jean"));

            this.prenda4.AgregarCaracteristica(new Caracteristica("nombre", "botas"));
            this.prenda4.AgregarCaracteristica(new Caracteristica("Categoria", "calzado"));
            this.prenda4.AgregarCaracteristica(new Caracteristica("tela", "goma"));

            this.atuendo1.AgregarPrenda(this.prenda1);
            this.atuendo1.AgregarPrenda(this.prenda2);
            this.atuendo1.AgregarPrenda(this.prenda3);
            this.atuendo1.AgregarPrenda(this.prenda4);

            Assert.IsFalse(this.regla1.Validar(this.atuendo1));
        }


        [TestMethod]
        public void GenerarAtuendosDeNPrendas()
        {
            this.prenda1.AgregarCaracteristica(new Caracteristica("nombre", "Remera1"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("Categoria", "Superior"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("mangas", "Cortas"));
            this.prenda1.AgregarCaracteristica(new Caracteristica("color", "Azul"));

            this.prenda2.AgregarCaracteristica(new Caracteristica("nombre", "campera1"));
            this.prenda2.AgregarCaracteristica(new Caracteristica("Categoria", "Superior"));
            this.prenda2.AgregarCaracteristica(new Caracteristica("tela", "cuero"));
            this.prenda2.AgregarCaracteristica(new Caracteristica("color", "marron"));

            this.prenda3.AgregarCaracteristica(new Caracteristica("nombre", "pantalon1"));
            this.prenda3.AgregarCaracteristica(new Caracteristica("Categoria", "inferior"));
            this.prenda3.AgregarCaracteristica(new Caracteristica("tela", "jean"));

            this.prenda4.AgregarCaracteristica(new Caracteristica("nombre", "botas1"));
            this.prenda4.AgregarCaracteristica(new Caracteristica("Categoria", "calzado"));
            this.prenda4.AgregarCaracteristica(new Caracteristica("tela", "goma"));

            this.prenda5.AgregarCaracteristica(new Caracteristica("nombre", "Remera2"));
            this.prenda5.AgregarCaracteristica(new Caracteristica("Categoria", "Superior"));
            this.prenda5.AgregarCaracteristica(new Caracteristica("mangas", "Cortas"));
            this.prenda5.AgregarCaracteristica(new Caracteristica("color", "Azul"));

            this.prenda6.AgregarCaracteristica(new Caracteristica("nombre", "campera2"));
            this.prenda6.AgregarCaracteristica(new Caracteristica("Categoria", "Superior"));
            this.prenda6.AgregarCaracteristica(new Caracteristica("tela", "cuero"));
            this.prenda6.AgregarCaracteristica(new Caracteristica("color", "marron"));

            this.prenda7.AgregarCaracteristica(new Caracteristica("nombre", "pantalon2"));
            this.prenda7.AgregarCaracteristica(new Caracteristica("Categoria", "inferior"));
            this.prenda7.AgregarCaracteristica(new Caracteristica("tela", "jean"));

            this.prenda8.AgregarCaracteristica(new Caracteristica("nombre", "botas2"));
            this.prenda8.AgregarCaracteristica(new Caracteristica("Categoria", "calzado"));
            this.prenda8.AgregarCaracteristica(new Caracteristica("tela", "goma"));

            this.guardarropa1.Prendas.Add(this.prenda1);
            this.guardarropa1.Prendas.Add(this.prenda2);
            this.guardarropa1.Prendas.Add(this.prenda3);
            this.guardarropa1.Prendas.Add(this.prenda4);
            this.guardarropa1.Prendas.Add(this.prenda5);
            this.guardarropa1.Prendas.Add(this.prenda6);
            this.guardarropa1.Prendas.Add(this.prenda7);
            this.guardarropa1.Prendas.Add(this.prenda8);

            this.guardarropa1.GenerarCombinacionesDePrendas(2);

            // Formula de combinaciones
            // n! / (r!(n-r)!)
            Assert.IsTrue(this.guardarropa1.Atuendos.Count == 28);
        }
    }
}
