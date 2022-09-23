using System;
using System.Xml.Serialization;

namespace BibliotecaDeClases
{
    [XmlInclude(typeof(EmpleadoFreelance))]
    [XmlInclude(typeof(EmpleadoRelacionDependencia))]
    //DESARROLLAR 
    public abstract class Empleado : ICompensacion
    {

        public decimal dni;
        public string nombreCompleto;
        public string posicion;
        public int remuneracionPretendida;


        public Empleado(decimal dni, string nombre, string posicion) : this()
        {
            this.dni = dni;
            this.nombreCompleto = nombre;
            this.posicion = posicion;
        }

        private Empleado()
        {
            this.remuneracionPretendida = GeneradorDeDatos.Rnd.Next(100000, 250000);
        }

        public string Posicion
        {
            get { return posicion; }
        }

        public decimal Dni { get => dni; set => dni = value; }
        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }

        public abstract float CalcularHonorarios { get; }
    }
}
