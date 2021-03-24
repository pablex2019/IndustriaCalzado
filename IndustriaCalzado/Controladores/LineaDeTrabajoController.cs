using IndustriaCalzado.Configuracion;
using IndustriaCalzado.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public LineaDeTrabajoModel ObtenerColor(int Codigo)
        {
            Leer();
            return ListaLineasDeTrabajos.FirstOrDefault(x => x.Codigo == Codigo && x.Estado == false);
        }
    }
}
