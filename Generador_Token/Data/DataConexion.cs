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
                throw new InvalidOperationException("La cadena de conexión no ha sido configurada. Seleccione un servidor y la base de datos correspondiente antes de continuar.");
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
            ActualizarCadenaConexion();
        }

        public static ConexionIp ObtenerConfiguracionActual()
        {
            return configuracionActual;
        }

        public static void SeleccionarBaseDatos(string nombreBaseDatos)
        {
            if (configuracionActual == null)
            {
                throw new InvalidOperationException("Seleccione primero un servidor para la conexión.");
            }

            configuracionActual.Database = nombreBaseDatos;
            ActualizarCadenaConexion();
        }

        private static void ActualizarCadenaConexion()
        {
            if (configuracionActual == null)
            {
                connectionString = null;
                return;
            }

            var databaseSegment = string.IsNullOrWhiteSpace(configuracionActual.Database)
                ? string.Empty
                : $"Database={configuracionActual.Database}; ";

            connectionString = $"{databaseSegment}Data Source={configuracionActual.DataSource}; User Id={configuracionActual.Usuario}; Password={configuracionActual.Password}; ConvertZeroDateTime=True";
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
