using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ListaExtended
    {
        public static string InfoDeLaLista(this List<Producto> lista)
        {
            StringBuilder s = new StringBuilder();
            foreach (var item in lista)
            {
                s.AppendLine(item.ToString());
            }
            return s.ToString();
            //return lista.ToString();
        }
    }
}
