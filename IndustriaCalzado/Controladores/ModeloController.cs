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
    public class ModeloController
    {
        private string Archivo { get; set; }
        private Global AccesoADatos { get; set; }
        private List<ModeloModel> ListaModelos { get; set; }
        private string DatosModelos;

        public ModeloController(string _Archivo)
        {
            this.Archivo = _Archivo;
            this.AccesoADatos = new Global(this.Archivo);
        }
        private void Leer()
        {
            this.DatosModelos = this.AccesoADatos.Leer();
            this.ListaModelos = this.DatosModelos?.Length > 0 ? JsonConvert.DeserializeObject<List<ModeloModel>>(this.DatosModelos) : new List<ModeloModel>();
        }
        private void Guardar()
        {
            //Convierto todos los datos a string
            this.DatosModelos = JsonConvert.SerializeObject(this.ListaModelos);
            this.AccesoADatos.Guardar(this.DatosModelos);
        }
        public int ObtenerUltimoIdModelo()
        {
            Leer();
            if(ListaModelos.Count == 0)
            {
                return 1;
            }
            else
            {
                return ListaModelos.Max(x => x.Id) + 1;
            }
        }
        public List<ModeloModel> Listado()
        {
            Leer();
            return ListaModelos.Where(x => x.Estado != true).ToList();
        }
        public ModeloModel ObtenerModelo(string Sku)
        {
            Leer();
            return ListaModelos.FirstOrDefault(x => x.Sku == Sku && x.Estado == false);
        }
        public void Existe(int Operacion,Vista.Modelo.Nuevo Nuevo, Vista.Modelo.Editar Editar, DataGridView Grilla)
        {
            Leer();
            if (ListaModelos.Count >= 0)
            {
                switch (Operacion)
                {
                    case 1:
                        if (ListaModelos.Any(x => (x.Sku == Nuevo.txtSku.Text || x.Denominación == Nuevo.txtDenominacion.Text) && x.Estado != true) == false)
                        {
                            ABM(1, Nuevo, null, null, Grilla);
                        }
                        else
                        {
                            MessageBox.Show("Ya se encuentra registrado el color, ya sea con la misma descripción o el mismo codigo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case 2:
                        if (ListaModelos.Any(x => (x.Sku == Editar.txtSku.Text && x.Denominación == Editar.txtDenominacion.Text) && x.Estado != true) == false)
                        {
                            ABM(2, null, Editar, Editar.txtSku.Text, Grilla);
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
        public void ABM(int Operacion, Vista.Modelo.Nuevo Nuevo, Vista.Modelo.Editar Editar, string Sku, DataGridView Grilla)
        {
            ModeloModel modelo = new ModeloModel();
            if (!string.IsNullOrEmpty(Sku) || Operacion != 3)
            {
                switch (Operacion)
                {

                    case 1:
                        modelo.Id = ObtenerUltimoIdModelo();
                        modelo.Sku = Nuevo.txtSku.Text;
                        modelo.Denominación = Nuevo.txtDenominacion.Text;
                        modelo.Objetivo = Convert.ToInt32(Nuevo.txtObjetivo.Text);
                        modelo.Estado = false;
                        ListaModelos.Add(modelo);
                        MessageBox.Show("Modelo Agregado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Nuevo.txtSku.Text = string.Empty;
                        Nuevo.txtDenominacion.Text = string.Empty; 
                        Nuevo.txtObjetivo.Text = string.Empty;
                        break;
                    case 2:
                        modelo = ObtenerModelo(Sku);
                        modelo.Sku = Editar.txtSku.Text;
                        modelo.Denominación = Editar.txtDenominacion.Text;
                        modelo.Objetivo = Convert.ToInt32(Editar.txtObjetivo.Text);
                        MessageBox.Show("Modelo Editado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Editar.Close();
                        break;
                    case 3:
                        modelo = ObtenerModelo(Sku);
                        modelo.Estado = true;
                        MessageBox.Show("Modelo Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
                Guardar();
                Grilla.DataSource = Listado();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un modelo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Salir(string valor)
        {
            AccesoADatos.Finalizar(valor);
        }
    }
}
