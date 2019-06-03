using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Atuendos
{
    public class Prenda
    {
        private List<Caracteristica> Caracteristicas { get; set; }

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
                if (c.EsLaMisma(clave.ToUpper(), valor.ToUpper()))
                    return;
            this.Caracteristicas.Add(new Caracteristica(clave.ToUpper(), valor.ToUpper()));
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
                if (c.EsLaMisma(clave.ToUpper(), valor.ToUpper()))
                    return true;
            return false;
        }

        public bool TieneCaracteristica(string clave)
        {
            foreach (Caracteristica c in this.Caracteristicas)
                if (c.EsLaMismaClave(clave.ToUpper()))
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
    }
}
