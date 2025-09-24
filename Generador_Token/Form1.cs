using Generador_Token.Data;
using Generador_Token.Models;
using Generador_Token.Service;
using Generador_Token.Services;
using MySqlConnector;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
        }

        private static void ConectionDatabase()
        {

        }

        //--------------------GENERADOR DE TOKEN---------------------------
        //Boton que genera el token una vez seleccionados el dispositivo y la mac
        private async void GenerarToken_Click(object sender, EventArgs e)
        {
            dispositivoSelect = CmbDispositivo.SelectedItem?.ToString(); // se obtiene el dispositivo seleccionado
            codigoMac = CmbMac.SelectedItem?.ToString(); // se obtiene la MAC seleccionada

            if (empresa != null && dispositivoSelect != null && codigoMac != null)
            {
                string codigo = ServiceCodigo.CrearCodActivacionFecha(empresa, dispositivoSelect, codigoMac);
                await ServiceCodigo.RegistrarCod(codigo,codigoMac); // se registra el código generado en la base de datos
                MessageBox.Show("Su Codigo es: " + codigo);


                TbToken.Text = codigo; // se muestra el código generado en el TextBox
            }
            else
            {
                MessageBox.Show("Ingrese los datos");
            }
            
        }

        private async void ProbarConexion()
        {
            try
            {
                DataConexion.GetConnectionString(new List<Models.EmpresaModel>()); // Cambiado a acceso estático
                await DataConexion.Conectar(); // Cambiado a acceso estático
                //DataConexion.Abrir(); // Cambiado a acceso estático
                MessageBox.Show("Conexión exitosa");

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }
            finally
            {
                DataConexion.Cerrar(); // Cambiado a acceso estático
                
            }
        }

        //Boton Para buscar la Mac segun el Dispositivo
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dispositivoSelect = CmbDispositivo.SelectedItem?.ToString(); // se obtiene la mac de los dispositivos seleccionados

            var mac = ServiceBuscarEquipo.ListaMac(dispositivoSelect).GetAwaiter().GetResult();// se obtiene la lista de MACs del dispositivo seleccionado
            CmbMac.Items.AddRange(mac.ToArray()); // se agregan las MACs al ComboBox

            //Servicesllequipo.ListaDispositivos(codigo).GetAwaiter().GetResult();
            //ServiceBuscarEquipo.ListaMac(tipoDispositivo);
        }

        private void tbToken_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmbTipodispositivo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Boton que realiza la busqueda de Dispositivos segun la Base de datos Empresa (A000)
        private void button1_Click(object sender, EventArgs e)
        {
            //CmbMac
            empresa = TxtCodEmpresa.Text;
            var dispositivo = Servicesllequipo.ListaDispositivos(empresa).GetAwaiter().GetResult(); // se guarda la lista de dispositivos
            CmbDispositivo.Items.AddRange(dispositivo.ToArray()); // se agregan los dispositivos al ComboBox
            

        }
    }
}
