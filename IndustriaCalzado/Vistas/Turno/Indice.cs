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
        private int Codigo;
        private TurnoController TurnoController;

        public Indice()
        {
            InitializeComponent();
            TurnoController = new TurnoController("Turnos");
        }
        private void Indice_Load(object sender, EventArgs e)
        {
            dgvTurnos.DataSource = TurnoController.Listado();
        }
        private void dgvTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Codigo = Convert.ToInt32(dgvTurnos.Rows[e.RowIndex].Cells[1].Value.ToString());
        }
        private void dgvTurnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Vistas.Turno.Ver ver = new Vistas.Turno.Ver();
            ver.Codigo = Codigo;
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
            if (Codigo!=0)
            {
                Turno.Editar editar = new Editar();
                editar.Codigo = Codigo;
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
            TurnoController.ABM(3, null, null, Codigo, Grilla = dgvTurnos,null);
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
