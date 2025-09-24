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
        public static async Task<List<string>> ListaDispositivos(string codEmpresa)
        {
            var lista = new List<string>();
            try
            {
                DataConexion.GetConnectionString(new List<Models.EmpresaModel>()); // Cambiado a acceso estático
                var conexionDB = await DataConexion.Conectar();
                DataConexion.Abrir();

                string query = $"SELECT DISTINCT maquina FROM empresas.llequipo WHERE empresa = '{codEmpresa}' ORDER BY maquina ASC;";

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

        //public static async Task<List<string>> ListaDispositivos(string codEmpresa)
        //{
        //    var lista = new List<string>();

        //    try
        //    {
        //        DataConexion.GetConnectionString(new List<Models.EmpresaModel>());
        //        var conexionDB = await DataConexion.ObtenerConexion();

        //        //DataConexion.Abrir();

        //        string query = "SELECT DISTINCT maquina " +
        //                       "FROM empresas.llequipo " +
        //                       "WHERE empresa = @empresa " +
        //                       "ORDER BY maquina ASC;";

        //        using (var cmd = new MySqlCommand(query, conexionDB))
        //        {
        //            cmd.Parameters.AddWithValue("@empresa", codEmpresa);

        //            using (var reader = await cmd.ExecuteReaderAsync())
        //            {
        //                while (await reader.ReadAsync())
        //                {
        //                    lista.Add(reader["maquina"].ToString());
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al cargar dispositivos: " + ex.Message);
        //    }
        //    finally
        //    {
        //        DataConexion.Cerrar();
        //    }

        //    return lista;
        //}


    }
}
