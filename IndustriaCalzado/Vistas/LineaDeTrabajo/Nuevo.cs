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

namespace IndustriaCalzado.Vista.LineaDeTrabajo
{
    public partial class Nuevo : Form
    {
        public DataGridView Grilla;
        private LineaDeTrabajoController LineaDeTrabajoController;

        public Nuevo()
        {
            InitializeComponent();
            LineaDeTrabajoController = new LineaDeTrabajoController("Lineas de Trabajos");
        }

        private void Nuevo_Load(object sender, EventArgs e)
        {
            var fecha = DateTime.Now.ToString();
            txtFechaInicio.Text = fecha;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            LineaDeTrabajoController.Existe(1,this, Grilla);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Vistas.OrdenDeProduccion.Nuevo nuevo = new Vistas.OrdenDeProduccion.Nuevo();
            nuevo.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
