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
        public DataGridView Grilla;
        private TurnoController TurnoController;
        private HorarioController HorarioController;

        public Nuevo()
        {
            InitializeComponent();
            TurnoController = new TurnoController("Turnos");
            HorarioController = new HorarioController("Horarios");
        }
        private void Nuevo_Load(object sender, EventArgs e)
        {
            dgvHorarios.DataSource = HorarioController.Listado();
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
            //if (!string.IsNullOrEmpty(Sku))
            //{
            //    Modelo.Editar Editar = new Modelo.Editar();
            //    Editar.Sku = Sku;
            //    Editar.Grilla = dgvModelos;
            //    Editar.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Debe seleccionar un modelo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Turno.ABM(3, null, null, Sku, Grilla = dgvModelos);
        }
        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TurnoController.Existe(this, Grilla,dgvHorarios);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
