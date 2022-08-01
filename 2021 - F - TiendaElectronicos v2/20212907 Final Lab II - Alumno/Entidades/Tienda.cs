using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoProducto();
    public static class Tienda
    {
        private static event DelegadoProducto eventoObtenerDAtos;
        static private List<Producto> stock;
        //public static List<Producto> Stock { get; set; }
        public static List<Producto> Stock { get { return stock; } }
        public static void CargarDatos() { eventoObtenerDAtos?.Invoke(); }//
        public static string InfoTienda() {
            return stock.InfoDeLaLista();
        }
        public static void ObtenerCelulares() {
            ManejadorArchivos<Producto> m = new ManejadorArchivos<Producto>();
            List<Producto> l = m.Leer2();
            foreach (Producto p in l)
            {
                if (stock.Count == 0 || stock != p)//p eso sobrecargaste el list<Producto>, Producto p
                {
                    stock.Add(p);
                }
            }
        }
        public static void ObtenerTelevisores() {
            List<Producto> l = ManejadorBaseDeDatos.ObtenerProductos();
            if (l != null) { stock.AddRange(l); }
        }

        static Tienda()
        {
            stock = new List<Producto>();
            eventoObtenerDAtos += ObtenerTelevisores;
            eventoObtenerDAtos += ObtenerCelulares;//asignar = agregar = escuchar
            //unCelu();
        }
        private static void unCelu() {
            Celular c = new Celular("C01", 12000, "SONY", 32, false);
            stock.Add(c);
        }

        public static List<Producto> listar() { return stock; }
    }
}
