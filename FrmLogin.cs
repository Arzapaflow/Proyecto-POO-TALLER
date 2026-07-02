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
using Proyecto1.Repositorios;


namespace Proyecto1
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            btnIngresar.Click += btnIngresar_Click;
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
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(password))
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
                using (System.Data.SQLite.SQLiteConnection conexion =
                       Database.ConexionBD.CrearConexion())
                {
                    string consulta = @"
                SELECT COUNT(*)
                FROM Usuarios
                WHERE NombreUsuario = @NombreUsuario
                  AND Contrasena = @Contrasena
                  AND Activo = 1;";

                    using (System.Data.SQLite.SQLiteCommand comando =
                           new System.Data.SQLite.SQLiteCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@NombreUsuario", usuario);
                        comando.Parameters.AddWithValue("@Contrasena", password);

                        conexion.Open();

                        int resultado = Convert.ToInt32(comando.ExecuteScalar());

                        if (resultado > 0)
                        {
                            MessageBox.Show(
                                "Inicio de sesión correcto.",
                                "Bienvenido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
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
