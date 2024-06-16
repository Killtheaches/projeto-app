using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, insira o e-mail e a senha.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DatabaseHelper db = new DatabaseHelper();
            if (db.Login(email, senha))
            {
                MessageBox.Show("Login bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Aqui você pode abrir uma nova tela ou realizar outras ações após o login bem-sucedido
            }
            else
            {
                MessageBox.Show("E-mail ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblCadastro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {// Aqui você pode abrir a tela de cadastro
            FormCadastro formCadastro = new FormCadastro();
            formCadastro.Show();
        }
    }
}
