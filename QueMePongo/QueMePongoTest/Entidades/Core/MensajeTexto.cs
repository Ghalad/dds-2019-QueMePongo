using System;
using Ar.UTN.QMP.Lib.Entidades.Comunicacion;

namespace Ar.UTN.QMP.Test.Entidades.Core
{
    public class MensajeTexto : ComunicacionAdapter
    {
        public void Notificar(string mensaje)
        {
            Console.WriteLine("BRIP! BRIP!");
            Console.WriteLine(string.Format("Mensaje recibido: [{0}]", mensaje));
        }
    }
}
