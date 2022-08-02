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
            Console.WriteLine("Atender!");
            Thread.Sleep(Medico.tiempoAleatorio.Next(5000, 10000));
            this.FinalizarAtencion();
        }

        public void IniciarAtencion(Paciente p)
        {
            Thread hilo = new Thread(Atender);
            hilo.Start();
            this.PacienteActual = p;
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
