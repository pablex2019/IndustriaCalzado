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
        public int Estado { get; set; }
    }
}
