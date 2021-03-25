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

namespace IndustriaCalzado.Vistas.Turno
{
    public partial class Ver : Form
    {
        public int Codigo;
        private TurnoController TurnoController;
        private HorarioController HorarioController;

        public Ver()
        {
            InitializeComponent();
            TurnoController = new TurnoController("Turnos");
            HorarioController = new HorarioController("Horarios");
        }

        private void Ver_Load(object sender, EventArgs e)
        {
            var turno = TurnoController.ObtenerTurno(Codigo);
            txtCodigo.Text = turno.Codigo.ToString();
            txtDescripcion.Text = turno.Descripcion;
            dgvHorarios.DataSource = HorarioController.Listado();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
