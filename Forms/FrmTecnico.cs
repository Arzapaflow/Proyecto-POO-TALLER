using Proyecto1.Models;
using Proyecto1.Models.Enums;
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
    public partial class FrmTecnicos : Form
    {
        private readonly ITecnicoService _tecnicoService;

        private int _idEmpleadoSeleccionado = 0;

        public FrmTecnicos()
        {
            InitializeComponent();

            _tecnicoService = new TecnicoService();
            cmbEspecialidad.DataSource = Enum.GetValues(typeof(Especialidad));
        }

        private void FrmTecnicos_Load(object sender, EventArgs e)
        {
            cmbEstado.DataSource =
                Enum.GetValues(typeof(EstadoEmpleado));

            cmbEspecialidad.DataSource =
                Enum.GetValues(typeof(Especialidad));
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            ConfigurarGrid();

            CargarTecnicos();

            LimpiarFormulario();
        }
        private void ConfigurarGrid()
        {
            dgvTecnicos.AutoGenerateColumns = false;

            dgvTecnicos.Columns.Clear();

            dgvTecnicos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvTecnicos.MultiSelect = false;

            dgvTecnicos.ReadOnly = true;

            dgvTecnicos.AllowUserToAddRows = false;

            dgvTecnicos.AllowUserToDeleteRows = false;

            dgvTecnicos.RowHeadersVisible = false;

            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "IdEmpleado",
                HeaderText = "ID",
                DataPropertyName = "Id"
            });

            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Width = 180
            });

            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Telefono",
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono",
                Width = 120
            });

            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Correo",
                HeaderText = "Correo",
                DataPropertyName = "Correo",
                Width = 180
            });

            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 90
            });

            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Especialidad",
                HeaderText = "Especialidad",
                DataPropertyName = "Especialidad",
                Width = 170
            });

            dgvTecnicos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Usuario",
                HeaderText = "Usuario",
                DataPropertyName = "Usuario",
                Width = 120
            });
        }
        private void LimpiarFormulario()
        {
            _idEmpleadoSeleccionado = 0;

            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtUsuario.Clear();
            txtContrasena.Clear();

            if (cmbEspecialidad.Items.Count > 0)
                cmbEspecialidad.SelectedIndex = 0;

            if (cmbEstado.Items.Count > 0)
                cmbEstado.SelectedIndex = 0;

            dgvTecnicos.ClearSelection();

            txtNombre.Focus();
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre.");

                txtNombre.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Ingrese el teléfono.");

                txtTelefono.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Ingrese el correo.");

                txtCorreo.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Ingrese el usuario.");

                txtUsuario.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Ingrese la contraseña.");

                txtContrasena.Focus();

                return false;
            }

            return true;
        }

        private void CargarTecnicos()
        {
            dgvTecnicos.DataSource = null;

            dgvTecnicos.DataSource =
                _tecnicoService.ObtenerTodos();
        }
        
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                if (_idEmpleadoSeleccionado != 0)
                {
                    MessageBox.Show(
                        "Hay un técnico seleccionado.\nUse Editar o Limpiar antes de registrar uno nuevo.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                Tecnico tecnico = new Tecnico();

                tecnico.Nombre = txtNombre.Text.Trim();
                tecnico.Telefono = txtTelefono.Text.Trim();
                tecnico.Correo = txtCorreo.Text.Trim();
                tecnico.Usuario = txtUsuario.Text.Trim();
                tecnico.Contraseña = txtContrasena.Text;
                tecnico.Estado = (EstadoEmpleado)cmbEstado.SelectedItem;
                tecnico.Especialidad = (Especialidad)cmbEspecialidad.SelectedItem;

                Usuario usuario = new Usuario();

                usuario.NombreUsuario = txtUsuario.Text.Trim();
                usuario.Contrasena = txtContrasena.Text;
                usuario.IdRol = 3;
                usuario.Activo = true;

                _tecnicoService.Registrar(tecnico, usuario);

                MessageBox.Show(
                    "Técnico registrado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarTecnicos();

                LimpiarFormulario();
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
        private void dgvTecnicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                int id = Convert.ToInt32(
                    dgvTecnicos.Rows[e.RowIndex].Cells["IdEmpleado"].Value);

                Tecnico tecnico =
                    _tecnicoService.ObtenerPorId(id);

                if (tecnico == null)
                    return;

                _idEmpleadoSeleccionado = tecnico.Id;

                txtNombre.Text = tecnico.Nombre;
                txtTelefono.Text = tecnico.Telefono;
                txtCorreo.Text = tecnico.Correo;
                txtUsuario.Text = tecnico.Usuario;

                txtContrasena.Clear();

                cmbEstado.SelectedItem = tecnico.Estado;
                cmbEspecialidad.SelectedItem = tecnico.Especialidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_idEmpleadoSeleccionado == 0)
            {
                MessageBox.Show(
                    "Seleccione un técnico.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            try
            {
                if (_idEmpleadoSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Seleccione un técnico.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                if (!ValidarCampos())
                    return;

                Tecnico tecnico = new Tecnico();

                tecnico.Id = _idEmpleadoSeleccionado;
                tecnico.Nombre = txtNombre.Text.Trim();
                tecnico.Telefono = txtTelefono.Text.Trim();
                tecnico.Correo = txtCorreo.Text.Trim();
                tecnico.Usuario = txtUsuario.Text.Trim();
                tecnico.Contraseña = txtContrasena.Text;
                tecnico.Estado = (EstadoEmpleado)cmbEstado.SelectedItem;
                tecnico.Especialidad = (Especialidad)cmbEspecialidad.SelectedItem;

                Usuario usuario = new Usuario();

                usuario.NombreUsuario = txtUsuario.Text.Trim();
                usuario.Contrasena = txtContrasena.Text;
                usuario.IdRol = 3;
                usuario.Activo = true;
                DialogResult respuesta = MessageBox.Show(
    "¿Desea guardar los cambios realizados a este técnico?",
    "Confirmar edición",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                _tecnicoService.Actualizar(tecnico, usuario);

                MessageBox.Show(
                    "Técnico actualizado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarTecnicos();

                LimpiarFormulario();
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
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idEmpleadoSeleccionado == 0)
            {
                MessageBox.Show(
                    "Seleccione un técnico.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Desea eliminar este técnico?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r != DialogResult.Yes)
                return;

            try
            {
                _tecnicoService.Eliminar(_idEmpleadoSeleccionado);

                MessageBox.Show(
                    "Técnico eliminado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarTecnicos();

                LimpiarFormulario();
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
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

    }
}
