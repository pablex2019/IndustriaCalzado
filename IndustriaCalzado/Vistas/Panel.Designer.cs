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
            this.mnuEmpleado = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPerfil = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenesDeProducciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineaDeTrabajoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTurno = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuColor,
            this.mnuModelo,
            this.mnuTurno,
            this.mnuPerfil,
            this.mnuEmpleado,
            this.ordenesDeProducciónToolStripMenuItem,
            this.lineaDeTrabajoToolStripMenuItem,
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
            this.mnuColor.Size = new System.Drawing.Size(48, 20);
            this.mnuColor.Text = "Color";
            this.mnuColor.Click += new System.EventHandler(this.mnuColor_Click);
            // 
            // mnuModelo
            // 
            this.mnuModelo.Name = "mnuModelo";
            this.mnuModelo.Size = new System.Drawing.Size(60, 20);
            this.mnuModelo.Text = "Modelo";
            this.mnuModelo.Click += new System.EventHandler(this.mnuModelo_Click);
            // 
            // mnuEmpleado
            // 
            this.mnuEmpleado.Name = "mnuEmpleado";
            this.mnuEmpleado.Size = new System.Drawing.Size(72, 20);
            this.mnuEmpleado.Text = "Empleado";
            this.mnuEmpleado.Click += new System.EventHandler(this.mnuEmpleado_Click);
            // 
            // mnuPerfil
            // 
            this.mnuPerfil.Name = "mnuPerfil";
            this.mnuPerfil.Size = new System.Drawing.Size(46, 20);
            this.mnuPerfil.Text = "Perfil";
            this.mnuPerfil.Click += new System.EventHandler(this.mnuPerfil_Click);
            // 
            // ordenesDeProducciónToolStripMenuItem
            // 
            this.ordenesDeProducciónToolStripMenuItem.Name = "ordenesDeProducciónToolStripMenuItem";
            this.ordenesDeProducciónToolStripMenuItem.Size = new System.Drawing.Size(143, 20);
            this.ordenesDeProducciónToolStripMenuItem.Text = "Ordenes de Producción";
            // 
            // lineaDeTrabajoToolStripMenuItem
            // 
            this.lineaDeTrabajoToolStripMenuItem.Name = "lineaDeTrabajoToolStripMenuItem";
            this.lineaDeTrabajoToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.lineaDeTrabajoToolStripMenuItem.Text = "Linea de Trabajo";
            // 
            // mnuCerrarSesion
            // 
            this.mnuCerrarSesion.Name = "mnuCerrarSesion";
            this.mnuCerrarSesion.Size = new System.Drawing.Size(88, 20);
            this.mnuCerrarSesion.Text = "Cerrar Sesion";
            this.mnuCerrarSesion.Click += new System.EventHandler(this.mnuCerrarSesion_Click);
            // 
            // mnuTurno
            // 
            this.mnuTurno.Name = "mnuTurno";
            this.mnuTurno.Size = new System.Drawing.Size(50, 20);
            this.mnuTurno.Text = "Turno";
            this.mnuTurno.Click += new System.EventHandler(this.mnuTurno_Click);
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuColor;
        private System.Windows.Forms.ToolStripMenuItem mnuModelo;
        private System.Windows.Forms.ToolStripMenuItem mnuEmpleado;
        private System.Windows.Forms.ToolStripMenuItem ordenesDeProducciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineaDeTrabajoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem mnuPerfil;
        private System.Windows.Forms.ToolStripMenuItem mnuTurno;
    }
}