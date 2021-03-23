using IndustriaCalzado.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndustriaCalzado.Vista.Turno
{
    public partial class Nuevo : Form
    {
        public DataGridView Grilla;
        private TurnoController TurnoController;

        public Nuevo()
        {
            InitializeComponent();
            TurnoController = new TurnoController("Turno");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TurnoController.Existe(this, Grilla);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
