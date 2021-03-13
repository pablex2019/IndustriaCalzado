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

namespace IndustriaCalzado.Vista.Perfil
{
    public partial class Nuevo : Form
    {
        public DataGridView Grilla;
        private PerfilController PerfilController;

        public Nuevo()
        {
            InitializeComponent();
            PerfilController = new PerfilController("Perfil");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            PerfilController.Existe(this, Grilla);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
