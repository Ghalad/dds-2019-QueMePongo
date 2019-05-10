using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;

namespace Ar.UTN.QMP.Test
{
    [TestClass]
    public class PrendasTest
    {
        [TestMethod]
        public void NoPermiteRemeraDeCuero()
        {
            Prenda prenda = new Prenda();
            prenda.AgregarCaracteristica(new Caracteristica("nombre", "remera"));
            prenda.AgregarCaracteristica(new Caracteristica("material", "cuero"));

            ReglaExistencia regla = new ReglaExistencia();
            regla.AgregarCondicion(new Condicion(new Caracteristica("nombre", "remerA")));
            regla.AgregarCondicion(new Condicion(new Caracteristica("material", "cuero")));

            Atuendo atuendo = new Atuendo();
            atuendo.Prendas.Add(prenda);

            Assert.IsFalse(regla.Validar(atuendo));
        }
    }
}
