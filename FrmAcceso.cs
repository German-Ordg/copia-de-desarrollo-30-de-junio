using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pantallas_proyecto
{
    public partial class FrmAcceso : Form
    {
        public FrmAcceso()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "Usuario")
            {
                if (txtContrasena.Text != "Contraseña")
                {
                    ClsLogin usuario = new ClsLogin();
                    var validar = usuario.Login(txtUsuario.Text, txtContrasena.Text);
                    if (validar == true)
                    {                     
                        FrmMenuPrincipalGerente menu = new FrmMenuPrincipalGerente();                      
                        menu.Show();
                        menu.FormClosed += cerrarSesion;
                        this.Hide();
                    }
                    else
                    {
                        msjError("Usuario o contraseña incorrecta \n\t Intente de nuevo");
                        txtUsuario.Clear();
                        txtContrasena.Clear();
                    }
                }
                else
                    msjError("Ingrese la contraseña");
            }
            else
                msjError("Ingrese el usuario");
        }
        private void msjError(string msj)
        {
            lblError.Text = msj;
            lblError.Visible = true;
            picError.Visible = true;
        }
        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void picError_Click(object sender, EventArgs e)
        {

        }

        private void chkMostrarContra_CheckedChanged(object sender, EventArgs e)
        {
            string text = txtContrasena.Text;
            if (chkMostrarContra.Checked)
            {
                txtContrasena.UseSystemPasswordChar = false;
                txtContrasena.Text = text;
            }
            else
            {
                txtContrasena.UseSystemPasswordChar = true;
                txtContrasena.Text = text;
            }
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "Contraseña")
            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.Black;
                txtContrasena.UseSystemPasswordChar = true;
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "Constraseña";
                txtContrasena.ForeColor = Color.Black;
                txtContrasena.UseSystemPasswordChar = false;
            }
        }
        private void cerrarSesion(object sender, FormClosedEventArgs e)
        {
            txtUsuario.Clear();
            txtContrasena.Clear();
            lblError.Visible = false;
            this.Show();
            txtUsuario.Focus();
            picError.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            FrmRecuperaContra recuperacion = new FrmRecuperaContra();
            recuperacion.Show();
            recuperacion.FormClosed += cerrarSesion;
            this.Hide();
        }
    }
}
