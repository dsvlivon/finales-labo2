
namespace UI
{
    partial class Visual
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtb_catalogo = new System.Windows.Forms.RichTextBox();
            this.lb_catalogo = new System.Windows.Forms.Label();
            this.rtb_oferta = new System.Windows.Forms.RichTextBox();
            this.lb_oferta = new System.Windows.Forms.Label();
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.btn_MostrarOfertas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtb_catalogo
            // 
            this.rtb_catalogo.Location = new System.Drawing.Point(26, 82);
            this.rtb_catalogo.Name = "rtb_catalogo";
            this.rtb_catalogo.Size = new System.Drawing.Size(312, 329);
            this.rtb_catalogo.TabIndex = 0;
            this.rtb_catalogo.Text = "";
            // 
            // lb_catalogo
            // 
            this.lb_catalogo.AutoSize = true;
            this.lb_catalogo.ForeColor = System.Drawing.Color.White;
            this.lb_catalogo.Location = new System.Drawing.Point(150, 57);
            this.lb_catalogo.Name = "lb_catalogo";
            this.lb_catalogo.Size = new System.Drawing.Size(65, 13);
            this.lb_catalogo.TabIndex = 2;
            this.lb_catalogo.Text = "CATALOGO";
            // 
            // rtb_oferta
            // 
            this.rtb_oferta.Location = new System.Drawing.Point(454, 82);
            this.rtb_oferta.Name = "rtb_oferta";
            this.rtb_oferta.Size = new System.Drawing.Size(244, 118);
            this.rtb_oferta.TabIndex = 3;
            this.rtb_oferta.Text = "";
            // 
            // lb_oferta
            // 
            this.lb_oferta.AutoSize = true;
            this.lb_oferta.ForeColor = System.Drawing.Color.White;
            this.lb_oferta.Location = new System.Drawing.Point(514, 57);
            this.lb_oferta.Name = "lb_oferta";
            this.lb_oferta.Size = new System.Drawing.Size(139, 13);
            this.lb_oferta.TabIndex = 4;
            this.lb_oferta.Text = "OFERTAS DE LA SEMANA";
            // 
            // lbl_Titulo
            // 
            this.lbl_Titulo.AutoSize = true;
            this.lbl_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titulo.ForeColor = System.Drawing.Color.White;
            this.lbl_Titulo.Location = new System.Drawing.Point(268, 9);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Size = new System.Drawing.Size(70, 25);
            this.lbl_Titulo.TabIndex = 5;
            this.lbl_Titulo.Text = "label1";
            // 
            // btn_MostrarOfertas
            // 
            this.btn_MostrarOfertas.Location = new System.Drawing.Point(454, 239);
            this.btn_MostrarOfertas.Name = "btn_MostrarOfertas";
            this.btn_MostrarOfertas.Size = new System.Drawing.Size(244, 23);
            this.btn_MostrarOfertas.TabIndex = 6;
            this.btn_MostrarOfertas.Text = "Mostrar ofertas";
            this.btn_MostrarOfertas.UseVisualStyleBackColor = true;
            this.btn_MostrarOfertas.Click += new System.EventHandler(this.btn_MostrarOfertas_Click);
            // 
            // Visual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(732, 450);
            this.Controls.Add(this.btn_MostrarOfertas);
            this.Controls.Add(this.lbl_Titulo);
            this.Controls.Add(this.lb_oferta);
            this.Controls.Add(this.rtb_oferta);
            this.Controls.Add(this.lb_catalogo);
            this.Controls.Add(this.rtb_catalogo);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Visual";
            this.Text = "Apellido.Nombre";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Visual_FormClosing);
            this.Load += new System.EventHandler(this.Visual_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_catalogo;
        private System.Windows.Forms.Label lb_catalogo;
        private System.Windows.Forms.RichTextBox rtb_oferta;
        private System.Windows.Forms.Label lb_oferta;
        private System.Windows.Forms.Label lbl_Titulo;
        private System.Windows.Forms.Button btn_MostrarOfertas;
    }
}

