using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ar.UTN.QMP.Lib.Entidades.Prendas.PartesSuperiores;
using static Ar.UTN.QMP.Lib.Entidades.Prendas.Prenda;
using static Ar.UTN.QMP.Lib.Entidades.Prendas.ParteSuperior;
using Ar.UTN.QMP.Lib.Entidades.Guardaropa;
using Ar.UTN.QMP.Lib.Entidades.Prendas;

namespace QueMePongoTest
{
    [TestClass]
    public class PrendasTest
    {
        [TestMethod]
        public void CrearRemeraDeSeda()
        {
            Atuendo Atuendo;
            AtuendoBuilder builder = new AtuendoBuilder();

            builder.CrearAtuendo()
                   .ConAccesorio(Accesorio.Tipo.ANTEOJOS_DE_SOL)
                   .AccesorioConColorPrincipal(eColor.NEGRO)
                   .AccesorioDeMaterial(eMaterialAccesorio.METAL)
                   .ConParteSuperior(Tipo.REMERA_MANGA_CORTA)
                   .ParteSuperiorConColorPrincipal(eColor.AZUL)
                   .ParteSuperiorConColorSecundario(eColor.BLANCO);

            Atuendo = builder.getAtuedo();
        }
    }
}
