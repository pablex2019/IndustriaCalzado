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

namespace IndustriaCalzado.Vista.Perfil
{
    public partial class Indice : Form
    {
        private string Descripcion;
        private DataGridView Grilla;
        private PerfilController PerfilController;

        public Indice()
        {
            InitializeComponent();
            PerfilController = new PerfilController("Perfiles");
        }
        private void Indice_Load(object sender, EventArgs e)
        {
            dgvPerfiles.DataSource = PerfilController.Listado();
        }
        private void dgvPerfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Descripcion = dgvPerfiles.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Perfil.Nuevo nuevo = new Perfil.Nuevo();
            nuevo.Grilla = dgvPerfiles;
            nuevo.Show();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Descripcion))
            {
                Perfil.Editar Editar = new Perfil.Editar();
                Editar.Descripcion = Descripcion;
                Editar.Grilla = dgvPerfiles;
                Editar.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un perfil", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            PerfilController.ABM(3, null, null, Descripcion, Grilla = dgvPerfiles);
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
