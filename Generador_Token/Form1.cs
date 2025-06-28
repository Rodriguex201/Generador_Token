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
        string empresa;
        public Form1()
        {
            InitializeComponent();
            empresa = TxtCodEmpresa.Text;

            var dispositivo = Servicesllequipo.ListaDispositivos(empresa).GetAwaiter().GetResult(); // se guarda la lista de dispositivos
            CmbTipodispositivo.Items.AddRange(dispositivo.ToArray()); // se agregan los dispositivos al ComboBox

        }

        private void GenerarToken_Click(object sender, EventArgs e)
        {
            dispositivoSelect = CmbTipodispositivo.SelectedItem?.ToString(); // se obtiene el dispositivo seleccionado
            codigoMac = CmbId.SelectedItem?.ToString(); // se obtiene la MAC seleccionada

            if (empresa != null && dispositivoSelect != null && codigoMac != null)
            {
                string codigo = ServiceCodigo.CrearCodActivacionFecha(empresa, dispositivoSelect, codigoMac);
                ServiceCodigo.RegistrarCod(codigo,codigoMac); // se registra el código generado en la base de datos
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dispositivoSelect = CmbTipodispositivo.SelectedItem?.ToString(); // se obtiene el dispositivo seleccionado

            var mac = ServiceBuscarEquipo.ListaMac(dispositivoSelect).GetAwaiter().GetResult();// se obtiene la lista de MACs del dispositivo seleccionado
            CmbId.Items.AddRange(mac.ToArray()); // se agregan las MACs al ComboBox

            //Servicesllequipo.ListaDispositivos(codigo).GetAwaiter().GetResult();
            //ServiceBuscarEquipo.ListaMac(tipoDispositivo);
        }

        private void tbToken_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
