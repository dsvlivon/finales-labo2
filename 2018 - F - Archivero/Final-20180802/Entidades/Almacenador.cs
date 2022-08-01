using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   //Crear un constructor que reciba y asigne el/los atributos de la misma.
   //La clase debe ser abstracta.
   //Crear un método abstracto llamado MostrarArchivos que retorne void.
    public abstract class Almacenador
    {
        public int capacidad;
        public Almacenador(int cap)
        {
            this.capacidad = cap;
        }
        public Almacenador()
        {
            this.capacidad = 5;
        }
        public abstract void MostrarArchivos();
    }
}
