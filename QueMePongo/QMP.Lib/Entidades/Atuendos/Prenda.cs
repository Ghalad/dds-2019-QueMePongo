using Ar.UTN.QMP.Lib.Entidades.Calificaciones;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Prenda
    {
        private List<Caracteristica> Caracteristicas { get; set; }
        public Image Imagen { get; set; }
        private static int RESOLUCION = 140; // Esto se podria setear por archivo de configuracion
        public Calificacion Calificacion;

        public Prenda()
        {
            this.Caracteristicas = new List<Caracteristica>();
        }


        /// <summary>
        /// Permite agregar una caracteristica, a traves de un objeto Caracteristica
        /// </summary>
        /// <param name="caracteristica"></param>
        public void AgregarCaracteristica(Caracteristica caracteristica)
        {
            foreach(Caracteristica c in this.Caracteristicas)
                if (c.EsLaMisma(caracteristica))
                    return;
            this.Caracteristicas.Add(caracteristica);
        }


        /// <summary>
        /// Permite agregar una caracteristica, a traves de un par Clave, Valor
        /// </summary>
        /// <param name="clave"></param>
        /// <param name="valor"></param>
        public void AgregarCaracteristica(string clave, string valor)
        {
            foreach (Caracteristica c in this.Caracteristicas)
                if (c.EsLaMisma(clave, valor))
                    return;
            this.Caracteristicas.Add(new Caracteristica(clave, valor));
        }


        /// <summary>
        /// Permite agregar una imagen a la prenda y normalizarla
        /// </summary>
        /// <param name="imagen"></param>
        public void AgregarImagen(Image imagen)
        {
            if (imagen != null)
            {
                try
                {
                    double escala = (double)RESOLUCION / (double)imagen.Width;
                    Graphics tmpGraphics = default(Graphics);
                    Bitmap tmpResizedImage = new Bitmap(Convert.ToInt32(escala * imagen.Width), Convert.ToInt32(escala * imagen.Height));
                    tmpGraphics = Graphics.FromImage(tmpResizedImage);
                    tmpGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    tmpGraphics.DrawImage(imagen, 0, 0, tmpResizedImage.Width + 1, tmpResizedImage.Height + 1);
                    this.Imagen = tmpResizedImage;
                }
                catch
                {
                    throw new Exception("Error al normalizar la imagen de la prenda");
                }
            }
            else
                throw new Exception("No se puede agregar una imagen nula");
        }

        public int ObtenerPuntaje()
        {
            return this.Calificacion.ObtenerPuntaje();
        }


        /// <summary>
        /// Valida si la prenda tiene la misma caracteristica, a traves de un objeto Caracteristica
        /// </summary>
        /// <param name="caracteristica"></param>
        /// <returns></returns>
        public bool TieneCaracteristica(Caracteristica caracteristica)
        {
            foreach(Caracteristica c in this.Caracteristicas)
                if(c.EsLaMisma(caracteristica))
                    return true;
            return false;
        }


        /// <summary>
        /// Valida si la prenda tiene la misma caracteristica, a traves de un par Clave, Valor
        /// </summary>
        /// <param name="clave"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public bool TieneCaracteristica(string clave, string valor)
        {
            foreach (Caracteristica c in this.Caracteristicas)
                if (c.EsLaMisma(clave, valor))
                    return true;
            return false;
        }


        /// <summary>
        /// Valida si la prenda tiene el caracteristica, a traves de la Calve
        /// </summary>
        /// <param name="clave"></param>
        /// <returns></returns>
        public bool TieneCaracteristica(string clave)
        {
            foreach (Caracteristica c in this.Caracteristicas)
                if (c.EsLaMismaClave(clave))
                    return true;
            return false;
        }


        /// <summary>
        /// Valida si la prenda tiene las mismas caracteristicas que otra prenda
        /// </summary>
        /// <param name="prenda"></param>
        /// <returns></returns>
        public bool EsLaMisma(Prenda prenda)
        {
            foreach(Caracteristica c in this.Caracteristicas)
                if (!prenda.TieneCaracteristica(c))
                    return false;
            return true;
        }


        /// <summary>
        /// Devuelve la cantidad total de caracteristicas que componen la prenda
        /// </summary>
        /// <returns></returns>
        public int CantidadDeCaracteristicas()
        {
            return this.Caracteristicas.Count;
        }
        

        /// <summary>
        /// Devuelve la cantidad de veces que la prenda tiene una unica caracteristica
        /// </summary>
        /// <param name="clave"></param>
        /// <returns></returns>
        public int CantidadDeCaracteristica(string clave)
        {
            int i = 0;
            foreach (Caracteristica c in this.Caracteristicas)
                if (c.EsLaMismaClave(clave))
                    i++;
            return i;
        }
        

        /// <summary>
        /// Obtiene una caracteristica a partir de su Clave
        /// </summary>
        /// <param name="clave"></param>
        /// <returns></returns>
        public string ObtenerCaracteristica(string clave)
        {
            foreach (Caracteristica c in this.Caracteristicas)
                if (c.EsLaMismaClave(clave.ToUpper()))
                    return c.Valor;
            return null;
        }




        [Obsolete("Esto no va")]
        public int NumeroSuperposicion()
        {
            foreach(Caracteristica c in Caracteristicas)
                if (c.EsLaMismaClave("superposicion"))
                    return Convert.ToInt32(c.Valor);

            return -1;
        }
        [Obsolete("Esto no va")]
        public void MostrarPorPantalla()
        {
            foreach (Caracteristica c in Caracteristicas)
            {
                if (c.Clave == "TIPO")
                {
                    Console.WriteLine(c.Valor);
                }
            }
        }
        [Obsolete("Esto no va")]
        public void ToString()
        {
            int i = 1;
            foreach (Caracteristica c in Caracteristicas)
            {
                Console.WriteLine(string.Format("{0}) clave=[{1}] valor=[{2}]", i++, c.Clave, c.Valor));
            }
        }
    }
}
