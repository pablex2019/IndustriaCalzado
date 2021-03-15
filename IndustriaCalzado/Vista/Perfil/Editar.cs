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
    public partial class Editar : Form
    {
        public string Descripcion;
        public DataGridView Grilla;
        private PerfilController PerfilController;

        public Editar()
        {
            InitializeComponent();
            PerfilController = new PerfilController("Perfil");
        }
        private void Editar_Load(object sender, EventArgs e)
        {
            var perfil = PerfilController.ObtenerPerfil(Descripcion);
            txtDescripcion.Text = perfil.Descripcion;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            PerfilController.ABM(2, null, this, Descripcion, Grilla);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
