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
    public class HorarioController
    {
        private string Archivo { get; set; }
        private Global AccesoADatos { get; set; }
        private List<HorarioModel> ListaHorarios { get; set; }
        private string DatosHorarios;

        public HorarioController(string _Archivo)
        {
            this.Archivo = _Archivo;
            this.AccesoADatos = new Global(this.Archivo);
        }
        private void Leer()
        {
            this.DatosHorarios = this.AccesoADatos.Leer();
            this.ListaHorarios = this.DatosHorarios?.Length > 0 ? JsonConvert.DeserializeObject<List<HorarioModel>>(this.DatosHorarios) : new List<HorarioModel>();
        }
        private void Guardar()
        {
            //Convierto todos los datos a string
            this.DatosHorarios = JsonConvert.SerializeObject(this.ListaHorarios);
            this.AccesoADatos.Guardar(this.DatosHorarios);
        }
        public int ObtenerUltimoIdTurno()
        {
            Leer();
            if (ListaHorarios.Count == 0)
            {
                return 1;
            }
            else
            {
                return ListaHorarios.Max(x => x.Id) + 1;
            }
        }
        public HorarioModel ObtenerHorario(int Id)
        {
            Leer();
            return ListaHorarios.FirstOrDefault(x => x.Id == Id);
        }
        public void Existe(Vistas.Horario.Nuevo Nuevo, DataGridView Grilla)
        {
            Leer();
            if (ListaHorarios.Count >= 0)
            {
                //if (ListaHorarios.Any(x => x.HoraDesde == Convert.ToInt32(Nuevo.Text) || x.Descripcion == Nuevo.txtDescripcion.Text) == false)
                //{
                //    ABM(1, Nuevo, null, 0, Grilla);
                //}
                //else
                //{
                //    MessageBox.Show("Ya se encuentra registrado el horario, ya sea con la misma descripción o el mismo codigo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }
    }
}
