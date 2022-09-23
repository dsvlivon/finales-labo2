using BibliotecaDeClases;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{

    // DESARROLLAR
    public partial class FrmProgramacionMultiHilo : Form
    {
     
        CancellationTokenSource cts;
        List<Empleado> listaEmpleados;

        public FrmProgramacionMultiHilo()
        {
            InitializeComponent();

            cts = new CancellationTokenSource();
         
            listaEmpleados = new List<Empleado>();

        }

        private void ComenzarCarga()
        {
            float sueldosDolarizados = 0;
            float sueldosPesificados = 0;
            float montoTotalAguinaldos = 0;

            while (true)
            {

                Empleado unEmpleado = GeneradorDeDatos.GetEmpleadoAleatorio;


                dtg_ListadoPuestosEncontrados.DataSource = null;
                dtg_ListadoPuestosEncontrados.DataSource = listaEmpleados;

                lb_SueldoDolarizado.Text = "Sueldos Dolarizados a Liquidar mensualmente: " + sueldosDolarizados;
                lb_MontoAguinaldo.Text = "Monto a liquidar en Aguinaldos: " + montoTotalAguinaldos;
                lb_SueldoPesificado.Text = "Sueldos Pesificados a Liquidar mensualmente:  " + sueldosPesificados;


                Thread.Sleep(2000);
            }

        }


        private void CancelarProceso()
        {
            this.btn_comenzarCarga.BeginInvoke((MethodInvoker)delegate ()
            {
                cts.Cancel();
                MessageBox.Show($"Hasta aqui dan las finanzas: Se les pagará a {listaEmpleados.Count} empleados");
                btn_comenzarCarga.Enabled = false;
            });
        }


        private void btn_comenzarCarga_Click(object sender, EventArgs e)
        {
            btn_comenzarCarga.Enabled = false;
            //cargaEmpleados.Start();
        }
    }
}
