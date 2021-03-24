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
    public class TurnoController
    {
        private string Archivo { get; set; }
        private Global AccesoADatos { get; set; }
        private List<TurnoModel> ListaTurnos { get; set; }
        private string DatosTurnos;

        public TurnoController(string _Archivo)
        {
            this.Archivo = _Archivo;
            this.AccesoADatos = new Global(this.Archivo);
        }
        private void Leer()
        {
            this.DatosTurnos = this.AccesoADatos.Leer();
            this.ListaTurnos = this.DatosTurnos?.Length > 0 ? JsonConvert.DeserializeObject<List<TurnoModel>>(this.DatosTurnos) : new List<TurnoModel>();
        }
        private void Guardar()
        {
            //Convierto todos los datos a string
            this.DatosTurnos = JsonConvert.SerializeObject(this.ListaTurnos);
            this.AccesoADatos.Guardar(this.DatosTurnos);
        }
        public int ObtenerUltimoIdTurno()
        {
            Leer();
            if (ListaTurnos.Count == 0)
            {
                return 1;
            }
            else
            {
                return ListaTurnos.Max(x => x.Id) + 1;
            }
        }
        public List<TurnoModel> Listado()
        {
            Leer();
            return ListaTurnos.Where(x => x.Estado != true).ToList();
        }
        public TurnoModel ObtenerTurno(string Descripcion)
        {
            Leer();
            return ListaTurnos.FirstOrDefault(x => x.Descripcion == Descripcion);
        }
        public void Existe(Vista.Turno.Nuevo Nuevo, DataGridView GrillaTurno, DataGridView GrillaHorario)
        {
            Leer();
            if (ListaTurnos.Count >= 0)
            {
                if (ListaTurnos.Any(x => x.Descripcion == Nuevo.txtDescripcion.Text) == false)
                {
                    ABM(1, Nuevo, null, null, GrillaTurno, GrillaHorario);
                }
                else
                {
                    MessageBox.Show("Ya existe el turno", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Estado = False (Significa que se encuentra activo)
        /// Estado = true (Significa que se encuentra inactivo)
        /// </summary>
        /// <param name="Operacion"></param>
        /// <param name="Nuevo"></param>
        public void ABM(int Operacion, Vista.Turno.Nuevo Nuevo, Vista.Turno.Editar Editar, string Descripcion, DataGridView GrillaTurnos,DataGridView GrillaHorarios)
        {
            TurnoModel turno = new TurnoModel();
            List<HorarioModel> ListadoHorarios = new List<HorarioModel>();
            if (!string.IsNullOrEmpty(Descripcion) || Operacion != 3)
            {
                switch (Operacion)
                {

                    case 1:
                        //Agregar Turno
                        turno.Id = ObtenerUltimoIdTurno();
                        turno.Codigo = Convert.ToInt32(Nuevo.txtCodigo.Text);
                        turno.Descripcion = Nuevo.txtDescripcion.Text;
                        turno.Estado = false;
                        //Agregar Horario
                        HorarioModel horario = new HorarioModel();
                        for (int fila = 0;fila <GrillaHorarios.Rows.Count;fila ++)
                        {
                            //for(int col = 0; col <GrillaHorarios.Rows[fila].Cells.Count;col++)
                            //{
                                horario.Id = Convert.ToInt32(GrillaHorarios.Rows[fila].Cells[0].Value.ToString());
                                horario.Codigo = Convert.ToInt32(GrillaHorarios.Rows[fila].Cells[1].Value.ToString());
                                horario.HoraDesde = GrillaHorarios.Rows[fila].Cells[2].Value.ToString();
                                horario.HoraHasta = GrillaHorarios.Rows[fila].Cells[3].Value.ToString();
                                horario.Estado = false;
                                ListadoHorarios.Add(horario);
                            //}
                        }
                        turno.HorarioModels = ListadoHorarios;
                        ListaTurnos.Add(turno);
                        MessageBox.Show("Turno Agregado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Nuevo.txtDescripcion.Text = string.Empty;
                        GrillaHorarios.DataSource = 0;
                        break;
                    case 2:
                        turno = ObtenerTurno(Descripcion);
                        turno.Descripcion = Editar.txtDescripcion.Text;
                        MessageBox.Show("Turno Editado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Editar.Close();
                        break;
                    case 3:
                        turno = ObtenerTurno(Descripcion);
                        turno.Estado = true;
                        MessageBox.Show("Turno Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
                Guardar();
                GrillaTurnos.DataSource = Listado();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un turno", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Salir(string valor)
        {
            AccesoADatos.Finalizar(valor);
        }
    }
}
