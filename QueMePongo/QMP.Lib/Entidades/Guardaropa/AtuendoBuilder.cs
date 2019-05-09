using Ar.UTN.QMP.Lib.Entidades.Prendas.Accesorios;
using Ar.UTN.QMP.Lib.Entidades.Prendas.PartesSuperiores;
using static Ar.UTN.QMP.Lib.Entidades.Prendas.Prenda;
using Ar.UTN.QMP.Lib.Entidades.Prendas;
using Ar.UTN.QMP.Lib.Entidades.Prendas.PartesInferiores;
using Ar.UTN.QMP.Lib.Entidades.Prendas.Calzados;

namespace Ar.UTN.QMP.Lib.Entidades.Guardaropa
{
    public class AtuendoBuilder
    {
        public  Atuendo Atuendo { get; private set; }

        public AtuendoBuilder()
        {
            this.Atuendo = new Atuendo();
        }


        #region ACCESORIO
        public AtuendoBuilder ConAccesorio(Accesorio.eTipoAnteOjo tipo)
        {
            Anteojos anteojo = new Anteojos();
            anteojo.Tipo = tipo;
            this.Atuendo.Accesorio = anteojo;
            return this;
        }
        public AtuendoBuilder ConAccesorio(eTipoPañuelo tipo)
        {
            Pañuelo pañuelo = new Pañuelo();
            pañuelo.Tipo = tipo;
            this.Atuendo.Accesorio = pañuelo;
            return this;
        }
        public AtuendoBuilder ConAccesorio(eTipoSombrero tipo)
        {
            Sombrero sombrero = new Sombrero();
            sombrero.Tipo = tipo;
            this.Atuendo.Accesorio = sombrero;
            return this;
        }
        public AtuendoBuilder AccesorioConColorPrincipal(eColor color)
        {
            this.Atuendo.Accesorio.ColorPrincipal = color;
            return this;
        }
        public AtuendoBuilder AccesorioConColorSecundario(eColor color)
        {
            if (this.Atuendo.Accesorio.ColorPrincipal != color)
                this.Atuendo.Accesorio.ColorSecundario = color;
            else
            {
                // DEFINIR EXCEPCIONES
            }
            return this;
        }
        public AtuendoBuilder AccesorioEsFavorito()
        {
            this.Atuendo.Accesorio.EsFavorita = true;
            return this;
        }
        public AtuendoBuilder AccesorioEsRegaladoPor(string nombre)
        {
            this.Atuendo.Accesorio.EsRegaloPor = nombre.ToUpper();
            return this;
        }
        public AtuendoBuilder AccesorioDeMaterial(eMaterialesAnteojos material)
        {
            if(this.Atuendo.Accesorio is Anteojos)
                ((Anteojos)this.Atuendo.Accesorio).Material = material;
            return this;
        }
        public AtuendoBuilder AccesorioDeMaterial(eMaterialesPañuelos material)
        {
            if (this.Atuendo.Accesorio is Pañuelo)
                ((Pañuelo)this.Atuendo.Accesorio).Material = material;
            return this;
        }
        public AtuendoBuilder AccesorioDeMaterial(eMaterialesSombrero material)
        {
            if (this.Atuendo.Accesorio is Sombrero)
                ((Sombrero)this.Atuendo.Accesorio).Material = material;
            return this;
        }
        #endregion ACCESORIO

        #region PARTESUPERIOR
        public AtuendoBuilder ConParteSuperior(ParteSuperior.eTipoRemera tipo)
        {
            Remera remera = new Remera();
            remera.Tipo = tipo;
            this.Atuendo.ParteSuperior = remera;
            return this;
        }
        public AtuendoBuilder ConParteSuperior(ParteSuperior.eTipoCampera tipo)
        {
            Campera campera = new Campera();
            campera.Tipo = tipo;
            this.Atuendo.ParteSuperior = campera;
            return this;
        }
        public AtuendoBuilder ConParteSuperior(ParteSuperior.eTipoCamisa tipo)
        {
            Camisa camisa = new Camisa();
            camisa.Tipo = tipo;
            this.Atuendo.ParteSuperior = camisa;
            return this;
        }
        public AtuendoBuilder ParteSuperiorConColorPrincipal(eColor color)
        {
            this.Atuendo.ParteSuperior.ColorPrincipal = color;
            return this;
        }
        public AtuendoBuilder ParteSuperiorConColorSecundario(eColor color)
        {
            if (this.Atuendo.ParteSuperior.ColorPrincipal != color)
                this.Atuendo.ParteSuperior.ColorSecundario = color;
            else
            {
                // DEFINIR EXCEPCIONES
            }
            return this;
        }
        public AtuendoBuilder ParteSuperiorEsFavorito()
        {
            this.Atuendo.ParteSuperior.EsFavorita = true;
            return this;
        }
        public AtuendoBuilder ParteSuperiorEsRegaladoPor(string nombre)
        {
            this.Atuendo.ParteSuperior.EsRegaloPor = nombre.ToUpper();
            return this;
        }
        public AtuendoBuilder ParteSuperiorDeTalle(ParteSuperior.eTalleParteSuperior talle)
        {
            this.Atuendo.ParteSuperior.Talle = talle;
            return this;
        }
        public AtuendoBuilder ParteSuperiorDeMaterial(ParteSuperior.eMaterialesRemera material)
        {
            if (this.Atuendo.ParteSuperior is Remera)
                ((Remera)this.Atuendo.ParteSuperior).Material = material;
            return this;
        }
        public AtuendoBuilder ParteSuperiorDeMaterial(ParteSuperior.eMaterialesCamisa material)
        {
            if (this.Atuendo.ParteSuperior is Camisa)
                ((Camisa)this.Atuendo.ParteSuperior).Material = material;
            return this;
        }
        public AtuendoBuilder ParteSuperiorDeMaterial(ParteSuperior.eMaterialesCampera material)
        {
            if (this.Atuendo.ParteSuperior is Campera)
                ((Campera)this.Atuendo.ParteSuperior).Material = material;
            return this;
        }
        public AtuendoBuilder ParteSuperiorConEstampado(ParteSuperior.eEstampados estampado)
        {
            if(this.Atuendo.ParteSuperior is Remera)
                ((Remera)this.Atuendo.ParteSuperior).Estampado = estampado;
            return this;
        }
        #endregion PARTESUPERIOR

