using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
using System.Threading;

namespace Entidades
{
    //a.Deberá heredar de Almacenador e implementar IAlmacenable.
    //b. El método Guardar deberá insertar un archivo en la base de datos. 
    //c.El método Leer recibirá el nombre de la tabla a consultar. Deberá leer y retornar todos los archivos de la base de datos.
    //d.Tanto en Leer como en Guardar capturar y relanzar las excepciones. IMPLEMENTADO EN LAS CLASES ArchivoDB y DBConnection
    //e.El método MostrarArchivos por el momento sólo deberá recorrer la lista de archivos y por cada uno simular un retardo de 5 segundos.
    //f.Agregar un constructor en el cual se deberá cargar la lista a partir de los datos guardados en la base.
    //g.El constructor privado inicializará la lista. Por defecto la capacidad será 5.
    //h.Sobrecargar el operador + para agregar un archivo a la lista siempre y cuando no supere la capacidad, caso contrario lanzará una excepción con el mensaje "El disco está lleno!".

    public delegate void myDelegado(string x);
    public class DiscoElectronico : Almacenador, IAlmacenable<Archivo>
    {
        public List<Archivo> archivosGuardados;
        public event myDelegado eventoMostrarInfo;

        public DiscoElectronico(int cap) : base(cap)
        {
            archivosGuardados = new List<Archivo>();            
        }
        public DiscoElectronico()
        {
            this.capacidad = 5;
            archivosGuardados = new List<Archivo>();
        }

        public bool Guardar(Archivo elemento)
        {
            return ArchivoDB.InsertProducto(elemento); // como el metodo es estatico no necesito la instancia p usarlo
        }
        public List<Archivo> Leer(string path)
        {
            archivosGuardados = ArchivoDB.SelectAll(path);
            
            return archivosGuardados;
        }
        


        public override void MostrarArchivos()
        {
            List<Archivo> l = this.archivosGuardados;

            foreach (var i in l)
            {
                Thread.Sleep(5000);//simular un retardo de 5 segundos??? no necesitas un hilo especifico p esto...     
            }            
        }

        public void InvocarEvento() {
            this.Leer("Archivo");
            eventoMostrarInfo?.Invoke(this.archivosGuardados.ToString());              
        }

        public static DiscoElectronico operator +(DiscoElectronico d, Archivo a)
        {
            List<Archivo> aux = d.archivosGuardados;
            DiscoElectronico ret = null;
            if (aux.Count()< d.capacidad)
            {
                aux.Add(a);
                d.archivosGuardados = aux;
                ret = d;
            } else {
                throw new Exception("El disco esta lleno!");
            }
            return ret;
        }        
    }
}
