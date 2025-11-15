using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generador_Token.Models
{
    internal class ConexionIp
    {
        public string Nombre { get; set; }
        public string Database { get; set; }
        public string DataSource { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Nombre) ? base.ToString() : Nombre;
        }
    }
}
