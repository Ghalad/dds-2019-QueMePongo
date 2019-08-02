using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas.Tests
{
    [TestClass()]
    public class ReglaTests
    {
        PrendaBuilder pb;
        Atuendo a1, a2, a3, a4;
        Regla r1,r2, r3, r4;
        List<Caracteristica> listaCar;

        [TestInitialize]
        public void Initialize()
        {
            this.pb = new PrendaBuilder();

            #region ATUENDO_1
            this.a1 = new Atuendo();
            pb.CrearPrenda()
              .ConCategoria("accesorio")
              .ConTipo("gorra")
              .ConMaterial("lana")
              .ConColor("verde")
              .ConColor("negro");
            this.a1.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_corta")
              .ConMaterial("algodon")
              .ConColor("azul")
              .ConColor("blanco");
            this.a1.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("sweater")
              .ConMaterial("lana")
              .ConColor("negro");
            this.a1.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("campera_de_lluvia")
              .ConMaterial("poliester")
              .ConColor("negro")
              .ConColor("azul");
            this.a1.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pantalon_largo")
              .ConMaterial("poliester")
              .ConColor("negro");
            this.a1.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("slip_on")
              .ConMaterial("lana")
              .ConColor("azul");
            this.a1.AgregarPrenda(pb.ObtenerPrenda());
            #endregion ATUENDO_1

            #region ATUENDO_2
            this.a2 = new Atuendo();
            pb.CrearPrenda()
              .ConCategoria("accesorio")
              .ConTipo("gorra")
              .ConMaterial("lana")
              .ConColor("verde")
              .ConColor("negro");
            this.a2.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_corta")
              .ConMaterial("algodon")
              .ConColor("azul")
              .ConColor("blanco");
            this.a2.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_larga")
              .ConMaterial("algodon")
              .ConColor("negro");
            this.a2.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("campera_de_lluvia")
              .ConMaterial("poliester")
              .ConColor("negro")
              .ConColor("azul");
            this.a2.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pantalon_largo")
              .ConMaterial("poliester")
              .ConColor("negro");
            this.a2.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("slip_on")
              .ConMaterial("lana")
              .ConColor("azul");
            this.a2.AgregarPrenda(pb.ObtenerPrenda());
            #endregion ATUENDO_2

            #region ATUENDO_3
            this.a3 = new Atuendo();
            this.pb.CrearPrenda()
                   .ConCategoria("inferior")
                   .ConTipo("pantalon_corto");
            this.a3.Prendas.Add(this.pb.ObtenerPrenda());

            this.pb.CrearPrenda()
                   .ConCategoria("calzado")
                   .ConTipo("zapato_taco_bajo");
            this.a3.Prendas.Add(this.pb.ObtenerPrenda());

            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("remera_manga_corta")
                   .ConMaterial("cuero");
            this.a3.Prendas.Add(this.pb.ObtenerPrenda());
            #endregion ATUENDO_3

            #region ATUENDO_4
            this.a4 = new Atuendo();
            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("remera_manga_corta")
                   .ConMaterial("algodon");
            this.a4.Prendas.Add(this.pb.ObtenerPrenda());
            #endregion ATUENDO_4

            #region REGLA_1
            this.r1 = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "1"));
            this.r1.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "2"));
            this.r1.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "3"));
            this.r1.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "4"));
            this.r1.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));
            #endregion REGLA_1

            #region REGLA_2
            this.r2 = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("tipo", "remera_manga_corta"));
            this.listaCar.Add(new Caracteristica("material", "cuero"));
            this.r2.AgregarCondicion(new CondicionMultiple(this.listaCar));
            #endregion REGLA_2

            #region REGLA_3
            this.r3 = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "calzado"));
            this.r3.AgregarCondicion(new CondicionComparacion(new OperadorIgual(0), listaCar));
            this.r3.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));
            #endregion REGLA_3
        }


        [TestMethod()]
        public void ReglaParaValidarSuperposicion_1()
        {
            Assert.IsTrue(r1.Validar(this.a1));
        }

        [TestMethod()]
        public void ReglaParaValidarSuperposicion_2()
        {
            Assert.IsFalse(r1.Validar(this.a2));
        }

        [TestMethod()]
        public void ReglaParaValidarAtuendoInvalido_1()
        {
            Assert.IsFalse(this.r2.Validar(this.a3));
        }

        [TestMethod()]
        public void ReglaParaValidarAtuendoSinCalzado()
        {
            Assert.IsFalse(this.r3.Validar(this.a4));
        }

        [TestMethod()]
        public void ReglaParaValidarAtuendoConMasDeUnCalzado()
        {
            this.pb.CrearPrenda()
                   .ConCategoria("calzado")
                   .ConTipo("slip_on")
                   .ConMaterial("lana");
            this.a3.Prendas.Add(this.pb.ObtenerPrenda());
            Assert.IsFalse(this.r3.Validar(this.a4));
        }
    }
}