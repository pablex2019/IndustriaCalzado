using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustriaCalzado.Modelo
{
    public class EmpleadoModel
    {
        public int Id { get; set; }
        public int Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string CorreoElectronico { get; set; }
        public string Sexo { get; set; }
        public PerfilModel PerfilModel { get; set; }
        public TurnoModel TurnoModel { get; set; }
        public HorarioModel HorarioModel { get; set; }
        public UsuarioModel UsuarioModel { get; set; }
        public bool Estado { get; set; }
    }
}
