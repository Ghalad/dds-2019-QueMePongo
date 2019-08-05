using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Prenda
    {
        private List<Caracteristica> Caracteristicas { get; set; }
        private Image Foto { get; set; }
        private static int SCALE_IMAGEN = 140;

        public Prenda()
        {
            this.Caracteristicas = new List<Caracteristica>();
        }



        public void AgregarCaracteristica(Caracteristica caracteristica)
        {
            foreach(Caracteristica c in this.Caracteristicas)
                if (c.EsLaMisma(caracteristica))
                    return;
            this.Caracteristicas.Add(caracteristica);
        }
        public void AgregarCaracteristica(string clave, string valor)
        {
            foreach (Caracteristica c in this.Caracteristicas)
                if (c.EsLaMisma(clave, valor))
                    return;
            this.Caracteristicas.Add(new Caracteristica(clave, valor));
        }
        public void AgregarImagen(Image imagen)
        {
            if (imagen != null)
            {
                #region NORMALIZACION
                try
                {
                    double escala = (double)SCALE_IMAGEN / (double)imagen.Width;
                    Graphics tmpGraphics = default(Graphics);
                    Bitmap tmpResizedImage = new Bitmap(Convert.ToInt32(escala * imagen.Width), Convert.ToInt32(escala * imagen.Height));
                    tmpGraphics = Graphics.FromImage(tmpResizedImage);
                    tmpGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    tmpGraphics.DrawImage(imagen, 0, 0, tmpResizedImage.Width + 1, tmpResizedImage.Height + 1);
                    this.Foto = tmpResizedImage;
                }
                catch
                {
                    //TODO manejo de excepciones
                }
                #endregion NORMALIZACION
            }
        }



        public bool TieneCaracteristica(Caracteristica caracteristica)
        {
            foreach(Caracteristica c in this.Caracteristicas)
                if(c.EsLaMisma(caracteristica))
                    return true;
            return false;
        }
        public bool TieneCaracteristica(string clave, string valor)
        {
            foreach (Caracteristica c in this.Caracteristicas)
                if (c.EsLaMisma(clave, valor))
                    return true;
            return false;
        }
        public bool TieneCaracteristica(string clave)
        {
            foreach (Caracteristica c in this.Caracteristicas)
                if (c.EsLaMismaClave(clave))
                    return true;
            return false;
        }



        public bool EsLaMisma(Prenda prenda)
        {
            foreach(Caracteristica c in this.Caracteristicas)
                if (!prenda.TieneCaracteristica(c))
                    return false;
            return true;
        }



        public int CantidadDeCaracteristicas()
        {
            return this.Caracteristicas.Count;
        }
        
        public int CantidadDeCaracteristica(string clave)
        {
            int i = 0;
            foreach (Caracteristica c in this.Caracteristicas)
                if (c.EsLaMismaClave(clave))
                    i++;
            return i;
        }
        
        public string ObtenerCaracteristica(string clave)
        {
            foreach (Caracteristica c in this.Caracteristicas)
                if (c.EsLaMismaClave(clave.ToUpper()))
                    return c.Valor;
            return null;
        }

        public int NumeroSuperposicion()
        {
            foreach(Caracteristica c in Caracteristicas)
                if (c.EsLaMismaClave("superposicion"))
                    return Convert.ToInt32(c.Valor);

            return -1;
        }
    }
}
