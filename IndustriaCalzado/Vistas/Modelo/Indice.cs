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

namespace IndustriaCalzado.Vista.Modelo
{
    public partial class Indice : Form
    {
        private string Sku;
        private DataGridView Grilla;
        private ModeloController ModeloController;

        public Indice()
        {
            InitializeComponent();
            ModeloController = new ModeloController("Modelos");
        }
        private void Indice_Load(object sender, EventArgs e)
        {
            dgvModelos.DataSource = ModeloController.Listado();
        }
        private void dgvModelos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Sku = dgvModelos.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Modelo.Nuevo Nuevo = new Modelo.Nuevo();
            Nuevo.Grilla = dgvModelos;
            Nuevo.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Sku))
            {
                Modelo.Editar Editar = new Modelo.Editar();
                Editar.Sku = Sku;
                Editar.Grilla = dgvModelos;
                Editar.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un modelo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ModeloController.ABM(3, null, null, Sku, Grilla = dgvModelos);
            dgvModelos.DataSource = ModeloController.Listado();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
