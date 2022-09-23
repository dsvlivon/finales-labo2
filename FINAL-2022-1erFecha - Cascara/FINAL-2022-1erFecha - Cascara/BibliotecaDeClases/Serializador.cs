using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace BibliotecaDeClases
{


    // DESARROLLAR
    public static class Serializador<T>
    {
        
        public static void SerializarAXml(T objeto, string ruta)
        {


            XmlTextWriter writer = null;
            string rutaAbsoluta = ruta + @"\" + "empleado.xml";
            try
            {
                writer = new XmlTextWriter(rutaAbsoluta, Encoding.UTF8);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, objeto);
            }
            catch (ArgumentException ex)
            {
                throw ex;           
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}
