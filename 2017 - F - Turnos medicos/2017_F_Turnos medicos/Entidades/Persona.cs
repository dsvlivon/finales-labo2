using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        protected string nombre;
        protected string apellido;
        public Persona(string n, string a)
        {
            this.apellido = a; this.nombre = n;
        }
    }
}
