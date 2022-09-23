using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Comun;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine(rnd.TirarMoneda());
            Console.WriteLine(rnd.TirarMoneda());
            Console.WriteLine(rnd.TirarMoneda());
            Console.WriteLine(rnd.TirarMoneda());

            Personaje p = new Personaje(1111, "q");
            Personaje p2 = new Personaje(1112, "b",10);
            Personaje p3 = new Personaje(1113, "c", 100);
            Personaje p3x = new Personaje(1113, "c", 150);
            Personaje p4 = new Personaje(1114, "d");

            Console.WriteLine(p4.GetHashCode());

            Console.ReadLine();
        }
    }
}
