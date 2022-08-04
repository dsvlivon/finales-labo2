using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Logger
    {
        private string ruta;
        //this.ruta = "C:/Users/L54556/OneDrive - Kimberly-Clark/Desktop/PRACTICA/2022 - F - Combate/";
        void GuardarLog(string txt) {
            try
            {
                DateTime date = DateTime.Now;
                string path = this.ruta + "Log_" + date.ToString("yyyy'-'MM'-'dd") + ".txt";
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(txt);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error con metodo .Leer() - {e.Message} - {e.GetBaseException()}");
            }
        }

        public Logger(string ruta)
        {
            this.ruta = ruta;
        }
    }
}
