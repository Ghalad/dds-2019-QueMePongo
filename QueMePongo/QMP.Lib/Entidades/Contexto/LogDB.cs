using Ar.UTN.QMP.Lib.Entidades.Logs;
using System;

namespace Ar.UTN.QMP.Lib.Entidades.Contexto
{
    public class LogDB
    {
        public void Fatal(string fullClassName, string mensaje)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                Log log = new Log();
                log.Level = "FATAL";
                log.NameSpace = fullClassName;
                log.Mensaje = mensaje;
                log.FechaCreacion = DateTime.Now;

                db.Logs.Add(log);
                db.SaveChanges();
            }
        }
        public void Debug(string fullClassName, string mensaje)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                Log log = new Log();
                log.Level = "DEBUG";
                log.NameSpace = fullClassName;
                log.Mensaje = mensaje;
                log.FechaCreacion = DateTime.Now;

                db.Logs.Add(log);
                db.SaveChanges();
            }
        }
    }
}
