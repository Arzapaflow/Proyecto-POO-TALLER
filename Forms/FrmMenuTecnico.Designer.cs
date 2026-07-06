namespace Proyecto1.Forms
{
    partial class FrmMenuTecnico
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
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.iconInicio = new FontAwesome.Sharp.IconPictureBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new FontAwesome.Sharp.IconButton();
            this.btnTickets = new FontAwesome.Sharp.IconButton();
            this.btnEquipos = new FontAwesome.Sharp.IconButton();
            this.btnClientes = new FontAwesome.Sharp.IconButton();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.pnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconInicio)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlSuperior.Controls.Add(this.iconPictureBox2);
            this.pnlSuperior.Controls.Add(this.lblSubtitulo);
            this.pnlSuperior.Controls.Add(this.lblTitulo);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1182, 80);
            this.pnlSuperior.TabIndex = 0;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.SteelBlue;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Wrench;
            this.iconPictureBox2.IconColor = System.Drawing.Color.White;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 29;
            this.iconPictureBox2.Location = new System.Drawing.Point(3, 12);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(36, 29);
            this.iconPictureBox2.TabIndex = 2;
            this.iconPictureBox2.TabStop = false;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.Location = new System.Drawing.Point(23, 54);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(118, 23);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Menú Técnico";
            this.lblSubtitulo.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(30, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(221, 41);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "TallerArzapalo";
            this.lblTitulo.UseWaitCursor = true;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContenedor.Controls.Add(this.label2);
            this.pnlContenedor.Controls.Add(this.label1);
            this.pnlContenedor.Controls.Add(this.iconInicio);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 80);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1182, 573);
            this.pnlContenedor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(583, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione una opción del menú para comenzar.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(595, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Área de trabajo";
            // 
            // iconInicio
            // 
            this.iconInicio.BackColor = System.Drawing.Color.Transparent;
            this.iconInicio.ForeColor = System.Drawing.Color.SteelBlue;
            this.iconInicio.IconChar = FontAwesome.Sharp.IconChar.DesktopAlt;
            this.iconInicio.IconColor = System.Drawing.Color.SteelBlue;
            this.iconInicio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconInicio.IconSize = 58;
            this.iconInicio.Location = new System.Drawing.Point(697, 87);
            this.iconInicio.Name = "iconInicio";
            this.iconInicio.Size = new System.Drawing.Size(58, 60);
            this.iconInicio.TabIndex = 0;
            this.iconInicio.TabStop = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.DimGray;
            this.pnlMenu.Controls.Add(this.btnCerrarSesion);
            this.pnlMenu.Controls.Add(this.btnTickets);
            this.pnlMenu.Controls.Add(this.btnEquipos);
            this.pnlMenu.Controls.Add(this.btnClientes);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 80);
            this.pnlMenu.MinimumSize = new System.Drawing.Size(220, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(220, 573);
            this.pnlMenu.TabIndex = 2;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.DimGray;
            this.btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.btnCerrarSesion.IconColor = System.Drawing.Color.Black;
            this.btnCerrarSesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrarSesion.IconSize = 28;
            this.btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 165);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnCerrarSesion.Size = new System.Drawing.Size(220, 55);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnTickets
            // 
            this.btnTickets.BackColor = System.Drawing.Color.DimGray;
            this.btnTickets.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTickets.FlatAppearance.BorderSize = 0;
            this.btnTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTickets.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTickets.ForeColor = System.Drawing.Color.White;
            this.btnTickets.IconChar = FontAwesome.Sharp.IconChar.Ticket;
            this.btnTickets.IconColor = System.Drawing.Color.Black;
            this.btnTickets.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTickets.IconSize = 28;
            this.btnTickets.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTickets.Location = new System.Drawing.Point(0, 110);
            this.btnTickets.Name = "btnTickets";
            this.btnTickets.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTickets.Size = new System.Drawing.Size(220, 55);
            this.btnTickets.TabIndex = 2;
            this.btnTickets.Text = "Tickets";
            this.btnTickets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTickets.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTickets.UseVisualStyleBackColor = false;
            this.btnTickets.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // btnEquipos
            // 
            this.btnEquipos.BackColor = System.Drawing.Color.DimGray;
            this.btnEquipos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEquipos.FlatAppearance.BorderSize = 0;
            this.btnEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEquipos.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEquipos.ForeColor = System.Drawing.Color.White;
            this.btnEquipos.IconChar = FontAwesome.Sharp.IconChar.Laptop;
            this.btnEquipos.IconColor = System.Drawing.Color.Black;
            this.btnEquipos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEquipos.IconSize = 28;
            this.btnEquipos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEquipos.Location = new System.Drawing.Point(0, 55);
            this.btnEquipos.Name = "btnEquipos";
            this.btnEquipos.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnEquipos.Size = new System.Drawing.Size(220, 55);
            this.btnEquipos.TabIndex = 1;
            this.btnEquipos.Text = "Equipos";
            this.btnEquipos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEquipos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEquipos.UseVisualStyleBackColor = false;
            this.btnEquipos.Click += new System.EventHandler(this.btnEquipos_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.DimGray;
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnClientes.IconColor = System.Drawing.Color.Black;
            this.btnClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClientes.IconSize = 28;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(0, 0);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnClientes.Size = new System.Drawing.Size(220, 55);
            this.btnClientes.TabIndex = 0;
            this.btnClientes.Text = " Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // FrmMenuTecnico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlSuperior);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "FrmMenuTecnico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Técnico";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconInicio)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private FontAwesome.Sharp.IconButton btnClientes;
        private FontAwesome.Sharp.IconButton btnCerrarSesion;
        private FontAwesome.Sharp.IconButton btnTickets;
        private FontAwesome.Sharp.IconButton btnEquipos;
        private FontAwesome.Sharp.IconPictureBox iconInicio;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}