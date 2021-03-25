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

namespace IndustriaCalzado.Vistas.Horario
{
    public partial class Editar : Form
    {
        public int Codigo;
        public DataGridView Grilla;
        private HorarioController HorarioController;

        public Editar()
        {
            InitializeComponent();
            HorarioController = new HorarioController("Horarios");
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            var horario = HorarioController.ObtenerHorario(Codigo);
            txtCodigo.Text = horario.Codigo.ToString();
            txtHoraDesde.Text = horario.HoraDesde;
            txtHoraHasta.Text = horario.HoraHasta;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            HorarioController.Existe(2, null, this, Grilla);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
