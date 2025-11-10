using Generador_Token.Data;
using Generador_Token.Models;
using Generador_Token.Service;
using Generador_Token.Services;
using MySqlConnector;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generador_Token
{
    public partial class Form1 : Form
    {


        string codigoMac;
        string dispositivoSelect;
        public string empresa;

        public Form1()
        {
            InitializeComponent();
            //ConectionDatabase();
            BtnBuscarDispo.Visible = false;
            btnBuscarMac.Visible = false;
        }

        private async void CargarDatos()
        {
            try
            {
                // Configurar conexión
                DataConexion.GetConnectionString(new List<EmpresaModel>()); // opcional si ya lo hace internamente
                var conexionDB = await DataConexion.Conectar(); // debe retornar MySqlConnection, NO Task<MySqlConnection>
                DataConexion.Abrir();

                // Consulta
                string query = $"SELECT maquina, nro_mac, modulos, codigo_act FROM empresas.llequipo where '{empresa}'";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB))
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Tabla.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }


        //--------------------GENERADOR DE TOKEN---------------------------
        //Boton que genera el token una vez seleccionados el dispositivo y la mac
        private async void GenerarToken_Click(object sender, EventArgs e) //GENERAR TOKEN
        {
            dispositivoSelect = CmbDispositivo.SelectedItem?.ToString(); // se obtiene el dispositivo seleccionado
            codigoMac = CmbMac.SelectedItem?.ToString(); // se obtiene la MAC seleccionada

            if (empresa != null && dispositivoSelect != null && codigoMac != null)
            {
                string codigo = ServiceCodigo.CrearCodActivacionFecha(empresa, dispositivoSelect, codigoMac);
                await ServiceCodigo.RegistrarCod(codigo,codigoMac); // se registra el código generado en la base de datos
                MessageBox.Show("Su Codigo es: " + codigo);


                TbToken.Text = codigo; // se muestra el código generado en el TextBox
                await CargarMacsParaDispositivoAsync(dispositivoSelect);
            }
            else
            {
                MessageBox.Show("Ingrese los datos");
            }
            
        }

        //Boton Para buscar la Mac segun el Dispositivo
        private async void btnBuscar_Click(object sender, EventArgs e) //BUSCAR MAC
        {
            await CargarMacsParaDispositivoAsync(CmbDispositivo.SelectedItem?.ToString());
        }



        //Boton que realiza la busqueda de Dispositivos segun la Base de datos Empresa (A000)
        private async void button1_Click(object sender, EventArgs e) //BUSCAR DISPOSITIVOS
        {
            await CargarDispositivosPorEmpresaAsync();
        }
        private void btnBuscar_Click_1(object sender, EventArgs e)  //CARGAR TABLA
        {
            empresa = txtEmpresa.Text;
            try
            {
                if (string.IsNullOrWhiteSpace(empresa))
                {
                    MessageBox.Show("Por favor, ingrese un código de empresa válido.");
                    return;
                }
                else
                {
                    var dispositivo = Servicesllequipo.Consultar(empresa).GetAwaiter().GetResult(); // se guarda la lista de dispositivos
                    // M10: Pedidos(Distribuicion) y M12: Restaurantes
                    var listaFiltrada = dispositivo
                        .Select(x => new
                        {
                            Dispositivo = x.maquina,
                            MAC = x.nro_mac,
                            Modulos = x.modulos,
                            Token = x.codigo_act
                        })
                        .ToList();

                    Tabla.DataSource = listaFiltrada; // se agregan los dispositivos al ComboBox
                    Tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
                                                                                                // Proyectar solo los campos necesarios para mostrar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tabla: " + ex.Message);

            }
        }

        private void tbToken_TextChanged(object sender, EventArgs e)
        {

        }

        private async void CmbTipodispositivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            await CargarMacsParaDispositivoAsync(CmbDispositivo.SelectedItem?.ToString());
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)  //BORRAR REGISTRO
        {
            if (Tabla.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor selecciona una fila para borrar.");
                return;
            }

            string tokenSeleccionado = Tabla.SelectedRows[0].Cells["Token"].Value.ToString();

            var confirmResult = MessageBox.Show("¿Estás seguro de que deseas borrar este registro?",
                                                "Confirmar Borrado",
                                                MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                // ✅ Llamar al método async con await
                var borrado = Servicesllequipo.Borrar(tokenSeleccionado);

                CargarDatos(); // vuelve a cargar la tabla

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar borrar: " + ex.Message);
            }
        }

        private async Task CargarDispositivosPorEmpresaAsync()
        {
            empresa = TxtCodEmpresa.Text.Trim();

            CmbDispositivo.Items.Clear();
            CmbMac.Items.Clear();

            if (string.IsNullOrWhiteSpace(empresa))
            {
                return;
            }

            try
            {
                var dispositivos = await Servicesllequipo.ListaDispositivos(empresa);

                if (dispositivos != null && dispositivos.Count > 0)
                {
                    CmbDispositivo.Items.AddRange(dispositivos.ToArray());
                    CmbDispositivo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar dispositivos: " + ex.Message);
            }
        }

        private async Task CargarMacsParaDispositivoAsync(string dispositivo)
        {
            CmbMac.Items.Clear();

            if (string.IsNullOrWhiteSpace(dispositivo))
            {
                return;
            }

            var codigoEmpresa = empresa;
            if (string.IsNullOrWhiteSpace(codigoEmpresa))
            {
                codigoEmpresa = TxtCodEmpresa.Text.Trim();
            }

            if (string.IsNullOrWhiteSpace(codigoEmpresa))
            {
                return;
            }

            try
            {
                var macs = await ServiceBuscarEquipo.ListaMac(codigoEmpresa, dispositivo);

                if (macs != null && macs.Count > 0)
                {
                    CmbMac.Items.AddRange(macs.ToArray());
                    CmbMac.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar direcciones MAC: " + ex.Message);
            }
        }

        private async void TxtCodEmpresa_TextChanged(object sender, EventArgs e)
        {
            await CargarDispositivosPorEmpresaAsync();
        }
    }
}
