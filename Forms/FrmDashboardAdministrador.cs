using Proyecto1.Models;
using Proyecto1.Models.Enums;
using Proyecto1.Services;
using Proyecto1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto1.Forms
{
    public partial class FrmDashboardAdministrador : Form
    {
        private readonly ITicketService _ticketService;

        private decimal porcentajePagoTecnico = 0.30m;
        private decimal porcentajeMateriales = 0.40m;
        private decimal porcentajeUtilidad = 0.30m;

        public FrmDashboardAdministrador()
        {
            InitializeComponent();

            _ticketService = new TicketService();

            ConfigurarGrid();

            CargarDashboard();
        }

        private void FrmDashboardAdministrador_Load(object sender, EventArgs e)
        {

        }

        private void ConfigurarGrid()
        {
            dgvResumen.AutoGenerateColumns = false;

            dgvResumen.AllowUserToAddRows = false;
            dgvResumen.AllowUserToDeleteRows = false;

            dgvResumen.ReadOnly = true;

            dgvResumen.MultiSelect = false;

            dgvResumen.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvResumen.RowHeadersVisible = false;

            dgvResumen.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvResumen.Columns["Concepto"].FillWeight = 45;

            dgvResumen.Columns["Precio"].FillWeight = 18;

            dgvResumen.Columns["PagoTecnico"].FillWeight = 18;

            dgvResumen.Columns["Utilidad"].FillWeight = 19;

            dgvResumen.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvResumen.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvResumen.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvResumen.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvResumen.Columns["Concepto"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
        }

        private void CargarDashboard()
        {
            dgvResumen.Rows.Clear();

            int ticketsHoy = 0;
            int ticketsTerminados = 0;

            decimal totalPagoTecnicos = 0;
            decimal totalUtilidad = 0;

            List<Ticket> tickets =
                _ticketService.ObtenerTodos();

            foreach (Ticket ticket in tickets)
            {
                if (ticket.FechaIngreso.Date == DateTime.Today)
                {
                    ticketsHoy++;
                }

                if (ticket.Estado != EstadoTicket.Terminado)
                    continue;

                ticketsTerminados++;

                decimal precio = 0;

                if (ticket.CostoFinal.HasValue)
                    precio = ticket.CostoFinal.Value;
                else
                    precio = ticket.CostoEstimado;

                decimal pagoTecnico =
       CalcularPagoTecnico(precio);

                decimal utilidad =
                    CalcularUtilidad(precio);

                totalPagoTecnicos += pagoTecnico;

                totalUtilidad += utilidad;

                string concepto =
                    ticket.Problema.Nombre +
                    Environment.NewLine +
                    ticket.Equipo.Marca +
                    " " +
                    ticket.Equipo.Modelo;

                dgvResumen.Rows.Add(
                    concepto,
                    precio.ToString("C2"),
                    pagoTecnico.ToString("C2"),
                    utilidad.ToString("C2"));
            }

            lblTicketsHoy.Text =
                ticketsHoy.ToString();

            lblTerminados.Text =
                ticketsTerminados.ToString();

            lblPagoTecnicos.Text =
                totalPagoTecnicos.ToString("C2");

            lblGanancia.Text =
                totalUtilidad.ToString("C2");

            lblPorcentajePago.Text =
                (porcentajePagoTecnico * 100).ToString("0") + "%";

            lblPorcentajeUtilidad.Text =
                (porcentajeUtilidad * 100).ToString("0") + "%";
        }

        private void ActualizarPorcentajes()
        {
            ActualizarPorcentajes();
        }
        private decimal CalcularPagoTecnico(decimal precio)
        {
            return precio * porcentajePagoTecnico;
        }

        private decimal CalcularMateriales(decimal precio)
        {
            return precio * porcentajeMateriales;
        }

        private decimal CalcularUtilidad(decimal precio)
        {
            return precio * porcentajeUtilidad;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

    }

}
