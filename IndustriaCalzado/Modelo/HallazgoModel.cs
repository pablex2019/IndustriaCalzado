using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustriaCalzado.Modelo
{
    public class HallazgoModel
    {
        public int Id { get; set; }
        public string Hora { get; set; }
        public int cantidad { get; set; }
        public HorarioModel TurnoModel { get; set; }
        public EmpleadoModel EmpleadoModel { get; set; }
        PieModel PieModel { get; set; }
    }
}
