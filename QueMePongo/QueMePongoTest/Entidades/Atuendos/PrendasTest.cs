using Ar.UTN.QMP.Lib.Entidades.Contexto;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos.Tests
{
    [TestClass]
    public class PrendasTest
    {
        Prenda p1, p2;

        [TestInitialize]
        public void Initialize()
        {
            this.p1 = new Prenda();
            this.p2 = new Prenda();
        }

        [TestMethod]
        public void TieneCaracteristica1()
        {
            this.p1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            Assert.IsTrue(this.p1.TieneCaracteristica(new Caracteristica("categoria", "superior")));
        }

        [TestMethod]
        public void TieneCaracteristica2()
        {
            this.p1.AgregarCaracteristica("categoria", "superior");
            Assert.IsTrue(this.p1.TieneCaracteristica("categoria", "superior"));
        }

        [TestMethod]
        public void TieneCaracteristica3()
        {
            this.p1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            Assert.IsTrue(this.p1.TieneCaracteristica("categoria"));
        }

        [TestMethod]
        public void NoTieneCaracteristica1()
        {
            this.p1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            Assert.IsFalse(this.p1.TieneCaracteristica(new Caracteristica("material", "hilo")));
        }

        [TestMethod]
        public void NoTieneCaracteristica2()
        {
            this.p1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            Assert.IsFalse(this.p1.TieneCaracteristica("material", "hilo"));
        }

        [TestMethod]
        public void NoTieneCaracteristica3()
        {
            this.p1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            Assert.IsFalse(this.p1.TieneCaracteristica("material"));
        }

        [TestMethod]
        public void CantidadDeCaracteristicas()
        {
            this.p1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            this.p1.AgregarCaracteristica(new Caracteristica("tipo", "remera"));
            this.p1.AgregarCaracteristica(new Caracteristica("material", "cuero"));
            this.p1.AgregarCaracteristica(new Caracteristica("color", "azul"));
            
            Assert.IsTrue(this.p1.CantidadDeCaracteristicas() == 4);
        }

        [TestMethod]
        public void NoAgregaCaracteristicaRepetida1()
        {
            this.p1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            this.p1.AgregarCaracteristica(new Caracteristica("tipo", "remera"));
            this.p1.AgregarCaracteristica(new Caracteristica("material", "cuero"));
            this.p1.AgregarCaracteristica(new Caracteristica("color", "azul"));
            this.p1.AgregarCaracteristica(new Caracteristica("material", "cuero")); // NO AGREGAGA REPETIDOS

            Assert.IsTrue(this.p1.CantidadDeCaracteristicas() == 4);
        }

        [TestMethod]
        public void NoAgregaCaracteristicaRepetida2()
        {
            this.p1.AgregarCaracteristica(new Caracteristica("categoria", "superior"));
            this.p1.AgregarCaracteristica(new Caracteristica("tipo", "remera"));
            this.p1.AgregarCaracteristica(new Caracteristica("material", "cuero"));
            this.p1.AgregarCaracteristica(new Caracteristica("color", "azul"));
            this.p1.AgregarCaracteristica("material", "cuero"); // NO AGREGA REPETIDOS

            Assert.IsTrue(this.p1.CantidadDeCaracteristicas() == 4);
        }







        [TestMethod]
        public void DB_PersistirGuardarropa()
        {
            Prenda p;
            PrendaBuilder pb = new PrendaBuilder();
            Guardarropa g;

            try
            {
                // genero la prenda
                pb.CrearPrenda()
                  .ConCategoria("superior")
                  .ConTipo("remera_manga_larga")
                  .ConMaterial("hilo")
                  .ConColor("blanco")
                  .ConColor("azul");

                p = pb.ObtenerPrenda();

                using (QueMePongoDB db = new QueMePongoDB())
                {
                    g = new Guardarropa(10);
                    // Asigno la prenda al guardarropa
                    g.AgregarPrenda(p);

                    // agrego el guardarropa a la base, marca todos los objetos con estado ADDED
                    db.Guardarropas.Add(g);

                    // Marco las caracteristicas (que ya estaban en la base) con estdo UNCHANGED
                    foreach(Caracteristica c in g.Prendas.FirstOrDefault().Caracteristicas)
                        db.Entry(c).State = System.Data.Entity.EntityState.Unchanged;
                    
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod]
        public void DB_CargarGuardarropa()
        {
            Guardarropa g1;

            try
            {
                using (QueMePongoDB db = new QueMePongoDB())
                {
                    // Cargo el guardarropa
                    g1 = db.Guardarropas.Find(1);

                    // Cargo las prendas relacionadas al guardarropa
                    db.Entry(g1).Collection(g => g.Prendas).Load();

                    // Cargo cada caracteristica relacionada a las prendas del guardarropa
                    foreach(var p in g1.Prendas)
                        db.Entry(p).Collection(p1 => p1.Caracteristicas).Load();
                }
            }
            catch(Exception ex)
            {

            }
        }

        [TestMethod]
        public void DB_PersistirUsuarioGuardarropas()
        {
            Usuario u;
            Guardarropa g;

            try
            {
                using (QueMePongoDB db = new QueMePongoDB())
                {
                    u = new UsrPremium("Guido");
                    g = new Guardarropa(2);
                    u.AgregarGuardarropa(g);

                    db.Usuarios.Add(u);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
