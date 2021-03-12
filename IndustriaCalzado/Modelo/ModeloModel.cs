using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustriaCalzado.Modelo
{
    public class ModeloModel
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Denominación { get; set; }
        public int Objetivo { get; set; }
        public bool Estado { get; set; }
    }
}
