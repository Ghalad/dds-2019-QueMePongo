using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Prenda
    {
        private List<Caracteristica> Caracteristicas { get; set; }
        private Bitmap Foto { get; set; }

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
        public void AgregarImagen(Bitmap imagen)
        {
            if (imagen != null)
            {
                this.Foto = imagen;
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
