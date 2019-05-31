namespace Ar.UTN.QMP.Lib.Entidades.Atuendos.Builders
{
    public class AccesorioBuilder : IPrendaBuilder
    {
        private Prenda prenda { get; set; }

        public IPrendaBuilder CrearPrenda()
        {
            this.prenda = new Prenda();
            this.prenda.AgregarCaracteristica(new Caracteristica("CATEGORIA", "ACCESORIO"));
            return this;
        }

        public IPrendaBuilder DeTipo(string tipo)
        {
            if (this.prenda != null)
                this.prenda.AgregarCaracteristica(new Caracteristica("TIPO", tipo));
            return this;
        }
       

        public IPrendaBuilder DeMaterial(string material)
        {
            if (this.prenda != null)
                this.prenda.AgregarCaracteristica(new Caracteristica("MATERIAL", material));
            return this;
        }

        public IPrendaBuilder DeColorPrimario(string color)
        {
            if (this.prenda != null)
                this.prenda.AgregarCaracteristica(new Caracteristica("COLOR_PRIMARIO", color));
            return this;
        }

        public IPrendaBuilder DeColorSecundario(string color)
        {
            if (this.prenda != null && !this.prenda.TieneColorPrimario(color))
                this.prenda.AgregarCaracteristica(new Caracteristica("COLOR_PRIMARIO", color));
            return this;
        }

        public Prenda ObtenerPrenda()
        {
            return this.prenda;
        }
    }
}
