using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using System.Collections.Generic;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;
using Ar.UTN.QMP.Lib.Entidades.Guardaropa;
using System.Linq;
using System;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;

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

            Assert.IsFalse(regla.Validar(atuendo));
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

            Assert.IsFalse(regla.Validar(atuendo));
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

            Assert.IsFalse(regla.Validar(atuendo));
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

            Assert.IsFalse(regla.Validar(atuendo));
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

            Assert.IsTrue(regla.Validar(atuendo));
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


        [TestMethod]
        public void GenerarAtuendosDeNPrendas()
        {
            Prenda p1 = new Prenda();
            p1.AgregarCaracteristica(new Caracteristica("nombre", "Remera1"));
            p1.AgregarCaracteristica(new Caracteristica("Categoria", "Superior"));
            p1.AgregarCaracteristica(new Caracteristica("mangas", "Cortas"));
            p1.AgregarCaracteristica(new Caracteristica("color", "Azul"));

            Prenda p2 = new Prenda();
            p2.AgregarCaracteristica(new Caracteristica("nombre", "campera1"));
            p2.AgregarCaracteristica(new Caracteristica("Categoria", "Superior"));
            p2.AgregarCaracteristica(new Caracteristica("tela", "cuero"));
            p2.AgregarCaracteristica(new Caracteristica("color", "marron"));

            Prenda p3 = new Prenda();
            p3.AgregarCaracteristica(new Caracteristica("nombre", "pantalon1"));
            p3.AgregarCaracteristica(new Caracteristica("Categoria", "inferior"));
            p3.AgregarCaracteristica(new Caracteristica("tela", "jean"));

            Prenda p4 = new Prenda();
            p4.AgregarCaracteristica(new Caracteristica("nombre", "botas1"));
            p4.AgregarCaracteristica(new Caracteristica("Categoria", "calzado"));
            p4.AgregarCaracteristica(new Caracteristica("tela", "goma"));

            Prenda p5 = new Prenda();
            p5.AgregarCaracteristica(new Caracteristica("nombre", "Remera2"));
            p5.AgregarCaracteristica(new Caracteristica("Categoria", "Superior"));
            p5.AgregarCaracteristica(new Caracteristica("mangas", "Cortas"));
            p5.AgregarCaracteristica(new Caracteristica("color", "Azul"));

            Prenda p6 = new Prenda();
            p6.AgregarCaracteristica(new Caracteristica("nombre", "campera2"));
            p6.AgregarCaracteristica(new Caracteristica("Categoria", "Superior"));
            p6.AgregarCaracteristica(new Caracteristica("tela", "cuero"));
            p6.AgregarCaracteristica(new Caracteristica("color", "marron"));

            Prenda p7 = new Prenda();
            p7.AgregarCaracteristica(new Caracteristica("nombre", "pantalon2"));
            p7.AgregarCaracteristica(new Caracteristica("Categoria", "inferior"));
            p7.AgregarCaracteristica(new Caracteristica("tela", "jean"));

            Prenda p8 = new Prenda();
            p8.AgregarCaracteristica(new Caracteristica("nombre", "botas2"));
            p8.AgregarCaracteristica(new Caracteristica("Categoria", "calzado"));
            p8.AgregarCaracteristica(new Caracteristica("tela", "goma"));

            Guardarropa g = new Guardarropa("123");
            g.Prendas.Add(p1);
            g.Prendas.Add(p2);
            g.Prendas.Add(p3);
            g.Prendas.Add(p4);
            g.Prendas.Add(p5);
            g.Prendas.Add(p6);
            g.Prendas.Add(p7);
            g.Prendas.Add(p8);

            g.GenerarCombinacionesDePrendas(2);

            // Formula de combinaciones
            // n! / (r!(n-r)!)
            Assert.IsTrue(g.Atuendos.Count == 28);
        }

        [TestMethod]
        public void CrearPrendaIncorrecta()
        {
            Usuario usr = new Usuario();

            usr.CrearGuardarropa("123");
            try
            {
                usr.CrearPrenda("123", Tipos.TCategoria.CALZADO, Tipos.TTipoSuperior.REMERA_MANGA_CORTA, Tipos.TMateriales.ALGODON, Tipos.TColores.AZUL, Tipos.TColores.BLANCO);
            }
            catch
            {

            }

            Assert.IsTrue(usr.Guardarropas[0].Prendas.Count == 0);
        }

        [TestMethod]
        public void CrearPrendaCorrecta()
        {
            Usuario usr = new Usuario();

            usr.CrearGuardarropa("123");
            try
            {
                usr.CrearPrenda("123", Tipos.TCategoria.PARTE_SUPERIOR, Tipos.TTipoSuperior.REMERA_MANGA_CORTA, Tipos.TMateriales.ALGODON, Tipos.TColores.AZUL, Tipos.TColores.BLANCO);
            }
            catch
            {

            }

            Assert.IsTrue(usr.Guardarropas[0].Prendas.Count == 1);
        }

        [TestMethod]
        public void ObtenerSugerenciasDesdeVariosGuardarropas()
        {
            Usuario usr = new Usuario();
            bool match = false;

            usr.CrearGuardarropa("1");
            usr.CrearGuardarropa("2");
            try
            {
                usr.CrearPrenda("1", Tipos.TCategoria.PARTE_SUPERIOR, Tipos.TTipoSuperior.REMERA_MANGA_CORTA, Tipos.TMateriales.ALGODON, Tipos.TColores.AZUL, Tipos.TColores.BLANCO);
                usr.CrearPrenda("1", Tipos.TCategoria.PARTE_INFERIOR, Tipos.TTipoInferior.PANTALON_CORTO, Tipos.TMateriales.CUERO, Tipos.TColores.VERDE);
                usr.CrearPrenda("1", Tipos.TCategoria.CALZADO, Tipos.TTipoCalzado.ZAPATILLA_OUTDOOR, Tipos.TMateriales.CUERO, Tipos.TColores.AZUL, Tipos.TColores.NEGRO);
                usr.CrearPrenda("1", Tipos.TCategoria.CALZADO, Tipos.TTipoCalzado.ZAPATO_MOCASIN, Tipos.TMateriales.CUERO, Tipos.TColores.NEGRO);

                usr.CrearPrenda("2", Tipos.TCategoria.PARTE_SUPERIOR, Tipos.TTipoSuperior.REMERA_MANGA_CORTA, Tipos.TMateriales.ALGODON, Tipos.TColores.AZUL, Tipos.TColores.BLANCO);
                usr.CrearPrenda("2", Tipos.TCategoria.PARTE_SUPERIOR, Tipos.TTipoSuperior.REMERA_MANGA_LARGA, Tipos.TMateriales.CUERO, Tipos.TColores.AZUL, Tipos.TColores.BLANCO);
                usr.CrearPrenda("2", Tipos.TCategoria.PARTE_SUPERIOR, Tipos.TTipoInferior.PANTALON_CORTO, Tipos.TMateriales.JEAN, Tipos.TColores.AZUL, Tipos.TColores.BLANCO);
                usr.CrearPrenda("2", Tipos.TCategoria.PARTE_SUPERIOR, Tipos.TTipoInferior.POLLERA, Tipos.TMateriales.JEAN, Tipos.TColores.AZUL, Tipos.TColores.BLANCO);
            }catch{}

            usr.Guardarropas[0].GenerarCombinacionesDePrendas(4);
            usr.Guardarropas[1].GenerarCombinacionesDePrendas(4);
            Atuendo a1 = usr.ObtenerAtuendo("1");
            Atuendo a2 = usr.ObtenerAtuendo("2");

            foreach (Prenda p in a1.Prendas)
            {
                //if
            }
                
        }
    }
}
