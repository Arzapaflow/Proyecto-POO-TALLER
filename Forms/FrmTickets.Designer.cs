namespace Proyecto1.Forms
{
    partial class FrmTickets
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTipoEquipo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNumeroSerie = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAccesorios = new System.Windows.Forms.TextBox();
            this.txtObservacionesEquipo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbProblema = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbPrioridad = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDescripcionFalla = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCostoEstimado = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtObservacionesTicket = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(444, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "REGISTRO DE TICKET";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "DATOS DEL EQUIPO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "DATOS DEL TICKET";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(324, 52);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(329, 24);
            this.cmbCliente.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tipo de equipo:";
            // 
            // cmbTipoEquipo
            // 
            this.cmbTipoEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEquipo.FormattingEnabled = true;
            this.cmbTipoEquipo.Location = new System.Drawing.Point(337, 117);
            this.cmbTipoEquipo.Name = "cmbTipoEquipo";
            this.cmbTipoEquipo.Size = new System.Drawing.Size(151, 24);
            this.cmbTipoEquipo.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(565, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Marca:";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(626, 125);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(132, 22);
            this.txtMarca.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(216, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Modelo:";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(297, 153);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(132, 22);
            this.txtModelo.TabIndex = 10;
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(626, 156);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(100, 22);
            this.txtColor.TabIndex = 11;
            this.txtColor.TextChanged += new System.EventHandler(this.txtColor_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(565, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Color:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(216, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "Num. de serie:";
            // 
            // txtNumeroSerie
            // 
            this.txtNumeroSerie.Location = new System.Drawing.Point(337, 184);
            this.txtNumeroSerie.Name = "txtNumeroSerie";
            this.txtNumeroSerie.Size = new System.Drawing.Size(151, 22);
            this.txtNumeroSerie.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(219, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 16);
            this.label10.TabIndex = 15;
            this.label10.Text = "Accesorios:";
            // 
            // txtAccesorios
            // 
            this.txtAccesorios.Location = new System.Drawing.Point(312, 215);
            this.txtAccesorios.Multiline = true;
            this.txtAccesorios.Name = "txtAccesorios";
            this.txtAccesorios.Size = new System.Drawing.Size(163, 57);
            this.txtAccesorios.TabIndex = 16;
            // 
            // txtObservacionesEquipo
            // 
            this.txtObservacionesEquipo.Location = new System.Drawing.Point(773, 184);
            this.txtObservacionesEquipo.Multiline = true;
            this.txtObservacionesEquipo.Name = "txtObservacionesEquipo";
            this.txtObservacionesEquipo.Size = new System.Drawing.Size(151, 68);
            this.txtObservacionesEquipo.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(565, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(169, 16);
            this.label11.TabIndex = 18;
            this.label11.Text = "Observaciones del equipo:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(222, 312);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 16);
            this.label12.TabIndex = 19;
            this.label12.Text = "Problema:";
            // 
            // cmbProblema
            // 
            this.cmbProblema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProblema.FormattingEnabled = true;
            this.cmbProblema.Location = new System.Drawing.Point(312, 304);
            this.cmbProblema.Name = "cmbProblema";
            this.cmbProblema.Size = new System.Drawing.Size(156, 24);
            this.cmbProblema.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(565, 312);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 16);
            this.label13.TabIndex = 21;
            this.label13.Text = "Prioridad:";
            // 
            // cmbPrioridad
            // 
            this.cmbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrioridad.FormattingEnabled = true;
            this.cmbPrioridad.Location = new System.Drawing.Point(652, 304);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new System.Drawing.Size(121, 24);
            this.cmbPrioridad.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(222, 346);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 16);
            this.label14.TabIndex = 23;
            this.label14.Text = "Descripción de la falla:";
            // 
            // txtDescripcionFalla
            // 
            this.txtDescripcionFalla.Location = new System.Drawing.Point(225, 366);
            this.txtDescripcionFalla.Multiline = true;
            this.txtDescripcionFalla.Name = "txtDescripcionFalla";
            this.txtDescripcionFalla.Size = new System.Drawing.Size(228, 76);
            this.txtDescripcionFalla.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(568, 346);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 16);
            this.label15.TabIndex = 25;
            this.label15.Text = "Costo Estimado:";
            // 
            // txtCostoEstimado
            // 
            this.txtCostoEstimado.Location = new System.Drawing.Point(709, 343);
            this.txtCostoEstimado.Name = "txtCostoEstimado";
            this.txtCostoEstimado.ReadOnly = true;
            this.txtCostoEstimado.Size = new System.Drawing.Size(137, 22);
            this.txtCostoEstimado.TabIndex = 26;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(568, 378);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(158, 16);
            this.label16.TabIndex = 27;
            this.label16.Text = "Observaciones del ticket:";
            // 
            // txtObservacionesTicket
            // 
            this.txtObservacionesTicket.Location = new System.Drawing.Point(766, 378);
            this.txtObservacionesTicket.Multiline = true;
            this.txtObservacionesTicket.Name = "txtObservacionesTicket";
            this.txtObservacionesTicket.Size = new System.Drawing.Size(158, 64);
            this.txtObservacionesTicket.TabIndex = 28;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(447, 477);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(87, 39);
            this.btnNuevo.TabIndex = 29;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(571, 477);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(102, 39);
            this.btnGuardar.TabIndex = 30;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(401, 525);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 16);
            this.label17.TabIndex = 31;
            this.label17.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(477, 522);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(240, 22);
            this.txtBuscar.TabIndex = 32;
            // 
            // dgvTickets
            // 
            this.dgvTickets.AllowUserToAddRows = false;
            this.dgvTickets.AllowUserToDeleteRows = false;
            this.dgvTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTickets.Location = new System.Drawing.Point(477, 550);
            this.dgvTickets.MultiSelect = false;
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.ReadOnly = true;
            this.dgvTickets.RowHeadersVisible = false;
            this.dgvTickets.RowHeadersWidth = 51;
            this.dgvTickets.RowTemplate.Height = 24;
            this.dgvTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTickets.Size = new System.Drawing.Size(240, 150);
            this.dgvTickets.TabIndex = 33;
            // 
            // FrmTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.dgvTickets);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.txtObservacionesTicket);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtCostoEstimado);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtDescripcionFalla);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbPrioridad);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbProblema);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtObservacionesEquipo);
            this.Controls.Add(this.txtAccesorios);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtNumeroSerie);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTipoEquipo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmTickets";
            this.Text = "Gestión de Tickets";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTipoEquipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNumeroSerie;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAccesorios;
        private System.Windows.Forms.TextBox txtObservacionesEquipo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbProblema;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbPrioridad;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDescripcionFalla;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCostoEstimado;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtObservacionesTicket;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvTickets;
    }
}