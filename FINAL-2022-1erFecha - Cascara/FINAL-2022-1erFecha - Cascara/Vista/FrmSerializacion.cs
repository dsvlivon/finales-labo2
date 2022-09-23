﻿using BibliotecaDeClases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vista
{
    public delegate void DelegadoSerializar(Empleado e, string r);
    public partial class FrmSerializacion : Form
    {
        public event DelegadoSerializar eventoSerializar;
        public FrmSerializacion()
        {
            InitializeComponent();
            eventoSerializar += Serializar;
        }


        //no cambiar
        private void ActualizarComponentesFormulario(string texto)
        {
            lb_mensaje.Text = texto;
            lb_mensaje.Visible = true;
            btn_deserializar.Enabled = false;
        }

        private void btn_deserializar_Click(object sender, EventArgs e)
        {
            string rutaFile = string.Empty;
            Empleado empleado = GeneradorDeDatos.GetEmpleadoAleatorio;

            rutaFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\RSP_2022\\";

            //this.eventoSerializar ? Invoke(empleado, rutaFile);

        }

        private void FrmSerializacion_Load(object sender, EventArgs e)
        {
            
        }

        void Serializar(Empleado e, string ruta)
        {
            Serializador<Empleado>.SerializarAXml(e, ruta);
        }
    }
}
