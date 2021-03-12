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

namespace IndustriaCalzado.Vista.Empleado
{
    public partial class Nuevo : Form
    {
        public DataGridView Grilla;
        private EmpleadoController EmpleadoController;

        public Nuevo()
        {
            InitializeComponent();
            EmpleadoController = new EmpleadoController("Empledo");
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EmpleadoController.Existe(this, Grilla);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
