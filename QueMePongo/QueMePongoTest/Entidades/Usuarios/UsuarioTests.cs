using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Reglas;

namespace Ar.UTN.QMP.Lib.Entidades.Usuarios.Tests
{
    [TestClass()]
    public class UsuarioTests
    {
        Atuendo atuendo1;
        Regla regla1;
        List<Caracteristica> listaCar;
        PrendaBuilder pb;
        Usuario usr;

        [TestInitialize]
        public void Initialize()
        {
            this.atuendo1 = new Atuendo();
            this.regla1 = new Regla();
            this.listaCar = new List<Caracteristica>();
            this.pb = new PrendaBuilder();
            this.usr = new UsrPremium();
        }




    }
}