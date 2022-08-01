using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    #region Consigna 
    /*
    -Deberá heredar de Almacenador e implementar IAlmacenable.
    -Crear un constructor que reciba y asigne el/los atributos de la misma.
    -El método MostrarArchivos lanzará una excepción del tipo NotImplementedException.
    -El método Guardar deberá guardar un objeto de tipo archivo en un archivo de texto en la ubicación definida en el atributo pathArchivos.
    -El método Leer recibirá el nombre de un archivo y deberá retornar su contenido.
    -Tanto en Leer como en Guardar capturar y relanzar las excepciones.
    */
    #endregion

    public class ArchiveroFisico : Almacenador, IAlmacenable<Archivo>
    {
        private string pathArchivos;

        public ArchiveroFisico(string p, int cap):base(cap)
        {
                this.pathArchivos=p;
        }

        public bool Guardar(Archivo elemento)
        {//-El método Guardar deberá guardar un objeto de tipo archivo en un archivo de texto en la ubicación definida en el atributo pathArchivos.
            bool ret = false;
            try
            {
                string ruta = this.pathArchivos + elemento.nombre+".txt";
                using (StreamWriter writer = new StreamWriter(ruta))
                {
                    writer.WriteLine(elemento.ToString());
                    ret = true;
                    Console.WriteLine("Guardar: OK");
                }
                return ret;
            } catch (Exception e) {
                throw new Exception($"ERROR Guardar() - {e.Message} - {e.GetBaseException()}");
            }
        }

        public List<Archivo> Leer(string path)
        {//-El método Leer recibirá el nombre de un archivo y deberá retornar su contenido.
            string text = string.Empty;
            string newLine = string.Empty;
            StreamReader reader=null;
            List<Archivo> l = new List<Archivo>();
            string ruta = this.pathArchivos + path + ".txt";
            try
            {
                reader = new StreamReader(ruta);  
                string x = reader.ReadLine();
                string z = reader.ReadLine();
                
                //while (newLine != null)
                //{
                //    Console.WriteLine("el coso: " + text);
                //    text += newLine + "\n";
                //    newLine = reader.ReadLine();
                //    Console.WriteLine("newLine: " + newLine);
                //    //newLine = reader.ReadLine();
                //    //Console.WriteLine("newLine: "+newLine);
                //}
                Archivo a = new Archivo(x, z);

                l.Add(a);
                return l;
                
            } catch (Exception e) {
                throw new Exception($"ERROR Leer() - {e.Message} - {e.GetBaseException()}");
            } finally {
                if(reader!= null)
                {
                    reader.Close();
                }
            }
        }

        public override void MostrarArchivos()
        {
            throw new NotImplementedException();
        }
    }
}
