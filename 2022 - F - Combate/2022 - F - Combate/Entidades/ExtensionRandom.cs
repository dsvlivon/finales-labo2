using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /*Extenderá el tipo Random y le agregará el método de extensión TirarUnaMoneda que 
     retornará de forma aleatoria alguno de los valores del enumerado LadosMoneda*/
    public static class ExtensionRandom
    {
        public static Enum TirarMoneda(this Random r)
        {
            if (r.Next(1, 3) == 1)
            {
                return LadosMoneda.cara;
            } else {
                return LadosMoneda.ceca; 
            }
        }
    }
}
