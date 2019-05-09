using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Ar.UTN.QMP.Lib.Entidades.Prendas.Prenda;
using Ar.UTN.QMP.Lib.Entidades.Guardaropa;

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

            builder.ConAccesorio(eTipoAnteOjo.DE_SOL)
                   .AccesorioConColorPrincipal(eColor.PLATEADO)
                   .AccesorioDeMaterial(eMaterialesAnteojos.METAL)
                   .ConParteSuperior(eTipoRemera.MANGA_CORTA)
                   .ParteSuperiorConColorPrincipal(eColor.AZUL)
                   .ParteSuperiorConColorSecundario(eColor.BLANCO)
                   .ConParteInferior(eTipoPantalon.CORTO)
                   .ParteInferiorConColorPrincipal(eColor.NEGRO)
                   .ConCalzado(eTipoOjota.HAVAIANNA)
                   .CalzadoConColorPrincipal(eColor.BLANCO);

            Atuendo = builder.Atuendo;
        }
    }
}
