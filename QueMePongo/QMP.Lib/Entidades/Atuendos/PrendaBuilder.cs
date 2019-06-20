﻿namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
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
    }
}