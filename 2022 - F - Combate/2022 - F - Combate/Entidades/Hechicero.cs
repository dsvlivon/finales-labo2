using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Hechicero : Personaje
    {
        public Hechicero(decimal id, string nom) : base(id, nom)
        {
            Filler();
            AplicarBeneficiosDeClase();
        }
        public Hechicero(decimal id, string nom, short nivel) : base(id, nom, nivel)
        {
            Filler();
            AplicarBeneficiosDeClase();
        }

        public override void AplicarBeneficiosDeClase()
        {
            int nuevo = Convert.ToInt32(this.puntosDePoder * 1.10);
            this.puntosDePoder = nuevo;
        }
    }
}
