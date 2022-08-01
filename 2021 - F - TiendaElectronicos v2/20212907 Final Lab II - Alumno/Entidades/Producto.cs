using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Celular))]
    public abstract class Producto
    {
        protected string modelo;
        protected string marca;
        protected float precio;
        public string Modelo {get; set; }
        public string Marca { get; set; }
        public float Precio { get; set; }

        public abstract string Garantia { get; }


        public Producto() { }
        public Producto(string mod, float precio, string marca) {
            this.Modelo = mod; this.Precio = precio; this.Marca = marca;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Marca: {this.Marca}");
            sb.AppendLine($"Modelo: {this.Modelo}");
            sb.AppendLine($"Precio: {this.Precio}");

            return sb.ToString();
        }

        public static bool operator == (Producto p1, Producto p2)
        {
            if(p1.Marca == p2.Marca && p1.Modelo == p2.Modelo && p1.GetType() == p2.GetType())
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Producto p1, Producto p2) { return !(p1 == p2); }

        public static bool operator == (List<Producto>l, Producto p)
        {
            foreach (Producto i in l)
            {
                if (p == i) { return true; }
            }
            return false;
        }

        public static bool operator !=(List<Producto> l, Producto p)
        {
            foreach (Producto i in l)
            {
                if (p == i) { return false; }
            }
            return true;
        }
    }
}
