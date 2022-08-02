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
    public class Paciente :Persona
    {
        private int turno;
        private static int ultimoTurno; //de clase es statico?

        public int Turno { get { return this.turno; } }

        static Paciente() { ultimoTurno = 0; }
        public Paciente(string a, string n, int turno) : base(n, a) { 
            this.turno = turno;
            ultimoTurno = this.turno;
        }

        public Paciente(string a, string n): base(n, a) {
            ultimoTurno++;
            this.turno = ultimoTurno;
        }

        public override string ToString()
        {
            return String.Format("Turno Nº{0}: {1}, {2}", this.Turno, this.Apellido, this.Nombre);
        }

        public string Nombre { get { return this.nombre; } }
        public string Apellido { get { return this.apellido; } }
    }
}
