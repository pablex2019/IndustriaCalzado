using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustriaCalzado.Modelo
{
    public class DefectoModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public List<HallazgoModel> HallazgoModels { get; set; }
        TipoDefectoModel TipoDefectoModel { get; set; }
        public bool Estado { get; set; }
    }
}
