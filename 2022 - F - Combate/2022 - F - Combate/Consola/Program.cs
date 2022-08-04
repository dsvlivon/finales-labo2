using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Comun;
using Entidades;


namespace Consola
{
    class Program
    {
        /*
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine(rnd.TirarMoneda());
            Console.WriteLine(rnd.TirarMoneda());
            Console.WriteLine(rnd.TirarMoneda());
            Console.WriteLine(rnd.TirarMoneda().GetType());


            //Personaje p = new Personaje(111, "  Jorge");
            //Console.WriteLine(p.ToString());
            //Personaje p2 = new Personaje(1112, "Goku", 10);
            //Console.WriteLine(p2.ToString());
            //Personaje p3 = new Personaje(1113, "Gohan", 100);
            //Console.WriteLine(p3.ToString());
            //Personaje p3x = new Personaje(1113, "Roshi", 150);
            //Console.WriteLine(p3x.ToString());
            //Personaje p4 = new Personaje(1114, "Buu   ");
            //Console.WriteLine(p4.ToString());


            Hechicero p = new Hechicero(111, "  Jorge");
            //Console.WriteLine(p.ToString());
            Personaje p2 = new Guerrero(1112, "Goku", 10);
            //Console.WriteLine(p2.ToString());
            Personaje p3 = new Guerrero(1113, "Gohan", 100);
            //Console.WriteLine(p3.ToString());
            Hechicero p3x = new Hechicero(1113, "Roshi", 150);
            //Console.WriteLine(p3x.ToString());
            Personaje p4 = new Guerrero(1114, "Buu   ");
            //Console.WriteLine(p4.ToString());

            //Console.WriteLine(p4.GetHashCode());

            Combate c = new Combate(p, p2);

            Console.WriteLine("\nArranca: " + (Combate.SeleccionarPrimerAtacante(p, p2)).ToString());//deberia devolver p="jorge"
            Console.WriteLine("\nArranca: " + (Combate.SeleccionarPrimerAtacante(p, p4)).ToString());//tira random...


            Console.ReadLine();
        }*/
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void Main(string[] args)
        {
            Thread hilo;
            Personaje personaje1 = PersonajeDAO.ObtenerUnPersonajePorId(1);
            Console.WriteLine(personaje1.ToString());
            Personaje personaje2 = PersonajeDAO.ObtenerUnPersonajePorId(2);
            Console.WriteLine(personaje2.ToString());
            Combate combate = new Combate(personaje1, personaje2);
            Console.WriteLine("¡FIGHT!");
            hilo = combate.IniciarCombate();

            Thread.Sleep(2000);//FALTA CAMBIAR LO DE LA TASK X EL THREAD

            //Y TAMBIEN FALTA LA PARTE VI Y VII.....  es putamente interminable esto....
            Console.ReadLine();
        }
        static void IniciarRonda(IJugador atacante, IJugador atacado)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"¡{atacante} ataca a {atacado}!");
        }
        static void FinalizarCombate(IJugador ganador)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Combate finalizado. El ganador es {ganador}.");
        }
        static void MostrarAtaqueLanzado(Personaje personaje, int puntosDeAtaque)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{personaje} lanzó un ataque de {puntosDeAtaque} puntos.");
            }
        static void MostrarAtaqueRecibido(Personaje personaje, int puntosDeAtaque)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{personaje} recibió un ataque por {puntosDeAtaque} puntos.Le quedan { personaje.PuntosDeVida} puntos de vida.");
            }



    }
}
