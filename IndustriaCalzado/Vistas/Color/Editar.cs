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

namespace IndustriaCalzado.Vista.Color
{
    public partial class Editar : Form
    {
        public int Codigo;
        public DataGridView Grilla;
        private ColorController ColorController;

        public Editar()
        {
            InitializeComponent();
            ColorController = new ColorController("Colores");
        }

        private void Editar_Load(object sender, EventArgs e)
        {
           var color = ColorController.ObtenerColor(Codigo);
           txtCodigo.Text = color.Codigo.ToString();
           txtDescripcion.Text = color.Descripcion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ColorController.ABM(2, null,this,Codigo, Grilla);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
