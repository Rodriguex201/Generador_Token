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

        public static async Task<List<EmpresaModel>> Consultar (string codEmpresa)
        {
            var lista = new List<EmpresaModel>();
            try
            {
                DataConexion.GetConnectionString(new List<EmpresaModel>()); // Cambiado a acceso estático
                var conexionDB = await DataConexion.Conectar();
                DataConexion.Abrir();

                string query = $"select maquina, nro_mac, codigo_act FROM empresas.llequipo where empresa = '{codEmpresa}' ;";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dispositivo = new EmpresaModel
                            {
                                maquina = reader["maquina"].ToString(),
                                nro_mac = reader["nro_mac"].ToString(),
                                //codigo_act = Convert.ToInt32(reader["codigo_act"].ToString())
                                codigo_act = int.TryParse(reader["codigo_act"].ToString(), out int codigoActValue) ? codigoActValue : 0
                            };
                            lista.Add(dispositivo);
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

        public static async Task<List<EmpresaModel>> Borrar(string codEmpresa)
        {
            var lista = new List<EmpresaModel>();
            try
            {
                DataConexion.GetConnectionString(new List<EmpresaModel>()); // Cambiado a acceso estático
                var conexionDB = await DataConexion.Conectar();
                DataConexion.Abrir();

                string query = $"select maquina, nro_mac, codigo_act FROM empresas.llequipo where empresa = '{codEmpresa}' ;";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dispositivo = new EmpresaModel
                            {
                                maquina = reader["maquina"].ToString(),
                                nro_mac = reader["nro_mac"].ToString(),
                                //codigo_act = Convert.ToInt32(reader["codigo_act"].ToString())
                                codigo_act = int.TryParse(reader["codigo_act"].ToString(), out int codigoActValue) ? codigoActValue : 0
                            };
                            lista.Add(dispositivo);
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
