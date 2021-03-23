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
        public int Codigo { get; set; }
        public string Descripcion { get; set; } //Mañana-Tarde-Noche
        public List<HorarioModel> HorarioModels { get; set; }
        public bool Estado { get; set; }
    }
}
