namespace Proyecto1.Forms
{
    partial class FrmDashboardAdministrador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTituloTicketsHoy = new System.Windows.Forms.Label();
            this.labelTituloTerminados = new System.Windows.Forms.Label();
            this.labelTituloPago = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPorcentajePago = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPorcentajeUtilidad = new System.Windows.Forms.Label();
            this.dgvResumen = new System.Windows.Forms.DataGridView();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoTecnico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Utilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPagoTecnicos = new System.Windows.Forms.Label();
            this.lblTerminados = new System.Windows.Forms.Label();
            this.lblTicketsHoy = new System.Windows.Forms.Label();
            this.labelTituloGanancia = new System.Windows.Forms.Label();
            this.lblGanancia = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumen)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTituloTicketsHoy
            // 
            this.labelTituloTicketsHoy.AutoSize = true;
            this.labelTituloTicketsHoy.Location = new System.Drawing.Point(51, 47);
            this.labelTituloTicketsHoy.Name = "labelTituloTicketsHoy";
            this.labelTituloTicketsHoy.Size = new System.Drawing.Size(95, 16);
            this.labelTituloTicketsHoy.TabIndex = 0;
            this.labelTituloTicketsHoy.Text = "Tickets de hoy";
            this.labelTituloTicketsHoy.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelTituloTerminados
            // 
            this.labelTituloTerminados.AutoSize = true;
            this.labelTituloTerminados.Location = new System.Drawing.Point(179, 47);
            this.labelTituloTerminados.Name = "labelTituloTerminados";
            this.labelTituloTerminados.Size = new System.Drawing.Size(127, 16);
            this.labelTituloTerminados.TabIndex = 1;
            this.labelTituloTerminados.Text = "Tickets Terminados";
            // 
            // labelTituloPago
            // 
            this.labelTituloPago.AutoSize = true;
            this.labelTituloPago.Location = new System.Drawing.Point(340, 47);
            this.labelTituloPago.Name = "labelTituloPago";
            this.labelTituloPago.Size = new System.Drawing.Size(104, 16);
            this.labelTituloPago.TabIndex = 2;
            this.labelTituloPago.Text = "Pago a técnicos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pago técnico:";
            // 
            // lblPorcentajePago
            // 
            this.lblPorcentajePago.AutoSize = true;
            this.lblPorcentajePago.Location = new System.Drawing.Point(429, 143);
            this.lblPorcentajePago.Name = "lblPorcentajePago";
            this.lblPorcentajePago.Size = new System.Drawing.Size(33, 16);
            this.lblPorcentajePago.TabIndex = 4;
            this.lblPorcentajePago.Text = "30%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(479, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Utilidad";
            // 
            // lblPorcentajeUtilidad
            // 
            this.lblPorcentajeUtilidad.AutoSize = true;
            this.lblPorcentajeUtilidad.Location = new System.Drawing.Point(549, 143);
            this.lblPorcentajeUtilidad.Name = "lblPorcentajeUtilidad";
            this.lblPorcentajeUtilidad.Size = new System.Drawing.Size(33, 16);
            this.lblPorcentajeUtilidad.TabIndex = 6;
            this.lblPorcentajeUtilidad.Text = "30%";
            // 
            // dgvResumen
            // 
            this.dgvResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResumen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Concepto,
            this.Precio,
            this.PagoTecnico,
            this.Utilidad});
            this.dgvResumen.Location = new System.Drawing.Point(22, 176);
            this.dgvResumen.Name = "dgvResumen";
            this.dgvResumen.RowHeadersWidth = 51;
            this.dgvResumen.RowTemplate.Height = 24;
            this.dgvResumen.Size = new System.Drawing.Size(544, 150);
            this.dgvResumen.TabIndex = 7;
            // 
            // Concepto
            // 
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.MinimumWidth = 6;
            this.Concepto.Name = "Concepto";
            this.Concepto.Width = 125;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.Width = 125;
            // 
            // PagoTecnico
            // 
            this.PagoTecnico.HeaderText = "Pago Técnico";
            this.PagoTecnico.MinimumWidth = 6;
            this.PagoTecnico.Name = "PagoTecnico";
            this.PagoTecnico.Width = 125;
            // 
            // Utilidad
            // 
            this.Utilidad.HeaderText = "Utilidad";
            this.Utilidad.MinimumWidth = 6;
            this.Utilidad.Name = "Utilidad";
            this.Utilidad.Width = 125;
            // 
            // lblPagoTecnicos
            // 
            this.lblPagoTecnicos.AutoSize = true;
            this.lblPagoTecnicos.Location = new System.Drawing.Point(362, 85);
            this.lblPagoTecnicos.Name = "lblPagoTecnicos";
            this.lblPagoTecnicos.Size = new System.Drawing.Size(38, 16);
            this.lblPagoTecnicos.TabIndex = 8;
            this.lblPagoTecnicos.Text = "$0.00";
            // 
            // lblTerminados
            // 
            this.lblTerminados.AutoSize = true;
            this.lblTerminados.Location = new System.Drawing.Point(222, 85);
            this.lblTerminados.Name = "lblTerminados";
            this.lblTerminados.Size = new System.Drawing.Size(14, 16);
            this.lblTerminados.TabIndex = 9;
            this.lblTerminados.Text = "0";
            // 
            // lblTicketsHoy
            // 
            this.lblTicketsHoy.AutoSize = true;
            this.lblTicketsHoy.Location = new System.Drawing.Point(83, 85);
            this.lblTicketsHoy.Name = "lblTicketsHoy";
            this.lblTicketsHoy.Size = new System.Drawing.Size(14, 16);
            this.lblTicketsHoy.TabIndex = 10;
            this.lblTicketsHoy.Text = "0";
            // 
            // labelTituloGanancia
            // 
            this.labelTituloGanancia.AutoSize = true;
            this.labelTituloGanancia.Location = new System.Drawing.Point(473, 47);
            this.labelTituloGanancia.Name = "labelTituloGanancia";
            this.labelTituloGanancia.Size = new System.Drawing.Size(109, 16);
            this.labelTituloGanancia.TabIndex = 11;
            this.labelTituloGanancia.Text = "Ganancia de hoy";
            // 
            // lblGanancia
            // 
            this.lblGanancia.AutoSize = true;
            this.lblGanancia.Location = new System.Drawing.Point(503, 85);
            this.lblGanancia.Name = "lblGanancia";
            this.lblGanancia.Size = new System.Drawing.Size(38, 16);
            this.lblGanancia.TabIndex = 12;
            this.lblGanancia.Text = "$0.00";
            // 
            // FrmDashboardAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblGanancia);
            this.Controls.Add(this.labelTituloGanancia);
            this.Controls.Add(this.lblTicketsHoy);
            this.Controls.Add(this.lblTerminados);
            this.Controls.Add(this.lblPagoTecnicos);
            this.Controls.Add(this.dgvResumen);
            this.Controls.Add(this.lblPorcentajeUtilidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPorcentajePago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTituloPago);
            this.Controls.Add(this.labelTituloTerminados);
            this.Controls.Add(this.labelTituloTicketsHoy);
            this.Name = "FrmDashboardAdministrador";
            this.Text = "FrmDashboardAdministrador";
            this.Load += new System.EventHandler(this.FrmDashboardAdministrador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTituloTicketsHoy;
        private System.Windows.Forms.Label labelTituloTerminados;
        private System.Windows.Forms.Label labelTituloPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPorcentajePago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPorcentajeUtilidad;
        private System.Windows.Forms.DataGridView dgvResumen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoTecnico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Utilidad;
        private System.Windows.Forms.Label lblPagoTecnicos;
        private System.Windows.Forms.Label lblTerminados;
        private System.Windows.Forms.Label lblTicketsHoy;
        private System.Windows.Forms.Label labelTituloGanancia;
        private System.Windows.Forms.Label lblGanancia;
    }
}