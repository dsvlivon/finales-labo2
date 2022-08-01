using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    #region Consigna
    /*
     1-ultimoTurnoDado será de clase y privado. Se inicializará en el constructor, también de clase, con el valor 0.
     2-El constructor Paciente(string, string, int) asignará los valores a cada atributo, modificando también ultimoTurnoDado por el valor recibido.
     3-El constructor Paciente(string, string) incrementará el valor de ultimoTurnoDado en 1 y se lo asignará al turno.
     4-ToString() retornará los datos del paciente con el siguiente formato "Turno Nº{0}: {2}, {1}", siendo los valores número de turno, apellido y nombre respectivamente.
     */
    #endregion
    class Paciente :Persona
    {
        private int turno;
        private int ultimoTurno; //de clase es statico?

        public int Turno { get; }

        private Paciente() { this.ultimoTurno = 0; }

        public Paciente(string a, string n): base(n, a) {
            this.ultimoTurno++;
            this.turno = ultimoTurno;
        }
        public Paciente(string a, string n, int turno) : base(n, a) { 
            this.turno = turno;
            this.ultimoTurno = turno;
        }

        public override string ToString()
        {
            return String.Format("Turno Nº{0}: {2}, {1}", this.Turno, this. apellido, this.nombre);
        }
    }
}
