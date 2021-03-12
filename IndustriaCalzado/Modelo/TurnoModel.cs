using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustriaCalzado.Modelo
{
    public class TurnoModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string HoraDesde { get; set; }
        public string HoraHasta { get; set; }
        public string Estado { get; set; }
    }
}
