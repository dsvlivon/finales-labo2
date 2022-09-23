using System;

namespace BibliotecaDeClases
{

    // DESARROLLAR
    public class Puesto : ICompensacion
    {
        Random rnd;

        string nombrePuesto;
        float remuneraciónOfrecida;

        private Puesto()
        {
            this.remuneraciónOfrecida = GeneradorDeDatos.Rnd.Next(10000, 30000);
        }

        public Puesto(string nombre) : this()
        {
            this.nombrePuesto = nombre;
        }

        public string Posicion
        {
            get
            {
                return this.nombrePuesto;
                //=> nombrePuesto; } //probar si la expresion funca
            }
        }

        public float CalcularHonorarios
        {
            get
            {
                return this.remuneraciónOfrecida;
            }
        }

        public override string ToString()
        {
            return "Se busca " + this.nombrePuesto + " - " + "Sueldo ofrecido: " + CalcularHonorarios.ToString();
        }
    }
}
