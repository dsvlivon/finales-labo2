using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Televisor : Producto
    {
        private int pulgadas;

        public override string Garantia {
        get {
                if (this.pulgadas > 40) { return "Garantia de 48 meses"; }
                else { return "Garantia de 24 meses"; }
            }
        }
        public Televisor(string marca, string mod, int pulg, float precio): 
            base(mod, precio, marca) {
            this.pulgadas = pulg;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Televisor de {this.pulgadas}");
            sb.AppendLine(base.ToString());
            return sb.ToString();
        }
    }
}
