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
using Entidades;

namespace FrmFinal
{
    #region Consigna
    /* frmFinal_Load() el evento de carga del formulario, dónde inicializaremos el hilo mocker.
     * frmFinal_FormClosing() el evento de cierre del formulario, dónde, si el hilo mocker aun está activo, se abortará.
     * MockPacientes() dónde se agreguen pacientes a la cola pacientesEnEspera, haciendo un Sleep de 5000 (Thread.Sleep(5000)).
     * AtenderPacientes(IMedico) será invocado por los eventos click de los botones(btnEspecialista_Click y btnGeneral_Click) pasandole el médico que corresponda(medicoEspecialista o medicoGeneral, respectivamente). En el caso de haber pacientes en espera, se deberá iniciar la atención del primer elemento de la cola.
     * FinAtencion(Paciente, Medico) mostrará por medio de un MessageBox un mensaje con el formato "Finalizó la atención de {0} por {1}!", dónde se indicará el nombre del paciente y el del médico que lo atendió, respectivamente */
    #endregion
    public partial class FrmFinal : Form
    {
        private MEspecialista medicoEspecialista;
        private MGeneral medicoGeneral;
        private Thread mocker;
        private Queue<Paciente> pacientesEnEspera;
        
        public FrmFinal()
        {
            InitializeComponent();
            this.medicoGeneral = new MGeneral("Luis", "Salinas");
            this.medicoEspecialista = new MEspecialista("Jorge", "Iglesias", MEspecialista.Especialidad.Traumatologo);
            this.pacientesEnEspera = new Queue<Paciente>();
            this.mocker = new Thread(MockPacientes);
            
            //mocker.Start();
        }
        
        private void FrmFinal_FormClosing(object sender, FormClosingEventArgs e) {
            if (this.mocker.IsAlive) { this.mocker.Abort(); }
        }
        private void MockPacientes()
        { //hacer un bucle
            Paciente p1 = new Paciente("juan", "baez",4);
            Paciente p2 = new Paciente("pepe", "perez",5);
            Paciente p3 = new Paciente("lola", "garcia",6);
            Paciente p4 = new Paciente("viki", "lopez",7);
            List<Paciente> l = new List<Paciente>();
            l.Add(p1); l.Add(p2); l.Add(p3); l.Add(p4); l.Add(p1);//5
            foreach (var item in l)
            {
                this.pacientesEnEspera.Enqueue(item);
                //Thread.Sleep(5000);
                MessageBox.Show("Iniciando.... \n\nPacientes en espera: "+this.pacientesEnEspera.Count().ToString());
                Thread.Sleep(5000);
            }
        }    

        private void btnEspecialista_Click(object sender, EventArgs e)
        {
            if (this.pacientesEnEspera.Count() > 0)
            {
                Paciente p = this.pacientesEnEspera.Dequeue();
                medicoEspecialista.IniciarAtencion(p);
                MessageBox.Show("El Dr. "+ medicoEspecialista.Apellido + " esta atendiendo a " + medicoEspecialista.EstaAtendiendoA);                
                //eventoespecialista();
            }
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            if (this.pacientesEnEspera.Count() > 0)
            {
                medicoGeneral.IniciarAtencion(this.pacientesEnEspera.Dequeue());
                MessageBox.Show("El Dr. " + medicoGeneral.Apellido + " esta atendiendo a " + medicoGeneral.EstaAtendiendoA);
                //eventogeneral();
            }
        }

        private void FinAtencion() {
            //MessageBox.Show("???");
            MessageBox.Show(String.Format("Finalizó la atención de {0} por {1}!",medicoEspecialista.EstaAtendiendoA, "Dr. "+medicoEspecialista.Apellido));
        }

        private void FrmFinal_Load(object sender, EventArgs e)
        {
            medicoEspecialista.AtencionFinalizada += FinAtencion;
            medicoGeneral.AtencionFinalizada += FinAtencion;
            mocker.Start();//inicilizar un hilo es .start()
        }
    }
}
