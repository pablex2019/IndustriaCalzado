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
    public class ColorController
    {
        private string Archivo { get; set; }
        private Global AccesoADatos { get; set; }
        private List<ColorModel> ListaColores { get; set; }
        private string DatosColores;

        public ColorController(string _Archivo)
        {
            this.Archivo = _Archivo;
            this.AccesoADatos = new Global(this.Archivo);
        }
        private void Leer()
        {
            this.DatosColores = this.AccesoADatos.Leer();
            this.ListaColores = this.DatosColores?.Length > 0 ? JsonConvert.DeserializeObject<List<ColorModel>>(this.DatosColores) : new List<ColorModel>();
        }
        private void Guardar()
        {
            //Convierto todos los datos a string
            this.DatosColores = JsonConvert.SerializeObject(this.ListaColores);
            this.AccesoADatos.Guardar(this.DatosColores);
        }
        public int ObtenerUltimoIdColor()
        {
            Leer();
            if (ListaColores.Count == 0)
            {
                return 1;
            }
            else
            {
                return ListaColores.Max(x => x.Id) + 1;
            }
        }
        public List<ColorModel> Listado()
        {
            Leer();
            return ListaColores.Where(x=>x.Estado!=true).ToList();
        }
        public ColorModel ObtenerColor(int Codigo)
        {
            Leer();
            return ListaColores.FirstOrDefault(x => x.Codigo == Codigo && x.Estado == false);
        }
        public void Existe(int Operacion,Vista.Color.Nuevo Nuevo,Vista.Color.Editar Editar, DataGridView Grilla)
        {
            Leer();
            if (ListaColores.Count >= 0)
            {
                switch (Operacion)
                {
                    case 1:
                        if (ListaColores.Any(x => (x.Codigo == Convert.ToInt32(Nuevo.txtCodigo.Text) || x.Descripcion == Nuevo.txtDescripcion.Text) && x.Estado != true) == false)
                        {
                            ABM(1, Nuevo, null, 0, Grilla);
                        }
                        else
                        {
                            MessageBox.Show("Ya se encuentra registrado el color, ya sea con la misma descripción o el mismo codigo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case 2:
                        if (ListaColores.Any(x => (x.Codigo == Convert.ToInt32(Editar.txtCodigo.Text) && x.Descripcion == Editar.txtDescripcion.Text) && x.Estado != true) == false)
                        {
                            ABM(2, null, Editar, Convert.ToInt32(Editar.txtCodigo.Text), Grilla);
                        }
                        else
                        {
                            MessageBox.Show("Ya se encuentra registrado el color, ya sea con la misma descripción o el mismo codigo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// Estado = False (Significa que se encuentra activo)
        /// Estado = true (Significa que se encuentra inactivo)
        /// </summary>
        /// <param name="Operacion"></param>
        /// <param name="Nuevo"></param>
        public void ABM(int Operacion,Vista.Color.Nuevo Nuevo,Vista.Color.Editar Editar,int Codigo,DataGridView Grilla)
        {
            ColorModel color = new ColorModel();
            if(Codigo != 0 ||  Operacion != 3)
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
                        Nuevo.txtCodigo.Text = string.Empty;
                        Nuevo.txtDescripcion.Text = string.Empty;
                        break;
                    case 2:
                        color = ObtenerColor(Codigo);
                        color.Codigo = Convert.ToInt32(Editar.txtCodigo.Text);
                        color.Descripcion = Editar.txtDescripcion.Text;
                        MessageBox.Show("Color Editado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Editar.Close();
                        break;
                    case 3:
                        color = ObtenerColor(Codigo);
                        color.Estado = true;
                        MessageBox.Show("Color Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
                Guardar();
                Grilla.DataSource = Listado();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un color","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void Salir(string valor)
        {
            AccesoADatos.Finalizar(valor); 
        }
    }
}
