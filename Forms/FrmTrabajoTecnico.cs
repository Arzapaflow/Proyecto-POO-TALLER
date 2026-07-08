using Proyecto1.Models;
using Proyecto1.Services;
using Proyecto1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Proyecto1.Forms
{
    public partial class FrmTrabajoTecnico : Form
    {
        private readonly ITicketService _ticketService;

        private int _idTicketSeleccionado = 0;

        public FrmTrabajoTecnico()
        {
            InitializeComponent();

            _ticketService = new TicketService();

            ConfigurarGrid();

            Load += FrmTrabajoTecnico_Load;
        }

        private void FrmTrabajoTecnico_Load(object sender, EventArgs e)
        {
            CargarTickets();
        }

        private void ConfigurarGrid()
        {
            DgvTickets.AutoGenerateColumns = false;

            DgvTickets.Columns.Clear();

            DgvTickets.Columns.Add("Id", "Folio");
            DgvTickets.Columns.Add("Cliente", "Cliente");
            DgvTickets.Columns.Add("Equipo", "Equipo");
            DgvTickets.Columns.Add("Problema", "Problema");
            DgvTickets.Columns.Add("Estado", "Estado");
            DgvTickets.Columns.Add("Prioridad", "Prioridad");
            DgvTickets.Columns.Add("Fecha", "Fecha");

            DgvTickets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvTickets.MultiSelect = false;
            DgvTickets.ReadOnly = true;
            DgvTickets.AllowUserToAddRows = false;
            DgvTickets.AllowUserToDeleteRows = false;
        }

        private void CargarTickets()
        {
            DgvTickets.Rows.Clear();

            List<Ticket> lista =
                _ticketService.ObtenerPorTecnico(
                    SesionActual.Usuario.IdEmpleado);

            foreach (Ticket ticket in lista)
            {
                DgvTickets.Rows.Add(
                    ticket.Id,
                    ticket.Equipo.Cliente.Nombre,
                    ticket.Equipo.TipoEquipo.Nombre + " " +
                    ticket.Equipo.Marca + " " +
                    ticket.Equipo.Modelo,
                    ticket.Problema.Nombre,
                    ticket.Estado.ToString(),
                    ticket.Prioridad,
                    ticket.FechaIngreso.ToShortDateString());
            }
        }

        private void DgvTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _idTicketSeleccionado =
                Convert.ToInt32(
                    DgvTickets.Rows[e.RowIndex].Cells[0].Value);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}