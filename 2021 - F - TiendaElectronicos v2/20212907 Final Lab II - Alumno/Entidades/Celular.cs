using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Celular:Producto
    {
        private int mpx;
        private bool oferta;

        public int Mpx { get; set; }
        public bool Oferta { get; set; }

        public Celular(){}

        public Celular(string mod, float precio, string marca, int mpx, bool oferta) 
            :base(mod, precio, marca)
        {
            this.Mpx = mpx; this.Oferta = oferta;
        }
        public override string Garantia
        {
            get
            {
                if(this.Marca == "Noblex") { return "Garantia de 12 meses";  }
                if (this.Mpx > 12) { return "Garantia de 36 meses"; }
                else { return "Garantia de 24 meses"; }
            }
        }
        /*El método ToString() utilizará el método ToString() de su clase base, mostrará también los 
        megapíxeles del celular, y por ultimo agregará como encabezado “Teléfono Celular */

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Telefono Celular");
            sb.AppendLine($"Mpx: {this.Mpx}");
            sb.AppendLine(base.ToString());
            return sb.ToString();
        }
    }
}
