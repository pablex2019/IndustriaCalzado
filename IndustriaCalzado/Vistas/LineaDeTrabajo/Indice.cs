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

namespace IndustriaCalzado.Vista.LineaDeTrabajo
{
    public partial class Indice : Form
    {
        private LineaDeTrabajoController LineaDeTrabajoController;

        public Indice()
        {
            InitializeComponent();
            LineaDeTrabajoController = new LineaDeTrabajoController("Lineas de Trabajos");
        }
        private void Indice_Load(object sender, EventArgs e)
        {
            dgvLineaDeTrabajo.DataSource = LineaDeTrabajoController.Listado();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Vista.LineaDeTrabajo.Nuevo nuevo = new Vista.LineaDeTrabajo.Nuevo();
            nuevo.Show();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
