using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class MEspecialista:Medico, IMedico
    {
        private Especialidad especialidad;
        //private Thread hilo;

        protected override void Atender()
        {
            //int noni = (Medico.tiempoAleatorio.Next(5000, 10000));
            int noni = (Medico.tiempoAleatorio.Next(2000, 2500));
            this.FinalizarAtencion();
            
            Console.WriteLine("Atender - tiempo de espera: "+noni);
            Thread.Sleep(noni);
        }

        public void IniciarAtencion(Paciente p)
        {
            Thread hilo = new Thread(Atender);
            this.PacienteActual = p;
            hilo.Start();

            //Console.WriteLine("Iniciando atencion\n");
        }

        public MEspecialista(string n, string a, Especialidad e):base(n,a)
        {
            this.especialidad = e;
        }
        public enum Especialidad
        {
            Traumatologo, Odontologo
        }
        
    }
}
