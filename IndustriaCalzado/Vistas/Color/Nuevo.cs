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
    public partial class Nuevo : Form
    {
        public DataGridView Grilla;
        private ColorController ColorController;

        public Nuevo()
        {
            InitializeComponent();
            ColorController = new ColorController("Colores");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ColorController.Existe(1,this,null,Grilla);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
