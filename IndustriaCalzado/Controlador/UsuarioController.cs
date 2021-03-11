using IndustriaCalzado.Configuracion;
using IndustriaCalzado.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndustriaCalzado.Controlador
{
    public class UsuarioController
    {
        private string Archivo { get; set; }
        private Global AccesoADatos { get; set; }
        private List<UsuarioModel> ListaUsuarios { get; set; }
        private string DatosUsuarios;

        public UsuarioController(string _Archivo)
        {
            this.Archivo = _Archivo;
            this.AccesoADatos = new Global(this.Archivo);
        }
        private void Leer()
        {
            this.DatosUsuarios = this.AccesoADatos.Leer();
            this.ListaUsuarios = this.DatosUsuarios?.Length > 0 ? JsonConvert.DeserializeObject<List<UsuarioModel>>(this.DatosUsuarios) : new List<UsuarioModel>();
        }
        private void Guardar()
        {
            //Convierto todos los datos a string
            this.DatosUsuarios = JsonConvert.SerializeObject(this.ListaUsuarios);
            this.AccesoADatos.Guardar(this.DatosUsuarios);
        }
        public void ValidarExistencia(string Nombre,string Clave,IniciarSesion IniciarSesion)
        {
            Leer();
            if (ListaUsuarios.Count > 0) 
            {
                if(ListaUsuarios.Any(x => x.Nombre == Nombre && x.Clave == Clave)==true)
                {
                    new Vista.Panel().Show();
                    IniciarSesion.Hide();
                }
                else
                {
                    MessageBox.Show("No existe el usuario y/o clave", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
            else
            {
                UsuarioModel usuario = new UsuarioModel();
                usuario.Id = 1;
                usuario.Nombre = "admin";
                usuario.Clave = "123";
                ListaUsuarios.Add(usuario);
                MessageBox.Show("No existen usuario en la base de datos, por tal motivo se creo el siguiente usuario" + Environment.NewLine + Environment.NewLine + "Usuario: admin" + Environment.NewLine + "Clave: 123","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Guardar();
            }
        }
        public void Salir(string valor,Vista.Panel Panel)
        {
            AccesoADatos.Finalizar(valor);
            if (Panel == null)
            {
                Application.Exit();
            }
            else
            {   
                Panel.Hide();
                new IniciarSesion().Show();
            }
        }
    }
}
