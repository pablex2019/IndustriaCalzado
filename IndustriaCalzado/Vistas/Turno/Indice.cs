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
    public partial class Indice : Form
    {
        public DataGridView Grilla; 
        private string Descripcion;
        private TurnoController TurnoController;

        public Indice()
        {
            InitializeComponent();
            TurnoController = new TurnoController("Turnos");
        }
        private void Indice_Load(object sender, EventArgs e)
        {
            dgvTurnos.DataSource = TurnoController.Listado();
            dgvTurnos.Columns[3].Visible = false;
        }
        private void dgvTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Descripcion = dgvTurnos.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        private void dgvTurnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Vistas.Turno.Ver ver = new Vistas.Turno.Ver();
            ver.Descripcion = Descripcion;
            ver.Show();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Turno.Nuevo nuevo = new Nuevo();
            nuevo.Grilla = dgvTurnos;
            nuevo.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Descripcion))
            {
                Turno.Editar editar = new Editar();
                editar.Descripcion = Descripcion;
                editar.Grilla = dgvTurnos;
                editar.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un turno", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            TurnoController.ABM(3, null, null, Descripcion, Grilla = dgvTurnos,null);
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
