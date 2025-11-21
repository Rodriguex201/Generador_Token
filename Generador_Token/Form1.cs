using Generador_Token.Data;
using Generador_Token.Models;
using Generador_Token.Service;
using Generador_Token.Services;
using MySqlConnector;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        private List<ConsultaTokenRow> _datosConsultaToken = new List<ConsultaTokenRow>();
        private DateTime? _fechaFiltroActiva;
        private readonly List<ConexionIp> _conexionesDisponibles;

        private class ConsultaTokenRow
        {
            public string FechaActivacion { get; set; }
            public string Dispositivo { get; set; }
            public string MAC { get; set; }
            public string Modulos { get; set; }
            public string Token { get; set; }

            [Browsable(false)]
            public DateTime? FechaActivacionValor { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            _conexionesDisponibles = CrearConexionesPredeterminadas();
            InicializarSelectorConexion();
            //ConectionDatabase();
            BtnBuscarDispo.Visible = false;
            btnBuscarMac.Visible = false;

            var iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "iconotoken.ico");
            if (File.Exists(iconPath))
            {
                this.Icon = new Icon(iconPath);
            }
        }

        private List<ConexionIp> CrearConexionesPredeterminadas()
        {
            const string usuario = "RmSoft20X";
            const string password = "*LiLo89*";

            return new List<ConexionIp>
            {
                new ConexionIp
                {
                    Nombre = "Servidor 200.118.190.213",
                    DataSource = "200.118.190.213",
                    Usuario = usuario,
                    Password = password
                },
                new ConexionIp
                {
                    Nombre = "Servidor 168.232.32.74",
                    DataSource = "168.232.32.74",
                    Usuario = usuario,
                    Password = password
                }
            };
        }

        private bool IntentarConfigurarBaseDatos(string codigoEmpresa)
        {
            if (string.IsNullOrWhiteSpace(codigoEmpresa))
            {
                return false;
            }

            try
            {
                DataConexion.SeleccionarBaseDatos(codigoEmpresa);
                return true;
            }
            catch (InvalidOperationException ex)
            { 
                MessageBox.Show(ex.Message);
                return false;
            }
        } 

        private void InicializarSelectorConexion()
        {
            cmbConexion.DisplayMember = nameof(ConexionIp.Nombre);
            cmbConexion.ValueMember = null;
            cmbConexion.DataSource = _conexionesDisponibles;

            if (_conexionesDisponibles.Count > 0)
            {
                DataConexion.Configure(_conexionesDisponibles[0]);
            }
        }

        private async void CargarDatos()
        {
            try
            {
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
                if (!IntentarConfigurarBaseDatos(empresa))
                {
                    return;
                }

                await ServiceCodigo.AsignarModuloM10SiCorresponde(codigoMac);

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



        //Boton que realiza la busqueda de Dispositivos segun la base de datos seleccionada
        private async void button1_Click(object sender, EventArgs e) //BUSCAR DISPOSITIVOS
        {

            var dispositivoActual = CmbDispositivo.SelectedItem?.ToString();
            var macActual = CmbMac.SelectedItem?.ToString();

            await CargarDispositivosPorEmpresaAsync(dispositivoActual);

            var dispositivoSeleccionado = CmbDispositivo.SelectedItem?.ToString();
            if (!string.IsNullOrWhiteSpace(dispositivoSeleccionado))
            {
                await CargarMacsParaDispositivoAsync(dispositivoSeleccionado, macActual);
            }
        }

        private async void btnRefrescarGenerar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtCodEmpresa.Text))
            {
                MessageBox.Show("Ingrese un código de empresa para refrescar los datos.");
                return;
            }

            var dispositivoActual = CmbDispositivo.SelectedItem?.ToString();
            var macActual = CmbMac.SelectedItem?.ToString();

            await CargarDispositivosPorEmpresaAsync(dispositivoActual);

            var dispositivoSeleccionado = CmbDispositivo.SelectedItem?.ToString();
            if (!string.IsNullOrWhiteSpace(dispositivoSeleccionado))
            {
                await CargarMacsParaDispositivoAsync(dispositivoSeleccionado, macActual);
            }

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
                    if (!IntentarConfigurarBaseDatos(empresa))
                    {
                        return;
                    }

                    var dispositivo = Servicesllequipo.Consultar(empresa).GetAwaiter().GetResult(); // se guarda la lista de dispositivos
                    // M10: Pedidos(Distribuicion) y M12: Restaurantes
                    _datosConsultaToken = dispositivo
                        .Where(x => !string.IsNullOrWhiteSpace(x.modulos) &&
                                    x.modulos.IndexOf("M", StringComparison.OrdinalIgnoreCase) >= 0)

                        .Select((x, index) => new
                        {
                            Fila = CrearFilaConsulta(x),
                            OrdenOriginal = index
                        })
                        .OrderByDescending(x => EsModuloPendiente(x.Fila.Modulos))
                        .ThenBy(x => x.OrdenOriginal)
                        .Select(x => x.Fila)

                        .ToList();

                    AplicarFiltro(null);

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
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            var columnaSeleccionada = Tabla.Columns[e.ColumnIndex];
            if (columnaSeleccionada == null || columnaSeleccionada.Name != nameof(ConsultaTokenRow.FechaActivacion))
            {
                return;
            }

            if (Tabla.Rows[e.RowIndex].DataBoundItem is ConsultaTokenRow fila && fila.FechaActivacionValor.HasValue)
            {
                var fechaSeleccionada = fila.FechaActivacionValor.Value.Date;

                if (_fechaFiltroActiva.HasValue && _fechaFiltroActiva.Value.Date == fechaSeleccionada)
                {
                    AplicarFiltro(null);
                }
                else
                {
                    AplicarFiltro(fechaSeleccionada);
                }
            }
        }

        private ConsultaTokenRow CrearFilaConsulta(EmpresaModel dispositivo)
        {
            var fecha = ObtenerFecha(dispositivo.factivar);
            return new ConsultaTokenRow
            {
                FechaActivacion = fecha.HasValue ? fecha.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty,
                FechaActivacionValor = fecha,
                Dispositivo = dispositivo.maquina,
                MAC = dispositivo.nro_mac,
                Modulos = dispositivo.modulos,
                Token = dispositivo.codigo_act == 0 ? string.Empty : dispositivo.codigo_act.ToString()
            };
        }

        private DateTime? ObtenerFecha(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                return null;
            }

            if (DateTime.TryParseExact(valor, new[] { "dd/MM/yyyy HH:mm", "dd/MM/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd" },
                System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var fechaExacta))
            {
                return fechaExacta;
            }

            if (DateTime.TryParse(valor, out var fechaLibre))
            {
                return fechaLibre;
            }

            return null;
        }

        private void AplicarFiltro(DateTime? fecha)
        {
            IEnumerable<ConsultaTokenRow> datosFiltrados = _datosConsultaToken;

            if (fecha.HasValue)
            {
                datosFiltrados = datosFiltrados
                    .Where(fila => fila.FechaActivacionValor.HasValue && fila.FechaActivacionValor.Value.Date == fecha.Value.Date);
            }

            Tabla.DataSource = new BindingList<ConsultaTokenRow>(datosFiltrados.ToList());
            Tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            if (Tabla.Columns.Contains(nameof(ConsultaTokenRow.FechaActivacion)))
            {
                var columnaFecha = Tabla.Columns[nameof(ConsultaTokenRow.FechaActivacion)];
                columnaFecha.DisplayIndex = 0;
                columnaFecha.HeaderText = "Fecha activación";
            }

            _fechaFiltroActiva = fecha;
        }

        private bool EsModuloPendiente(string modulos)
        {
            return string.Equals(modulos?.Trim(), "M", StringComparison.OrdinalIgnoreCase);

        }

        private async void button1_Click_1(object sender, EventArgs e)  //BORRAR REGISTRO
        {
            if (Tabla.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor selecciona una fila para borrar.");
                return;
            }

            string tokenSeleccionado = Tabla.SelectedRows[0].Cells["Token"].Value.ToString();

            if (string.IsNullOrWhiteSpace(tokenSeleccionado))
            {
                MessageBox.Show("El registro seleccionado no tiene un token asociado para borrar.");
                return;
            }

            var confirmResult = MessageBox.Show("¿Estás seguro de que deseas borrar este registro?",
                                                "Confirmar Borrado",
                                                MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                // ✅ Llamar al método async con await
                var borrado = await Servicesllequipo.Borrar(tokenSeleccionado);

                if (!borrado)
                {
                    return;
                }

                if (Tabla.SelectedRows[0].DataBoundItem is ConsultaTokenRow filaSeleccionada)
                {
                    _datosConsultaToken.Remove(filaSeleccionada);
                    AplicarFiltro(_fechaFiltroActiva);
                }
                else
                {
                    CargarDatos(); // vuelve a cargar la tabla
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar borrar: " + ex.Message);
            }
        }


        private async Task CargarDispositivosPorEmpresaAsync(string dispositivoSeleccionado = null)

        {
            empresa = TxtCodEmpresa.Text.Trim();

            CmbDispositivo.Items.Clear();
            CmbMac.Items.Clear();

            if (string.IsNullOrWhiteSpace(empresa))
            {
                return;
            }

            if (!IntentarConfigurarBaseDatos(empresa))
            {
                return;
            }

            try
            {
                var dispositivos = await Servicesllequipo.ListaDispositivos(empresa);

                if (dispositivos != null && dispositivos.Count > 0)
                {
                    CmbDispositivo.Items.AddRange(dispositivos.ToArray());

                    if (!string.IsNullOrWhiteSpace(dispositivoSeleccionado) && dispositivos.Contains(dispositivoSeleccionado))
                    {
                        CmbDispositivo.SelectedItem = dispositivoSeleccionado;
                    }
                    else
                    {
                        CmbDispositivo.SelectedIndex = 0;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar dispositivos: " + ex.Message);
            }
        }


        private async Task CargarMacsParaDispositivoAsync(string dispositivo, string macSeleccionada = null)

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

            if (!IntentarConfigurarBaseDatos(codigoEmpresa))
            {
                return;
            }

            try
            {
                var macs = await ServiceBuscarEquipo.ListaMac(codigoEmpresa, dispositivo);

                if (macs != null && macs.Count > 0)
                {
                    CmbMac.Items.AddRange(macs.ToArray());

                    if (!string.IsNullOrWhiteSpace(macSeleccionada) && macs.Contains(macSeleccionada))
                    {
                        CmbMac.SelectedItem = macSeleccionada;
                    }
                    else
                    {
                        CmbMac.SelectedIndex = 0;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar direcciones MAC: " + ex.Message);
            }
        }

        private async void cmbConexion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cmbConexion.SelectedItem is ConexionIp conexionSeleccionada))
            {
                return;
            }

            DataConexion.Configure(conexionSeleccionada);

            var dispositivoActual = CmbDispositivo.SelectedItem?.ToString();
            var macActual = CmbMac.SelectedItem?.ToString();

            if (!string.IsNullOrWhiteSpace(TxtCodEmpresa.Text))
            {
                await CargarDispositivosPorEmpresaAsync(dispositivoActual);

                if (!string.IsNullOrWhiteSpace(dispositivoActual))
                {
                    await CargarMacsParaDispositivoAsync(dispositivoActual, macActual);
                }
            }

            if (!string.IsNullOrWhiteSpace(txtEmpresa.Text) && Tabla.DataSource != null)
            {
                btnBuscar_Click_1(sender, e);
            }
        }

        private async void TxtCodEmpresa_TextChanged(object sender, EventArgs e)
        {
            var codigoEmpresa = TxtCodEmpresa.Text.Trim();

            if (codigoEmpresa.Length < 4)
            {
                CmbDispositivo.Items.Clear();
                CmbMac.Items.Clear();
                return;
            }

            await CargarDispositivosPorEmpresaAsync();
        }
    }
}
