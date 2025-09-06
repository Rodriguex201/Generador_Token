using Generador_Token.Data;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generador_Token.Service
{
    internal class ServiceBuscarEquipo
    {
        public static async Task<List<string>> ListaMac(string dispositivo)
        {
            DataConexion.GetConnectionString(new List<Models.EmpresaModel>()); // Cambiado a acceso estático
            var conexionDB = await DataConexion.Conectar();
            List<string> lista = new List<string>();
            try
            {
                DataConexion.Abrir();
                //string query = $"SELECT * FROM empresas.llequipo where maquina = '{dispositivo}'";
                string query = $"SELECT DISTINCT nro_mac FROM empresas.llequipo where maquina = '{dispositivo}'";
                MySqlCommand cmd = new MySqlCommand(query);

                MySqlDataReader reader = null;
                cmd.Connection = conexionDB;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lista.Add(reader["nro_mac"].ToString());
                    }
                }
                else { DataConexion.Cerrar(); }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
            finally
            {
                DataConexion.Cerrar();
            }
            return lista;
        }
    }
}
