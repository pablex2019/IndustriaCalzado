namespace IndustriaCalzado.Vista
{
    partial class Panel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModelo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPerfil = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTurno = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmpleado = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrdenesDeProduccion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLineasDeTrabajo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuColor,
            this.mnuModelo,
            this.mnuPerfil,
            this.mnuTurno,
            this.mnuEmpleado,
            this.mnuOrdenesDeProduccion,
            this.mnuLineasDeTrabajo,
            this.mnuCerrarSesion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1116, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuColor
            // 
            this.mnuColor.Name = "mnuColor";
            this.mnuColor.Size = new System.Drawing.Size(59, 20);
            this.mnuColor.Text = "Colores";
            this.mnuColor.Click += new System.EventHandler(this.mnuColor_Click);
            // 
            // mnuModelo
            // 
            this.mnuModelo.Name = "mnuModelo";
            this.mnuModelo.Size = new System.Drawing.Size(65, 20);
            this.mnuModelo.Text = "Modelos";
            this.mnuModelo.Click += new System.EventHandler(this.mnuModelo_Click);
            // 
            // mnuPerfil
            // 
            this.mnuPerfil.Name = "mnuPerfil";
            this.mnuPerfil.Size = new System.Drawing.Size(57, 20);
            this.mnuPerfil.Text = "Perfiles";
            this.mnuPerfil.Click += new System.EventHandler(this.mnuPerfil_Click);
            // 
            // mnuTurno
            // 
            this.mnuTurno.Name = "mnuTurno";
            this.mnuTurno.Size = new System.Drawing.Size(55, 20);
            this.mnuTurno.Text = "Turnos";
            this.mnuTurno.Click += new System.EventHandler(this.mnuTurno_Click);
            // 
            // mnuEmpleado
            // 
            this.mnuEmpleado.Name = "mnuEmpleado";
            this.mnuEmpleado.Size = new System.Drawing.Size(77, 20);
            this.mnuEmpleado.Text = "Empleados";
            this.mnuEmpleado.Click += new System.EventHandler(this.mnuEmpleado_Click);
            // 
            // mnuOrdenesDeProduccion
            // 
            this.mnuOrdenesDeProduccion.Name = "mnuOrdenesDeProduccion";
            this.mnuOrdenesDeProduccion.Size = new System.Drawing.Size(143, 20);
            this.mnuOrdenesDeProduccion.Text = "Ordenes de Producción";
            this.mnuOrdenesDeProduccion.Click += new System.EventHandler(this.mnuOrdenesDeProduccion_Click);
            // 
            // mnuLineasDeTrabajo
            // 
            this.mnuLineasDeTrabajo.Name = "mnuLineasDeTrabajo";
            this.mnuLineasDeTrabajo.Size = new System.Drawing.Size(109, 20);
            this.mnuLineasDeTrabajo.Text = "Lineas de Trabajo";
            this.mnuLineasDeTrabajo.Click += new System.EventHandler(this.mnuLineasDeTrabajo_Click);
            // 
            // mnuCerrarSesion
            // 
            this.mnuCerrarSesion.Name = "mnuCerrarSesion";
            this.mnuCerrarSesion.Size = new System.Drawing.Size(88, 20);
            this.mnuCerrarSesion.Text = "Cerrar Sesion";
            this.mnuCerrarSesion.Click += new System.EventHandler(this.mnuCerrarSesion_Click);
            // 
            // Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1116, 436);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Panel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel";
            this.Load += new System.EventHandler(this.Panel_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrarSesion;
        public System.Windows.Forms.ToolStripMenuItem mnuColor;
        public System.Windows.Forms.ToolStripMenuItem mnuModelo;
        public System.Windows.Forms.ToolStripMenuItem mnuEmpleado;
        public System.Windows.Forms.ToolStripMenuItem mnuOrdenesDeProduccion;
        public System.Windows.Forms.ToolStripMenuItem mnuLineasDeTrabajo;
        public System.Windows.Forms.ToolStripMenuItem mnuPerfil;
        public System.Windows.Forms.ToolStripMenuItem mnuTurno;
    }
}