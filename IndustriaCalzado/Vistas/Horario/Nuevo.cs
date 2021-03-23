using IndustriaCalzado.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndustriaCalzado.Vistas.Horario
{
    public partial class Nuevo : Form
    {
        public DataGridView Grilla;
        private HorarioController HorarioController;

        public Nuevo()
        {
            InitializeComponent();
            HorarioController = new HorarioController("Horarios");
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            HorarioController.Existe(this, Grilla);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
