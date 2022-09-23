using System;
using System.Collections.Generic;

namespace BibliotecaDeClases
{

    //DESARROLLAR

    public class Empresa
    {
        List<Puesto> posicionesAbiertas;
        int cantPuestosACubrir;

        public List<Puesto> Posiciones { get => posicionesAbiertas; }

        public Empresa(int puestosACubrir)
        {
            this.cantPuestosACubrir = puestosACubrir;
            posicionesAbiertas = new List<Puesto>();
        }

        public List<Puesto> AbrirBusqueda()
        {

            return null;

        }

    }
}
