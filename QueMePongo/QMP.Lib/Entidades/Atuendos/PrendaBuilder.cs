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





        /// <summary>
        /// Agregar una caracteristica CATEGORIA
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public PrendaBuilder ConCategoria(string categoria)
        {
            string clave = "CATEGORIA";

            if (!string.IsNullOrWhiteSpace(categoria))
            {
                if (this.Prenda != null)
                {
                    if (Tipos.GetInstance().ExisteCaracteristica(clave, categoria.ToUpper()))
                    {
                        if (!this.Prenda.TieneCaracteristica(clave))
                        {
                            if (this.Prenda.TieneCaracteristica("TIPO"))
                            {
                                if (Tipos.GetInstance().ExisteCaracteristicaXTipo(categoria.ToUpper(), this.Prenda.ObtenerCaracteristica("TIPO")))
                                    this.Prenda.AgregarCaracteristica(clave, categoria.ToUpper());
                                else
                                    throw new Exception(string.Format("La categoria [{0}] no se corresponde con el tipo de prenda [{1}] que posee", categoria, this.Prenda.ObtenerCaracteristica("TIPO")));
                            }
                            else
                                this.Prenda.AgregarCaracteristica(clave, categoria.ToUpper());
                        }
                        else
                            throw new Exception("La prenda ya posee categoria");
                    }
                    else
                        throw new Exception(string.Format("No existe la caracteristica [{0}]", categoria));
                }
                else
                    throw new Exception("Antes de agregar una caracteristica debe crear la prenda");
            }
            else
                throw new Exception("Categoria requerida");

            return this;
        }

        /// <summary>
        /// Agrega una caracteristica TIPO
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public PrendaBuilder ConTipo(string tipo)
        {
            string clave = "TIPO";

            if (!string.IsNullOrWhiteSpace(tipo))
            {
                if (this.Prenda != null)
                {
                    if (Tipos.GetInstance().ExisteCaracteristica(clave, tipo.ToUpper()))
                    {
                        if (!this.Prenda.TieneCaracteristica(clave))
                        {
                            if (this.Prenda.TieneCaracteristica("CATEGORIA"))
                            {
                                if (Tipos.GetInstance().ExisteCaracteristicaXTipo(this.Prenda.ObtenerCaracteristica("CATEGORIA"), tipo.ToUpper()))
                                {
                                    this.Prenda.AgregarCaracteristica(clave, tipo.ToUpper());
                                    this.Prenda.AgregarCaracteristica("SUPERPOSICION", Tipos.GetInstance().ObtenerSuperposicion(tipo));
                                    this.Prenda.AgregarCaracteristica("ABRIGO", Tipos.GetInstance().ObtenerAbrigo(tipo));
                                    this.AgregarClimas(tipo);
                                }
                                else
                                    throw new Exception(string.Format("El tipo de prenda [{0}] no se corresponde con la categoria [{1}] que posee", tipo, this.Prenda.ObtenerCaracteristica("CATEGORIA")));
                            }
                            else
                            {
                                this.Prenda.AgregarCaracteristica(clave, tipo.ToUpper());
                                this.Prenda.AgregarCaracteristica("SUPERPOSICION", Tipos.GetInstance().ObtenerSuperposicion(tipo));
                                this.AgregarClimas(tipo);
                            }
                        }
                        else
                            throw new Exception("La prenda ya posee tipo");
                    }
                    else
                        throw new Exception(string.Format("No existe la caracteristica [{0}]", tipo));
                }
                else
                    throw new Exception("Antes de agregar una caracteristica debe crear la prenda");
            }
            else
                throw new Exception("Tipo requerido");

            return this;
        }


        /// <summary>
        /// Agregar una caracteristica MATERIAL
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        public PrendaBuilder ConMaterial(string material)
        {
            string clave = "MATERIAL";

            if (!string.IsNullOrWhiteSpace(material))
            {
                if (this.Prenda != null)
                {
                    if (Tipos.GetInstance().ExisteCaracteristica(clave, material.ToUpper()))
                    {
                        if (!this.Prenda.TieneCaracteristica(clave))
                            this.Prenda.AgregarCaracteristica(clave, material.ToUpper());
                        else
                            throw new Exception("La prenda ya posee material");
                    }
                    else
                        throw new Exception(string.Format("No existe la caracteristica [{0}]", material));
                }
                else
                    throw new Exception("Antes de agregar una caracteristica debe crear la prenda");
            }
            else
                throw new Exception("Material requerido");

            return this;
        }


        /// <summary>
        /// Agregar una caracteristica COLOR
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public PrendaBuilder ConColor(string color)
        {
            string clave = "COLOR";

            if (!string.IsNullOrWhiteSpace(color))
            {
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
                        else
                            throw new Exception("La prenda ya posee color primario y secundario");
                    }
                    else
                        throw new Exception(string.Format("No existe la caracteristica [{0}]", color));
                }
                else
                    throw new Exception("Antes de agregar una caracteristica debe crear la prenda");
            }
            else
                throw new Exception("Color requerido");

            return this;
        }


        /// <summary>
        /// Agregar una caracteristica EVENTO
        /// </summary>
        /// <param name="tipoEvento"></param>
        /// <returns></returns>
        public PrendaBuilder ConEvento(string tipoEvento)
        {
            string clave = "EVENTO";
            //TODO LOS EVENTOS SE TIENEN QUE PODER REPETIR
            if (!string.IsNullOrWhiteSpace(tipoEvento))
            {
                if (this.Prenda != null)
                {
                    if (Tipos.GetInstance().ExisteCaracteristica(clave, tipoEvento.ToUpper()))
                    {
                        if (!this.Prenda.TieneCaracteristica(clave, tipoEvento.ToUpper()))
                            this.Prenda.AgregarCaracteristica(clave, tipoEvento.ToUpper());
                        else
                            throw new Exception("La prenda ya posee un evento");
                    }
                    else
                        throw new Exception(string.Format("No existe la caracteristica [{0}]", tipoEvento));
                }
                else
                    throw new Exception("Antes de agregar una caracteristica debe crear la prenda");
            }
            else
                throw new Exception("Tipo de evento requerido");

            return this;
        }


        /// <summary>
        /// Agregar una imagen
        /// </summary>
        /// <param name="imagen"></param>
        /// <returns></returns>
        public PrendaBuilder ConImagen(Image imagen)
        {
            if (imagen != null)
            {
                if (this.Prenda != null)
                    this.Prenda.AgregarImagen(imagen);
                else
                    throw new Exception("Antes de agregar una imagen debe crear la prenda");
            }
            else
                throw new Exception("Imagen requerida");

            return this;
        }


        #region PRIVADO
        private void AgregarClimas(string tipoPrenda)
        {
#pragma warning disable CS0612 // 'Tipos.ObtenerClimas(string)' is obsolete
            foreach(string str in Tipos.GetInstance().ObtenerClimas(tipoPrenda))
#pragma warning restore CS0612 // 'Tipos.ObtenerClimas(string)' is obsolete
                this.Prenda.AgregarCaracteristica(new Caracteristica("CLIMA", str.ToUpper()));
        }
        #endregion PRIVADO
    }
}
