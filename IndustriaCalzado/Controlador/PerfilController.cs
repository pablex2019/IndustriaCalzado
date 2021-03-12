using IndustriaCalzado.Configuracion;
using IndustriaCalzado.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public PerfilModel ObtenerColor(int Codigo)
        {
            Leer();
            return ListaPerfiles.FirstOrDefault(x => x.Codigo == Codigo);
        }
        public void Existe(Vista.Color.Nuevo Nuevo, DataGridView Grilla)
        {
            Leer();
            if (ListaColores.Count >= 0)
            {
                if (ListaColores.Any(x => x.Codigo == Convert.ToInt32(Nuevo.txtCodigo.Text) || x.Descripcion == Nuevo.txtDescripcion.Text) == false)
                {
                    ABM(1, Nuevo, null, 0, Grilla);
                }
                else
                {
                    MessageBox.Show("Ya existe el color", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Estado = False (Significa que se encuentra activo)
        /// Estado = true (Significa que se encuentra inactivo)
        /// </summary>
        /// <param name="Operacion"></param>
        /// <param name="Nuevo"></param>
        public void ABM(int Operacion, Vista.Color.Nuevo Nuevo, Vista.Color.Editar Editar, int Codigo, DataGridView Grilla)
        {
            ColorModel color = new ColorModel();
            if (Codigo != 0 || Operacion != 3)
            {
                switch (Operacion)
                {

                    case 1:
                        color.Id = ObtenerUltimoIdColor();
                        color.Codigo = Convert.ToInt32(Nuevo.txtCodigo.Text);
                        color.Descripcion = Nuevo.txtDescripcion.Text;
                        color.Estado = false;
                        ListaColores.Add(color);
                        MessageBox.Show("Color Agregado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grilla.DataSource = ListaColores.ToList();
                        break;
                    case 2:
                        color = ObtenerColor(Codigo);
                        color.Codigo = Convert.ToInt32(Editar.txtCodigo.Text);
                        color.Descripcion = Editar.txtDescripcion.Text;
                        MessageBox.Show("Color Editado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grilla.DataSource = ListaColores.ToList();
                        Editar.Close();
                        break;
                    case 3:
                        color = ObtenerColor(Codigo);
                        color.Estado = true;
                        MessageBox.Show("Color Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grilla.DataSource = ListaColores.ToList();
                        break;
                }
                Guardar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un color", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Salir(string valor)
        {
            AccesoADatos.Finalizar(valor);
        }
    }
}
