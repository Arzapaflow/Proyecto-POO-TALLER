using Proyecto1.Models;
using Proyecto1.Models.Enums;
using Proyecto1.Repositorios;
using Proyecto1.Repositorios.Interfaces;
using Proyecto1.Services;
using Proyecto1.Services.Interfaces;
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
    public partial class FrmTickets : Form
    {
        private readonly IClienteService _clienteService;
        private readonly ITipoEquipoRepository _tipoEquipoRepository;
        private readonly IProblemaRepository _problemaRepository;
        private readonly IEquipoRepository _equipoRepository;
        private readonly ITicketService _ticketService;
        private readonly IRecepcionistaRepository _recepcionistaRepository;
        private int _idTicketSeleccionado = 0;
        private readonly ITecnicoService _tecnicoService;
        private readonly ITecnicoService _tecnicoService =
    new TecnicoService();

        public FrmTickets()
        {
            InitializeComponent();
            dgvTickets.AutoGenerateColumns = false;
            dgvTickets.Columns.Clear();

            dgvTickets.Columns.Add("Id", "Folio");
            dgvTickets.Columns.Add("Cliente", "Cliente");
            dgvTickets.Columns.Add("Equipo", "Equipo");
            dgvTickets.Columns.Add("Problema", "Problema");
            dgvTickets.Columns.Add("Prioridad", "Prioridad");
            dgvTickets.Columns.Add("Estado", "Estado");
            dgvTickets.Columns.Add("Fecha", "Fecha");

            _clienteService = new ClienteService();
            _tipoEquipoRepository = new TipoEquipoRepository();
            _problemaRepository = new ProblemaRepository();

            _equipoRepository = new EquipoRepository();
            _ticketService = new TicketService();
            _recepcionistaRepository = new RecepcionistaRepository();
            _tecnicoService = new TecnicoService();

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
        //efs
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

            // Si es administrador, permitir registrar tickets
            if (SesionActual.Usuario.IdRol == 1)
            {
                Recepcionista recepcionistaAdmin =
                    _recepcionistaRepository.ObtenerPorId(idEmpleadoActual);

                if (recepcionistaAdmin == null)
                {
                    recepcionistaAdmin = new Recepcionista();
                    recepcionistaAdmin.Id = idEmpleadoActual;
                }

                return recepcionistaAdmin;
            }

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

                CargarTickets();

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
        

        private void FrmTickets_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarTiposEquipo();
            CargarProblemas();

            CargarTickets();
        }
        private void CargarTickets()
        {
            dgvTickets.Rows.Clear();

            foreach (Ticket ticket in _ticketService.ObtenerTodos())
            {
                dgvTickets.Rows.Add(
                    ticket.Id,
                    ticket.Equipo.Cliente.Nombre,
                    ticket.Equipo.TipoEquipo.Nombre + " - " +
                    ticket.Equipo.Marca + " " +
                    ticket.Equipo.Modelo,
                    ticket.Problema.Nombre,
                    ticket.Prioridad,
                    ticket.Estado.ToString(),
                    ticket.FechaIngreso.ToShortDateString()
                );
            }
        }
        private void dgvTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _idTicketSeleccionado =
                Convert.ToInt32(dgvTickets.Rows[e.RowIndex].Cells[0].Value);

            Ticket ticket =
                _ticketService.ObtenerPorId(_idTicketSeleccionado);

            if (ticket == null)
                return;

            cmbCliente.SelectedValue =
                ticket.Equipo.Cliente.Id;

            cmbTipoEquipo.SelectedValue =
                ticket.Equipo.TipoEquipo.Id;

            cmbProblema.SelectedValue =
                ticket.Problema.Id;

            txtMarca.Text =
                ticket.Equipo.Marca;

            txtModelo.Text =
                ticket.Equipo.Modelo;

            txtColor.Text =
                ticket.Equipo.Color;

            txtNumeroSerie.Text =
                ticket.Equipo.NumeroSerie;

            txtAccesorios.Text =
                ticket.Equipo.Accesorios;

            txtObservacionesEquipo.Text =
                ticket.Equipo.Observaciones;

            txtDescripcionFalla.Text =
                ticket.DescripcionFalla;

            cmbPrioridad.SelectedItem =
                ticket.Prioridad;

            txtObservacionesTicket.Text =
                ticket.Observaciones;
        }
        private void btnEditar_Click(object sender, EventArgs e)
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

            try
            {
                Ticket ticket = _ticketService.ObtenerPorId(_idTicketSeleccionado);

                if (ticket == null)
                {
                    MessageBox.Show("El ticket ya no existe.");
                    return;
                }

                ticket.Problema.Id =
                    Convert.ToInt32(cmbProblema.SelectedValue);

                ticket.DescripcionFalla =
                    txtDescripcionFalla.Text.Trim();

                ticket.Prioridad =
                    cmbPrioridad.Text;

                ticket.Observaciones =
                    txtObservacionesTicket.Text.Trim();

                ticket.CostoEstimado =
                    decimal.Parse(txtCostoEstimado.Text);
                ticket.Equipo.Cliente = (Cliente)cmbCliente.SelectedItem;
                ticket.Equipo.TipoEquipo = (TipoEquipo)cmbTipoEquipo.SelectedItem;
                ticket.Equipo.Marca = txtMarca.Text.Trim();
                ticket.Equipo.Modelo = txtModelo.Text.Trim();
                ticket.Equipo.Color = txtColor.Text.Trim();
                ticket.Equipo.NumeroSerie = txtNumeroSerie.Text.Trim();
                ticket.Equipo.Accesorios = txtAccesorios.Text.Trim();
                ticket.Equipo.Observaciones = txtObservacionesEquipo.Text.Trim();

                bool actualizado =
                    _ticketService.Actualizar(ticket);

                if (actualizado)
                {
                    MessageBox.Show(
                        "Ticket actualizado correctamente.");

                    CargarTickets();

                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo actualizar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idTicketSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione un ticket.");
                return;
            }

            DialogResult respuesta =
                MessageBox.Show(
                    "¿Desea eliminar el ticket seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                bool eliminado =
                    _ticketService.Eliminar(_idTicketSeleccionado);

                if (eliminado)
                {
                    MessageBox.Show(
                        "Ticket eliminado correctamente.");

                    CargarTickets();

                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CargarTecnicos(Especialidad especialidad)
        {
            cmbTecnico.DataSource = null;

            List<Tecnico> lista =
                _tecnicoService.ObtenerPorEspecialidad(especialidad);

            cmbTecnico.DisplayMember = "Nombre";
            cmbTecnico.ValueMember = "Id";
            cmbTecnico.DataSource = lista;
        }

        private void cmbTipoEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoEquipo.SelectedItem == null)
                return;

            TipoEquipo tipo =
                (TipoEquipo)cmbTipoEquipo.SelectedItem;

            cmbTecnico.DataSource =
                _tecnicoService.ObtenerPorTipoEquipo(tipo);

            cmbTecnico.DisplayMember = "Nombre";
            cmbTecnico.ValueMember = "Id";
        }
    }

}
