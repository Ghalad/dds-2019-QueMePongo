using Ar.UTN.QMP.Lib.Entidades._0._Para_DB;
using Ar.UTN.QMP.Lib.Entidades.Calificaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    [Table("Prendas")]
    public class Prenda
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int PrendaId { get; set; }
        [NotMapped]
        public Image Imagen { get; set; }
        public byte[] ImagenEnBytes { get; set; }
        public static int RESOLUCION = 140; // Esto se podria setear por archivo de configuracion
        public Calificacion Calificacion { get; set; }
        public DateTime fechaDeUso { get; set; }
        public ICollection<CaracteristicaPrenda> Caracteristicas { get; set; }
        public ICollection<Guardarropa> Guardarropas { get; set; }

        public Prenda()
        {
            this.Caracteristicas = new List<CaracteristicaPrenda>();
            this.fechaDeUso = new DateTime(1990, 12, 13);
            this.Calificacion = null;
            this.Guardarropas = new HashSet<Guardarropa>();
        }

        public void AgregarGuardarropa(Guardarropa guardarropa)
        {
            this.Guardarropas.Add(guardarropa);
        }

        public Prenda(Prenda aCopiar)
        {
            this.Caracteristicas = new List<CaracteristicaPrenda>();
            this.PrendaId = aCopiar.PrendaId;
            this.Calificacion = aCopiar.Calificacion;
            this.Caracteristicas = aCopiar.Caracteristicas;
            this.fechaDeUso = aCopiar.fechaDeUso;
            this.Imagen = aCopiar.Imagen;
            this.ImagenEnBytes = aCopiar.ImagenEnBytes;
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
            this.Caracteristicas.Add(new CaracteristicaPrenda(caracteristica.Clave, caracteristica.Valor, this));
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
            this.Caracteristicas.Add(new CaracteristicaPrenda(clave, valor, this));
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
                    this.ImagenEnBytes = imageToByteArray(this.Imagen);
                }
                catch
                {
                    throw new Exception("Error al normalizar la imagen de la prenda");
                }
            }
            else
                throw new Exception("No se puede agregar una imagen nula");
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


        public void MarcarComoUsada()
        {
            this.fechaDeUso = DateTime.Now;
            return;
        }

        public bool EstaEnUso()
        {
            int diasQueSeUsaUnaPrenda = 2;
            if((DateTime.Now - fechaDeUso).TotalDays > diasQueSeUsaUnaPrenda)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int ObtenerPuntaje()
        {
            if (Calificacion == null)
                return 0;
            return this.Calificacion.ObtenerPuntaje();
        }

        internal void Puntuar(int puntaje)
        {
            if (Calificacion == null)
                Calificacion = new Calificacion(puntaje);
            else
                Calificacion.Calificar(puntaje);
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
#pragma warning disable CS0114 // 'Prenda.ToString()' hides inherited member 'object.ToString()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.
        public void ToString()
#pragma warning restore CS0114 // 'Prenda.ToString()' hides inherited member 'object.ToString()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.
        {
            int i = 1;
            foreach (Caracteristica c in Caracteristicas)
            {
                Console.WriteLine(string.Format("{0}) clave=[{1}] valor=[{2}]", i++, c.Clave, c.Valor));
            }
        }
    }
}
