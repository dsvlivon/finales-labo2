using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace miForm
{
    public partial class Form1 : Form
    {
        public Thread hilo;
        public Form1()
        {
            InitializeComponent();
            hilo = new Thread(MetodoT);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("HOLa Mundo!");
            ClassPrueba.InvocarEventosMsg();
            MessageBox.Show(ClassPrueba.msg);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClassPrueba.InvocarEventos();
            MessageBox.Show("nombre: "+ClassPrueba.nombre +"\nvalor: "+ClassPrueba.valor);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string m = this.richTextBox1.Text;
            ClassPrueba.InvocarEventosRta(m);
            this.richTextBox1.Text = ClassPrueba.rta;
        }

        public void MetodoT()
        {
            try
            {
                ClassPrueba.nombre = "Esteban Estevanez";
                MessageBox.Show("nombre: " + ClassPrueba.nombre + "\nvalor: " + ClassPrueba.valor);
                Thread.Sleep(3000);
                //if (this.hilo.IsAlive)
                //{
                //    this.hilo.();
                //}
            } catch (Exception xe) { }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            hilo.Start();
        }
    }
}
