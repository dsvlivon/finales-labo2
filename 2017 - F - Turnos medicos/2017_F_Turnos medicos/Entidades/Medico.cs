﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void FinAtencionPaciente();
    public abstract class Medico:Persona
    {
        public event FinAtencionPaciente AtencionFinalizada;
        private Paciente pacienteActual;
        protected static Random tiempoAleatorio;

        public Paciente PacienteActual { set { this.pacienteActual = value; } }

        public virtual string EstaAtendiendoA
        {
            get
            {
                if (this.pacienteActual != null)
                {
                    return this.pacienteActual.ToString();
                }
                else { return "Sin pacientes asignados"; }
            }
        }

        protected abstract void Atender();
        protected void FinalizarAtencion() {
            AtencionFinalizada?.Invoke();//es suficiente
            this.PacienteActual = null;
        }
        public Medico(string n, string a): base(n,a) { }
        static Medico()
        {
            tiempoAleatorio = new Random();
        }
        public string Nombre { get { return this.nombre; } }
        public string Apellido { get { return this.apellido; } }
    }
}
