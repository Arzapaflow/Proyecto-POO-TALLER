namespace Proyecto1.Forms
{
    partial class FrmTrabajoTecnico
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
            this.DgvTickets = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.solución = new System.Windows.Forms.Label();
            this.txtSolucion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCostoFinal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGarantia = new System.Windows.Forms.TextBox();
            this.Estado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvTickets
            // 
            this.DgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTickets.Location = new System.Drawing.Point(47, 28);
            this.DgvTickets.Name = "DgvTickets";
            this.DgvTickets.RowHeadersWidth = 51;
            this.DgvTickets.RowTemplate.Height = 24;
            this.DgvTickets.Size = new System.Drawing.Size(692, 150);
            this.DgvTickets.TabIndex = 0;
            this.DgvTickets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTickets_CellClick);            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Diagnóstico";
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Location = new System.Drawing.Point(38, 223);
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(159, 85);
            this.txtDiagnostico.TabIndex = 2;
            
            // 
            // solución
            // 
            this.solución.AutoSize = true;
            this.solución.Location = new System.Drawing.Point(581, 195);
            this.solución.Name = "solución";
            this.solución.Size = new System.Drawing.Size(59, 16);
            this.solución.TabIndex = 3;
            this.solución.Text = "Solución";
            
            // 
            // txtSolucion
            // 
            this.txtSolucion.Location = new System.Drawing.Point(570, 223);
            this.txtSolucion.Multiline = true;
            this.txtSolucion.Name = "txtSolucion";
            this.txtSolucion.Size = new System.Drawing.Size(132, 85);
            this.txtSolucion.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 345);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Costo Final";
            // 
            // txtCostoFinal
            // 
            this.txtCostoFinal.Location = new System.Drawing.Point(97, 364);
            this.txtCostoFinal.Name = "txtCostoFinal";
            this.txtCostoFinal.Size = new System.Drawing.Size(100, 22);
            this.txtCostoFinal.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Garantía";
            // 
            // txtGarantia
            // 
            this.txtGarantia.Location = new System.Drawing.Point(327, 364);
            this.txtGarantia.Name = "txtGarantia";
            this.txtGarantia.Size = new System.Drawing.Size(100, 22);
            this.txtGarantia.TabIndex = 8;
            // 
            // Estado
            // 
            this.Estado.AutoSize = true;
            this.Estado.Location = new System.Drawing.Point(621, 333);
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(50, 16);
            this.Estado.TabIndex = 9;
            this.Estado.Text = "Estado";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(594, 364);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 24);
            this.cmbEstado.TabIndex = 10;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(291, 400);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(165, 23);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tickets Asignados";
            // 
            // FrmTrabajoTecnico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.Estado);
            this.Controls.Add(this.txtGarantia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCostoFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSolucion);
            this.Controls.Add(this.solución);
            this.Controls.Add(this.txtDiagnostico);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvTickets);
            this.Name = "FrmTrabajoTecnico";
            this.Text = "FrmTrabajoTecnico";
            ((System.ComponentModel.ISupportInitialize)(this.DgvTickets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvTickets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label solución;
        private System.Windows.Forms.TextBox txtSolucion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCostoFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGarantia;
        private System.Windows.Forms.Label Estado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label4;
    }
}