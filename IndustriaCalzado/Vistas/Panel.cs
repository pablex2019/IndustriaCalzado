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

namespace IndustriaCalzado.Vista
{
    public partial class Panel : Form
    {
        private UsuarioController UsuarioController;
        private ColorController ColorController;

        public Panel()
        {
            InitializeComponent();
            UsuarioController = new UsuarioController("Usuario");
            ColorController = new ColorController("Color");
        }
        private void mnuColor_Click(object sender, EventArgs e)
        {
            new Color.Indice().Show();
        }
        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            UsuarioController.Salir("Usuario", this);
            ColorController.Salir("Color");
        }

        private void mnuModelo_Click(object sender, EventArgs e)
        {
            new Modelo.Indice().Show();
        }

        private void mnuEmpleado_Click(object sender, EventArgs e)
        {
            new Empleado.Indice().Show();
        }

        private void mnuPerfil_Click(object sender, EventArgs e)
        {
            new Perfil.Indice().Show();
        }

        private void mnuTurno_Click(object sender, EventArgs e)
        {
            new Turno.Indice().Show();
        }
    }
}
