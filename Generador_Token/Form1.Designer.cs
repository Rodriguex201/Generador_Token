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
            this.CmbTipodispositivo = new System.Windows.Forms.ComboBox();
            this.lbId = new System.Windows.Forms.Label();
            this.CmbId = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lbToken = new System.Windows.Forms.Label();
            this.TbToken = new System.Windows.Forms.TextBox();
            this.GenerarToken = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbCodEmpresa
            // 
            this.lbCodEmpresa.AutoSize = true;
            this.lbCodEmpresa.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodEmpresa.Location = new System.Drawing.Point(13, 43);
            this.lbCodEmpresa.Name = "lbCodEmpresa";
            this.lbCodEmpresa.Size = new System.Drawing.Size(121, 23);
            this.lbCodEmpresa.TabIndex = 4;
            this.lbCodEmpresa.Text = "Cod. Empresa:";
            // 
            // TxtCodEmpresa
            // 
            this.TxtCodEmpresa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodEmpresa.ForeColor = System.Drawing.Color.DarkGreen;
            this.TxtCodEmpresa.Location = new System.Drawing.Point(167, 43);
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
            this.lbTipoDispositivo.Location = new System.Drawing.Point(13, 91);
            this.lbTipoDispositivo.Name = "lbTipoDispositivo";
            this.lbTipoDispositivo.Size = new System.Drawing.Size(138, 23);
            this.lbTipoDispositivo.TabIndex = 3;
            this.lbTipoDispositivo.Text = "Tipo Dispositivo:";
            // 
            // CmbTipodispositivo
            // 
            this.CmbTipodispositivo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipodispositivo.FormattingEnabled = true;
            this.CmbTipodispositivo.Location = new System.Drawing.Point(167, 91);
            this.CmbTipodispositivo.Name = "CmbTipodispositivo";
            this.CmbTipodispositivo.Size = new System.Drawing.Size(268, 26);
            this.CmbTipodispositivo.TabIndex = 7;
            this.CmbTipodispositivo.Text = "Seleccione un dispositivo";
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbId.Location = new System.Drawing.Point(13, 141);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(115, 23);
            this.lbId.TabIndex = 2;
            this.lbId.Text = "Identificador:";
            // 
            // CmbId
            // 
            this.CmbId.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbId.FormattingEnabled = true;
            this.CmbId.Location = new System.Drawing.Point(167, 141);
            this.CmbId.Name = "CmbId";
            this.CmbId.Size = new System.Drawing.Size(268, 26);
            this.CmbId.TabIndex = 6;
            this.CmbId.Text = "Seleccione direccion Mac";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBuscar.Location = new System.Drawing.Point(267, 182);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(168, 38);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar Dispositivo";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lbToken
            // 
            this.lbToken.AutoSize = true;
            this.lbToken.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbToken.Location = new System.Drawing.Point(12, 273);
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
            this.TbToken.Location = new System.Drawing.Point(167, 273);
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
            this.GenerarToken.Location = new System.Drawing.Point(304, 314);
            this.GenerarToken.Name = "GenerarToken";
            this.GenerarToken.Size = new System.Drawing.Size(131, 38);
            this.GenerarToken.TabIndex = 5;
            this.GenerarToken.Text = "Generar Token";
            this.GenerarToken.UseVisualStyleBackColor = false;
            this.GenerarToken.Click += new System.EventHandler(this.GenerarToken_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(447, 395);
            this.Controls.Add(this.TxtCodEmpresa);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.CmbTipodispositivo);
            this.Controls.Add(this.CmbId);
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
        public System.Windows.Forms.ComboBox CmbTipodispositivo;

        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.ComboBox CmbId;
        
        private Button btnBuscar;
        
        private System.Windows.Forms.Label lbToken;
        private System.Windows.Forms.TextBox TbToken;
        private System.Windows.Forms.Button GenerarToken;

    }
}

