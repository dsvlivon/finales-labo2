using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibliotecaDeClases
{

    public enum EBono
    {
        Basico = 15000,
        Medio = 25000,
        Alto = 40000
    }

    public class EmpleadoRelacionDependencia : Empleado
    {

        EBono bono;

        public EmpleadoRelacionDependencia(decimal dni, string nombreCompleto, string posicion, EBono bono) : base(dni, nombreCompleto, posicion)
        {
            this.bono = bono;
        }

        public override float CalcularHonorarios
        {
            get
            {
                validarRemuneracion();
                return this.remuneracionPretendida;
            }
        }

        public float CalcularHonorario
        {
            get
            {
                float valor = (float)this.remuneracionPretendida * (float)1.50;
                if ((EBono)this.bono == EBono.Basico)
                {
                    valor = valor * 15000;
                }
                else if ((EBono)this.bono == EBono.Medio)
                {
                    valor = valor * 25000;
                }
                else
                {
                    valor = valor * 40000;
                }
                return valor;
            }
        }

        void validarRemuneracion()
        {
            if (this.remuneracionPretendida > 25000)
            {
                this.remuneracionPretendida = Convert.ToInt32((this.remuneracionPretendida / 30) / 100);
            }
        }
    }
}
