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
    
    public class ManejadorArchivos <T>: ISerializar<T>
    {
        private string ruta;
        public ManejadorArchivos()
        {
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.ruta = "C:/Users/L54556/OneDrive - Kimberly-Clark/Desktop/PRACTICA/2021 - F - TiendaElectronicos v2/";
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
        
        public List<T> Leer()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Celular>));
            List<T> ls = new List<T>();
            try
            {
                //using (FileStream stream = File.OpenRead(this.ruta+"Celulares.xml"))
                using (XmlReader reader = XmlReader.Create(this.ruta + "Celulares.xml"))
                {
                    int x = 0;
                    while (reader.Read()) {
                        //ls = (List<T>)serializer.Deserialize(reader);
                        if(reader.Value != null || reader.Value !="")
                        {
                            Console.WriteLine(reader.Value);
                            x++;
                            Console.WriteLine("contador: "+x);
                        }
                    }
                }
            } catch(Exception e) {
                throw new Exception($"Error con metodo .Leer() - {e.Message} - {e.GetBaseException()}");
            }
            return ls;
        }

        public List<T> Leer2()
        {
            string path = Path.Combine(this.ruta, "Celulares.xml");
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader stream = new StreamReader(path))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
                        object objecto = xmlSerializer.Deserialize(stream);
                        return (List<T>)objecto;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"Error con metodo .Leer() - {e.Message} - {e.GetBaseException()}");
                }
            }
            else
            {
                string mensajeError = "No existe el archivo Celulares.xml";
                this.GenerarLog(mensajeError);
                throw new NoExisteFileException(mensajeError);
            }
        }
        public void GuardarXml_ponele()
        {
            string path = Path.Combine(this.ruta, "Celulares.xml");
            try
            {
                //Error 2 de 2 , porque lo que retorno no es lo mismo donde lo almacelo fuera del método.

                Celular c1 = new Celular("S21", 100000, "Samsung", 20, false);
                Celular c2 = new Celular("S21", 100000, "Samsung", 20, false);
                Celular c3 = new Celular("S21", 100000, "Samsung", 20, false);
                Celular c4 = new Celular("S21", 100000, "Samsung", 20, false);
                Celular c5 = new Celular("S21", 100000, "Samsung", 20, false);
                Celular c6 = new Celular("MotoE", 38000, "Samsung", 8, false);
                Celular c7 = new Celular("E6I", 1800, "Motorola", 8, true);
                Celular c8 = new Celular("G30", 34000, "Motorola", 16, false);
                Celular c9 = new Celular("A51", 48000, "Samsung", 20, true);
                Celular c10 = new Celular("G9", 43000, "Motorola", 12, false);
                Celular c11 = new Celular("A21s", 38999, "Samsung", 12, true);
                Celular c12 = new Celular("K51s", 27999, "LG", 8, true);
                Celular c13 = new Celular("K51s", 72999, "Samsung", 26, false);

                List<Producto> products = new List<Producto>();
                products.Add(c1);
                products.Add(c2);
                products.Add(c3);
                products.Add(c4);
                products.Add(c5);
                products.Add(c6);
                products.Add(c7);
                products.Add(c8);
                products.Add(c9);
                products.Add(c10);
                products.Add(c11);
                products.Add(c12);
                products.Add(c13);

                bool apenda = false;
                using (StreamWriter stream = new StreamWriter(path, apenda))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Producto>));
                    serializer.Serialize(stream, products);
                }

            }
            catch (Exception e)
            {
                throw new Exception($"Error con metodo GuardarXml() - {e.Message} - {e.GetBaseException()}");
            }
        }
    }
}
