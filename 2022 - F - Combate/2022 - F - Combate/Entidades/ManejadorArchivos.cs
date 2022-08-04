using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    
    public class ManejadorArchivos
    {
        private string ruta;
        public ManejadorArchivos()
        {
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.ruta = "C:/Users/L54556/OneDrive - Kimberly-Clark/Desktop/PRACTICA/2022 - F - Combate/";
            //C:\Users\L54556\OneDrive - Kimberly-Clark\Desktop\PRACTICA\2021 - F - TiendaElectronicos v2
        }
        public void GenerarLog(string dato)
        {
            try
            {
                DateTime date = DateTime.Now;
                string path = this.ruta + "Log_" + date.ToString("yyyy'-'MM'-'dd") + ".txt";
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(dato);
                }
            } catch (Exception e )
            {
                throw new Exception($"Error con metodo .Leer() - {e.Message} - {e.GetBaseException()}");
            }
        }
        
        public void GuardarXml(ResultadoCombate r)
        {
            string path = Path.Combine(this.ruta, "Celulares.xml");
            try
            {             
                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(path, apenda))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<ResultadoCombate>));
                    serializer.Serialize(stream, r);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error con metodo GuardarXml() - {e.Message} - {e.GetBaseException()}");
            }
        }
    }
}
