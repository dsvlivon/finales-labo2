using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public static class ExtensionRandom
    {
        public static Enum TirarMoneda(this Random r)
        {
            if (r.Next(1, 3) == 1)
            {
                return LadosMoneda.Cara;
            } else { return LadosMoneda.Ceca; }
        }
    }
}
