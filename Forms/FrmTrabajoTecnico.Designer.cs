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
            this.dgvTickets = new System.Windows.Forms.DataGridView();
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
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcionFalla = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTickets
            // 
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTickets.Location = new System.Drawing.Point(64, 68);
            this.dgvTickets.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.RowHeadersWidth = 51;
            this.dgvTickets.RowTemplate.Height = 24;
            this.dgvTickets.Size = new System.Drawing.Size(1111, 204);
            this.dgvTickets.TabIndex = 0;
            this.dgvTickets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTickets_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(142, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Diagnóstico";
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Location = new System.Drawing.Point(147, 444);
            this.txtDiagnostico.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(178, 105);
            this.txtDiagnostico.TabIndex = 2;
            // 
            // solución
            // 
            this.solución.AutoSize = true;
            this.solución.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solución.Location = new System.Drawing.Point(712, 410);
            this.solución.Name = "solución";
            this.solución.Size = new System.Drawing.Size(93, 28);
            this.solución.TabIndex = 3;
            this.solución.Text = "Solución";
            // 
            // txtSolucion
            // 
            this.txtSolucion.Location = new System.Drawing.Point(745, 444);
            this.txtSolucion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSolucion.Multiline = true;
            this.txtSolucion.Name = "txtSolucion";
            this.txtSolucion.Size = new System.Drawing.Size(148, 105);
            this.txtSolucion.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(208, 582);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Costo Final";
            // 
            // txtCostoFinal
            // 
            this.txtCostoFinal.Location = new System.Drawing.Point(213, 620);
            this.txtCostoFinal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCostoFinal.Name = "txtCostoFinal";
            this.txtCostoFinal.Size = new System.Drawing.Size(112, 26);
            this.txtCostoFinal.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(482, 582);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "Garantía";
            // 
            // txtGarantia
            // 
            this.txtGarantia.Location = new System.Drawing.Point(472, 620);
            this.txtGarantia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGarantia.Name = "txtGarantia";
            this.txtGarantia.Size = new System.Drawing.Size(112, 26);
            this.txtGarantia.TabIndex = 8;
            // 
            // Estado
            // 
            this.Estado.AutoSize = true;
            this.Estado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Estado.Location = new System.Drawing.Point(787, 582);
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(75, 28);
            this.Estado.TabIndex = 9;
            this.Estado.Text = "Estado";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(757, 618);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(136, 28);
            this.cmbEstado.TabIndex = 10;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.AutoSize = true;
            this.btnGuardarCambios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCambios.Location = new System.Drawing.Point(500, 789);
            this.btnGuardarCambios.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(186, 38);
            this.btnGuardarCambios.TabIndex = 11;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tickets Asignados";
            // 
            // txtDescripcionFalla
            // 
            this.txtDescripcionFalla.Location = new System.Drawing.Point(337, 280);
            this.txtDescripcionFalla.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescripcionFalla.Multiline = true;
            this.txtDescripcionFalla.Name = "txtDescripcionFalla";
            this.txtDescripcionFalla.ReadOnly = true;
            this.txtDescripcionFalla.Size = new System.Drawing.Size(620, 125);
            this.txtDescripcionFalla.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(102, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 28);
            this.label5.TabIndex = 13;
            this.label5.Text = "Descripcion de la falla";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(295, 665);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(624, 116);
            this.txtObservaciones.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(124, 665);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 28);
            this.label6.TabIndex = 15;
            this.label6.Text = "Observaciones";
            // 
            // FrmTrabajoTecnico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 871);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescripcionFalla);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGuardarCambios);
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
            this.Controls.Add(this.dgvTickets);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmTrabajoTecnico";
            this.Text = "FrmTrabajoTecnico";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTickets;
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
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescripcionFalla;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label6;
    }
}