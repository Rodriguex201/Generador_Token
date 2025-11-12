using Generador_Token;
using Generador_Token.Data;
using Generador_Token.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

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

                string query = "SELECT DISTINCT maquina FROM empresas.llequipo WHERE empresa = @empresa " +

                               "AND modulos IN ('M10','M12','M') ORDER BY maquina ASC;";


                MySqlCommand cmd = new MySqlCommand(query);
                MySqlDataReader reader = null;
                cmd.Connection = conexionDB;
                cmd.Parameters.AddWithValue("@empresa", codEmpresa);

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

                string query = "SELECT maquina, nro_mac, codigo_act, modulos, factivar FROM empresas.llequipo " +
                               "WHERE empresa = @empresa AND modulos IN ('M10','M12','M');";


                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB))
                {
                    cmd.Parameters.AddWithValue("@empresa", codEmpresa);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dispositivo = new EmpresaModel
                            {
                                maquina = reader["maquina"].ToString(),
                                nro_mac = reader["nro_mac"].ToString(),
                                modulos = reader["modulos"].ToString(),
                                factivar = ObtenerFechaActivacion(reader["factivar"]),
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

        private static string ObtenerFechaActivacion(object valorFecha)
        {
            if (valorFecha == null || valorFecha == DBNull.Value)
            {
                return string.Empty;
            }

            var fechaTexto = valorFecha.ToString();

            if (DateTime.TryParse(fechaTexto, out DateTime fecha))
            {
                return fecha.ToString("dd/MM/yyyy HH:mm");
            }

            return fechaTexto;
        }

        //public static async Task<List<EmpresaModel>> Borrar(string codEmpresa)
        public static async Task<bool> Borrar(string token)
        {
            // Usaremos un bloque try/catch/finally para manejar la conexión y errores.
            bool eliminacionExitosa = false;

            try
            {
                DataConexion.GetConnectionString(new List<EmpresaModel>()); // Cambiado a acceso estático
                var conexionDB = await DataConexion.Conectar();
                DataConexion.Abrir();

                if (conexionDB.State != ConnectionState.Open)
                    conexionDB.Open();

                string query = "DELETE FROM empresas.llequipo WHERE codigo_act = @tokenParam;";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB))
                {
                    // ¡IMPORTANTE! Añadir el parámetro para evitar Inyección SQL
                    cmd.Parameters.AddWithValue("@tokenParam", token);

                    // 3. Ejecutar el comando NO QUERY
                    // ExecuteNonQuery() devuelve el número de filas afectadas.
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    // Si filasAfectadas > 0, significa que al menos un registro fue borrado.MY
                    if (filasAfectadas > 0)
                    {
                        eliminacionExitosa = true;
                        MessageBox.Show("Registro eliminado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el registro.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Si hay un error de conexión, sintaxis SQL, etc.
                MessageBox.Show("Error al eliminar registro: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                eliminacionExitosa = false;
            }
            finally
            {
                // 5. Cerrar la conexión, independientemente de si hubo error o éxito.
                DataConexion.Cerrar();
            }

            // 6. Devolver el resultado
            return eliminacionExitosa;
        }
    }
}
