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
        private ModeloController ModeloController;

        public Panel()
        {
            InitializeComponent();
            UsuarioController = new UsuarioController("Usuarios");
            ColorController = new ColorController("Colores");
            ModeloController = new ModeloController("Modelos");
        }
        private void mnuColor_Click(object sender, EventArgs e)
        {
            new Color.Indice().Show();
        }
        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            UsuarioController.Salir("Usuarios", this);
            ColorController.Salir("Colores");
            ModeloController.Salir("Modelos");
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

        private void mnuLineasDeTrabajo_Click(object sender, EventArgs e)
        {
            new Vista.LineaDeTrabajo.Indice().Show();
        }

        private void mnuOrdenesDeProduccion_Click(object sender, EventArgs e)
        {
            new Vista.LineaDeTrabajo.Indice().Show();
        }
    }
}
