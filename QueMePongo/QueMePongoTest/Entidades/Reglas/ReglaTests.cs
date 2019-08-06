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
        Atuendo atuendo;
        Regla regla;
        List<Caracteristica> listaCar;

        [TestInitialize]
        public void Initialize()
        {
            this.pb = new PrendaBuilder();
        }


        [TestMethod]
        public void ReglaParaValidarSuperposicion_1()
        {
            #region ATUENDO
            this.atuendo = new Atuendo();
            pb.CrearPrenda()
              .ConCategoria("accesorio")
              .ConTipo("gorra")
              .ConMaterial("lana")
              .ConColor("verde")
              .ConColor("negro");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_corta")
              .ConMaterial("algodon")
              .ConColor("azul")
              .ConColor("blanco");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("sweater")
              .ConMaterial("lana")
              .ConColor("negro");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("campera_de_lluvia")
              .ConMaterial("poliester")
              .ConColor("negro")
              .ConColor("azul");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pantalon_largo")
              .ConMaterial("poliester")
              .ConColor("negro");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("PANCHAS")
              .ConMaterial("lana")
              .ConColor("azul");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());
            #endregion ATUENDO

            #region REGLA
            this.regla = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "1"));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "2"));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "3"));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "4"));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));
            #endregion REGLA

            Assert.IsTrue(regla.Validar(this.atuendo));
        }

        [TestMethod]
        public void ReglaParaValidarSuperposicion_2()
        {
            #region ATUENDO
            this.atuendo = new Atuendo();
            pb.CrearPrenda()
              .ConCategoria("accesorio")
              .ConTipo("gorra")
              .ConMaterial("lana")
              .ConColor("verde")
              .ConColor("negro");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_corta")
              .ConMaterial("algodon")
              .ConColor("azul")
              .ConColor("blanco");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_larga")
              .ConMaterial("algodon")
              .ConColor("negro");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("campera_de_lluvia")
              .ConMaterial("poliester")
              .ConColor("negro")
              .ConColor("azul");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pantalon_largo")
              .ConMaterial("poliester")
              .ConColor("negro");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("PANCHAS")
              .ConMaterial("lana")
              .ConColor("azul");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());
            #endregion ATUENDO

            #region REGLA
            this.regla = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "1"));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "2"));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "3"));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "4"));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));
            #endregion REGLA

            Assert.IsFalse(this.regla.Validar(this.atuendo));
        }

        [TestMethod]
        public void ReglaParaValidarSuperposicion_3()
        {
            #region ATUENDO
            this.atuendo = new Atuendo();
            pb.CrearPrenda()
              .ConCategoria("accesorio")
              .ConTipo("gorra")
              .ConMaterial("lana")
              .ConColor("verde")
              .ConColor("negro");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_corta")
              .ConMaterial("algodon")
              .ConColor("azul")
              .ConColor("blanco");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("sweater")
              .ConMaterial("lana")
              .ConColor("negro");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("campera_de_lluvia")
              .ConMaterial("poliester")
              .ConColor("negro")
              .ConColor("azul");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("inferior")
              .ConTipo("pantalon_largo")
              .ConMaterial("poliester")
              .ConColor("negro");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("medias")
              .ConMaterial("lana")
              .ConColor("blanco");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("PANCHAS")
              .ConMaterial("lana")
              .ConColor("azul");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());
            #endregion ATUENDO

            #region REGLA
            this.regla = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "1"));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "2"));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "3"));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "4"));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "calzado"));
            this.listaCar.Add(new Caracteristica("superposicion", "1"));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "calzado"));
            this.listaCar.Add(new Caracteristica("superposicion", "2"));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));
            #endregion REGLA

            Assert.IsTrue(regla.Validar(this.atuendo));
        }

        [TestMethod]
        public void ReglaParaValidarAtuendoInvalido_1()
        {
            #region ATUENDO
            this.atuendo = new Atuendo();
            this.pb.CrearPrenda()
                   .ConCategoria("inferior")
                   .ConTipo("pantalon_corto");
            this.atuendo.Prendas.Add(this.pb.ObtenerPrenda());

            this.pb.CrearPrenda()
                   .ConCategoria("calzado")
                   .ConTipo("zapato_taco_bajo");
            this.atuendo.Prendas.Add(this.pb.ObtenerPrenda());

            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("remera_manga_corta")
                   .ConMaterial("cuero");
            this.atuendo.Prendas.Add(this.pb.ObtenerPrenda());
            #endregion ATUENDO

            #region REGLA
            this.regla = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("tipo", "remera_manga_corta"));
            this.listaCar.Add(new Caracteristica("material", "cuero"));
            this.regla.AgregarCondicion(new CondicionNegativa(this.listaCar));
            #endregion REGLA

            Assert.IsFalse(this.regla.Validar(this.atuendo));
        }

        [TestMethod]
        public void ReglaParaValidarAtuendoSinCalzado()
        {
            #region ATUENDO
            this.atuendo = new Atuendo();
            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("remera_manga_corta")
                   .ConMaterial("algodon");
            this.atuendo.Prendas.Add(this.pb.ObtenerPrenda());
            #endregion ATUENDO

            #region REGLA
            this.regla = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "calzado"));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorIgual(0), listaCar));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));
            #endregion REGLA

            Assert.IsFalse(this.regla.Validar(this.atuendo));
        }

        [TestMethod]
        public void ReglaParaValidarAtuendoConMasDeUnCalzado()
        {
            #region ATUENDO
            this.atuendo = new Atuendo();
            this.pb.CrearPrenda()
                   .ConCategoria("inferior")
                   .ConTipo("pantalon_corto");
            this.atuendo.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .ConCategoria("calzado")
                   .ConTipo("zapato_taco_bajo");
            this.atuendo.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("remera_manga_corta")
                   .ConMaterial("cuero");
            this.atuendo.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .ConCategoria("calzado")
                   .ConTipo("PANCHAS")
                   .ConMaterial("lana");
            this.atuendo.Prendas.Add(this.pb.ObtenerPrenda());
            #endregion ATUENDO

            #region REGLA
            this.regla = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "calzado"));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorIgual(0), listaCar));
            this.regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));
            #endregion REGLA

            Assert.IsFalse(this.regla.Validar(this.atuendo));
        }
    }
}