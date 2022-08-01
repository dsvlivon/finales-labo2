using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Medico:Persona
    {
        private Paciente pacienteActual;
        protected Random tiempoAleatorio;

        private Paciente AtenderA { set
            { this.pacienteActual = value;  } }
        public string EstaAtendiendoA { get; }

        protected void Atender() { }
        protected void FinalizarAtencion() { }
        private Medico()
        {

        }
        public Medico(string n, string a): base(n,a)
        {

        }
    }
}
