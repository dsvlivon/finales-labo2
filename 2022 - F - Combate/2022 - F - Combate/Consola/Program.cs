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
            Random rnd = new Random();
            Console.WriteLine(rnd.TirarMoneda());
            Console.WriteLine(rnd.TirarMoneda());
            Console.WriteLine(rnd.TirarMoneda());
            Console.WriteLine(rnd.TirarMoneda());


            Console.ReadLine();
        }
    }
}
