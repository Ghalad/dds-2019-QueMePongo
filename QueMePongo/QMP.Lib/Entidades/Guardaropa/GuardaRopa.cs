using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Guardaropa
{
    public class GuardaRopa
    {
        public List<Prenda> prendas; 

        //public Atuendo UnAtuendo;
        // Me parece mas apropiado que el guardarropa guarde el conjunto de prendas totales que tiene
        // y que los atuendos sea algo dinámico que se vaya definiendo según la combinación de prendas

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

    }
}
