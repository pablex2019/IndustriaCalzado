using IndustriaCalzado.Configuracion;
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

namespace IndustriaCalzado
{
    public partial class IniciarSesion : Form
    {
        private UsuarioController UsuarioController;
        private ColorController ColorController;

        public IniciarSesion()
        {
            InitializeComponent();
            UsuarioController = new UsuarioController("Usuario");
            ColorController = new ColorController("Color");
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            UsuarioController.ValidarExistencia(txtUsuario.Text, txtClave.Text,this);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            UsuarioController.Salir("Usuario", null);
            ColorController.Salir("Color");
        }
    }
}
