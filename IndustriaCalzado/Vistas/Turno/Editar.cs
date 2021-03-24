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
    public partial class Editar : Form
    {
        public string Descripcion;
        public DataGridView Grilla;
        private TurnoController TurnoController;

        public Editar()
        {
            InitializeComponent();
            TurnoController = new TurnoController("Turnos");
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            var turno = TurnoController.ObtenerTurno(Descripcion);
            txtDescripcion.Text = turno.Descripcion;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TurnoController.ABM(2, null, this, Descripcion, Grilla,null);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
