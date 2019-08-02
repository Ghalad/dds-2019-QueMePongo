using System;
using System.Drawing;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class PrendaBuilder
    {
        private Prenda Prenda { get; set; }

        public PrendaBuilder CrearPrenda()
        {
            this.Prenda = new Prenda();
            return this;
        }

        public Prenda ObtenerPrenda()
        {
            return this.Prenda;
        }

        [Obsolete("Metodo obsoleto, Utilizar especificos 'ConCategoria, ConTipo, ConMaterial, etc...'")]
        public PrendaBuilder AgregarCaracteristica(string clave, string valor)
        {
            if (this.Prenda != null && Tipos.GetInstance().ExisteCaracteristica(clave, valor))
            {
                if (!this.Prenda.TieneCaracteristica(clave))
                {
                    if (clave.ToUpper().Equals("TIPO"))
                    {
                        if(Tipos.GetInstance().ValidarTipo(valor.ToUpper(), this.Prenda.ObtenerCaracteristica("CATEGORIA")))
                            this.Prenda.AgregarCaracteristica(clave, valor);
                    }
                    else if (clave.ToUpper().Equals("CATEGORIA"))
                    {
                        if (Tipos.GetInstance().ValidarCategoria(valor.ToUpper(), this.Prenda.ObtenerCaracteristica("TIPO")))
                            this.Prenda.AgregarCaracteristica(clave, valor);
                    }
                    else
                        this.Prenda.AgregarCaracteristica(clave, valor);
                }
                else
                    if (clave.ToUpper().Equals("COLOR") &&
                        this.Prenda.CantidadDeCaracteristica(clave) == 1 &&
                        !this.Prenda.ObtenerCaracteristica("COLOR").Equals(valor.ToUpper()))
                    {
                        this.Prenda.AgregarCaracteristica(clave, valor);
                    }

            }
            
            return this;
        }






        public PrendaBuilder ConCategoria(string categoria)
        {
            string clave = "CATEGORIA";

            if (this.Prenda != null)
            {
                if (Tipos.GetInstance().ExisteCaracteristica(clave, categoria.ToUpper()))
                {
                    if(!this.Prenda.TieneCaracteristica(clave))
                    {
                        if (this.Prenda.TieneCaracteristica("TIPO"))
                        {
                            if (this.CorrespondeCategoriaTipo(categoria.ToUpper(), this.Prenda.ObtenerCaracteristica("TIPO")))
                            {
                                this.Prenda.AgregarCaracteristica(clave, categoria.ToUpper());
                            }
                        }
                        else
                        {
                            this.Prenda.AgregarCaracteristica(clave, categoria.ToUpper());
                        }
                    }
                }
            }

            return this;
        }

        public PrendaBuilder ConTipo(string tipo)
        {
            string clave = "TIPO";

            if (this.Prenda != null)
            {
                if (Tipos.GetInstance().ExisteCaracteristica(clave, tipo.ToUpper()))
                {
                    if (!this.Prenda.TieneCaracteristica(clave))
                    {
                        if (this.Prenda.TieneCaracteristica("CATEGORIA"))
                        {
                            if (this.CorrespondeCategoriaTipo(this.Prenda.ObtenerCaracteristica("CATEGORIA"), tipo.ToUpper()))
                            {
                                this.Prenda.AgregarCaracteristica(clave, tipo.ToUpper());
                                this.Prenda.AgregarCaracteristica("SUPERPOSICION", Tipos.GetInstance().ObtenerSuperposicion(tipo));
                            }
                        }
                        else
                        {
                            this.Prenda.AgregarCaracteristica(clave, tipo.ToUpper());
                            this.Prenda.AgregarCaracteristica("SUPERPOSICION", Tipos.GetInstance().ObtenerSuperposicion(tipo));
                        }
                    }
                }
            }

            return this;
        }

        public PrendaBuilder ConMaterial(string material)
        {
            string clave = "MATERIAL";

            if (this.Prenda != null)
            {
                if (Tipos.GetInstance().ExisteCaracteristica(clave, material.ToUpper()))
                {
                    if (!this.Prenda.TieneCaracteristica(clave))
                    {
                        this.Prenda.AgregarCaracteristica(clave, material.ToUpper());
                    }
                }
            }
            return this;
        }

        public PrendaBuilder ConColor(string color)
        {
            string clave = "COLOR";

            if (this.Prenda != null)
            {
                if (Tipos.GetInstance().ExisteCaracteristica(clave, color.ToUpper()))
                {
                    if (!this.Prenda.TieneCaracteristica(clave))
                    {
                        // color primario
                        this.Prenda.AgregarCaracteristica(clave, color.ToUpper());
                    }
                    else if (this.Prenda.CantidadDeCaracteristica(clave) < 2)
                    {
                        // color secundario
                        this.Prenda.AgregarCaracteristica(clave, color.ToUpper());
                    }
                }
            }
            return this;
        }

        public PrendaBuilder ConEvento(string evento)
        {
            string clave = "EVENTO";

            if (this.Prenda != null)
            {
                if (Tipos.GetInstance().ExisteCaracteristica(clave, evento.ToUpper()))
                {
                    if (!this.Prenda.TieneCaracteristica(clave, evento.ToUpper()))
                    {
                        this.Prenda.AgregarCaracteristica(clave, evento.ToUpper());
                    }
                }
            }

            return this;
        }

        public PrendaBuilder ConFoto(Bitmap imagen)
        {
            /*
             * FromFile
             * There are two direct ways to read an image file and load it into either a Bitmap or Image. Behold the C# code:
             * A) Image myImg = Image.FromFile("path here");
             * B) Bitmap myBmp = Bitmap.FromFile("path here");
             * 
             * Alternatively a Bitmap object can also be loaded with:
             * C)Bitmap myBmp = new Bitmap("path here");
             * The code above does not work with Image objects though, so it is best to stick with FromFile.
             * 
             * Dialog Box
             * Finally, to write an application that loads an image from a file, your C# program needs a dialogbox to select files. Using the .Net OpenFileDialog is simple enough.
             * Just apply the image-loading code to the Filename chosen by the user, so for example:
             * D)Bitmap loadedBitmap = Bitmap.FromFile(openFileDialog1.Filename);
             * */

            if (this.Prenda != null)
            {
                 if (imagen != null)
                {
                    this.Prenda.AgregarImagen(imagen);
                }
            }

            return this;
        }


        #region PRIVADO
        private bool CorrespondeCategoriaTipo(string car1, string car2)
        {
            if (this.Prenda != null)
            {
                if (Tipos.GetInstance().ExisteCaracteristicaXTipo(car1, car2))
                    return true;
                else
                    return false;
            }
            return false;
        }
        #endregion PRIVADO
    }
}
