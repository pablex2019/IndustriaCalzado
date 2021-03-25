using IndustriaCalzado.Configuracion;
using IndustriaCalzado.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndustriaCalzado.Controladores
{
    public class LineaDeTrabajoController
    {
        private string Archivo { get; set; }
        private Global AccesoADatos { get; set; }
        private List<LineaDeTrabajoModel> ListaLineasDeTrabajos { get; set; }
        private string DatosLineasDeTrabajos;

        public LineaDeTrabajoController(string _Archivo)
        {
            this.Archivo = _Archivo;
            this.AccesoADatos = new Global(this.Archivo);
        }
        private void Leer()
        {
            this.DatosLineasDeTrabajos = this.AccesoADatos.Leer();
            this.ListaLineasDeTrabajos = this.DatosLineasDeTrabajos?.Length > 0 ? JsonConvert.DeserializeObject<List<LineaDeTrabajoModel>>(this.DatosLineasDeTrabajos) : new List<LineaDeTrabajoModel>();
        }
        private void Guardar()
        {
            //Convierto todos los datos a string
            this.DatosLineasDeTrabajos = JsonConvert.SerializeObject(this.ListaLineasDeTrabajos);
            this.AccesoADatos.Guardar(this.DatosLineasDeTrabajos);
        }
        public int ObtenerUltimoIdLineaDeTrabajo()
        {
            Leer();
            if (ListaLineasDeTrabajos.Count == 0)
            {
                return 1;
            }
            else
            {
                return ListaLineasDeTrabajos.Max(x => x.Id) + 1;
            }
        }
        public List<LineaDeTrabajoModel> Listado()
        {
            Leer();
            return ListaLineasDeTrabajos.Where(x => x.Estado != true).ToList();
        }
        public LineaDeTrabajoModel ObtenerLineaDeTrabajo(int NumeroLinea)
        {
            Leer();
            return ListaLineasDeTrabajos.FirstOrDefault(x => x.NumeroLinea == NumeroLinea && x.Estado == false);
        }
        public void Existe(int Operacion,Vista.LineaDeTrabajo.Nuevo Nuevo, DataGridView Grilla)
        {
            Leer();
            if (ListaLineasDeTrabajos.Count >= 0)
            {
                switch (Operacion)
                {
                    case 1:
                        if (ListaLineasDeTrabajos.Any(x => x.NumeroLinea == Convert.ToInt32(Nuevo.txtNumeroLinea.Text) && x.Estado == false) == false)
                        {
                            ABM(1, Nuevo, null, 0, Grilla);
                        }
                        else
                        {
                            MessageBox.Show("Ya existe la linea de trabajo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
        }
        public void ABM(int Operacion, Vista.LineaDeTrabajo.Nuevo Nuevo, Vista.LineaDeTrabajo.Editar Editar, int NumeroDeLinea, DataGridView Grilla)
        {
            LineaDeTrabajoModel lineaDeTrabajoModel = new LineaDeTrabajoModel();
            OrdenDeProduccionModel ordenDeProduccionModel = new OrdenDeProduccionModel();
            if (NumeroDeLinea != 0 || Operacion != 3)
            {
                switch (Operacion)
                {
                    case 1:
                        //lineaDeTrabajoModel.Id = ObtenerUltimoIdLineaDeTrabajo();
                        //lineaDeTrabajoModel.NumeroLinea = Convert.ToInt32(Nuevo.txtNumeroLinea.Text);
                        //lineaDeTrabajoModel.OrdenesDeProduccionModel.Add();
                        //lineaDeTrabajoModel.Estado = false;
                        //ListaLineasDeTrabajos.Add();
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                }
                Guardar();
                Grilla.DataSource = Listado();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una linea de trabajo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Salir(string valor)
        {
            AccesoADatos.Finalizar(valor);
        }
    }
}
