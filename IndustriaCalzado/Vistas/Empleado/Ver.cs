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

namespace IndustriaCalzado.Vistas.Empleado
{
    public partial class Ver : Form
    {
        public int Documento;
        private EmpleadoController EmpladoController;
        private HorarioController HorarioController;

        public Ver()
        {
            InitializeComponent();
            EmpladoController = new EmpleadoController("Empleados");
            HorarioController = new HorarioController("Horarios");
        }
        private void Ver_Load(object sender, EventArgs e)
        {
            var empleado = EmpladoController.ObtenerEmpleado(Documento);
            txtDocumento.Text = empleado.Documento.ToString();
            txtNombre.Text = empleado.Nombres;
            txtApellido.Text = empleado.Apellidos;
            txtCorreoElectronico.Text = empleado.CorreoElectronico;
            List<string> Sexos = new List<string>();
            //Sexos.Add("Masculino");
            //Sexos.Add("Femenino");
            //Sexos.Add("Prefiero No Decirlo");
            //cboSexo.DataSource = Sexos;
            //cboSexo.SelectedIndex = empleado.Sexo.;
            //cboPerfil.Text = empleado.PerfilModel.Descripcion;
            //cboTurno.Text = empleado.TurnoModel.Descripcion;
            cboHorario.DataSource = HorarioController.Listado();
            cboHorario.SelectedItem = empleado.HorarioModel.Codigo.ToString();
            txtHoraDesde.Text = empleado.HorarioModel.HoraDesde;
            txtHoraHasta.Text = empleado.HorarioModel.HoraHasta;
            txtUsuario.Text = empleado.UsuarioModel.Nombre;
            txtClave.Text = empleado.UsuarioModel.Clave;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
