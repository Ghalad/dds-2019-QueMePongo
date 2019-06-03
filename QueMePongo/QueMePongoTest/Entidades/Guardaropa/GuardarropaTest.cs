﻿using Ar.UTN.QMP.Lib.Entidades.Atuendos;
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
        Atuendo atuendo1;
        Regla regla1;
        List<Caracteristica> listaCar;
        Guardarropa guardarropa1;
        PrendaBuilder pb;

        [TestInitialize]
        public void Initialize()
        {
            this.atuendo1 = new Atuendo();
            this.regla1 = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.guardarropa1 = new Guardarropa("1");
            this.pb = new PrendaBuilder();
        }

        [TestMethod]
        public void NoPermiteRemeraDeCueroUnaPrenda()
        {
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "remera_manga_corta")
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("material", "cuero");
            this.atuendo1.Prendas.Add(this.pb.ObtenerPrenda());

            this.listaCar.Add(new Caracteristica("tipo", "remera_manga_corta"));
            this.listaCar.Add(new Caracteristica("material", "cuero"));

            CondicionMultiple c = new CondicionMultiple(this.listaCar);

            this.regla1.AgregarCondicion(c);

            Assert.IsFalse(this.regla1.Validar(this.atuendo1));
        }

        [TestMethod]
        public void NoPermiteRemeraDeCueroMuchasPrendas()
        {
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "pantalon_corto")
                   .AgregarCaracteristica("Categoria", "inferior");
            this.atuendo1.Prendas.Add(this.pb.ObtenerPrenda());
            
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "zapato_taco_bajo")
                   .AgregarCaracteristica("Categoria", "calzado");
            this.atuendo1.Prendas.Add(this.pb.ObtenerPrenda());

            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "remera_manga_corta")
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("material", "cuero");
            this.atuendo1.Prendas.Add(this.pb.ObtenerPrenda());

            this.listaCar.Add(new Caracteristica("tipo", "remera_manga_corta"));
            this.listaCar.Add(new Caracteristica("material", "cuero"));

            CondicionMultiple c = new CondicionMultiple(this.listaCar);

            this.regla1.AgregarCondicion(c);

            Assert.IsFalse(this.regla1.Validar(this.atuendo1));
        }

        [TestMethod]
        public void NoPermiteAtuendoSinCalzado()
        {
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "remera_manga_corta")
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("material", "algodon");
            this.atuendo1.Prendas.Add(this.pb.ObtenerPrenda());

            CondicionComparacion c = new CondicionComparacion(new OperadorIgual(0), new Caracteristica("categoria", "calzado"));

            this.regla1.AgregarCondicion(c);

            Assert.IsFalse(this.regla1.Validar(this.atuendo1));
        }

        [TestMethod]
        public void NoPermiteAtuendosConMasDeUnCalzado()
        {
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "remera_manga_corta")
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("material", "algodon");
            this.atuendo1.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "zapatillas_de_correr")
                   .AgregarCaracteristica("Categoria", "calzado")
                   .AgregarCaracteristica("material", "cuero");
            this.atuendo1.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "pantalon_largo")
                   .AgregarCaracteristica("Categoria", "inferior")
                   .AgregarCaracteristica("color", "azul");
            this.atuendo1.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "ojotas")
                   .AgregarCaracteristica("Categoria", "calzado")
                   .AgregarCaracteristica("material", "goma");
            this.atuendo1.Prendas.Add(this.pb.ObtenerPrenda());

            CondicionComparacion c = new CondicionComparacion(new OperadorMayor(1), new Caracteristica("categoria", "calzado"));

            this.regla1.AgregarCondicion(c);

            Assert.IsFalse(this.regla1.Validar(this.atuendo1));
        }

        [TestMethod]
        public void AtuendoValido()
        {
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "remera_manga_corta")
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("material", "algodon");
            this.atuendo1.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "zapatillas_de_correr")
                   .AgregarCaracteristica("Categoria", "calzado")
                   .AgregarCaracteristica("material", "cuero");
            this.atuendo1.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "pantalon_largo")
                   .AgregarCaracteristica("Categoria", "inferior")
                   .AgregarCaracteristica("color", "azul");
            this.atuendo1.Prendas.Add(this.pb.ObtenerPrenda());

            this.regla1.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), new Caracteristica("categoria", "calzado")));

            this.listaCar.Add(new Caracteristica("nombre", "remera_manga_corta"));
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
            
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "remera_manga_corta")
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("material", "algodon");
            this.atuendo1.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "campera_de_abrigo")
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("color", "verde")
                   .AgregarCaracteristica("material", "cuero");
            this.atuendo1.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "pantalon_largo")
                   .AgregarCaracteristica("Categoria", "inferior")
                   .AgregarCaracteristica("material", "jean");
            this.atuendo1.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "zapatillas_de_correr")
                   .AgregarCaracteristica("Categoria", "calzado")
                   .AgregarCaracteristica("material", "goma");
            this.atuendo1.Prendas.Add(this.pb.ObtenerPrenda());

            Assert.IsFalse(this.regla1.Validar(this.atuendo1));
        }


        [TestMethod]
        public void GenerarAtuendosDeNPrendas()
        {
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "remera_manga_corta")
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("material", "algodon")
                   .AgregarCaracteristica("color","azul");
            this.guardarropa1.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "campera_de_abrigo")
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("color", "verde")
                   .AgregarCaracteristica("material", "cuero");
            this.guardarropa1.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "pantalon_largo")
                   .AgregarCaracteristica("Categoria", "inferior")
                   .AgregarCaracteristica("material", "jean");
            this.guardarropa1.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "zapatillas_de_correr")
                   .AgregarCaracteristica("Categoria", "calzado")
                   .AgregarCaracteristica("material", "goma");
            this.guardarropa1.Prendas.Add(this.pb.ObtenerPrenda());

            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "remera_manga_larga")
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("material", "cuero")
                   .AgregarCaracteristica("color", "negro");
            this.guardarropa1.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "campera_de_lluvia")
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("color", "blanco")
                   .AgregarCaracteristica("material", "cuero");
            this.guardarropa1.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "pantalon_corto")
                   .AgregarCaracteristica("Categoria", "inferior")
                   .AgregarCaracteristica("material", "jean");
            this.guardarropa1.Prendas.Add(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("tipo", "zapato_taco_bajo")
                   .AgregarCaracteristica("Categoria", "calzado")
                   .AgregarCaracteristica("material", "goma");
            this.guardarropa1.Prendas.Add(this.pb.ObtenerPrenda());

            this.guardarropa1.GenerarCombinacionesDePrendas(2);

            // Formula de combinaciones
            // n! / (r!(n-r)!)
            Assert.IsTrue(this.guardarropa1.Atuendos.Count == 28);
        }
    }
}
