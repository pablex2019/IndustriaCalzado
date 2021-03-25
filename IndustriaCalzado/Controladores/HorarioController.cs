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
        public void Existe(int Operacion,Vistas.Horario.Nuevo Nuevo,Vistas.Horario.Editar Editar, DataGridView Grilla)
        {
            Leer();
            if (ListaHorarios.Count >= 0)
            {
                switch(Operacion)
                {
                    case 1:
                        if (ListaHorarios.Any(x => (x.HoraDesde == Nuevo.txtHoraDesde.Text || x.HoraHasta == Nuevo.txtHoraHasta.Text || x.Codigo == Convert.ToInt32(Nuevo.txtCodigo.Text)) && x.Estado != true) == false)
                        {
                            ABM(1,Nuevo,null,0,Grilla);
                        }
                        else
                        {
                            MessageBox.Show("Ya se encuentra registrado el mismo rango de horario", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case 2:
                        if (ListaHorarios.Any(x => (x.HoraDesde == Editar.txtHoraDesde.Text || x.HoraHasta == Editar.txtHoraHasta.Text && x.Codigo == Convert.ToInt32(Editar.txtCodigo.Text)) && x.Estado != true) == false)
                        {
                            ABM(2,null,Editar,Editar.Codigo,Grilla);
                        }
                        else
                        {
                            MessageBox.Show("Ya se encuentra registrado el mismo rango de horario", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
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
                        Nuevo.txtCodigo.Text = string.Empty;
                        Nuevo.txtHoraDesde.Text = string.Empty;
                        Nuevo.txtHoraHasta.Text = string.Empty;
                        MessageBox.Show("Horario Agregado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 2:
                        horario = ObtenerHorario(Codigo);
                        horario.Codigo = Convert.ToInt32(Editar.txtCodigo.Text);
                        horario.HoraDesde = Editar.txtHoraDesde.Text;
                        horario.HoraHasta = Editar.txtHoraHasta.Text;
                        MessageBox.Show("Horario Editado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Editar.Close();
                        break;
                    case 3:
                        horario = ObtenerHorario(Codigo);
                        horario.Estado = true;
                        MessageBox.Show("Horario Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
                Guardar();
                Grilla.DataSource = Listado();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un horario", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Salir(string valor)
        {
            AccesoADatos.Finalizar(valor);
        }
    }
}
