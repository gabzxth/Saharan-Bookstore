﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivrariaSaharan
{
    public partial class Login : Form
    {
        ConexaoBD conne;
        
        DataTable dt;
        SqlConnection conn = ConexaoBD.obterConexao();

        public Login()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            conne = new ConexaoBD();
            dt = new DataTable();

            String usu = TextBox1.Text;
            String senha = textBox2.Text;

            dt = conne.executarSQL("SELECT CPF,senhaLogin FROM tblFuncionario WHERE CPF = '" + usu + "' AND senhaLogin = '" + senha + "'");
            try
            {
                if (dt.Rows.Count > 0)
                {
                    Principal form = new Principal();
                    form.Show();
                    Login form2 = new Login();
                    form2.Close();
                }
                else
                {
                    errou.Visible = true;//o que vai acontecer se não existir
                    MessageBox.Show(TextBox1.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nós nos desculpamos, parece que temos problemas com o Banco de Dados");
            }

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
