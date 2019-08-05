using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;

namespace Ar.UTN.QMP.Lib.Entidades.Usuarios.Tests
{
    [TestClass()]
    public class UsuarioTests
    {
        Atuendo atuendo1;
        Regla regla1;
        List<Caracteristica> listaCar;
        PrendaBuilder pb;
        Usuario usr;

        [TestInitialize]
        public void Initialize()
        {
            this.atuendo1 = new Atuendo();
            this.regla1 = new Regla("R1");
            this.listaCar = new List<Caracteristica>();
            this.pb = new PrendaBuilder();
            this.usr = new UsrPremium();
        }

        [TestMethod()]
        public void VariosGuardarropasSinCompartirPrendas1()
        {
            /*this.usr.CrearGuardarropa("g1");
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("tipo", "remera_manga_corta")
                   .AgregarCaracteristica("material", "cuero");
            this.usr.AgregarPrenda("g1", this.pb.ObtenerPrenda());


            this.usr.CrearGuardarropa("g2");
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("tipo", "remera_manga_larga")
                   .AgregarCaracteristica("material", "cuero");
            this.usr.AgregarPrenda("g2", this.pb.ObtenerPrenda());

            this.usr.Guardarropas[0].GenerarCombinacionesDePrendas(1);
            this.usr.Guardarropas[1].GenerarCombinacionesDePrendas(1);

            //Assert.IsFalse(this.usr.ObtenerAtuendo("g1").EsElMismo(this.usr.ObtenerAtuendo("g2")));
            */
        }

        [TestMethod()]
        public void VariosGuardarropasSinCompartirPrendas2()
        {
            /*
            this.usr.CrearGuardarropa("g1");
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("tipo", "remera_manga_corta")
                   .AgregarCaracteristica("material", "cuero");
            this.usr.AgregarPrenda("g1", this.pb.ObtenerPrenda());


            this.usr.CrearGuardarropa("g2");
            this.pb.CrearPrenda()
                   .AgregarCaracteristica("Categoria", "superior")
                   .AgregarCaracteristica("tipo", "remera_manga_corta")
                   .AgregarCaracteristica("material", "cuero");
            this.usr.AgregarPrenda("g2", this.pb.ObtenerPrenda());

            this.usr.Guardarropas[0].GenerarCombinacionesDePrendas(1);
            this.usr.Guardarropas[1].GenerarCombinacionesDePrendas(1);

            //Assert.IsTrue(this.usr.ObtenerAtuendo("g1").EsElMismo(this.usr.ObtenerAtuendo("g2")));
            */
        }
    }
}