using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Guardaropa
{
    public class Guardarropa
    {
        private List<Prenda> Accesorios { get; set; }
        private List<Prenda> PartesSuperior { get; set; }
        private List<Prenda> partesInferior { get; set; }
        private List<Prenda> Calzados { get; set; }

        private List<Atuendo> Atuendos { get; set; }
        public List<Regla> Reglas { get; set; }

        public Guardarropa()
        {
            this.Accesorios = new List<Prenda>();
            this.PartesSuperior = new List<Prenda>();
            this.partesInferior = new List<Prenda>();
            this.Calzados = new List<Prenda>();
            this.Atuendos = new List<Atuendo>();
            this.Reglas = new List<Regla>();
        }

        //public Atuendo UnAtuendo;
        // Me parece mas apropiado que el guardarropa guarde el conjunto de prendas totales que tiene
        // y que los atuendos sea algo dinámico que se vaya definiendo según la combinación de prendas

        /*
        public void atuendosPosibles()
        {
            Atuendos atuendoAux = new Atuendo();

            Caracteristica caractSuperior = new Caracteristica("Zona", "Superior");
            Caracteristica caractInferior = new Caracteristica("Zona", "Inferior");
            Caracteristica caractCalzado = new Caracteristica("Zona", "Calzado");
            Caracteristica caractAccesorio = new Caracteristica("Zona", "Accesorio");

            foreach (Prenda p in prendas)
            {
                if( p.tieneCaracteristica(caractSuperior))
                {
                    atuendoAux.agregarPrenda(p);

                    foreach ( Prenda p2 in prendas)
                    {
                        if( p2.tieneCaracteristica(caractInferior))
                        {
                            atuendoAux.agregarPrenda(p2);
                            atuendoAux.mostrar(); //acá lo mostraría descalzo. solo prenda superior e inferior

                            foreach( Prenda p3 in prendas)
                            {
                                if( p3.tieneCaracteristica(caractCalzado))
                                {
                                    atuendoAux.agregarPrenda(p3);
                                    atuendoAux.mostrar(); //hasta acá lo muestra con calzado sin accesorios
                                    foreach( Prenda p4 in prendas)
                                    {
                                        if( p4.tieneCaracteristica(caractAccesorio))
                                        {
                                            atuendoAux.agregarPrenda(p4);
                                            atuendoAux.mostrar(); //acá lo muestra con un accesorio
                                            atuendoAux.quitarPrenda(p4);
                                        }
                                    }
                                    atuendoAux.quitarPrenda(p3);
                                }
                            }

                            atuendoAux.quitarPrenda(p2);
                        }
                    }

                    atuendoAux.quitarPrenda(p);
                }
            }
        }
        */

        public void AgregarPrenda(Prenda unaPrenda)
        {
            if (unaPrenda.TieneCaracteristica(new Caracteristica("categoria", "accesorio")))
                this.Accesorios.Add(unaPrenda);
            else if (unaPrenda.TieneCaracteristica(new Caracteristica("categoria", "superior")))
                this.PartesSuperior.Add(unaPrenda);
            else if (unaPrenda.TieneCaracteristica(new Caracteristica("categoria", "inferior")))
                this.partesInferior.Add(unaPrenda);
            else if (unaPrenda.TieneCaracteristica(new Caracteristica("categoria", "calzado")))
                this.Calzados.Add(unaPrenda);
        }

        public Atuendo ObtenerAtuendo()
        {
            bool validoRegla = true;

            foreach (Atuendo atuendo in this.Atuendos)
            {
                foreach (Regla regla in this.Reglas)
                {
                    if (regla.Validar(atuendo))
                        validoRegla = true;
                    else
                    {
                        validoRegla = false;
                        break;
                    }
                }

                if (validoRegla && !atuendo.EsUsado)
                {
                    atuendo.EsUsado = true;
                    return atuendo;
                }
            }
            return null;
        }

        public void GenerarAtuendos()
        {
            Atuendo atuendo;

            foreach(Prenda a in this.Accesorios)
            {
                foreach (Prenda ps in this.PartesSuperior)
                {
                    foreach (Prenda pi in this.partesInferior)
                    {
                        foreach (Prenda c in this.Calzados)
                        {
                            atuendo = new Atuendo();
                            atuendo.Prendas.Add(a);
                            atuendo.Prendas.Add(ps);
                            atuendo.Prendas.Add(pi);
                            atuendo.Prendas.Add(c);
                        }
                    }
                }
            }
        }







        /*
         * public int mostrarSiEsValido(Atuendo unAtuendo, Regla laRegla)
        {
            if (laRegla.Validar(unAtuendo))
            {
                unAtuendo.mostrar(); //atuendos válidos de 2 piezas
                return 1;
            }

            return 0;
        }


        public int probarConPrendaAdicional(Atuendo unAtuendo, int contador, Regla laRegla)
        {
            int cantidadValidos = 0;

            foreach (Prenda p in Prendas)
            {
                unAtuendo.AgregarPrenda(p);

                cantidadValidos += this.mostrarSiEsValido(unAtuendo, laRegla);

                if(contador < 6)
                {
                    contador = contador + 1;
                    cantidadValidos += this.probarConPrendaAdicional(unAtuendo, contador, laRegla);
                }

                unAtuendo.quitarPrenda(p);
            }

            return cantidadValidos;
        }

        public int atuendosPosibles(Regla laRegla)
        {
            Atuendo unAtuendo = new Atuendo();
            int contador = 1;

            return this.probarConPrendaAdicional(unAtuendo, contador, laRegla);
        }
        */
    }
}
