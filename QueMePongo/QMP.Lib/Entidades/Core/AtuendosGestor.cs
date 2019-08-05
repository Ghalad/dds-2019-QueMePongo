using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Clima;
using Ar.UTN.QMP.Lib.Entidades.Eventos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Condiciones;
using Ar.UTN.QMP.Lib.Entidades.Reglas.Operadores;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;

namespace Ar.UTN.QMP.Lib.Entidades.Core
{
    public class AtuendosGestor
    {
        public List<Atuendo> atuendos { get; set; }
        private static AtuendosGestor Instance { get; set; }

        #region CONSTRUCTOR
        private AtuendosGestor() { atuendos = new List<Atuendo>(); }
        public static AtuendosGestor GetInstance()
        {
            if (Instance == null) Instance = new AtuendosGestor();
            return Instance;
        }
        #endregion CONSTRUCTOR

        public void FiltrarAtuendosTemperatura(decimal temperatura) //próximamente recibe como parámetro la ciudad
        {
            int minimoPrendas;
            int maximoPrendas;
            if (temperatura < 11)
            {
                maximoPrendas = 9999;
                minimoPrendas = 6;
            }
            else if (temperatura < 17)
            {
                maximoPrendas = 5;
                minimoPrendas = 5;
            }
            else
            {
                maximoPrendas = 4;
                minimoPrendas = 1;
            }

            foreach (Atuendo a in this.atuendos.ToList())
            {
                if (a.CantidadDePrendas() > maximoPrendas || a.CantidadDePrendas() < minimoPrendas)
                {
                    this.atuendos.Remove(a);
                }
            }
        }
        public void FiltrarAtuendosRegla(Regla regla)
        {
            foreach (Atuendo a in this.atuendos.ToList())
            {
                if (!regla.Validar(a))
                {
                    this.atuendos.Remove(a);
                }
            }
        }
        public void FiltrarAtuendosEvento(Evento evento)
        {
            Regla unaRegla = new Regla();
            List<Caracteristica> listaCar = new List<Caracteristica>();
            listaCar.Add(evento.GetEstilo());
            unaRegla.AgregarCondicion(new CondicionComparacion(new OperadorIgual(0), listaCar));

            WeatherServiceAdapter clima = OpenWeatherService.GetInstance();
            clima.SetCiudad("AR", "Buenos Aires"); //la idea es que use la ciudad del evento
            //clima.SetCiudad("AR", evento.GetCiudad());
            decimal temperatura = clima.ObtenerTemperatura();

            this.FiltrarAtuendosTemperatura(temperatura);
            this.FiltrarAtuendosRegla(unaRegla);
        }
        public void FiltrarAtuendosSuperpuestos()
        {
            Regla regla = new Regla();
            List<Caracteristica> listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "1"));
            regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "2"));
            regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "3"));
            regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            listaCar = new List<Caracteristica>();
            listaCar.Add(new Caracteristica("categoria", "superior"));
            listaCar.Add(new Caracteristica("superposicion", "4"));
            regla.AgregarCondicion(new CondicionComparacion(new OperadorMayor(1), listaCar));

            this.FiltrarAtuendosRegla(regla);
        }
        public void GenerarTodosLosAtuendosPosibles(Usuario usr)
        {
            Atuendo atuendo;
            List<Prenda> prendas;
            int n;

            foreach (Guardarropa g in usr.GetGuardarropas())
            {
                prendas = g.ObtenerPrendas();
                n = prendas.Count;

                while (n != 0)
                {
                    foreach (var row in new Combinaciones.Combinaciones(prendas.Count, n).GetRows())
                    {
                        atuendo = new Atuendo();
                        foreach (var seleccion in Combinaciones.Combinaciones.Permute(row, prendas))
                            atuendo.AgregarPrenda(seleccion);
                        atuendos.Add(atuendo);
                    }

                    n = n - 1;
                }
            }
        }
        public void MostrarAtuendos()
        {
            int i = 1;
            foreach (Atuendo a in atuendos)
            {
                Console.WriteLine(string.Format("Atuendo {0} \n", i));
                foreach (Prenda p in a.Prendas)
                {
                    p.MostrarPorPantalla();
                }
                Console.WriteLine("\n");
                i++;
            }
        }

        public List<Atuendo> ObtenerAtuendos()
        {
            return atuendos;
        }
    }
}
