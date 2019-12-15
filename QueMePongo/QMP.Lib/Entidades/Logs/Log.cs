using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ar.UTN.QMP.Lib.Entidades.Logs
{
    [Table("Logs")]
    public class Log
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Logid { get; set; }
        public string Level { get; set; }
        public string NameSpace { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
