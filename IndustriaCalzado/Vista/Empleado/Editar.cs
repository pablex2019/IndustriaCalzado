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
    public partial class Editar : Form
    {
        public int Documento;
        public DataGridView Grilla;
        private EmpleadoController EmpleadoController;

        public Editar()
        {
            InitializeComponent();
            EmpleadoController = new EmpleadoController("Empleado");
        }
    }
}
