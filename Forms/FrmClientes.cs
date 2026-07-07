using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto1.Models;
using Proyecto1.Services;
using Proyecto1.Services.Interfaces;
namespace Proyecto1.Forms
{
    public partial class FrmClientes : Form
    {
        private readonly IClienteService _clienteService;

        private int idClienteSeleccionado = 0;
        public FrmClientes()
        {
            InitializeComponent();

            _clienteService = new ClienteService();

            ConfigurarColumnas();

            CargarClientes();
        }
        private void ConfigurarColumnas()
        {
            dgvClientes.Columns.Clear();

            dgvClientes.Columns.Add("Id", "ID");
            dgvClientes.Columns.Add("Nombre", "Nombre");
            dgvClientes.Columns.Add("Telefono", "Teléfono");
            dgvClientes.Columns.Add("Correo", "Correo");

            dgvClientes.Columns["Id"].Visible = false;

            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.ReadOnly = true;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void CargarClientes()
        {
            dgvClientes.Rows.Clear();

            foreach (Cliente cliente in _clienteService.ObtenerTodos())
            {
                dgvClientes.Rows.Add(
                    cliente.Id,
                    cliente.Nombre,
                    cliente.Telefono,
                    cliente.Correo
                );
            }
        }
        private void LimpiarCampos()
        {
            idClienteSeleccionado = 0;

            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();

            txtNombre.Focus();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();

                cliente.Nombre = txtNombre.Text.Trim();
                cliente.Telefono = txtTelefono.Text.Trim();
                cliente.Correo = txtCorreo.Text.Trim();

                bool resultado;

                if (idClienteSeleccionado == 0)
                {
                    resultado = _clienteService.Registrar(cliente);

                    if (resultado)
                        MessageBox.Show("Cliente registrado correctamente.");
                }
                else
                {
                    cliente.Id = idClienteSeleccionado;

                    resultado = _clienteService.Actualizar(cliente);

                    if (resultado)
                        MessageBox.Show("Cliente actualizado correctamente.");
                }

                LimpiarCampos();
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un cliente.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este cliente?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                _clienteService.Eliminar(idClienteSeleccionado);

                LimpiarCampos();
                CargarClientes();

                MessageBox.Show("Cliente eliminado.");
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            dgvClientes.Rows.Clear();

            foreach (Cliente cliente in _clienteService.ObtenerTodos())
            {
                if (cliente.Nombre.ToLower().Contains(texto) ||
                    cliente.Telefono.ToLower().Contains(texto) ||
                    cliente.Correo.ToLower().Contains(texto))
                {
                    dgvClientes.Rows.Add(
                        cliente.Id,
                        cliente.Nombre,
                        cliente.Telefono,
                        cliente.Correo
                    );
                }
            }
        }


        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

            idClienteSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);

            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
            txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
        }
    }
    
}

