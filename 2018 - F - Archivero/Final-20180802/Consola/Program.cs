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

            Archivo a = new Archivo("radio", "UT");
            //Console.WriteLine(a.ToString());

            //DiscoElectronico d = new DiscoElectronico(5);
            //d.Guardar(a);
            //d.Leer("Archivo");

            //foreach (var i in d.archivosGuardados)
            //{
            //    Console.WriteLine(i.ToString());
            //}
            ArchiveroFisico f = new ArchiveroFisico("C:/Users/L54556/OneDrive - Kimberly-Clark/Desktop/PRACTICA/2018 - F - Archivero/",4);
            //DiscoElectronico d = new DiscoElectronico(4);
            f.Guardar(a);
            foreach (var i in f.Leer("banda")) { Console.WriteLine((string)i); }
            Console.ReadLine();
        }
    }
}
