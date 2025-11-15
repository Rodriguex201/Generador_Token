using Generador_Token.Data;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generador_Token.Service
{
    internal class ServiceBuscarEquipo
    {
        public static async Task<List<string>> ListaMac(string empresa, string dispositivo)
        {
            var conexionDB = await DataConexion.Conectar();
            List<string> lista = new List<string>();
            try
            {
                string query = "SELECT DISTINCT nro_mac FROM empresas.llequipo " +
                               "WHERE empresa = @empresa AND maquina = @dispositivo " +
                               "AND (codigo_act IS NULL OR codigo_act = '' OR codigo_act = 0);";
                DataConexion.Abrir();
                using (var cmd = new MySqlCommand(query, conexionDB))
                {
                    cmd.Parameters.AddWithValue("@empresa", empresa);
                    cmd.Parameters.AddWithValue("@dispositivo", dispositivo);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                lista.Add(reader["nro_mac"].ToString());
                            }
                        }
                    }
                }
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
