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
        public int ObtenerUltimoIdHorario()
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
        public List<HorarioModel> Listado()
        {
            Leer();
            return ListaHorarios.Where(x => x.Estado != true).ToList();
        }
        public HorarioModel ObtenerHorario(int Codigo)
        {
            Leer();
            return ListaHorarios.FirstOrDefault(x => x.Codigo == Codigo && x.Estado == false);
        }
        public void Existe(Vistas.Horario.Nuevo Nuevo, DataGridView Grilla)
        {
            Leer();
            if (ListaHorarios.Count >= 0)
            {
                if (ListaHorarios.Any(x => (x.HoraDesde == Nuevo.txtHoraDesde.Text || x.HoraHasta == Nuevo.txtHoraHasta.Text) && x.Estado != true) == false)
                {
                    ABM(1, Nuevo, null, 0, Grilla);
                }
                else
                {
                    MessageBox.Show("Ya se encuentra registrado el horario, con el mismo rango de horario", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void ABM(int Operacion, Vistas.Horario.Nuevo Nuevo, Vistas.Horario.Editar Editar, int Codigo, DataGridView Grilla)
        {
            HorarioModel horario = new HorarioModel();
            if (Codigo != 0 || Operacion != 3)
            {
                switch (Operacion)
                {
                    case 1:
                        horario.Id = ObtenerUltimoIdHorario();
                        horario.Codigo = Convert.ToInt32(Nuevo.txtCodigo.Text);
                        horario.HoraDesde = Nuevo.txtHoraDesde.Text;
                        horario.HoraHasta = Nuevo.txtHoraHasta.Text;
                        horario.Estado = false;
                        ListaHorarios.Add(horario);
                        MessageBox.Show("Horario Agregado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 2:
                        //horario = ObtenerHorario(Codigo);
                        
                        //MessageBox.Show("Modelo Editado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Editar.Close();
                        break;
                    case 3:
                        //modelo = ObtenerModelo(Sku);
                        //modelo.Estado = true;
                        //MessageBox.Show("Modelo Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
