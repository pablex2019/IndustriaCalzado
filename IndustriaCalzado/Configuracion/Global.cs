using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustriaCalzado.Configuracion
{
    public class Global
    {
        private string archivoDatos;

        public Global(string archivo)
        {
            this.archivoDatos = archivo;
            if (!File.Exists(this.archivoDatos))
            {
                //Si no existe el archivo lo crea
                FileStream fs = File.Create(this.archivoDatos);
                fs.Close();
            }
        }
        public string Leer()
        {
            //Se abre el archivo y se leer el contenido del mismo
            string s = string.Empty;
            using (StreamReader sr = File.OpenText(this.archivoDatos))
            {
                s = sr.ReadLine();
            }
            return s;
        }
        public void Guardar(string valores)
        {
            //Borro el archivo anterior
            if (File.Exists(this.archivoDatos))
            {
                File.Delete(this.archivoDatos);
            }
            //Creo el nuevo archivo con la información actualizada
            using (FileStream fs = File.Create(this.archivoDatos))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(valores);
                fs.Write(info, 0, info.Length);
            }
        }
        /// <summary>
        /// Metodo creado con el proposito de que al cerrar la aplicacion
        /// no quede ningun archivo de texto generado
        /// </summary>
        /// <param name="valores"></param>
        public void Finalizar(string valores) 
        {
            File.Delete(this.archivoDatos);
        }
    }
}
