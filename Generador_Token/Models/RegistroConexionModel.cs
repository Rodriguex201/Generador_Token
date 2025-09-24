using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generador_Token.Models
{
    internal class RegistroConexionModel
    {
        [PrimaryKey, AutoIncrement]
        public string CodEmpresa{get; set;}
        public string IpConexion { get; set;}
        public string User { get; set;}
        public string Password { get; set;} 
    }
}
