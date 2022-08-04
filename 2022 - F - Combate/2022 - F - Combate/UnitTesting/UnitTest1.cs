using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Comun; using Entidades;
namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InicioCorrectoDePuntosDeVida()
        {
            Hechicero p = new Hechicero(111, "  Jorge");
            //Console.WriteLine(p.PuntosDeVida);
            Personaje p2 = new Guerrero(1112, "Goku", 10);
            //Console.WriteLine(p2.PuntosDeVida);

            Assert.AreEqual(500, p.PuntosDeVida);
            Assert.AreEqual(500, p2.PuntosDeVida);
        }

        [TestMethod]
        public void BusinessExceptionLanzada()
        {
            Hechicero p3x = new Hechicero(1113, "Roshi", 150);

            Assert.AreEqual(1, p3x.Nivel);
        }
    }
}
