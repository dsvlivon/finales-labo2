using Entidades;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;


namespace UI
{
    #region Consigna Formulario
    /*
     8.	Formulario Visual:
        a.	Deberá tener un Thread llamado "hilo", que será instanciado en el constructor del formulario. El mismo deberá lanzar el método MostrarOfertas.
        b.	En el método Visual_Load se invocará el evento eventoObtenerDatos que está en tienda.
        c.	El método MostrarOfertas deberá recorrer el stock de la tienda, y por cada producto que sea un Celular, deberá llamar al método ActualizarCampo y luego esperar 2 segundos antes de volver a llamarlo.
        d.	El método ActualizarCampo recibirá el producto enviado por parámetro, y actualizará el richtextbox “rtb_oferta” con la información de ese producto. 
        e.	El evento FormClosing abortará el hilo.
        f.	El evento btn_MostrarOfertas arrancará el hilo.

      */
    #endregion

    public partial class Visual : Form
    {//a.	Deberá tener un Thread llamado "hilo", que será instanciado en el constructor del formulario. El mismo deberá lanzar el método MostrarOfertas.
        private Thread hilo;
        public Visual()
        {
            InitializeComponent();
            hilo = new Thread(this.MostrarOfertas); //siempre q diga instanciar
            //al hilo se le pasa el metodo sin "()"
        }

        private void Visual_Load(object sender, EventArgs e)
        {//b.	En el método Visual_Load se invocará el evento eventoObtenerDatos que está en tienda.
            this.Text = "Vizgarra.Daniel";
            this.lbl_Titulo.Text = "Electrodomesticos Peposo";
            try
            {
                Tienda.CargarDatos();
                this.rtb_catalogo.Text = Tienda.InfoTienda();
                this.btn_MostrarOfertas.Enabled = true;
            }
            catch (Exception ex)
            {
                this.btn_MostrarOfertas.Enabled = false;
                MessageBox.Show(ex.InnerException.Message);
            }

        }

        private void MostrarOfertas()
        {//c.	El método MostrarOfertas deberá recorrer el stock de la tienda, y por cada producto que sea un Celular, deberá llamar al método ActualizarCampo y luego esperar 2 segundos antes de volver a llamarlo.
            List<Producto> l = Tienda.Stock;
            foreach (var i in l)
            {
                if (i is Celular)
                {
                    ActualizarCampo(i);
                    Thread.Sleep(2000);
                }
            }
        }

        private void ActualizarCampo(Producto item)
        {// d.El método ActualizarCampo recibirá el producto enviado por parámetro, y actualizará el richtextbox “rtb_oferta” con la información de ese producto. 
            if (this.InvokeRequired)
            {
                try
                {
                    this.rtb_oferta.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.rtb_oferta.Text = item.ToString();
                    });
                }
                catch (Exception ex)
                {
                    this.rtb_oferta.Text = ex.Message;
                }
            }
        }

        private void Visual_FormClosing(object sender, FormClosingEventArgs e)
        {//e.	El evento FormClosing abortará el hilo.
            if (hilo != null && hilo.IsAlive)
            {
                hilo.Abort();
            }
        }

        private void btn_MostrarOfertas_Click(object sender, EventArgs e)
        {//f.	El evento btn_MostrarOfertas arrancará el hilo.
            hilo.Start();
        }
    }
}
