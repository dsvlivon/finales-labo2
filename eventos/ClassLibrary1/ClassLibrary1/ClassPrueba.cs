using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public delegate void miDelegado1(int a, int b);
    public delegate void miDelegado2();
    public delegate void miDelegado3(string m);

    public static class ClassPrueba
    {
        public static event miDelegado1 eventoUno;
        public static event miDelegado2 eventoDos;
        public static event miDelegado3 eventoTres;

        public static int valor;
        public static string nombre;
        public static string msg;
        public static string rta;

        static void MetodoY() { msg = "Me cago en estos eventos del orto!!!"; }
        static void MetodoX() { nombre = "Coco Cocardi"; }
        static void MetodoZ(int num1, int num2) { valor = num1 + num2; }
        static void MetodoW(string s) { rta = s+"\n-Si, lo juro!"; }

        public static void InvocarEventos()
        {
            eventoUno.Invoke(1, 3);
            eventoDos?.Invoke();
        }

        static ClassPrueba()
        {
            eventoUno += MetodoZ;
            eventoDos += MetodoX;
            eventoDos += MetodoY;
            eventoTres += MetodoW;
        }
        public static void InvocarEventosMsg()
        {
            eventoDos?.Invoke();
        }

        public static void InvocarEventosRta(string s)
        {
            eventoTres?.Invoke(s);
        }

    }
}
