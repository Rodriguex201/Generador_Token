using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generador_Token.Models
{
    public class EmpresaModel
    {   
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string empresa { get; set; }
        public string nro_mac { get; set; }
        public string maquina { get; set; }
        public string factivar { get; set; }
        public string facceso { get; set; }
        public string activar { get; set; }
        public DateTime fsuspende { get; set; }
        public string eq_notas { get; set; }
        public string ip_origen { get; set; }
        public string serieprg { get; set; }
        public string mensaje { get; set; }
        public string modulos { get; set; }
        public string terminal { get; set; }
        public int grupo { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string sucursal { get; set; }
        public string ipserver { get; set; }
        public string serverPassword { get; set; }
        public int codigo_act { get; set; }
    }
}