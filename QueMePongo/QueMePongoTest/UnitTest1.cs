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
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod2()
        {
            //************************
            // Creacion de condiciones

            Regla laRegla = new Regla();
            List<Caracteristica> cCaracteristicas = new List<Caracteristica>();
            Caracteristica caractSuperior = new Caracteristica("Categoría", "Superior");
            Caracteristica caractInferior = new Caracteristica("Categoría", "Inferior");
            Caracteristica caractCalzado = new Caracteristica("Categoría", "Calzado");
            cCaracteristicas.Add(caractSuperior);
            cCaracteristicas.Add(caractInferior);
            cCaracteristicas.Add(caractCalzado);
            Condicion alMenosUna = new CondicionTodasEstan(cCaracteristicas);

            laRegla.agregarCondicion(alMenosUna);

            //************************
            //Creación de guardarropas

            Prenda prenda1 = new Prenda();
            Caracteristica c11 = new Caracteristica("Detalle", "Remera Mangas Cortas Azul");
            prenda1.AgregarCaracteristica(c11);
            prenda1.AgregarCaracteristica(caractSuperior);

            Prenda prenda2 = new Prenda();
            Caracteristica c21 = new Caracteristica("Detalle", "Campera de cuero");
            prenda2.AgregarCaracteristica(c21);
            prenda2.AgregarCaracteristica(caractSuperior);

            Prenda prenda3 = new Prenda();
            Caracteristica c31 = new Caracteristica("Detalle", "Pantalon de Jean");
            prenda3.AgregarCaracteristica(c31);
            prenda3.AgregarCaracteristica(caractInferior);

            Prenda prenda4 = new Prenda();
            Caracteristica c41 = new Caracteristica("Detalle", "Botas de Goma");
            prenda4.AgregarCaracteristica(c41);
            prenda4.AgregarCaracteristica(caractCalzado);

            GuardaRopa unGuardarropas = new GuardaRopa();
            unGuardarropas.agregarPrenda(prenda1);
            unGuardarropas.agregarPrenda(prenda2);
            unGuardarropas.agregarPrenda(prenda3);
            unGuardarropas.agregarPrenda(prenda4);

            //Mostrar atuendos posibles

            unGuardarropas.atuendosPosibles(laRegla);
            Assert.AreEqual(1, unGuardarropas.atuendosPosibles(laRegla));

            Prenda prenda5 = new Prenda();
            Caracteristica c51 = new Caracteristica("Detalle", "Botas de Cuero");
            prenda4.AgregarCaracteristica(c51);
            prenda4.AgregarCaracteristica(caractCalzado);

            unGuardarropas.agregarPrenda(prenda5);

            Assert.AreEqual(2, unGuardarropas.atuendosPosibles(laRegla));



        }
    }
}
