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
    public partial class Editar : Form
    {
        public int Documento;
        public DataGridView Grilla;
        private EmpleadoController EmpleadoController;

        public Editar()
        {
            InitializeComponent();
            EmpleadoController = new EmpleadoController("Empleados");
        }
        private void Editar_Load(object sender, EventArgs e)
        {
            var empleado = EmpleadoController.ObtenerEmpleado(Documento);
            txtDocumento.Text = empleado.Documento.ToString();
            txtNombre.Text = empleado.Nombres;
            txtApellido.Text = empleado.Apellidos;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
