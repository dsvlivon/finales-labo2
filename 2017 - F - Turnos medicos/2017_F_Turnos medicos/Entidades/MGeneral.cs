using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class MGeneral : Medico, IMedico
    {
        protected override void Atender()
        {
            Thread.Sleep(Medico.tiempoAleatorio.Next(1500, 2200));
            this.FinalizarAtencion();
        }

        public void IniciarAtencion(Paciente p)
        {
            Thread hilo = new Thread(Atender);
            hilo.Start();
            this.PacienteActual = p;
        }

        public MGeneral(string n, string a):base(n,a) { }
        
    }
}
