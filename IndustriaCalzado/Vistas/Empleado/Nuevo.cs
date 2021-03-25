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

namespace IndustriaCalzado.Vista.Empleado
{
    public partial class Nuevo : Form
    {
        public DataGridView Grilla;
        public List<string> Sexos = new List<string>();
        private EmpleadoController EmpleadoController;
        private PerfilController PerfilController;
        private TurnoController TurnoController;
        private HorarioController HorarioController;

        public Nuevo()
        {
            InitializeComponent();
            EmpleadoController = new EmpleadoController("Empleados");
            PerfilController = new PerfilController("Perfiles");
            TurnoController = new TurnoController("Turnos");
            HorarioController = new HorarioController("Horarios");
        }
        private void Nuevo_Load(object sender, EventArgs e)
        {
            Sexos.Add("Masculino");
            Sexos.Add("Femenino");
            Sexos.Add("Prefiero No Decirlo");
            cboSexo.DataSource = Sexos.ToList();
            cboPerfil.DataSource = PerfilController.Listado().Select(x => x.Descripcion).ToList();
            cboTurno.DataSource = TurnoController.Listado().Select(x=>x.Descripcion).ToList();
        }
        private void cboTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboHorario.DataSource = HorarioController.Listado().Select(x => x.Codigo).ToList();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EmpleadoController.Existe(this, Grilla);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            var horario = HorarioController.ObtenerHorario(Convert.ToInt32(cboHorario.Text));
            txtHoraDesde.Text = horario.HoraDesde;
            txtHoraHasta.Text = horario.HoraHasta;
        }
    }
}
