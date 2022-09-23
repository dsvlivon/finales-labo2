using BibliotecaDeClases;
using System;
using System.Windows.Forms;
using BibliotecaDeClases;

namespace Vista
{


    public partial class FrmBaseDeDatos : Form
    {
        SqlManejador manejador;
        public FrmBaseDeDatos()
        {
            InitializeComponent();
            manejador = new SqlManejador();
        }


        // DESARROLLAR
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                EmpleadoFreelance f = new EmpleadoFreelance(Convert.ToDecimal(this.tb_dni.Text), this.tb_nombre.Text, this.tb_puestoACubrir.Text,false);
                manejador.Insertar(f);
                this.tb_dni.Text = ""; this.tb_nombre.Text = ""; this.tb_puestoACubrir.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        

    }
}
