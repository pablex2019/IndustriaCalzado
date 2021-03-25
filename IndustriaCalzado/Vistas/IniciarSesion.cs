using IndustriaCalzado.Configuracion;
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

namespace IndustriaCalzado
{
    public partial class IniciarSesion : Form
    {
        private UsuarioController UsuarioController;
        private ColorController ColorController;
        private ModeloController ModeloController;
        private PerfilController PerfilController;
        private TurnoController TurnoController;
        private HorarioController HorarioController;
        private EmpleadoController EmpleadoController;

        public IniciarSesion()
        {
            InitializeComponent();
            UsuarioController = new UsuarioController("Usuarios");
            ColorController = new ColorController("Colores");
            ModeloController = new ModeloController("Modelos");
            PerfilController = new PerfilController("Perfiles");
            TurnoController = new TurnoController("Turnos");
            EmpleadoController = new EmpleadoController("Empleados");
            HorarioController = new HorarioController("Horarios");
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            UsuarioController.ValidarExistencia(txtUsuario.Text, txtClave.Text,this);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            UsuarioController.Salir("Usuarios", null);
            ColorController.Salir("Colores");
            ModeloController.Salir("Modelos");
            PerfilController.Salir("Perfiles");
            TurnoController.Salir("Turnos");
            HorarioController.Salir("Horarios");
            //EmpleadoController.Salir("Empelados");           
        }
    }
}
