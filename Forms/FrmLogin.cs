using Proyecto1.Forms;
using Proyecto1.Models;
using Proyecto1.Services;
using Proyecto1.Services.Interfaces;
using System;
using System.Windows.Forms;
using Proyecto1.Models.Enums;

namespace Proyecto1
{
    public partial class FrmLogin : Form
    {
        private readonly IUsuarioService _usuarioService;

        public FrmLogin()
        {
            InitializeComponent();

            _usuarioService = new UsuarioService();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text.Trim();
            string contrasena = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(nombreUsuario) ||
                string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show(
                    "Ingresa el usuario y la contraseña.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                Usuario usuario = _usuarioService.Autenticar(
                    nombreUsuario,
                    contrasena
                );

                if (usuario != null)
                {
                    SesionActual.IniciarSesion(usuario);

                    MessageBox.Show(
                        "Inicio de sesión correcto.",
                        "Bienvenido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    txtPassword.Clear();

                    this.Hide();

                    Form menu = null;

                    switch (usuario.IdRol)
                    {
                        case 1: 
                            menu = new FrmMenuAdministrador();
                            break;

                        case 2: 
                            menu = new FrmMenuRecepcionista();
                            break;

                        case 3: 
                            menu = new FrmMenuTecnico();
                            break;

                        default:
                            MessageBox.Show(
                                "El rol del usuario no es válido.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );

                            this.Show();
                            return;
                    }

                    menu.FormClosed += (s, args) =>
                    {
                        this.Close();
                    };

                    menu.Show();
                }
                else
                {
                    MessageBox.Show(
                        "Usuario o contraseña incorrectos.",
                        "Acceso denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo iniciar sesión.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
