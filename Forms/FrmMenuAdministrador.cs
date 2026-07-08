using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1.Forms
{
    public partial class FrmMenuAdministrador : Form
    {
        public FrmMenuAdministrador()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmTickets());
        }

        private void AbrirFormulario(Form formulario)
        {
            pnlContenedor.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            pnlContenedor.Controls.Add(formulario);
            pnlContenedor.Tag = formulario;

            formulario.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmClientes());
        }

        

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmInventario());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();

            login.Show();

            this.Close();
        }

        private void btnTecnicos_Click(object sender, EventArgs e)
        {
            FrmTecnicos frm = new FrmTecnicos();
            frm.ShowDialog();
        }
    }
}
