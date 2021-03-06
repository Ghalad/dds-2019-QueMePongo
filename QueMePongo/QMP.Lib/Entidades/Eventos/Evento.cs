﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;

namespace Ar.UTN.QMP.Lib.Entidades.Eventos
{
    [Table("Eventos")]
    public class Evento
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int EventoId { get; set; }
        public string Descripcion { get; set; }
        public string CiudadEvento { get; set; }
        public DateTime FechaEvento { get; set; }
        public Caracteristica TipoEvento { get; set; }
        public string Repeticion { get; set; }


        public Evento() { }
        public Evento(string tipoEvento, DateTime fecha, string cuidad, string descripcion, string repeticion)
        {
            string clave = "EVENTO";
            GestorCaracteristicas GeCa = GestorCaracteristicas.GetInstance();

            if (!string.IsNullOrWhiteSpace(tipoEvento))
            {
                if (!string.IsNullOrWhiteSpace(cuidad))
                {
                    if (GeCa.ExisteCaracteristica(clave, tipoEvento))
                    {
                        if (this.EsUnaRepeticionValida(repeticion)) 
                        {
                            this.FechaEvento = fecha;
                            this.Descripcion = descripcion;
                            this.CiudadEvento = cuidad;
                            this.Repeticion = repeticion.ToUpper();
                            this.TipoEvento = GeCa.ObtenerCaracteristica(clave, tipoEvento);
                        }
                        else
                            throw new Exception("La frecuencia del evento debe ser una de las siguientes : A DIARIO, SEMANAL, MENSUAL, ANUAL");
                    }
                    else
                        throw new Exception(string.Format("No existe el evento [{0}]", tipoEvento));
                }
                else
                    throw new Exception("Debe informar la ciudad donde ocurrira el evento");
            }
            else
                throw new Exception("Debe informar el tipo de evento");
        }

        private bool EsUnaRepeticionValida(string repeticion)
        {
            switch (repeticion.ToUpper())
            {
                case "UNICO":
                case "A DIARIO":
                case "SEMANAL":
                case "MENSUAL":
                case "ANUAL":
                    return true;
                default:
                    return false;
            }
        }

        public bool SeRepite()
        {
            return Repeticion != "UNICO";
        }

        public Evento ObtenerSiguiente()
        {
            return new Evento(this.TipoEvento.Valor, this.ObtenerSiguienteFecha(), this.CiudadEvento, this.Descripcion, this.Repeticion);
        }

        private DateTime ObtenerSiguienteFecha()
        {
            switch (this.Repeticion.ToUpper())
            {
                case "A DIARIO":
                    return this.FechaEvento.AddDays(1);
                case "SEMANAL":
                    return this.FechaEvento.AddDays(7);
                case "MENSUAL":
                    return this.FechaEvento.AddMonths(1);
                case "ANUAL":
                    return this.FechaEvento.AddYears(1);
                default:
                    throw new Exception("Error de programación en evento, ObtenerSiguienteFecha");
            }
        }
    }
}
