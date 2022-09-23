using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Comun;

namespace Entidades
{
    public delegate void Atacar(Personaje p, int i);
    public abstract class Personaje //: IJugador
    {
        public event Atacar AtaqueLanzado;
        public event Atacar AtaqueRecibido;

        public const short minLvl = 1; 
        public const short maxLvl = 100;

        private decimal id;
        private short nivel;
        private string nombre;

        protected int puntosDeDefensa;
        protected int puntosDePoder;
        protected int puntosDeVida;

        private static Random random;
        private string titulo;

        public string Titulo { set { this.titulo = value; } }

        protected abstract void AplicarBeneficiosDeClase();
        public override bool Equals(Object obj) {
            Personaje p = obj as Personaje;
            return (p != null) && (id == p.id);
        }

        //public override decimal GetHashCode()
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
            //return Convert.ToDecimal(this.id.GetHashCode());
        }

        public static bool operator ==(Personaje p1, Personaje p2)
        {
            if(p1.id.GetHashCode() == p2.id.GetHashCode()) { return true; }
            return false;
        }
        public static bool operator !=(Personaje p1, Personaje p2)
        {
            return !(p1==p2);
        }

        static Personaje() { random = new Random(); }
        public Personaje(decimal id, string nombre) {
            this.id = id;
            ValidarDatos(nombre);            
            this.filler();
            this.nivel = 1;
        }
        public Personaje(decimal id, string nombre, short nivel):
            this(id, nombre){
            ValidarNivel(nivel);
            this.filler();
        }
        public override string ToString()
        {
            return base.ToString();
        }

        void filler() { this.puntosDeDefensa = 100; this.puntosDePoder = 100; this.puntosDeVida = 500; }

        void ValidarDatos(string s)
        {
            string x = s.Trim();
            try { 
                if (x == "" || x == null) {
                
                    throw new ArgumentNullException();
                } else {
                    this.nombre = s; 
                }
            } catch (Exception e)
            {

            }
        }

        void ValidarNivel(short n) {
            try
            {
                if(n>=minLvl && n <= maxLvl)
                {
                    this.nivel = n;
                } else {
                    throw new BusinessException("el nivel esta fuera de rango");    
                }
            } catch (Exception e) { }
        }
        /*Se detendrá el hilo de ejecución por un tiempo aleatorio de entre 1 y 5 
        segundos.
        - Retornará los puntos de ataque que tendrán un valor de entre un 10% y 
        un 100% de los puntos de poder. El porcentaje a aplicar se debe definir de 
        manera aleatoria.
        - Por último, lanza el evento AtaqueLanzado pasándole como argumentos a 
        la instancia del personaje que está atacando y los puntos de ataque 
        calculados. Sólo lanza el evento si el mismo tiene subscriptores.
*/
        static int Atacar(Personaje p)
        {
            int time= random.Next(1, 5);
            
            int pow = Convert.ToInt32((p.puntosDePoder*random.Next(10, 100))/100);
            
            Thread.Sleep(time);
            p.AtaqueLanzado?.Invoke(p, pow);//se refiere al invoke
            return pow;
        }

        static void defender(int ataque) {
            int pow = Convert.ToInt32((p.puntosDePoder * random.Next(10, 100)) / 100);
        }
    }
}
