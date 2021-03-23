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

namespace IndustriaCalzado.Vista.Color
{
    public partial class Indice : Form
    {
        private int Codigo;
        private DataGridView Grilla;
        private ColorController ColorController;

        public Indice()
        {
            InitializeComponent();
            ColorController = new ColorController("Colores");
        }
        private void Index_Load(object sender, EventArgs e)
        {
            dgvColores.DataSource = ColorController.Listado();
        }
        private void dgvColores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Codigo = Convert.ToInt32(dgvColores.Rows[e.RowIndex].Cells[1].Value.ToString());
        }
        private void dgvColores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrEmpty(dgvColores.Rows[e.RowIndex].Cells[0].ToString())) 
            { 
                Codigo = Convert.ToInt32(dgvColores.Rows[e.RowIndex].Cells[0].ToString());
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Color.Nuevo Nuevo = new Color.Nuevo();
            Nuevo.Grilla = dgvColores;
            Nuevo.Show();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(Codigo!=0)
            {
                Color.Editar editar = new Color.Editar();
                editar.Codigo = Codigo;
                editar.Grilla = dgvColores;
                editar.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un color", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ColorController.ABM(3, null, null,Codigo, Grilla = dgvColores);
            dgvColores.DataSource = ColorController.Listado();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
