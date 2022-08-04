using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Guerrero : Personaje
    {
        public Guerrero(decimal id, string nom) : base(id, nom)
        {
            Filler();
            AplicarBeneficiosDeClase();
        }
        public Guerrero(decimal id, string nom, short nivel) : base(id, nom,nivel)
        {
            Filler();
            AplicarBeneficiosDeClase();
        }

        public override void AplicarBeneficiosDeClase()
        {
            int nuevo = Convert.ToInt32(this.puntosDEDefensa * 1.10);
            this.puntosDEDefensa = nuevo;
        }
    }
}
