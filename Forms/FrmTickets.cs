using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Proyecto1.Models;
using Proyecto1.Repositorios;
using Proyecto1.Repositorios.Interfaces;
using Proyecto1.Services;
using Proyecto1.Services.Interfaces;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Forms
{
    public partial class FrmTickets : Form
    {
        private readonly IClienteService _clienteService;
        private readonly ITipoEquipoRepository _tipoEquipoRepository;
        private readonly IProblemaRepository _problemaRepository;
        private readonly IEquipoRepository _equipoRepository;
        private readonly ITicketService _ticketService;
        private readonly IRecepcionistaRepository _recepcionistaRepository;
        public FrmTickets()
        {
            InitializeComponent();

            _clienteService = new ClienteService();
            _tipoEquipoRepository = new TipoEquipoRepository();
            _problemaRepository = new ProblemaRepository();

            _equipoRepository = new EquipoRepository();
            _ticketService = new TicketService();
            _recepcionistaRepository = new RecepcionistaRepository();

            cmbProblema.SelectedIndexChanged += cmbProblema_SelectedIndexChanged;

            CargarClientes();
            CargarTiposEquipo();
            CargarProblemas();
            CargarPrioridades();

            LimpiarFormulario();
        }
        private void CargarClientes()
        {
            List<Cliente> clientes = _clienteService.ObtenerTodos();

            cmbCliente.DataSource = clientes;
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "Id";
            cmbCliente.SelectedIndex = -1;
        }

        private void CargarTiposEquipo()
        {
            List<TipoEquipo> tiposEquipo =
                _tipoEquipoRepository.ObtenerTodos();

            cmbTipoEquipo.DataSource = tiposEquipo;
            cmbTipoEquipo.DisplayMember = "Nombre";
            cmbTipoEquipo.ValueMember = "Id";
            cmbTipoEquipo.SelectedIndex = -1;
        }

        private void CargarProblemas()
        {
            List<Problema> problemasActivos = new List<Problema>();

            foreach (Problema problema in _problemaRepository.ObtenerTodos())
            {
                if (problema.Activo)
                {
                    problemasActivos.Add(problema);
                }
            }

            cmbProblema.DataSource = problemasActivos;
            cmbProblema.DisplayMember = "Nombre";
            cmbProblema.ValueMember = "Id";
            cmbProblema.SelectedIndex = -1;
        }

        private void CargarPrioridades()
        {
            cmbPrioridad.Items.Clear();

            cmbPrioridad.Items.Add("Baja");
            cmbPrioridad.Items.Add("Normal");
            cmbPrioridad.Items.Add("Alta");
            cmbPrioridad.Items.Add("Urgente");

            cmbPrioridad.SelectedItem = "Normal";
        }

        private void cmbProblema_SelectedIndexChanged(
    object sender,
    EventArgs e)
        {
            Problema problemaSeleccionado =
                cmbProblema.SelectedItem as Problema;

            if (problemaSeleccionado == null)
            {
                txtCostoEstimado.Clear();
                return;
            }

            txtCostoEstimado.Text =
                problemaSeleccionado.CostoEstimado.ToString("0.00");
        }

        private void LimpiarFormulario()
        {
            cmbCliente.SelectedIndex = -1;
            cmbTipoEquipo.SelectedIndex = -1;
            cmbProblema.SelectedIndex = -1;
            cmbPrioridad.SelectedItem = "Normal";

            txtMarca.Clear();
            txtModelo.Clear();
            txtColor.Clear();
            txtNumeroSerie.Clear();
            txtAccesorios.Clear();
            txtObservacionesEquipo.Clear();

            txtDescripcionFalla.Clear();
            txtCostoEstimado.Clear();
            txtObservacionesTicket.Clear();

            txtBuscar.Clear();

            cmbCliente.Focus();
        }

        private Recepcionista ObtenerRecepcionistaActual()
        {
            if (!SesionActual.HaySesion)
            {
                throw new InvalidOperationException(
                    "No existe una sesión iniciada."
                );
            }

            int idEmpleadoActual =
                SesionActual.Usuario.IdEmpleado;

            Recepcionista recepcionista =
                _recepcionistaRepository.ObtenerPorId(
                    idEmpleadoActual
                );

            if (recepcionista == null)
            {
                throw new InvalidOperationException(
                    "El usuario actual no está registrado como recepcionista."
                );
            }

            return recepcionista;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Equipo equipoRegistrado = null;

            try
            {
                Cliente clienteSeleccionado =
                    cmbCliente.SelectedItem as Cliente;

                TipoEquipo tipoSeleccionado =
                    cmbTipoEquipo.SelectedItem as TipoEquipo;

                Problema problemaSeleccionado =
                    cmbProblema.SelectedItem as Problema;

                if (clienteSeleccionado == null)
                {
                    MessageBox.Show(
                        "Seleccione un cliente.",
                        "Datos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    cmbCliente.Focus();
                    return;
                }

                if (tipoSeleccionado == null)
                {
                    MessageBox.Show(
                        "Seleccione un tipo de equipo.",
                        "Datos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    cmbTipoEquipo.Focus();
                    return;
                }

                if (problemaSeleccionado == null)
                {
                    MessageBox.Show(
                        "Seleccione un problema.",
                        "Datos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    cmbProblema.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMarca.Text))
                {
                    MessageBox.Show(
                        "Ingrese la marca del equipo.",
                        "Datos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtMarca.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtModelo.Text))
                {
                    MessageBox.Show(
                        "Ingrese el modelo del equipo.",
                        "Datos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtModelo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtDescripcionFalla.Text))
                {
                    MessageBox.Show(
                        "Describa la falla reportada.",
                        "Datos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtDescripcionFalla.Focus();
                    return;
                }

                Recepcionista recepcionista =
                    ObtenerRecepcionistaActual();

                equipoRegistrado = new Equipo();

                equipoRegistrado.Cliente =
                    clienteSeleccionado;

                equipoRegistrado.TipoEquipo =
                    tipoSeleccionado;

                equipoRegistrado.Marca =
                    txtMarca.Text.Trim();

                equipoRegistrado.Modelo =
                    txtModelo.Text.Trim();

                equipoRegistrado.Color =
                    txtColor.Text.Trim();

                equipoRegistrado.NumeroSerie =
                    txtNumeroSerie.Text.Trim();

                equipoRegistrado.Accesorios =
                    txtAccesorios.Text.Trim();

                equipoRegistrado.Observaciones =
                    txtObservacionesEquipo.Text.Trim();

                bool equipoGuardado =
                    _equipoRepository.Insertar(
                        equipoRegistrado
                    );

                if (!equipoGuardado ||
                    equipoRegistrado.Id <= 0)
                {
                    throw new InvalidOperationException(
                        "No se pudo registrar el equipo."
                    );
                }

                Ticket ticket = new Ticket();

                ticket.Equipo = equipoRegistrado;
                ticket.Problema = problemaSeleccionado;
                ticket.Recepcionista = recepcionista;

                ticket.DescripcionFalla =
                    txtDescripcionFalla.Text.Trim();

                ticket.Prioridad =
                    cmbPrioridad.SelectedItem.ToString();

                ticket.CostoEstimado =
                    problemaSeleccionado.CostoEstimado;

                ticket.Observaciones =
                    txtObservacionesTicket.Text.Trim();

                ticket.Diagnostico = string.Empty;
                ticket.SolucionAplicada = string.Empty;

                bool ticketGuardado =
                    _ticketService.Registrar(ticket);

                if (!ticketGuardado)
                {
                    _equipoRepository.Eliminar(
                        equipoRegistrado.Id
                    );

                    throw new InvalidOperationException(
                        "No se pudo registrar el ticket."
                    );
                }

                MessageBox.Show(
                    "Ticket registrado correctamente.\n\n" +
                    "Equipo registrado con ID: " +
                    equipoRegistrado.Id,
                    "Registro correcto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                if (equipoRegistrado != null &&
                    equipoRegistrado.Id > 0)
                {
                 

                    try
                    {
                        _equipoRepository.Eliminar(
                            equipoRegistrado.Id
                        );
                    }
                    catch
                    {
                        // Evita ocultar el error original.
                    }
                }

                MessageBox.Show(
                    "No se pudo registrar el ticket.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
