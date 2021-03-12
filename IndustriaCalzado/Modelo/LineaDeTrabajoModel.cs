using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustriaCalzado.Modelo
{
    public class LineaDeTrabajoModel
    {
        public int Id { get; set; }
        public List<OrdenDeProduccionModel> OrdenesDeProduccionModel { get; set; }
        public bool Estado;
    }
}
