using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConstructoresPaciente()
        {
            Paciente p1 = new Paciente("Nombre", "Apellido");
            Console.WriteLine("Turno p1:" + p1.Turno);
            Paciente p2 = new Paciente("Nombre", "Apellido", 5);
            Console.WriteLine("Turno p2:" + p2.Turno);
            Paciente p3 = new Paciente("Nombre", "Apellido");
            Console.WriteLine("Turno p3:" + p3.Turno);
            //p3.Turno = 1
            Assert.AreEqual(6, p3.Turno);
        }
    }
}