        #region PARTEINFERIOR
        public AtuendoBuilder ConParteInferior(eTipoPantalon tipo)
        {
            Pantalon pantalon = new Pantalon();
            pantalon.Tipo = tipo;
            this.Atuendo.ParteInferior = pantalon;
            return this;
        }
        public AtuendoBuilder ConParteInferior(eTipoPollera tipo)
        {
            Pollera pollera = new Pollera();
            pollera.Tipo = tipo;
            this.Atuendo.ParteInferior = pollera;
            return this;
        }
        public AtuendoBuilder ParteInferiorConColorPrincipal(eColor color)
        {
            this.Atuendo.ParteInferior.ColorPrincipal = color;
            return this;
        }
        public AtuendoBuilder ParteInferiorConColorSecundario(eColor color)
        {
            if (this.Atuendo.ParteInferior.ColorPrincipal != color)
                this.Atuendo.ParteInferior.ColorSecundario = color;
            else
            {
                // DEFINIR EXCEPCIONES??
            }
            return this;
        }
        public AtuendoBuilder ParteInferiorEsFavorito()
        {
            this.Atuendo.ParteInferior.EsFavorita = true;
            return this;
        }
        public AtuendoBuilder ParteInferiorEsRegaladoPor(string nombre)
        {
            this.Atuendo.ParteInferior.EsRegaloPor = nombre;
            return this;
        }
        public AtuendoBuilder ParteInferiorDeTalle(eTalleParteInferior talle)
        {
            this.Atuendo.ParteInferior.Talle = talle;
            return this;
        }
        public AtuendoBuilder ParteInferiorDeMaterial(eMaterialesPantalon material)
        {
            if(this.Atuendo.ParteInferior is Pantalon)
                ((Pantalon)this.Atuendo.ParteInferior).Material = material;
            return this;
        }
        public AtuendoBuilder ParteInferiorDeMaterial(eMaterialesPollera material)
        {
            if (this.Atuendo.ParteInferior is Pollera)
                ((Pollera)this.Atuendo.ParteInferior).Material = material;
            return this;
        }
        #endregion PARTEINFERIOR

        #region CALZADO
        public AtuendoBuilder ConCalzado(eTipoOjota tipo)
        {
            Ojota ojota = new Ojota();
            ojota.Tipo = tipo;
            this.Atuendo.Calzado = ojota;
            return this;
        }
        public AtuendoBuilder ConCalzado(eTipoZapato tipo)
        {
            Zapato zapato = new Zapato();
            zapato.Tipo = tipo;
            this.Atuendo.Calzado = zapato;
            return this;
        }
        public AtuendoBuilder ConCalzado(eTipoZapatilla tipo)
        {
            Zapatilla zapatilla = new Zapatilla();
            zapatilla.Tipo = tipo;
            this.Atuendo.Calzado = zapatilla;
            return this;
        }
        public AtuendoBuilder CalzadoConColorPrincipal(eColor color)
        {
            this.Atuendo.Calzado.ColorPrincipal = color;
            return this;
        }
        public AtuendoBuilder CalzadoConColorSecundario(eColor color)
        {
            if (this.Atuendo.Calzado.ColorPrincipal != color)
                this.Atuendo.Calzado.ColorSecundario = color;
            else
            {
                // DEFINIR EXCEPCIONES??
            }
            return this;
        }
        public AtuendoBuilder CalzadoEsFavorito()
        {
            this.Atuendo.Calzado.EsFavorita = true;
            return this;
        }
        public AtuendoBuilder CalzadoEsRegaladoPor(string nombre)
        {
            this.Atuendo.Calzado.EsRegaloPor = nombre.ToUpper();
            return this;
        }
        public AtuendoBuilder CalzadoDeTalle(eTalleCalzado talle)
        {
            this.Atuendo.Calzado.Talle = talle;
            return this;
        }
        public AtuendoBuilder CalzadoConMaterial(eMaterialesOjota material)
        {
            if (this.Atuendo.Calzado is Ojota)
                ((Ojota)this.Atuendo.Calzado).Material = material;
            return this;
        }
        public AtuendoBuilder CalzadoConMaterial(eMaterialesZapatilla material)
        {
            if (this.Atuendo.Calzado is Zapatilla)
                ((Zapatilla)this.Atuendo.Calzado).Material = material;
            return this;
        }
        public AtuendoBuilder CalzadoConMaterial(eMaterialesZapato material)
        {
            if (this.Atuendo.Calzado is Zapato)
                ((Zapato)this.Atuendo.Calzado).Material = material;
            return this;
        }
        #endregion CALZADO
    }
}
