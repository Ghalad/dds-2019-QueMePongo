using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Reglas
{
    public class Regla
    {
        public List<Condicion> Condiciones { get; set; }

        public Regla()
        {
            //this.Condiciones = new List<Condicion>(); 

            //podríamos usar Singleton para esta instancia 
            
            // |
            // V

            Operador menorATres = new OperadorMenor(2);
            Caracteristica caractSuperior = new Caracteristica("Zona", "Superior");
            Condicion unaPrendaSuperior = new CondicionComparacion(cantidadSuperior, caractSuperior);
            
            Caracteristica caractInferior = new Caracteristica("Zona", "Inferior");
            Condicion unaPrendaInferior = new CondicionUnitaria(caractInferior);

            Caracteristica caractCalzado = new Caracteristica("Zona", "Calzado");
            Condicion unCalzado = new CondicionUnitaria(caractCalzado);

            Condiciones.Add(unaPrendaSuperior);
            Condiciones.Add(unaPrendaInferior);
            Condiciones.Add(unCalzado);

        }

        public bool Validar(Atuendo atuendo)
        {
            foreach(Condicion condicion in this.Condiciones)
            {
                if (!condicion.Validar(atuendo))
                {
                    return false; // ATUENDO VALIDA
                }
            }

            return true; // ATUENDO INVALIDO
        }
    }
}
