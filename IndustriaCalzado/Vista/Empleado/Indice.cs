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
    public partial class Indice : Form
    {
        private int Documento;
        private DataGridView Grilla;
        private EmpleadoController EmpleadoController;

        public Indice()
        {
            InitializeComponent();
            EmpleadoController = new EmpleadoController("Empleado");
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Vista.Empleado.Nuevo nuevo = new Vista.Empleado.Nuevo();
            nuevo.Grilla = dgvEmpleado;
            nuevo.Show();

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Documento != 0)
            {
                Color.Editar Editar = new Color.Editar();
                Editar.Codigo = Documento;
                Editar.Grilla = dgvEmpleado;
                Editar.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un empleado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EmpleadoController.ABM(3, null, null, Documento, Grilla = dgvEmpleado);
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
