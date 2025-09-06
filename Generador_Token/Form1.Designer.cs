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
            this.SuspendLayout();
            // 
            // lbCodEmpresa
            // 
            this.lbCodEmpresa.AutoSize = true;
            this.lbCodEmpresa.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodEmpresa.Location = new System.Drawing.Point(132, 60);
            this.lbCodEmpresa.Name = "lbCodEmpresa";
            this.lbCodEmpresa.Size = new System.Drawing.Size(121, 23);
            this.lbCodEmpresa.TabIndex = 4;
            this.lbCodEmpresa.Text = "Cod. Empresa:";
            // 
            // TxtCodEmpresa
            // 
            this.TxtCodEmpresa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodEmpresa.ForeColor = System.Drawing.Color.DarkGreen;
            this.TxtCodEmpresa.Location = new System.Drawing.Point(286, 60);
            this.TxtCodEmpresa.MaximumSize = new System.Drawing.Size(300, 4);
            this.TxtCodEmpresa.Name = "TxtCodEmpresa";
            this.TxtCodEmpresa.Size = new System.Drawing.Size(268, 26);
            this.TxtCodEmpresa.TabIndex = 10;
            this.TxtCodEmpresa.Text = "A000";
            // 
            // lbTipoDispositivo
            // 
            this.lbTipoDispositivo.AutoSize = true;
            this.lbTipoDispositivo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTipoDispositivo.Location = new System.Drawing.Point(132, 125);
            this.lbTipoDispositivo.Name = "lbTipoDispositivo";
            this.lbTipoDispositivo.Size = new System.Drawing.Size(138, 23);
            this.lbTipoDispositivo.TabIndex = 3;
            this.lbTipoDispositivo.Text = "Tipo Dispositivo:";
            // 
            // CmbDispositivo
            // 
            this.CmbDispositivo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDispositivo.FormattingEnabled = true;
            this.CmbDispositivo.Location = new System.Drawing.Point(286, 125);
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
            this.lbId.Location = new System.Drawing.Point(132, 194);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(115, 23);
            this.lbId.TabIndex = 2;
            this.lbId.Text = "Identificador:";
            // 
            // CmbMac
            // 
            this.CmbMac.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMac.FormattingEnabled = true;
            this.CmbMac.Location = new System.Drawing.Point(286, 194);
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
            this.btnBuscarMac.Location = new System.Drawing.Point(395, 345);
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
            this.lbToken.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbToken.Location = new System.Drawing.Point(131, 262);
            this.lbToken.Name = "lbToken";
            this.lbToken.Size = new System.Drawing.Size(122, 23);
            this.lbToken.TabIndex = 0;
            this.lbToken.Text = "Codigo / Token";
            // 
            // TbToken
            // 
            this.TbToken.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TbToken.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbToken.ForeColor = System.Drawing.Color.FloralWhite;
            this.TbToken.Location = new System.Drawing.Point(286, 262);
            this.TbToken.Name = "TbToken";
            this.TbToken.ReadOnly = true;
            this.TbToken.Size = new System.Drawing.Size(268, 26);
            this.TbToken.TabIndex = 1;
            this.TbToken.Text = "TOKEN";
            this.TbToken.TextChanged += new System.EventHandler(this.tbToken_TextChanged);
            // 
            // GenerarToken
            // 
            this.GenerarToken.BackColor = System.Drawing.Color.ForestGreen;
            this.GenerarToken.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerarToken.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GenerarToken.Location = new System.Drawing.Point(517, 345);
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
            this.BtnBuscarDispo.Location = new System.Drawing.Point(221, 345);
            this.BtnBuscarDispo.Name = "BtnBuscarDispo";
            this.BtnBuscarDispo.Size = new System.Drawing.Size(168, 38);
            this.BtnBuscarDispo.TabIndex = 11;
            this.BtnBuscarDispo.Text = "Buscar Dispositivo";
            this.BtnBuscarDispo.UseVisualStyleBackColor = false;
            this.BtnBuscarDispo.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(660, 397);
            this.Controls.Add(this.BtnBuscarDispo);
            this.Controls.Add(this.TxtCodEmpresa);
            this.Controls.Add(this.btnBuscarMac);
            this.Controls.Add(this.CmbDispositivo);
            this.Controls.Add(this.CmbMac);
            this.Controls.Add(this.GenerarToken);
            this.Controls.Add(this.lbCodEmpresa);
            this.Controls.Add(this.lbTipoDispositivo);
            this.Controls.Add(this.lbId);
            this.Controls.Add(this.TbToken);
            this.Controls.Add(this.lbToken);
            this.Name = "Form1";
            this.Text = "Codigo y Registro Equipo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbCodEmpresa;
        public TextBox TxtCodEmpresa;

        private System.Windows.Forms.Label lbTipoDispositivo;
        public System.Windows.Forms.ComboBox CmbDispositivo;

        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.ComboBox CmbMac;
        
        private Button btnBuscarMac;
        
        private System.Windows.Forms.Label lbToken;
        private System.Windows.Forms.TextBox TbToken;
        private System.Windows.Forms.Button GenerarToken;
        private Button BtnBuscarDispo;
    }
}

