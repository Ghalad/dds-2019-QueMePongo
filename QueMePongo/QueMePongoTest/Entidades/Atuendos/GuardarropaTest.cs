using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos.Tests
{
    [TestClass]
    public class GuardarropaTest
    {
        Guardarropa guardarropa1;
        PrendaBuilder pb;

        [TestInitialize]
        public void Initialize()
        {
            this.guardarropa1 = new Guardarropa("1", 100);
            this.pb = new PrendaBuilder();
        }


        [TestMethod]
        public void GenerarAtuendosDeNPrendas()
        {
            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("remera_manga_corta")
                   .ConMaterial("algodon")
                   .ConColor("azul");
            this.guardarropa1.AgregarPrenda(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("campera_de_abrigo")
                   .ConColor("verde")
                   .ConMaterial("cuero");
            this.guardarropa1.AgregarPrenda(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .ConCategoria("inferior")
                   .ConTipo("pantalon_largo")
                   .ConMaterial("jean");
            this.guardarropa1.AgregarPrenda(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .ConCategoria("calzado")
                   .ConTipo("zapatillas_de_correr")
                   .ConMaterial("goma");
            this.guardarropa1.AgregarPrenda(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("remera_manga_larga")
                   .ConMaterial("cuero")
                   .ConColor("negro");
            this.guardarropa1.AgregarPrenda(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .ConCategoria("superior")
                   .ConTipo("campera_de_lluvia")
                   .ConColor("blanco")
                   .ConMaterial("cuero");
            this.guardarropa1.AgregarPrenda(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .ConCategoria("inferior")
                   .ConTipo("pantalon_corto")
                   .ConMaterial("jean");
            this.guardarropa1.AgregarPrenda(this.pb.ObtenerPrenda());
            this.pb.CrearPrenda()
                   .ConCategoria("calzado")
                   .ConTipo("zapato_taco_bajo")
                   .ConMaterial("goma");
            this.guardarropa1.AgregarPrenda(this.pb.ObtenerPrenda());

            //this.guardarropa1.GenerarCombinacionesDePrendas(2);

            // Formula de combinaciones
            // n! / (r!(n-r)!)
            //Assert.IsTrue(this.guardarropa1.Atuendos.Count == 28);
        }
    }
}
