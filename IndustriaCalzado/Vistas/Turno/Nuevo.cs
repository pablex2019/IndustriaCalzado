using IndustriaCalzado.Controlador;
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

namespace IndustriaCalzado.Vista.Turno
{
    public partial class Nuevo : Form
    {
        private int Codigo;
        public DataGridView Grilla;
        private TurnoController TurnoController;
        private HorarioController HorarioController;

        public Nuevo()
        {
            InitializeComponent();
            TurnoController = new TurnoController("Turnos");
            HorarioController = new HorarioController("Horarios");
        }
        private void dgvHorarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Codigo = Convert.ToInt32(dgvHorarios.Rows[e.RowIndex].Cells[1].Value.ToString());
        }

        #region Horario
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Vistas.Horario.Nuevo nuevo = new Vistas.Horario.Nuevo();
            nuevo.Grilla = dgvHorarios;
            nuevo.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Codigo!=0)
            {
                Vistas.Horario.Editar Editar = new Vistas.Horario.Editar();
                Editar.Codigo = Codigo;
                Editar.Grilla = dgvHorarios;
                Editar.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un horario", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            HorarioController.ABM(3, null, null, Codigo, dgvHorarios);
        }
        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TurnoController.Existe(1,this,null,Grilla,dgvHorarios);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
