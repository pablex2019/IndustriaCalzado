using IndustriaCalzado.Controlador;
using IndustriaCalzado.Controladores;
using IndustriaCalzado.Modelo;
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
    public partial class Editar : Form
    {
        public int Codigo;
        public DataGridView Grilla;
        private TurnoController TurnoController;
        private HorarioController HorarioController;

        public Editar()
        {
            InitializeComponent();
            TurnoController = new TurnoController("Turnos");
            HorarioController = new HorarioController("Horarios");
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            var turno = TurnoController.ObtenerTurno(Codigo);
            txtCodigo.Text = turno.Codigo.ToString();
            txtDescripcion.Text = turno.Descripcion;
            dgvHorarios.DataSource = turno.HorarioModels.ToList();
        }
        private void dgvHorarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Codigo = Convert.ToInt32(dgvHorarios.Rows[e.RowIndex].Cells[1].Value.ToString());
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TurnoController.Existe(2, null, this, Grilla, dgvHorarios);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Vistas.Horario.Nuevo nuevo = new Vistas.Horario.Nuevo();
            nuevo.Grilla = dgvHorarios;
            nuevo.Show();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Codigo != 0)
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
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            TurnoController.Existe(2, null, this, Grilla, dgvHorarios);
        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
