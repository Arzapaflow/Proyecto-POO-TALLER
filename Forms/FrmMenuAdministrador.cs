using System;
using System.Windows.Forms;
using Proyecto1.Models;

namespace Proyecto1.Forms
{
    public partial class FrmMenuAdministrador : Form
    {
        public FrmMenuAdministrador()
        {
            InitializeComponent();

            AbrirFormulario(new FrmDashboardAdministrador());
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

        private void iconButton2_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmTickets());
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmInventario());
        }

        private void btnTecnicos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmTecnicos());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();

            login.Show();

            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private decimal CalcularPagoTecnico(decimal costo)
        {
            return costo *
                   ConfiguracionTaller.PorcentajePagoTecnico;
        }

        private decimal CalcularUtilidad(decimal costo)
        {
            return costo -
                   CalcularPagoTecnico(costo);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmDashboardAdministrador());
        }
    }
}