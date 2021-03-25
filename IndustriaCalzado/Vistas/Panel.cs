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

namespace IndustriaCalzado.Vista
{
    public partial class Panel : Form
    {
        public string Usuario;
        public string Clave;
        private UsuarioController UsuarioController;
        private ColorController ColorController;
        private ModeloController ModeloController;
        private PerfilController PerfilController;
        private TurnoController TurnoController;
        private HorarioController HorarioController;
        private EmpleadoController EmpleadoController;

        public Panel()
        {
            InitializeComponent();
            UsuarioController = new UsuarioController("Usuarios");
            ColorController = new ColorController("Colores");
            ModeloController = new ModeloController("Modelos");
            PerfilController = new PerfilController("Perfiles");
            TurnoController = new TurnoController("Turnos");
            HorarioController = new HorarioController("Horarios");
            EmpleadoController = new EmpleadoController("Empleados");
        }
        private void mnuColor_Click(object sender, EventArgs e)
        {
            new Color.Indice().Show();
        }
        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            //UsuarioController.Salir("Usuarios", this);
            ColorController.Salir("Colores");
            ModeloController.Salir("Modelos");
            PerfilController.Salir("Perfiles");
            TurnoController.Salir("Turnos");
            HorarioController.Salir("Horarios");
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

        private void Panel_Load(object sender, EventArgs e)
        {
            EmpleadoController.Permisos(Usuario,Clave,this);
        }
    }
}
