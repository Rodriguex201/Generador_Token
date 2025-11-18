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

        public string NombreSeguro => string.IsNullOrWhiteSpace(Nombre)
            ? ConstruirNombreSeguro()
            : Nombre;

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Nombre) ? ConstruirNombreSeguro() : Nombre;
        }

        private string ConstruirNombreSeguro()
        {
            if (string.IsNullOrWhiteSpace(DataSource))
            {
                return string.Empty;
            }

            var segmentos = DataSource.Split('.');
            if (segmentos.Length >= 2)
            {
                var partesEnmascaradas = Enumerable.Repeat("XXX", segmentos.Length - 1)
                    .Append(segmentos.Last());

                return $"Servidor {string.Join(".", partesEnmascaradas)}";
            }

            var longitudVisible = Math.Min(3, DataSource.Length);
            var sufijo = DataSource.Substring(DataSource.Length - longitudVisible, longitudVisible);
            return $"Servidor XXX{sufijo}";
        }
    }
}
