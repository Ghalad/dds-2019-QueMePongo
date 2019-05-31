using static Ar.UTN.QMP.Lib.Entidades.Atuendos.Tipos;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class PrendaBuilder
    {
        private Prenda prenda { get; set; }

        public PrendaBuilder CrearPrenda()
        {
            this.prenda = new Prenda();
            return this;
        }

        public PrendaBuilder DeCategoria(TCategoria categoria)
        {
            string str = "CATEGORIA";
            if (this.prenda != null)
                switch (categoria)
                {
                    case TCategoria.ACCESORIO:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "ACCESORIO")); break;
                    case TCategoria.PARTE_SUPERIOR:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "SUPERIOR")); break;
                    case TCategoria.PARTE_INFERIOR:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "INFERIOR")); break;
                    case TCategoria.CALZADO:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "CALZADO")); break;
                    default: break;
                }

            return this;
        }

        public PrendaBuilder DeTipo(TTipoAccesorio tipo)
        {
            string str = "TIPO";
            if (this.prenda != null && this.prenda.TieneCaracteristica("CATEGORIA", "ACCESORIO"))
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
        public PrendaBuilder DeTipo(TTipoSuperior tipo)
        {
            string str = "TIPO";
            if (this.prenda != null && this.prenda.TieneCaracteristica("CATEGORIA", "SUPERIOR"))
            {
                switch (tipo)
                {
                    case TTipoSuperior.REMERA_MANGA_CORTA:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "REMERA_MANGA_CORTA")); break;
                    case TTipoSuperior.REMERA_MANGA_LARGA:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "REMERA_MANGA_LARGA")); break;
                    case TTipoSuperior.CAMPERA_DE_ABRIGO:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "CAMPERA_DE_ABRIGO")); break;
                    case TTipoSuperior.CAMPERA_IMPERMEABLE:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "CAMPERA_IMPERMEABLE")); break;
                    default: break;
                }
            }
            else
                throw new System.Exception("NO SE PUEDE");
            return this;
        }
        public PrendaBuilder DeTipo(TTipoInferior tipo)
        {
            string str = "TIPO";
            if (this.prenda != null && this.prenda.TieneCaracteristica("CATEGORIA", "INFERIOR"))
            {
                switch (tipo)
                {
                    case TTipoInferior.PANTALON_CORTO:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "PANTALON_CORTO")); break;
                    case TTipoInferior.PANTALON_LARGO:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "PANTALON_LARGO")); break;
                    case TTipoInferior.POLLERA:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "POLLERA")); break;
                    default: break;
                }
            }
            else
                throw new System.Exception("NO SE PUEDE");
            return this;
        }
        public PrendaBuilder DeTipo(TTipoCalzado tipo)
        {
            string str = "TIPO";
            if (this.prenda != null && this.prenda.TieneCaracteristica("CATEGORIA", "CALZADO"))
            {
                switch (tipo)
                {
                    case TTipoCalzado.ZAPATILLA_OUTDOOR:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "ZAPATILLA_OUTDOOR")); break;
                    case TTipoCalzado.ZAPATILLA_RUNNING:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "ZAPATILLA_RUNNING")); break;
                    case TTipoCalzado.ZAPATO_MOCASIN:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "ZAPATO_MOCASIN")); break;
                    case TTipoCalzado.ZAPATO_OXFORD:
                        this.prenda.AgregarCaracteristica(new Caracteristica(str, "ZAPATO_OXFORD")); break;
                    default: break;
                }
            }
            else
                throw new System.Exception("NO SE PUEDE");
            return this;
        }

        public PrendaBuilder DeMaterial(string material)
        {
            if (this.prenda != null)
                this.prenda.AgregarCaracteristica(new Caracteristica("MATERIAL", material));
            return this;
        }

        public PrendaBuilder DeColorPrimario(string color)
        {
            if (this.prenda != null)
                this.prenda.AgregarCaracteristica(new Caracteristica("COLOR_PRIMARIO", color));
            return this;
        }

        public PrendaBuilder DeColorSecundario(string color)
        {
            if (this.prenda != null && !this.prenda.TieneColorPrimario(color))
                this.prenda.AgregarCaracteristica(new Caracteristica("COLOR_SECUNDARIO", color));
            return this;
        }

        public Prenda ObtenerPrenda()
        {
            return this.prenda;
        }
    }
}
