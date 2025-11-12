using Generador_Token.Data;
using System;
using System.Windows.Forms;

namespace Generador_Token
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        /// 

        //public static DataBase Context { get; set; }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbCodEmpresa = new System.Windows.Forms.Label();
            this.TxtCodEmpresa = new System.Windows.Forms.TextBox();
            this.lbTipoDispositivo = new System.Windows.Forms.Label();
            this.CmbDispositivo = new System.Windows.Forms.ComboBox();
            this.lbId = new System.Windows.Forms.Label();
            this.CmbMac = new System.Windows.Forms.ComboBox();
            this.btnBuscarMac = new System.Windows.Forms.Button();
            this.lbToken = new System.Windows.Forms.Label();
            this.TbToken = new System.Windows.Forms.TextBox();
            this.GenerarToken = new System.Windows.Forms.Button();
            this.BtnBuscarDispo = new System.Windows.Forms.Button();
            this.btnRefrescarGenerar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Generar_Token = new System.Windows.Forms.TabPage();
            this.Consultar_Token = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lbCodEmpre = new System.Windows.Forms.Label();
            this.Tabla = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lbModuloInfo = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Generar_Token.SuspendLayout();
            this.Consultar_Token.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCodEmpresa
            // 
            this.lbCodEmpresa.AutoSize = true;
            this.lbCodEmpresa.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodEmpresa.Location = new System.Drawing.Point(21, 11);
            this.lbCodEmpresa.Name = "lbCodEmpresa";
            this.lbCodEmpresa.Size = new System.Drawing.Size(121, 23);
            this.lbCodEmpresa.TabIndex = 4;
            this.lbCodEmpresa.Text = "Cod. Empresa:";
            // 
            // TxtCodEmpresa
            // 
            this.TxtCodEmpresa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodEmpresa.ForeColor = System.Drawing.Color.DarkGreen;
            this.TxtCodEmpresa.Location = new System.Drawing.Point(25, 50);
            this.TxtCodEmpresa.MaximumSize = new System.Drawing.Size(300, 4);
            this.TxtCodEmpresa.Name = "TxtCodEmpresa";
            this.TxtCodEmpresa.Size = new System.Drawing.Size(268, 26);
            this.TxtCodEmpresa.TabIndex = 10;
            this.TxtCodEmpresa.TextChanged += new System.EventHandler(this.TxtCodEmpresa_TextChanged);
            // 
            // lbTipoDispositivo
            // 
            this.lbTipoDispositivo.AutoSize = true;
            this.lbTipoDispositivo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTipoDispositivo.Location = new System.Drawing.Point(21, 73);
            this.lbTipoDispositivo.Name = "lbTipoDispositivo";
            this.lbTipoDispositivo.Size = new System.Drawing.Size(138, 23);
            this.lbTipoDispositivo.TabIndex = 3;
            this.lbTipoDispositivo.Text = "Tipo Dispositivo:";
            // 
            // CmbDispositivo
            // 
            this.CmbDispositivo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDispositivo.FormattingEnabled = true;
            this.CmbDispositivo.Location = new System.Drawing.Point(25, 99);
            this.CmbDispositivo.Name = "CmbDispositivo";
            this.CmbDispositivo.Size = new System.Drawing.Size(268, 26);
            this.CmbDispositivo.TabIndex = 7;
            this.CmbDispositivo.Text = "Seleccione un dispositivo";
            this.CmbDispositivo.SelectedIndexChanged += new System.EventHandler(this.CmbTipodispositivo_SelectedIndexChanged);
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbId.Location = new System.Drawing.Point(27, 137);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(115, 23);
            this.lbId.TabIndex = 2;
            this.lbId.Text = "Identificador:";
            // 
            // CmbMac
            // 
            this.CmbMac.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMac.FormattingEnabled = true;
            this.CmbMac.Location = new System.Drawing.Point(25, 163);
            this.CmbMac.Name = "CmbMac";
            this.CmbMac.Size = new System.Drawing.Size(268, 26);
            this.CmbMac.TabIndex = 6;
            this.CmbMac.Text = "Seleccione direccion Mac";
            // 
            // btnBuscarMac
            // 
            this.btnBuscarMac.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarMac.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarMac.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBuscarMac.Location = new System.Drawing.Point(177, 318);
            this.btnBuscarMac.Name = "btnBuscarMac";
            this.btnBuscarMac.Size = new System.Drawing.Size(116, 38);
            this.btnBuscarMac.TabIndex = 9;
            this.btnBuscarMac.Text = "Buscar Mac";
            this.btnBuscarMac.UseVisualStyleBackColor = false;
            this.btnBuscarMac.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lbToken
            // 
            this.lbToken.AutoSize = true;
            this.lbToken.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbToken.Location = new System.Drawing.Point(27, 273);
            this.lbToken.Name = "lbToken";
            this.lbToken.Size = new System.Drawing.Size(63, 23);
            this.lbToken.TabIndex = 0;
            this.lbToken.Text = "Token:";
            // 
            // TbToken
            // 
            this.TbToken.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TbToken.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbToken.ForeColor = System.Drawing.Color.FloralWhite;
            this.TbToken.Location = new System.Drawing.Point(87, 274);
            this.TbToken.Name = "TbToken";
            this.TbToken.ReadOnly = true;
            this.TbToken.Size = new System.Drawing.Size(231, 26);
            this.TbToken.TabIndex = 1;
            this.TbToken.Text = "TOKEN";
            this.TbToken.TextChanged += new System.EventHandler(this.tbToken_TextChanged);
            // 
            // GenerarToken
            // 
            this.GenerarToken.BackColor = System.Drawing.Color.ForestGreen;
            this.GenerarToken.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerarToken.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GenerarToken.Location = new System.Drawing.Point(532, 318);
            this.GenerarToken.Name = "GenerarToken";
            this.GenerarToken.Size = new System.Drawing.Size(131, 38);
            this.GenerarToken.TabIndex = 5;
            this.GenerarToken.Text = "Generar Token";
            this.GenerarToken.UseVisualStyleBackColor = false;
            this.GenerarToken.Click += new System.EventHandler(this.GenerarToken_Click);
            // 
            // BtnBuscarDispo
            // 
            this.BtnBuscarDispo.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnBuscarDispo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarDispo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnBuscarDispo.Location = new System.Drawing.Point(3, 318);
            this.BtnBuscarDispo.Name = "BtnBuscarDispo";
            this.BtnBuscarDispo.Size = new System.Drawing.Size(168, 38);
            this.BtnBuscarDispo.TabIndex = 11;
            this.BtnBuscarDispo.Text = "Buscar Dispositivo";
            this.BtnBuscarDispo.UseVisualStyleBackColor = false;
            this.BtnBuscarDispo.Click += new System.EventHandler(this.button1_Click);
            //
            // btnRefrescarGenerar
            //
            this.btnRefrescarGenerar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRefrescarGenerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescarGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescarGenerar.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefrescarGenerar.Location = new System.Drawing.Point(307, 45);
            this.btnRefrescarGenerar.Name = "btnRefrescarGenerar";
            this.btnRefrescarGenerar.Size = new System.Drawing.Size(44, 37);
            this.btnRefrescarGenerar.TabIndex = 12;
            this.btnRefrescarGenerar.Text = "↻";
            this.btnRefrescarGenerar.UseVisualStyleBackColor = false;
            this.btnRefrescarGenerar.Click += new System.EventHandler(this.btnRefrescarGenerar_Click);
            //
            // tabControl1
            //
            this.tabControl1.Controls.Add(this.Generar_Token);
            this.tabControl1.Controls.Add(this.Consultar_Token);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabControl1.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, -3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(686, 397);
            this.tabControl1.TabIndex = 0;
            // 
            // Generar_Token
            // 
            this.Generar_Token.BackColor = System.Drawing.Color.Azure;
            this.Generar_Token.Controls.Add(this.btnRefrescarGenerar);
            this.Generar_Token.Controls.Add(this.GenerarToken);
            this.Generar_Token.Controls.Add(this.BtnBuscarDispo);
            this.Generar_Token.Controls.Add(this.lbToken);
            this.Generar_Token.Controls.Add(this.TxtCodEmpresa);
            this.Generar_Token.Controls.Add(this.TbToken);
            this.Generar_Token.Controls.Add(this.btnBuscarMac);
            this.Generar_Token.Controls.Add(this.lbId);
            this.Generar_Token.Controls.Add(this.CmbDispositivo);
            this.Generar_Token.Controls.Add(this.lbTipoDispositivo);
            this.Generar_Token.Controls.Add(this.CmbMac);
            this.Generar_Token.Controls.Add(this.lbCodEmpresa);
            this.Generar_Token.Location = new System.Drawing.Point(4, 24);
            this.Generar_Token.Name = "Generar_Token";
            this.Generar_Token.Size = new System.Drawing.Size(678, 369);
            this.Generar_Token.TabIndex = 0;
            this.Generar_Token.Text = "Generar Token";
            // 
            // Consultar_Token
            // 
            this.Consultar_Token.Controls.Add(this.lbModuloInfo);
            this.Consultar_Token.Controls.Add(this.button1);
            this.Consultar_Token.Controls.Add(this.txtEmpresa);
            this.Consultar_Token.Controls.Add(this.lbCodEmpre);
            this.Consultar_Token.Controls.Add(this.Tabla);
            this.Consultar_Token.Controls.Add(this.btnBuscar);
            this.Consultar_Token.Location = new System.Drawing.Point(4, 24);
            this.Consultar_Token.Name = "Consultar_Token";
            this.Consultar_Token.Size = new System.Drawing.Size(678, 369);
            this.Consultar_Token.TabIndex = 0;
            this.Consultar_Token.Text = "Consultar Token";
            this.Consultar_Token.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(570, 94);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(93, 45);
            this.button1.TabIndex = 13;
            this.button1.Text = "BORRAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpresa.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtEmpresa.Location = new System.Drawing.Point(155, 7);
            this.txtEmpresa.MaximumSize = new System.Drawing.Size(300, 4);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(168, 29);
            this.txtEmpresa.TabIndex = 12;
            // 
            // lbCodEmpre
            // 
            this.lbCodEmpre.AutoSize = true;
            this.lbCodEmpre.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodEmpre.Location = new System.Drawing.Point(11, 7);
            this.lbCodEmpre.Name = "lbCodEmpre";
            this.lbCodEmpre.Size = new System.Drawing.Size(129, 25);
            this.lbCodEmpre.TabIndex = 11;
            this.lbCodEmpre.Text = "Cod. Empresa:";
            // 
            // Tabla
            // 
            this.Tabla.AllowUserToAddRows = false;
            this.Tabla.AllowUserToDeleteRows = false;
            this.Tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tabla.Location = new System.Drawing.Point(8, 145);
            this.Tabla.Name = "Tabla";
            this.Tabla.Size = new System.Drawing.Size(655, 210);
            this.Tabla.TabIndex = 3;
            this.Tabla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.DarkBlue;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 5;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(12, 94);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBuscar.Size = new System.Drawing.Size(93, 45);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            //
            // lbModuloInfo
            //
            this.lbModuloInfo.AutoSize = true;
            this.lbModuloInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModuloInfo.ForeColor = System.Drawing.Color.DimGray;
            this.lbModuloInfo.Location = new System.Drawing.Point(12, 46);
            this.lbModuloInfo.Name = "lbModuloInfo";
            this.lbModuloInfo.Size = new System.Drawing.Size(260, 19);
            this.lbModuloInfo.TabIndex = 14;

            this.lbModuloInfo.Text = "M10: Pedidos (Distribución) | M12: Restaurantes | M: Pendientes asignacion modulo";

            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(679, 387);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Codigo y Registro Equipo";
            this.tabControl1.ResumeLayout(false);
            this.Generar_Token.ResumeLayout(false);
            this.Generar_Token.PerformLayout();
            this.Consultar_Token.ResumeLayout(false);
            this.Consultar_Token.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbCodEmpresa;
        public TextBox TxtCodEmpresa;
        public TextBox txtEmpresa;

        private System.Windows.Forms.Label lbTipoDispositivo;
        public System.Windows.Forms.ComboBox CmbDispositivo;

        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.ComboBox CmbMac;
        
        private Button btnBuscarMac;
        
        private System.Windows.Forms.Label lbToken;
        private System.Windows.Forms.TextBox TbToken;
        private System.Windows.Forms.Button GenerarToken;
        private Button BtnBuscarDispo;
        private Button btnRefrescarGenerar;
        private TabControl tabControl1;
        private TabPage Generar_Token;
        private TabPage Consultar_Token;
        private Button btnBuscar;
        private DataGridView Tabla;
        private Label lbCodEmpre;
        private Button button1;
        private Label lbModuloInfo;
    }
}

