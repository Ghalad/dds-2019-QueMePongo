using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace Ar.UTN.QMP.Lib.Entidades.Core.Tests
{
    [TestClass()]
    public class QueMePongoTests
    {
        [TestMethod()]
        public void SarasaTest()
        {
            QueMePongo qmp = QueMePongo.GetInstance();
            Usuario usr = new UsrGratis(100);

            Console.WriteLine("Main thread Start.");
            for (int i = 0; i < 10; i++)
            {
                //qmp.AgregarPedido(new Pedido(usr., i.ToString()));
                Thread.Sleep(1000);
            }

            Console.WriteLine("Main thread finished.");
        }
    }
}