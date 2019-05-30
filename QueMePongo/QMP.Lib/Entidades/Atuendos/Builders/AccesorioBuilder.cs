using Ar.UTN.QMP.Lib.Entidades.Atuendos.Caracteristicas;
using static Ar.UTN.QMP.Lib.Entidades.Atuendos.Tipos;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos.Builders
{
    public class AccesorioBuilder
    {
        private Prenda prenda { get; set; }

        public AccesorioBuilder CrearPrenda()
        {
            this.prenda = new Prenda();
            this.prenda.AgregarCaracteristica(new Caracteristica("CATEGORIA", "ACCESORIO"));
            return this;
        }

        public AccesorioBuilder DeTipo(TTipoAccesorio tipo)
        {
            string str = "TIPO";
            if (this.prenda != null)
            {
                switch (tipo)
                {
                    case TTipoAccesorio.GORRO:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "GORRO")); break;
                    case TTipoAccesorio.ARO:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "ARO")); break;
                    default: break;
                }
            }
            else
                throw new System.Exception("NO SE PUEDE");
            return this;
        }
       

        public AccesorioBuilder DeMaterial(TMateriales material)
        {
            string str = "MATERIAL";
            if (this.prenda != null)
            {
                switch (material)
                {
                    case TMateriales.ALGODON:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "ALGODON")); break;
                    case TMateriales.CORDEROY:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "CORDEROY")); break;
                    case TMateriales.CUERO:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "CUERO")); break;
                    case TMateriales.HILO:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "HILO")); break;
                    case TMateriales.JEAN:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "JEAN")); break;
                    default: break;
                }
            }
            return this;
        }

        public AccesorioBuilder DeColorPrimario(int color)
        {
            if (this.prenda != null)
                this.prenda.AgregarCaracteristica(new Caracteristica("COLOR_PRIMARIO", Colores.GetInstance().ObtenerColor(color)));
            return this;
        }

        public AccesorioBuilder DeColorSecundario(int color)
        {
            if (this.prenda != null && !this.prenda.TieneColorPrimario(color))
            {
                this.prenda.AgregarCaracteristica(new Caracteristica("COLOR_PRIMARIO", Colores.GetInstance().ObtenerColor(color)));
            }
            return this;
        }

        public Prenda ObtenerPrenda()
        {
            return this.prenda;
        }
    }
}
