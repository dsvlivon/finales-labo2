using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MiObjeto
    {
        private string nombre;
        public MiObjeto(string n)
        {
            this.Nombre = n;
        }
        public string Nombre { get; set; }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {this.Nombre}");

            return sb.ToString();
        }
    }
}
