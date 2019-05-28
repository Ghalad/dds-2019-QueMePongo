using System;
using System.Collections.Generic;
using static Ar.UTN.QMP.Lib.Entidades.Atuendos.Tipos;

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
            {
                if (c.Nombre.Equals(caracteristica.Nombre))
                    return;
            }
            this.Caracteristicas.Add(caracteristica);
        }

        public bool TieneCaracteristica(Caracteristica caracteristica)
        {
            foreach(Caracteristica c in this.Caracteristicas)
                if(c.Nombre.Equals(caracteristica.Nombre) && c.Valor.Equals(caracteristica.Valor))
                    return true;
            return false;
        }

        public bool TieneCaracteristica(string clave, string valor)
        {
            foreach (Caracteristica c in this.Caracteristicas)
                if (c.Nombre.Equals(clave.ToUpper()) && c.Valor.Equals(valor.ToUpper()))
                    return true;
            return false;
        }

        public bool TieneCaracteristica(string clave)
        {
            foreach (Caracteristica c in this.Caracteristicas)
                if (c.Nombre.Equals(clave.ToUpper()))
                    return true;
            return false;
        }

        public bool TieneColorPrimario(TColores color)
        {
            foreach (Caracteristica c in this.Caracteristicas)
                if (c.Nombre.Equals("COLOR_PRIMARIO"))
                {
                    switch (color)
                    {
                        case TColores.NEGRO:  if (c.Valor.Equals("NEGRO")) return true; break;
                        case TColores.BLANCO: if (c.Valor.Equals("BLANCO")) return true; break;
                        case TColores.AZUL:   if (c.Valor.Equals("AZUL")) return true; break;
                        case TColores.VERDE:  if (c.Valor.Equals("VERDE")) return true; break;
                        case TColores.ROJO:   if (c.Valor.Equals("ROJO")) return true; break;
                        default: break;
                    }
                }
            return false;
        }
    }
}
