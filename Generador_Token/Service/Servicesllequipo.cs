using Generador_Token.Data;
using Generador_Token.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

using Generador_Token;

namespace Generador_Token.Services
{
    public class Servicesllequipo
    {
        public static async Task<List<string>> ListaDispositivos (string codEmpresa)
        {
            DataConexion.GetConnectionString(new List<Models.EmpresaModel>()); // Cambiado a acceso estático
            var conexionDB = await DataConexion.Conectar();
            List<string> lista = new List<string>();
            try
            {
                DataConexion.Abrir();
                string query = $"SELECT * FROM empresas.llequipo where empresa = '{codEmpresa}'";
                MySqlCommand cmd = new MySqlCommand(query);

                MySqlDataReader reader = null;
                cmd.Connection = conexionDB;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lista.Add(reader["maquina"].ToString());
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
