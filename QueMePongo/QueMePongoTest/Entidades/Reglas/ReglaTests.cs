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
        List<Regla> reglas;

        [TestInitialize]
        public void Initialize()
        {
            this.pb = new PrendaBuilder();
            this.reglas = new List<Regla>();
        }


        [TestMethod]
        public void ReglaParaValidarSuperposicion_1()
        {
            /************************************************************************************
             * Valida que un atuendo no tenga mas de una prenda por cada nivel de superposicion
             ************************************************************************************/
            #region ATUENDO
            this.atuendo = new Atuendo();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("remera_manga_corta")
              .ConMaterial("algodon")
              .ConColor("blanco");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("sweater")
              .ConMaterial("algodon")
              .ConColor("azul");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("sweater")
              .ConMaterial("algodon")
              .ConColor("azul");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());
            #endregion ATUENDO

            #region REGLA
            this.regla = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "1"));
            this.regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            this.reglas.Add(regla);

            this.regla = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "2"));
            this.regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            this.reglas.Add(regla);

            this.regla = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "3"));
            this.regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            this.reglas.Add(regla);

            this.regla = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "4"));
            this.regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            this.reglas.Add(regla);
            #endregion REGLA

            bool resultado = true;

            foreach (Regla r in this.reglas)
            {
                resultado = r.Validar(this.atuendo);
                if (!resultado) break;
            }

             Assert.IsFalse(resultado); // el atuendo es INVALIDO
        }

        [TestMethod]
        public void ReglaParaValidarSuperposicion_2()
        {
            /************************************************************************************
             * Valida que un atuendo no tenga mas de una prenda por cada nivel de superposicion
             ************************************************************************************/
            #region ATUENDO
            this.atuendo = new Atuendo();
            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("medias")
              .ConMaterial("lana")
              .ConColor("blanco");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());

            pb.CrearPrenda()
              .ConCategoria("calzado")
              .ConTipo("medias")
              .ConMaterial("lana")
              .ConColor("azul");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());
            #endregion ATUENDO

            #region REGLA
            this.regla = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "calzado"));
            this.listaCar.Add(new Caracteristica("superposicion", "1"));
            this.regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            this.reglas.Add(regla);

            this.regla = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "calzado"));
            this.listaCar.Add(new Caracteristica("superposicion", "2"));
            this.regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            this.reglas.Add(regla);
            #endregion REGLA

            bool resultado = true;

            foreach (Regla r in this.reglas)
            {
                resultado = r.Validar(this.atuendo);
                if (!resultado) break;
            }

            Assert.IsFalse(resultado); // el atuendo es INVALIDO
        }

        [TestMethod]
        public void ReglaParaValidarSuperposicion_3()
        {
            /************************************************************************************
             * Si un atuendo posee una prenda de superposicion 4 sin una de 3, es invalido
             ************************************************************************************/
            #region ATUENDO
            this.atuendo = new Atuendo();

            pb.CrearPrenda()
              .ConCategoria("superior")
              .ConTipo("campera_de_lluvia")
              .ConMaterial("poliester")
              .ConColor("negro");
            this.atuendo.AgregarPrenda(pb.ObtenerPrenda());
            #endregion ATUENDO

            #region REGLA
            this.regla = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "1"));
            this.regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "superior"));
            this.listaCar.Add(new Caracteristica("superposicion", "4"));
            this.regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(0), listaCar));
            this.reglas.Add(this.regla);
            #endregion REGLA

            bool resultado = true;

            foreach (Regla r in this.reglas)
            {
                resultado = r.Validar(this.atuendo);
                if (!resultado) break;
            }

            Assert.IsFalse(resultado); // el atuendo es INVALIDO
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
            this.reglas.Add(this.regla);
            #endregion REGLA

            bool resultado = true;

            foreach (Regla r in this.reglas)
            {
                resultado = r.Validar(this.atuendo);
                if (!resultado) break;
            }

            Assert.IsFalse(resultado); // el atuendo es INVALIDO
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

            // Caso 1: sin calzado

            // Caso 2: con 2 calzados
            /*
            this.pb.CrearPrenda()
                   .ConCategoria("calzado")
                   .ConTipo("ojotas")
                   .ConMaterial("goma");
            this.atuendo.Prendas.Add(this.pb.ObtenerPrenda());

            this.pb.CrearPrenda()
                   .ConCategoria("calzado")
                   .ConTipo("ojotas")
                   .ConMaterial("goma");
            this.atuendo.Prendas.Add(this.pb.ObtenerPrenda());
             */
            #endregion ATUENDO

            #region REGLA
            this.regla = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "calzado"));
            this.regla.AgregarCondicion(new CondicionCantidad(new OperadorIgual(0), listaCar));
            this.reglas.Add(this.regla);

            this.regla = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.listaCar.Add(new Caracteristica("categoria", "calzado"));
            this.regla.AgregarCondicion(new CondicionCantidad(new OperadorMayor(1), listaCar));
            this.reglas.Add(this.regla);
            #endregion REGLA

            bool resultado = true;

            foreach (Regla r in this.reglas)
            {
                resultado = r.Validar(this.atuendo);
                if (!resultado) break;
            }

            Assert.IsFalse(resultado); // el atuendo es INVALIDO
        }
    }
}