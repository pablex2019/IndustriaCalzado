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
    public class PerfilController
    {
        private string Archivo { get; set; }
        private Global AccesoADatos { get; set; }
        private List<PerfilModel> ListaPerfiles { get; set; }
        private string DatosPerfiles;

        public PerfilController(string _Archivo)
        {
            this.Archivo = _Archivo;
            this.AccesoADatos = new Global(this.Archivo);
        }
        private void Leer()
        {
            this.DatosPerfiles = this.AccesoADatos.Leer();
            this.ListaPerfiles = this.DatosPerfiles?.Length > 0 ? JsonConvert.DeserializeObject<List<PerfilModel>>(this.DatosPerfiles) : new List<PerfilModel>();
        }
        private void Guardar()
        {
            //Convierto todos los datos a string
            this.DatosPerfiles = JsonConvert.SerializeObject(this.ListaPerfiles);
            this.AccesoADatos.Guardar(this.DatosPerfiles);
        }
        public int ObtenerUltimoIdPerfil()
        {
            Leer();
            if (ListaPerfiles.Count == 0)
            {
                return 1;
            }
            else
            {
                return ListaPerfiles.Max(x => x.Id) + 1;
            }
        }
        public List<PerfilModel> Listado()
        {
            Leer();
            return ListaPerfiles.Where(x => x.Estado != true).ToList();
        }
        public PerfilModel ObtenerPerfil(string Descrípcion)
        {
            Leer();
            return ListaPerfiles.FirstOrDefault(x => x.Descripcion == Descrípcion);
        }
        public void Existe(Vista.Perfil.Nuevo Nuevo, DataGridView Grilla)
        {
            Leer();
            if (ListaPerfiles.Count >= 0)
            {
                if (ListaPerfiles.Any(x => x.Descripcion == Nuevo.txtDescripcion.Text)==false)
                {
                    ABM(1, Nuevo, null, string.Empty, Grilla);
                }
                else
                {
                    MessageBox.Show("Ya existe el perfil", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Estado = False (Significa que se encuentra activo)
        /// Estado = true (Significa que se encuentra inactivo)
        /// </summary>
        /// <param name="Operacion"></param>
        /// <param name="Nuevo"></param>
        public void ABM(int Operacion, Vista.Perfil.Nuevo Nuevo, Vista.Perfil.Editar Editar, string Descripcion, DataGridView Grilla)
        {
            PerfilModel perfil = new PerfilModel();
            if (!string.IsNullOrEmpty(Descripcion) || Operacion != 3)
            {
                switch (Operacion)
                {

                    case 1:
                        perfil.Id = ObtenerUltimoIdPerfil();
                        perfil.Descripcion = Nuevo.txtDescripcion.Text;
                        perfil.Estado = false;
                        ListaPerfiles.Add(perfil);
                        MessageBox.Show("Perfil Agregado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grilla.DataSource = ListaPerfiles.ToList();
                        break;
                    case 2:
                        perfil = ObtenerPerfil(Descripcion);
                        perfil.Descripcion = Editar.txtDescripcion.Text;
                        perfil.Estado = false;
                        MessageBox.Show("Perfil Editado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grilla.DataSource = ListaPerfiles.ToList();
                        Editar.Close();
                        break;
                    case 3:
                        perfil = ObtenerPerfil(Descripcion);
                        perfil.Estado = true;
                        MessageBox.Show("Perfil Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grilla.DataSource = ListaPerfiles.ToList();
                        break;
                }
                Guardar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un perfil", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Salir(string valor)
        {
            AccesoADatos.Finalizar(valor);
        }
    }
}
