using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IJugador
    {
        int Atacar();
        void RecibirAtaque(int puntosDeAtaque);
       
        short Nivel{ get; }
        int PuntosDeVida { get; }
    }
}
