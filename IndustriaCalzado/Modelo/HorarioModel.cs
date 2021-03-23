using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustriaCalzado.Modelo
{
    public class HorarioModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string HoraDesde { get; set; }
        public string HoraHasta { get; set; }
        public bool Estado { get; set; }
    }
}
