using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(ResultadoCombate))]
    public class ResultadoCombate
    {
        private DateTime fechaCombate;
        private string nombreGanador;
        private string nombrePerdedor;
        
        public DateTime Fecha{ get; set; }
        public string Ganador { get; set; }
        public string Perdedor { get; set; }

        public ResultadoCombate(string winer, string loser, DateTime fecha)
        {
            this.Ganador = winer; this.Perdedor = loser; this.Fecha = fecha;
        }
    }
}
