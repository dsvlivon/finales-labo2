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
            int noni = (Medico.tiempoAleatorio.Next(1500, 2000));
            Console.WriteLine("Atender - tiempo de espera: "+noni);
            Thread.Sleep(noni);
            this.FinalizarAtencion();
        }

        public void IniciarAtencion(Paciente p)
        {
            Thread hilo = new Thread(Atender);
            hilo.Start();
            this.PacienteActual = p;
            Console.WriteLine("Iniciando atencion\n");
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
