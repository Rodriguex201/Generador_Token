using System;
using MySqlConnector;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Generador_Token.Models;
using System.Threading.Tasks;

namespace Generador_Token.Data
{
    internal class DataConexion
    {
        public static MySqlConnection conexionBD { get; set; }
        private static string connectionString { get; set; }

        public static async Task<MySqlConnection> Conectar()
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("La cadena de conexión no ha sido configurada. Seleccione una base de datos antes de continuar.");
            }

            try
            {
                conexionBD = new MySqlConnection(connectionString);
                return conexionBD;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("El error es " + ex.Message);
                //throw;
                return null;

            } 
        }
        private static ConexionIp configuracionActual;

        public static void Configure(ConexionIp configuracion)
        {
            if (configuracion == null)
            {
                throw new ArgumentNullException(nameof(configuracion));
            }

            configuracionActual = configuracion;
            connectionString = $"Database={configuracion.Database}; Data Source={configuracion.DataSource}; User Id={configuracion.Usuario}; Password={configuracion.Password}; ConvertZeroDateTime=True";
        }

        public static ConexionIp ObtenerConfiguracionActual()
        {
            return configuracionActual;
        }

        public static void Abrir()
        {
            conexionBD.Open();
        }

        public static void Cerrar()
        {
            conexionBD.Close();
        }
    }
}
