using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustriaCalzado.Modelo
{
    public class OrdenDeProduccionModel
    {
        public int Id { get; set; }
        public ColorModel ColorModel { get; set; }
        public ModeloModel ModeloModel { get; set; }
        public EmpleadoModel EmpleadoModel { get; set; }
        public TurnoModel TurnoModel { get; set; }
        public HorarioModel HorarioModel { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Estado { get; set; }

        /*
          ID: 1  
          Color: Blanco     Modelo:Nike 2021
          Fecha de Inicio: --   Fecha de Fin: ---
          Empleado: Pepito   Turno: Mañana
          Horario de Inicio: 08:00 - Horario de Fin: 12:00

         */
    }
}
