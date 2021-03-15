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
        public void Existe(Vista.Turno.Nuevo Nuevo, DataGridView Grilla)
        {
            Leer();
            if (ListaTurnos.Count >= 0)
            {
                if (ListaTurnos.Any(x => x.Descripcion == Nuevo.txtDescripcion.Text || x.HoraDesde == Nuevo.txtHoraDesde.Text || x.HoraHasta == Nuevo.txtHoraHasta.Text) == false)
                {
                    ABM(1, Nuevo, null, null, Grilla);
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
        public void ABM(int Operacion, Vista.Turno.Nuevo Nuevo, Vista.Turno.Editar Editar, string Descripcion, DataGridView Grilla)
        {
            TurnoModel turno = new TurnoModel();
            if (!string.IsNullOrEmpty(Descripcion) || Operacion != 3)
            {
                switch (Operacion)
                {

                    case 1:
                        turno.Id = ObtenerUltimoIdTurno();
                        turno.Descripcion = Nuevo.txtDescripcion.Text;
                        turno.HoraDesde = Nuevo.txtHoraDesde.Text;
                        turno.HoraHasta = Nuevo.txtHoraHasta.Text;
                        turno.Estado = false;
                        ListaTurnos.Add(turno);
                        MessageBox.Show("Turno Agregado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grilla.DataSource = ListaTurnos.ToList();
                        break;
                    case 2:
                        turno = ObtenerTurno(Descripcion);
                        turno.Descripcion = Editar.txtDescripcion.Text;
                        turno.HoraDesde = Editar.txtHoraDesde.Text;
                        turno.HoraHasta = Editar.txtHoraHasta.Text;
                        MessageBox.Show("Turno Editado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grilla.DataSource = ListaTurnos.ToList();
                        Editar.Close();
                        break;
                    case 3:
                        turno = ObtenerTurno(Descripcion);
                        turno.Estado = true;
                        MessageBox.Show("Turno Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
                Guardar();
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
