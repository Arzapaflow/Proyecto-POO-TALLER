using Proyecto1.Models;
using Proyecto1.Models.Enums;
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

            CargarTicketsTecnico();

            btnGuardarCambios.Enabled = false;

            dgvTickets.ClearSelection();
        }

        private void FrmTrabajoTecnico_Load(object sender, EventArgs e)
        {
            
        }

        private void ConfigurarGrid()
        {
            dgvTickets.AutoGenerateColumns = false;

            dgvTickets.Columns.Clear();

            dgvTickets.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvTickets.MultiSelect = false;

            dgvTickets.ReadOnly = true;

            dgvTickets.AllowUserToAddRows = false;

            dgvTickets.AllowUserToDeleteRows = false;

            dgvTickets.RowHeadersVisible = false;

            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Id",
                HeaderText = "Folio",
                DataPropertyName = "Id",
                Width = 60
            });

            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Cliente",
                HeaderText = "Cliente",
                Width = 160
            });

            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Equipo",
                HeaderText = "Equipo",
                Width = 180
            });

            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Problema",
                HeaderText = "Problema",
                Width = 180
            });

            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Estado",
                HeaderText = "Estado",
                Width = 110
            });
            CargarEstados();
        }

        private void CargarTicketsTecnico()
        {
            dgvTickets.Rows.Clear();

            if (!SesionActual.HaySesion)
                return;

            int idTecnico =
                SesionActual.Usuario.IdEmpleado;

            List<Ticket> tickets =
                _ticketService.ObtenerPorTecnico(idTecnico);

            foreach (Ticket ticket in tickets)
            {
                dgvTickets.Rows.Add(
                    ticket.Id,
                    ticket.Equipo.Cliente.Nombre,
                    ticket.Equipo.TipoEquipo.Nombre + " - " +
                    ticket.Equipo.Marca + " " +
                    ticket.Equipo.Modelo,
                    ticket.Problema.Nombre,
                    ticket.Estado.ToString()
                );
            }
        }
        private void LimpiarFormulario()
        {
            _idTicketSeleccionado = 0;

            txtDescripcionFalla.Clear();
            txtDiagnostico.Clear();
            txtSolucion.Clear();
            txtCostoFinal.Clear();
            txtGarantia.Clear();
            txtObservaciones.Clear();

            cmbEstado.SelectedIndex = -1;

            dgvTickets.ClearSelection();

            btnGuardarCambios.Enabled = false;
        }

        private void dgvTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _idTicketSeleccionado =
                Convert.ToInt32(
                    dgvTickets.Rows[e.RowIndex].Cells["Id"].Value);

            Ticket ticket =
                _ticketService.ObtenerPorId(_idTicketSeleccionado);

            if (ticket == null)
                return;

            txtDescripcionFalla.Text =
                ticket.DescripcionFalla;

            txtDiagnostico.Text =
                ticket.Diagnostico;

            txtSolucion.Text =
                ticket.SolucionAplicada;

            txtCostoFinal.Text =
                ticket.CostoFinal.HasValue
                    ? ticket.CostoFinal.Value.ToString("0.00")
                    : "";

            txtGarantia.Text =
                ticket.GarantiaDias.ToString();

            txtObservaciones.Text =
                ticket.Observaciones;

            cmbEstado.SelectedItem =
                ticket.Estado.ToString();
            btnGuardarCambios.Enabled = true;
        }
        private void CargarEstados()
        {
            cmbEstado.Items.Clear();

            cmbEstado.Items.Add("EnProgreso");
            cmbEstado.Items.Add("Terminado");
            cmbEstado.Items.Add("Cancelado");
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (_idTicketSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione un ticket.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult respuesta =
                MessageBox.Show(
                    "¿Guardar los cambios realizados?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                Ticket ticket =
                    _ticketService.ObtenerPorId(_idTicketSeleccionado);

                if (ticket == null)
                {
                    MessageBox.Show("El ticket ya no existe.");
                    return;
                }

                ticket.Diagnostico =
                    txtDiagnostico.Text.Trim();

                ticket.SolucionAplicada =
                    txtSolucion.Text.Trim();

                ticket.Observaciones =
                    txtObservaciones.Text.Trim();

                if (!decimal.TryParse(txtCostoFinal.Text, out decimal costo))
                {
                    MessageBox.Show(
                        "Ingrese un costo válido.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtCostoFinal.Focus();
                    return;
                }

                ticket.CostoFinal = costo;

                if (!int.TryParse(txtGarantia.Text, out int garantia))
                {
                    MessageBox.Show(
                        "Ingrese una garantía válida.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtGarantia.Focus();
                    return;
                }

                ticket.GarantiaDias = garantia;
                MessageBox.Show(cmbEstado.Text);
                ticket.Estado =
                    (EstadoTicket)Enum.Parse(
                        typeof(EstadoTicket),
                        cmbEstado.Text);
                if (ticket.Estado == EstadoTicket.Terminado &&
                        !ticket.FechaEntrega.HasValue)
                {
                    ticket.FechaEntrega = DateTime.Now;
                }

                bool actualizado =
                    _ticketService.Actualizar(ticket);

                if (actualizado)
                {
                    MessageBox.Show(
                        "Cambios guardados correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarTicketsTecnico();

                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show(
                        "No fue posible actualizar el ticket.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}