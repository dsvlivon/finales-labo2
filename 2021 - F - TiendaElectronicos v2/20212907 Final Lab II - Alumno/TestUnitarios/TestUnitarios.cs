using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        [TestMethod]
        public void DosObjetosNoSonIguales()
        {
            Producto producto1 = new Celular("motorola", 25000, "g20", 25, true);
            Producto producto2 = new Celular("motorol", 25000, "g20", 25, true);

            Assert.AreNotEqual(producto1, producto2);
        }
        [TestMethod]
        public void InstanciaDeUnObjeto()
        {
            Producto producto = new Televisor("noblex", "Smart", 50, 10000);

            Assert.IsNotNull(producto);
        }
        [TestMethod]
        public void ListaTiendaIsNotNull()
        {
            Tienda.CargarDatos();
            List<Producto> l = Tienda.listar();
            
            Assert.IsNotNull(l);
        }
    }
}
