using IndustriaCalzado.Configuracion;
using IndustriaCalzado.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndustriaCalzado.Controlador
{
    public class EmpleadoController
    {
        private string Archivo { get; set; }
        private Global AccesoADatos { get; set; }
        private List<EmpleadoModel> ListaEmpleados { get; set; }
        private string DatosEmpleados;
        private PerfilController PerfilController;
        private TurnoController TurnoController;
        private UsuarioController UsuarioController;

        public EmpleadoController(string _Archivo)
        {
            this.Archivo = _Archivo;
            this.AccesoADatos = new Global(this.Archivo);
            PerfilController = new PerfilController("Perfiles");
            TurnoController = new TurnoController("Turnos");
            UsuarioController = new UsuarioController("Usuarios");
        }
        private void Leer()
        {
            this.DatosEmpleados = this.AccesoADatos.Leer();
            this.ListaEmpleados = this.DatosEmpleados?.Length > 0 ? JsonConvert.DeserializeObject<List<EmpleadoModel>>(this.DatosEmpleados) : new List<EmpleadoModel>();
        }
        private void Guardar()
        {
            //Convierto todos los datos a string
            this.DatosEmpleados = JsonConvert.SerializeObject(this.ListaEmpleados);
            this.AccesoADatos.Guardar(this.DatosEmpleados);
        }
        public int ObtenerUltimoIdEmpleado()
        {
            Leer();
            if (ListaEmpleados.Count == 0)
            {
                return 1;
            }
            else
            {
                return ListaEmpleados.Max(x => x.Id) + 1;
            }
        }
        public List<EmpleadoModel> Listado()
        {
            Leer();
            return ListaEmpleados.Where(x => x.Estado != true).ToList();
        }
        public EmpleadoModel ObtenerEmpleado(int Documento)
        {
            Leer();
            return ListaEmpleados.FirstOrDefault(x => x.Documento == Documento);
        }
        public void Existe(Vista.Empleado.Nuevo Nuevo, DataGridView Grilla)
        {
            Leer();
            if (ListaEmpleados.Count >= 0)
            {
                if (ListaEmpleados.Any(x => x.Documento == Convert.ToInt32(Nuevo.txtDocumento.Text) || x.Sexo == Nuevo.ControlBox.ToString()) == false)
                {
                    ABM(1, Nuevo, null, 0, Grilla);
                }
                else
                {
                    MessageBox.Show("Ya existe el empleado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Estado = False (Significa que se encuentra activo)
        /// Estado = true (Significa que se encuentra inactivo)
        /// </summary>
        /// <param name="Operacion"></param>
        /// <param name="Nuevo"></param>
        public void ABM(int Operacion, Vista.Empleado.Nuevo Nuevo, Vista.Empleado.Editar Editar, int Documento, DataGridView Grilla)
        {
            EmpleadoModel empleado = new EmpleadoModel();
            if (Documento != 0 || Operacion != 3)
            {
                switch (Operacion)
                {
                    case 1:
                        empleado.Id = ObtenerUltimoIdEmpleado();
                        empleado.Documento = Convert.ToInt32(Nuevo.txtDocumento.Text);
                        empleado.Nombres = Nuevo.txtNombre.Text;
                        empleado.Apellidos = Nuevo.txtApellido.Text;
                        empleado.CorreoElectronico = Nuevo.txtCorreoElectronico.Text;
                        empleado.Sexo = Nuevo.cboSexo.Text;
                        empleado.PerfilModel = PerfilController.ObtenerPerfil(Nuevo.cboPerfil.Text);
                        empleado.TurnoModel = TurnoController.ObtenerTurno(Nuevo.cboTurno.Text);
                        UsuarioController.ABM(1, Nuevo, null, empleado.Documento);
                        empleado.UsuarioModel = UsuarioController.ObtenerUsuario(Nuevo.txtUsuario.Text, Nuevo.txtClave.Text);
                        empleado.Estado = false;
                        ListaEmpleados.Add(empleado);
                        MessageBox.Show("Empleado Agregado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grilla.DataSource = ListaEmpleados.ToList();
                        break;
                    case 2:
                        var _empleado = ObtenerEmpleado(Documento);
                        _empleado.Documento = Convert.ToInt32(Editar.txtDocumento.Text);
                        empleado.Id = ObtenerUltimoIdEmpleado();
                        empleado.Documento = Convert.ToInt32(Nuevo.txtDocumento.Text);
                        empleado.Nombres = Nuevo.txtNombre.Text;
                        empleado.Apellidos = Nuevo.txtApellido.Text;
                        empleado.CorreoElectronico = Nuevo.txtCorreoElectronico.Text;
                        empleado.Sexo = Nuevo.cboSexo.Text;
                        empleado.PerfilModel = PerfilController.ObtenerPerfil(Nuevo.cboPerfil.Text);
                        empleado.TurnoModel = TurnoController.ObtenerTurno(Nuevo.cboTurno.Text);
                        UsuarioController.ABM(1, Nuevo, null, empleado.Documento);
                        empleado.UsuarioModel = UsuarioController.ObtenerUsuario(Nuevo.txtUsuario.Text, Nuevo.txtClave.Text);
                        empleado.Estado = false;
                        ListaEmpleados.Add(empleado);
                        MessageBox.Show("Empleado Agregado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grilla.DataSource = ListaEmpleados.ToList();
                        break;
                    case 3:
                        empleado.Id = ObtenerUltimoIdEmpleado();
                        UsuarioController.ABM(1, Nuevo, null, empleado.Documento);
                        empleado.UsuarioModel = UsuarioController.ObtenerUsuario(Nuevo.txtUsuario.Text, Nuevo.txtClave.Text);
                        empleado.Estado = false;
                        ListaEmpleados.Add(empleado);
                        MessageBox.Show("Empleado Agregado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grilla.DataSource = ListaEmpleados.ToList();
                        break;
                }
                Guardar();
            }
            else
            {
                 MessageBox.Show("Debe seleccionar un empleado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
