using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;using Comun;

namespace Entidades
{
    public delegate void AtaqueDelegado(Personaje p, int i);
    
    public abstract class Personaje: IJugador
    {
        public static AtaqueDelegado AtaqueLanzado;
        public static AtaqueDelegado AtaqueRecibido;

        const short minLvl = 1;
        const short maxLvl = 100;
        private decimal id;
        private short nivel;
        private string nombre;

        protected int puntosDEDefensa;
        protected int puntosDePoder;
        protected int puntosDeVida;

        private static Random random;
        private string titulo;

        public string Titulo{ 
            set
            {
                this.titulo = value;
            }
        }

        public short Nivel
        {
            get { return this.nivel; }
        }

        public int PuntosDeVida
        {
            get { return this.puntosDeVida; }
        }

        public abstract void AplicarBeneficiosDeClase();

        public  override bool Equals(object obj)
        {
            Personaje p = obj as Personaje;
            return (p != null) && (id == p.id);
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
            //return Convert.ToDecimal(this.id.GetHashCode());
        }

        public static bool operator ==(Personaje p1, Personaje p2)
        {
            if(p1.GetHashCode() == p2.GetHashCode())
            {
                return true;
            } return false;
        }

        public static bool operator !=(Personaje p1, Personaje p2) { return !(p1 == p2); }

        static Personaje()
        {
            random = new Random();
        }

        public Personaje(decimal id, string nom)
        {
            ValidarNombre(nom);
            this.id = id;
            this.nivel = 1;

        }

        public Personaje(decimal id, string nom, short nivel):this(id, nom)
        {
            ValidarNivel(nivel);
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            if(this.titulo == ""||this.titulo == null)
            {
                sb.AppendLine("id: " + this.id);
                sb.AppendLine("nombre: " + this.nombre);
                sb.AppendLine("nivel: " + this.Nivel);
                sb.AppendLine("vida: " + this.PuntosDeVida);
                sb.AppendLine("poder: " + this.puntosDePoder);
                sb.AppendLine("defensa: " + this.puntosDEDefensa);
            } else {
                sb.AppendLine(this.nombre + ", " + this.titulo);
            }
            return sb.ToString();
        }

        public int Atacar()
        {
            int time = random.Next(1000, 5000);
            int pow = Convert.ToInt32((this.puntosDePoder / random.Next(10, 100)) / 100);

            Thread.Sleep(time);
            AtaqueLanzado?.Invoke(this, pow);//no se si puedo hacer eso...
            return pow;
        }

        public void RecibirAtaque(int puntosDeAtaque)
        {
            int ataqueFinal = puntosDeAtaque - Convert.ToInt32((this.puntosDEDefensa/random.Next(10, 100)) / 100);
            if (ataqueFinal > 0) { 
                if (ataqueFinal >= this.puntosDeVida)
                {
                    this.puntosDeVida = 0;
                } else {
                    this.puntosDeVida = this.PuntosDeVida - ataqueFinal;
                }
            } else { Console.WriteLine("tu ataque no m daña, insecto!"); }
            AtaqueRecibido?.Invoke(this, ataqueFinal);//no se si puedo hacer eso...
        }

        public void Filler()
        {
            this.puntosDEDefensa = 100; this.puntosDePoder = 100;this.puntosDeVida = 500;
        }

        void ValidarNombre(string n)
        {
            try
            {
                if(n!=null && n != "") { this.nombre = n; }
                else { throw new ArgumentNullException(); }

            } catch (Exception e) { }
        }
        void ValidarNivel(short n)
        {
            try
            {
                if (n>=minLvl && n<=maxLvl) { 
                    this.nivel = n; 
                }
                else { throw new BusinessException("error con el rango de niveles!!!"); }

            }
            catch (Exception e) { }
        }

       
    }
}
