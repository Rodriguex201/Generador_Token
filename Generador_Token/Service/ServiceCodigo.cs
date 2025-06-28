using Generador_Token.Data;
using Generador_Token.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Generador_Token.Service
{
    internal class ServiceCodigo
    {
        public static string CrearCodActivacionFecha(string mac, string dispositivo, string codigoEmpresa)
        {
            // Agrega la fecha al formato año-mes-día
            string fechaHoy = DateTime.UtcNow.ToString("yyyyMMdd"); // Ej: 20250628

            string datosCombinados = mac + dispositivo + codigoEmpresa + fechaHoy;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(datosCombinados));

                long numero = 0;
                for (int i = 0; i < 8; i++)
                {
                    numero = (numero << 8) + hashBytes[i];
                }

                long codigo8Digitos = Math.Abs(numero % 100000000);

                return codigo8Digitos.ToString("D8");
            }
        }

        public static async void RegistrarCod(string cod, string mac)
        {
            DataConexion.GetConnectionString(new List<Models.EmpresaModel>()); // Cambiado a acceso estático
            var conexionDB = await DataConexion.Conectar();

            try
            {
                DataConexion.Abrir();
                string query = $"UPDATE empresas.llequipo SET codigo_act = '{cod}' WHERE nro_mac = '{mac}';";
                MySqlCommand comando = new MySqlCommand(query);
                comando.Parameters.AddWithValue("@cod", cod);
                comando.Parameters.AddWithValue("@mac", mac);
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al registrar código: " + ex.Message);
            }
           
        }

    }
}
