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

namespace IndustriaCalzado.Vista.Modelo
{
    public partial class Editar : Form
    {
        public string Sku;
        public DataGridView Grilla;
        private ModeloController ModeloController;

        public Editar()
        {
            InitializeComponent();
            ModeloController = new ModeloController("Modelos");
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            var modelo = ModeloController.ObtenerModelo(Sku);
            txtSku.Text = modelo.Sku.ToString();
            txtDenominacion.Text = modelo.Denominación;
            txtObjetivo.Text = modelo.Objetivo.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ModeloController.ABM(2, null, this, Sku, Grilla);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
