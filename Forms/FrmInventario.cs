using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto1.Services;
using Proyecto1.Services.Interfaces;
using Proyecto1.Models;



namespace Proyecto1.Forms
{
    public partial class FrmInventario : Form
    {
        private readonly IMaterialService _materialService;

        public FrmInventario()
        {
            InitializeComponent();

            _materialService = new MaterialService();
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            CargarMateriales();
        }

        private void CargarMateriales()
        {
            dgvMateriales.DataSource = null;
            dgvMateriales.DataSource = _materialService.ObtenerTodos();

            dgvMateriales.ClearSelection();
            dgvMateriales.Columns["IdMaterial"].Visible = false;
            dgvMateriales.Columns["Codigo"].HeaderText = "Código";
            dgvMateriales.Columns["Nombre"].HeaderText = "Nombre";
            dgvMateriales.Columns["Descripcion"].HeaderText = "Descripción";
            dgvMateriales.Columns["Stock"].HeaderText = "Stock";
            dgvMateriales.Columns["StockMinimo"].HeaderText = "Stock mínimo";
            dgvMateriales.Columns["CostoUnitario"].HeaderText = "Costo unitario";
            dgvMateriales.Columns["Activo"].HeaderText = "Activo";
            dgvMateriales.Columns["CostoUnitario"].DefaultCellStyle.Format = "C2";
            dgvMateriales.Columns["Stock"].DefaultCellStyle.Alignment =
    DataGridViewContentAlignment.MiddleCenter;

            dgvMateriales.Columns["StockMinimo"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvMateriales.Columns["Activo"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewRow fila in dgvMateriales.Rows)
            {
                decimal stock = Convert.ToDecimal(fila.Cells["Stock"].Value);
                decimal minimo = Convert.ToDecimal(fila.Cells["StockMinimo"].Value);

                if (stock <= minimo)
                {
                    fila.DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtStock.Clear();
            txtStockMinimo.Clear();
            txtCostoUnitario.Clear();
            chkActivo.Checked = true;

            dgvMateriales.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Material material = new Material()
                {
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Stock = Convert.ToDecimal(txtStock.Text),
                    StockMinimo = Convert.ToDecimal(txtStockMinimo.Text),
                    CostoUnitario = Convert.ToDecimal(txtCostoUnitario.Text),
                    Activo = chkActivo.Checked
                };

                _materialService.Registrar(material);

                MessageBox.Show(
                    "Material registrado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarCampos();
                CargarMateriales();
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

        private void dgvMateriales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvMateriales.Rows[e.RowIndex];

            txtCodigo.Text = fila.Cells["Codigo"].Value.ToString();
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
            txtStock.Text = fila.Cells["Stock"].Value.ToString();
            txtStockMinimo.Text = fila.Cells["StockMinimo"].Value.ToString();
            txtCostoUnitario.Text = fila.Cells["CostoUnitario"].Value.ToString();
            chkActivo.Checked = Convert.ToBoolean(fila.Cells["Activo"].Value);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMateriales.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un material.");
                return;
            }

            try
            {
                Material material = new Material()
                {
                    IdMaterial = Convert.ToInt32(
                        dgvMateriales.CurrentRow.Cells["IdMaterial"].Value),

                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Stock = Convert.ToDecimal(txtStock.Text),
                    StockMinimo = Convert.ToDecimal(txtStockMinimo.Text),
                    CostoUnitario = Convert.ToDecimal(txtCostoUnitario.Text),
                    Activo = chkActivo.Checked
                };

                _materialService.Actualizar(material);

                MessageBox.Show(
                    "Material actualizado.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarMateriales();
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
            if (dgvMateriales.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un material.");
                return;
            }

            int id = Convert.ToInt32(
                dgvMateriales.CurrentRow.Cells["IdMaterial"].Value);

            DialogResult respuesta = MessageBox.Show(
                "¿Eliminar este material?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            _materialService.Eliminar(id);

            MessageBox.Show(
                "Material eliminado.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimpiarCampos();
            CargarMateriales();
        }
        private void BuscarMaterial()
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            var lista = _materialService.ObtenerTodos();

            if (!string.IsNullOrWhiteSpace(texto))
            {
                lista = lista.Where(m =>
                    m.Codigo.ToLower().Contains(texto) ||
                    m.Nombre.ToLower().Contains(texto) ||
                    m.Descripcion.ToLower().Contains(texto)
                ).ToList();
            }

            dgvMateriales.DataSource = null;
            dgvMateriales.DataSource = lista;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarMaterial();
        }
    }
}