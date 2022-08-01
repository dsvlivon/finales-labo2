using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Threading;

namespace VistaForm
{
    public partial class FormArchivos : Form
    {
        DiscoElectronico electronico;
        ArchiveroFisico fisico;
        Thread hilo;

        public FormArchivos()
        {
            InitializeComponent();            
        }

        //a.En el evento Load del formulario instanciar el DiscoElectrónico y el ArchiveroFísico del Form con capacidad para 3 archivos c/uno.
        private void Form1_Load(object sender, EventArgs e)
        {
            fisico = new ArchiveroFisico("C:/Users/L54556/OneDrive - Kimberly-Clark/Desktop/PRACTICA/2018 - F - Archivero/",3);
            electronico = new DiscoElectronico(3);
            hilo = new Thread(electronico.MostrarArchivos);
        }

        //instanciar un archivo a partir de los datos obtenidos de los controles del formulario.
        //Agregar el archivo a la lista del DiscoElectrónico siempre y cuando haya capacidad.
        //Si se pudo agregar a la lista, guardarlo también en la base de datos.
        //Finalmente limpiar el contenido de los controles del formulario.
        private void btnAlmacenarElectronico_Click(object sender, EventArgs e)//ok
        {
            if(this.txtNombreArchivo.Text != null) { 
                Archivo a = new Archivo(this.txtNombreArchivo.Text, this.rtbContenido.Text);
                int x = electronico.archivosGuardados.Count();
                try
                {
                    electronico = electronico + a;//esto es xq la sobrecarga ya valida q no se pase el limite...
                    if (electronico.archivosGuardados.Count() > x)
                    {
                        electronico.Guardar(a);
                        MessageBox.Show("Archivo Electronico guardado con exito!");
                    }
                }
                catch (Exception ex ){
                    MessageBox.Show("ERROR btnAlmacenarElectronico_Click()");
                }
            }
            //Código Alumno
            this.txtNombreArchivo.Text = "";
            this.rtbContenido.Text = "";
        }

        //Instanciar un archivo a partir de los datos obtenidos de los controles del formulario.
        //Guardarlo en un archivo de texto
        //Finalmente limpiar el contenido de los controles del formulario.
        private void btnAlmacenarFisico_Click(object sender, EventArgs e)
        {
            Archivo a = new Archivo(this.txtNombreArchivo.Text, this.rtbContenido.Text);
            try
            {
                fisico.Guardar(a);
                MessageBox.Show("Archivo Fisico guardado con exito!");
            } catch (Exception ex)
            {
                MessageBox.Show("ERROR btnAlmacenarFisico_Click()");
            }
            //Código Alumno
            this.txtNombreArchivo.Text = "";
            this.rtbContenido.Text = "";
        }

        //Asociar el manejador del formulario MostrarArchivo al evento MostrarInfo de la clase DiscoElectronico.
        //Ejecutar en un hilo el método MostrarArchivos de la clase DiscoElectronico.
        private void btnLeerElectronico_Click(object sender, EventArgs e)
        {
            this.rtbContenido.Text = "?????";
            try
            {
                hilo = new Thread(electronico.MostrarArchivos);//esto solo hace el sleep(5) x/c item
                hilo.Start();
                
                electronico.InvocarEvento();
                electronico.eventoMostrarInfo += this.MostrarArchivo;
                ////////////////////////////////////////////////////esto no m funca
                StringBuilder sb = new StringBuilder();
                foreach(var i in electronico.archivosGuardados)
                {
                    sb.AppendLine(i.ToString());
                }
                this.MostrarArchivo(sb.ToString());
            } catch (Exception ex)
            {
                MessageBox.Show("ERROR btnLeerElectronico_Click()");
            }
        }

        public void MostrarArchivo(string info)
        {
            MessageBox.Show(info);
            //this.rtbContenido.Text = "!!!!!!";
            this.rtbContenido.Text = info;
        }

        //En el manejador del botón LeerFisico se deberá, a partir del nombre ingresado en 
        //txtNombreArchivo, recuperar el contenido del archivo y mostrarlo en el rtbContenido.
        private void btnLeerFisico_Click(object sender, EventArgs e)//ok
        {
            string msg= "Debe cargar un nombre de archivo al menos";
            try
            {
                if (this.txtNombreArchivo.Text != null)
                {
                    foreach (var i in fisico.Leer(this.txtNombreArchivo.Text)) 
                    {
                        if(i!= null)
                        {
                            this.rtbContenido.Text = "archivo: \n"+(string)i;
                            this.txtNombreArchivo.Text = "";
                        } else { msg = "no se encontro el archivo"; }
                    }
                }
                //this.txtNombreArchivo.Text = "";
                //this.rtbContenido.Text = "";
            } catch (Exception ex) {
                MessageBox.Show(msg);
            }
            //this.rtbContenido.Text = "";
        }

        //Antes de cerrar, en el evento FormClosing, abortar el hilo del formulario en caso de que siga vivo.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)//ok
        {
            if (hilo == null) { hilo.Abort(); }
            if (hilo.IsAlive) { hilo.Abort(); }
        }
    }
}
