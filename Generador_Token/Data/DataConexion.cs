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
        public static void GetConnectionString(List<EmpresaModel> empresa)
        {
            connectionString = $"Database = a000; Data Source = 168.232.32.74; User Id = RmSoft20X; Password= *LiLo89*; ConvertZeroDateTime=True";
            //connectionString = "Database = login; Data Source = localhost; User Id = root; Password= 1234";
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
