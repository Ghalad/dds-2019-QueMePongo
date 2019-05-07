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
        private Atuendo Atuendo { get; set; }

        public AtuendoBuilder CrearAtuendo()
        {
            this.Atuendo = new Atuendo();
            return this;
        }
        public Atuendo getAtuedo()
        {
            return this.Atuendo;
        }

        #region ACCESORIO
        public AtuendoBuilder ConAccesorio(Accesorio.Tipo tipo)
        {
            if (tipo.Equals(Accesorio.Tipo.ANTEOJOS_DE_SOL))
            {
                this.Atuendo.Accesorio = new AnteojosDeSol();
            }
            else if (tipo.Equals(Accesorio.Tipo.PAÑUELO))
            {

                this.Atuendo.Accesorio = new Pañuelo();
            }
            else
            {
                // DEFINIR EXCEPCIONES
            }
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
            {
                this.Atuendo.Accesorio.ColorSecundario = color;
            }
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
        public AtuendoBuilder AccesorioEsRegalado()
        {
            this.Atuendo.Accesorio.EsRegalo = true;
            return this;
        }
        public AtuendoBuilder AccesorioDeMaterial(eMaterialAccesorio material)
        {
            this.Atuendo.Accesorio.Material = material;
            return this;
        }
        #endregion ACCESORIO

        #region PARTESUPERIOR
        public AtuendoBuilder ConParteSuperior(ParteSuperior.Tipo tipo)
        {
            if (tipo.Equals(ParteSuperior.Tipo.CAMPERA_DE_ABRIGO))
            {
                this.Atuendo.ParteSuperior = new CamperaDeAbrigo();
            }
            else if (tipo.Equals(ParteSuperior.Tipo.CAMPERA_ROMPE_VIENTO))
            {
                this.Atuendo.ParteSuperior = new CamperaRompeViento();
            }
            else if (tipo.Equals(ParteSuperior.Tipo.REMERA_MANGA_CORTA))
            {
                this.Atuendo.ParteSuperior = new RemeraMangaCorta();
            }
            else if (tipo.Equals(ParteSuperior.Tipo.REMERA_MANGA_LARGA))
            {
                this.Atuendo.ParteSuperior = new RemeraMangaLarga();
            }
            else
            {
                // DEFINIR EXCEPCIONES
            }
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
            {
                this.Atuendo.ParteSuperior.ColorSecundario = color;
            }
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
        public AtuendoBuilder ParteSuperiorEsRegalado()
        {
            this.Atuendo.ParteSuperior.EsRegalo = true;
            return this;
        }
        public AtuendoBuilder ParteSuperiorDeTalle(ParteSuperior.eTalle talle)
        {
            this.Atuendo.ParteSuperior.Talle = talle;
            return this;
        }
        public AtuendoBuilder ParteSuperiorDeTela(ParteSuperior.eTelaGruesa tela)
        {
            if (this.Atuendo.ParteSuperior is Campera)
            {
                ((Campera)this.Atuendo.ParteSuperior).Tela = tela;
            }
            else
            {
                // DEFINIR EXCEPCIONES
            }
            return this;
        }
        public AtuendoBuilder ParteSuperiorDeTela(ParteSuperior.eTelaFina tela)
        {
            if (this.Atuendo.ParteSuperior is Remera)
            {
                ((Remera)this.Atuendo.ParteSuperior).Tela = tela;
            }
            else
            {
                // DEFINIR EXCEPCIONES
            }
            return this;
        }
        public AtuendoBuilder ParteSuperiorConEstampado(ParteSuperior.eEstampado estampado)
        {
            if(this.Atuendo.ParteSuperior is Remera)
            {
                ((Remera)this.Atuendo.ParteSuperior).Estampado = estampado;
            }
            else
            {
                // DEFINIR EXCEPCIONES
            }
            return this;
        }
        #endregion PARTESUPERIOR

        #region PARTEINFERIOR
        public AtuendoBuilder ConParteInferior(ParteInferior.Tipo tipo)
        {
            if (tipo.Equals(ParteInferior.Tipo.PANTALON))
            {
                this.Atuendo.ParteInferior = new Pantalon();
            }
            else if (tipo.Equals(ParteInferior.Tipo.SHORT))
            {
                this.Atuendo.ParteInferior = new Short();
            }
            else
            {
                // DEFINIR EXCEPCIONES
            }
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
            {
                this.Atuendo.ParteInferior.ColorSecundario = color;
            }
            else
            {
                // DEFINIR EXCEPCIONES
            }
            return this;
        }
        public AtuendoBuilder ParteInferiorEsFavorito()
        {
            this.Atuendo.ParteInferior.EsFavorita = true;
            return this;
        }
        public AtuendoBuilder ParteInferiorEsRegalado()
        {
            this.Atuendo.ParteInferior.EsRegalo = true;
            return this;
        }
        public AtuendoBuilder ParteInferiorDeTalle(int talle)
        {
            this.Atuendo.ParteInferior.Talle = talle;
            return this;
        }
        public AtuendoBuilder ParteInferiorDeTela(ParteSuperior.eTelaGruesa tela)
        {
            this.Atuendo.ParteInferior.Tela = tela;
            return this;
        }
        #endregion PARTEINFERIOR

        #region CALZADO
        public AtuendoBuilder ConCalzado(Calzado.Tipo tipo)
        {
            if (tipo.Equals(Calzado.Tipo.ZAPATO))
            {
                this.Atuendo.Calzado = new Zapato();
            }
            else if (tipo.Equals(Calzado.Tipo.CROCKS))
            {
                this.Atuendo.Calzado = new Crocks();
            }
            else
            {
                // DEFINIR EXCEPCIONES
            }
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
            {
                this.Atuendo.Calzado.ColorSecundario = color;
            }
            else
            {
                // DEFINIR EXCEPCIONES
            }
            return this;
        }
        public AtuendoBuilder CalzadoEsFavorito()
        {
            this.Atuendo.Calzado.EsFavorita = true;
            return this;
        }
        public AtuendoBuilder CalzadoEsRegalado()
        {
            this.Atuendo.Calzado.EsRegalo = true;
            return this;
        }
        public AtuendoBuilder CalzadoDeTalle(int talle)
        {
            this.Atuendo.Calzado.Talle = talle;
            return this;
        }
        public AtuendoBuilder CalzadoConMAterial(Calzado.eMaterialCalzado material)
        {
            this.Atuendo.Calzado.Material = material;
            return this;
        }
        #endregion CALZADO
    }
}
