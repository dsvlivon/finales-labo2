using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CONSOLA DE PRUEBAS");
            List<Producto> l = new List<Producto>();

            //MiObjeto p = new MiObjeto("Carlos");
            //Console.WriteLine(p.ToString());

            //public Celular(string mod, float precio, string marca, int mpx, bool oferta) 
            Celular c = new Celular("C01", 12000, "SONY", 32, true);
            //Console.WriteLine(c.ToString());

            //public Televisor(string marca, string mod, int pulg, float precio): 
            Televisor t = new Televisor("SONY", "TV01", 55, 75000);
            //Console.WriteLine(t.ToString());

            //ManejadorArchivos<Celular> m = new ManejadorArchivos<Celular>();
            //.GenerarLog("msg de prueba");
            //l.AddRange(ManejadorBaseDeDatos.ObtenerProductos());
            //l.Add(c);
            //l.Add(t);

            //Tienda.Stock = l;
            //foreach (var x in l)
            //{
            //    Console.WriteLine(x.ToString());
            //}

            //Tienda.ObtenerTelevisores();
            //Tienda.ObtenerCelulares();
            Tienda.CargarDatos();

            List<Producto> l2 = Tienda.Stock;
            foreach (var x in l2)
            {
                Console.WriteLine(x.ToString());
            }


            //Console.WriteLine(Tienda.InfoTienda());
            Console.WriteLine("FINAL");
            Console.ReadLine();
        }
    }
}
