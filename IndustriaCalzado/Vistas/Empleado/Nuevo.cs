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

namespace IndustriaCalzado.Vista.Empleado
{
    public partial class Nuevo : Form
    {
        public DataGridView Grilla;
        private List<string> Sexos = new List<string>();
        private EmpleadoController EmpleadoController;
        private PerfilController PerfilController;
        private TurnoController TurnoController;

        public Nuevo()
        {
            InitializeComponent();
            EmpleadoController = new EmpleadoController("Empleado");
            PerfilController = new PerfilController("Perfil");
            TurnoController = new TurnoController("Turno");
        }
        private void Nuevo_Load(object sender, EventArgs e)
        {
            Sexos.Add("Masculino");
            Sexos.Add("Femenino");
            Sexos.Add("Indefinido");
            cboSexo.DataSource = Sexos.ToList();
            cboPerfil.DataSource = PerfilController.Listado().Select(x => x.Descripcion).ToList();
            cboTurno.DataSource = TurnoController.Listado().Select(x=>x.Descripcion).ToList();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EmpleadoController.Existe(this, Grilla);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
