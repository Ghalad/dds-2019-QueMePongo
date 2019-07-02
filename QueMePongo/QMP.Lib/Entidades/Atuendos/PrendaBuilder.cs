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
            string car = "CATEGORIA";

            if (this.Prenda != null)
            {
                if (Tipos.GetInstance().ExisteCaracteristica(car, categoria.ToUpper()))
                {
                    if(!this.Prenda.TieneCaracteristica(car))
                    {
                        if (this.Prenda.TieneCaracteristica("TIPO"))
                        {
                            if (this.CorrespondeCaracteristica(categoria.ToUpper(), this.Prenda.ObtenerCaracteristica("TIPO")))
                            {
                                this.Prenda.AgregarCaracteristica(car, categoria.ToUpper());
                            }
                        }
                        else
                        {
                            this.Prenda.AgregarCaracteristica(car, categoria.ToUpper());
                        }
                    }
                }
            }

            return this;
        }

        public PrendaBuilder ConTipo(string tipo)
        {
            string car = "TIPO";

            if (this.Prenda != null)
            {
                if (Tipos.GetInstance().ExisteCaracteristica(car, tipo.ToUpper()))
                {
                    if (!this.Prenda.TieneCaracteristica(car))
                    {
                        if (this.Prenda.TieneCaracteristica("CATEGORIA"))
                        {
                            if (this.CorrespondeCaracteristica(this.Prenda.ObtenerCaracteristica("CATEGORIA"), tipo.ToUpper()))
                            {
                                this.Prenda.AgregarCaracteristica(car, tipo.ToUpper());
                                this.Prenda.AgregarCaracteristica("SUPERPOCICION", Tipos.GetInstance().ObtenerSuperposicion(tipo));
                            }
                        }
                        else
                        {
                            this.Prenda.AgregarCaracteristica(car, tipo.ToUpper());
                            this.Prenda.AgregarCaracteristica("SUPERPOCICION", Tipos.GetInstance().ObtenerSuperposicion(tipo));
                        }
                    }
                }
            }

            return this;
        }

        public PrendaBuilder ConMaterial(string material)
        {
            string car = "MATERIAL";

            if (this.Prenda != null)
            {
                if (Tipos.GetInstance().ExisteCaracteristica(car, material.ToUpper()))
                {
                    if (!this.Prenda.TieneCaracteristica(car))
                    {
                        this.Prenda.AgregarCaracteristica(car, material.ToUpper());
                    }
                }
            }
            return this;
        }

        public PrendaBuilder ConColor(string color)
        {
            string car = "COLOR";

            if (this.Prenda != null)
            {
                if (Tipos.GetInstance().ExisteCaracteristica(car, color.ToUpper()))
                {
                    if (!this.Prenda.TieneCaracteristica(car))
                    {
                        // color primario
                        this.Prenda.AgregarCaracteristica(car, color.ToUpper());
                    }
                    else if (this.Prenda.CantidadDeCaracteristica(car) < 2)
                    {
                        // color secundario
                        this.Prenda.AgregarCaracteristica(car, color.ToUpper());
                    }
                }
            }
            return this;
        }


        #region PRIVADO
        private bool CorrespondeCaracteristica(string car1, string car2)
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
