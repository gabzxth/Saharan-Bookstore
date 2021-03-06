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
    public partial class Consulta : Form
    {
        SQLconexao con;
        DataTable dt;
        ConexaoBD conne;
        SqlConnection conn = ConexaoBD.obterConexao();

        public Consulta()
        {
            InitializeComponent();
        }



        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtPesq_Click(object sender, EventArgs e)
        {
            con = new SQLconexao();
            conne = new ConexaoBD();
            dt = new DataTable();

            String nome = txtNome.Text;
            

            dt = conne.executarSQL("SELECT A.IdEstoque,A.ISBN,b.CodigoBarras,A.Titulo,A.Autor,C.Genero,B.DataLote,B.qtdeEstoque,B.Preco FROM tblLivros AS A INNER JOIN tblEstoque AS B ON B.idEstoque = A.idEstoque INNER JOIN tblGenero AS C ON C.idGenero = A.Genero WHERE A.Titulo LIKE '%" + nome + "%' OR A.ISBN = '" + nome + "'");

            try 
            {
                if (dt.Rows.Count > 0)
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dt;
                    dataGridView1.DataSource = bs;
                }
                else
                {
                    dt = conne.executarSQL("SELECT A.ISAN,b.CodigoBarras,A.Titulo,A.Estudio,C.Genero,B.DataLote,B.qtdeEstoque,B.Preco FROM tblJogos AS A INNER JOIN tblEstoque AS B ON B.idEstoque = A.idEstoque INNER JOIN tblGenero AS C ON C.idGenero = A.Genero WHERE A.Titulo LIKE '%" + nome + "%' OR A.ISAN = '" + nome + "'");
                    if (dt.Rows.Count > 0)
                    {
                        BindingSource bs = new BindingSource();
                        bs.DataSource = dt;
                        dataGridView1.DataSource = bs;
                    }
                    else
                    {
                        dt = conne.executarSQL("SELECT A.ISMN,b.CodigoBarras,A.Titulo,D.Nome,E.Genero,B.DataLote,B.qtdeEstoque,B.Preco FROM tblMusicas AS A INNER JOIN tblEstoque AS B ON B.idEstoque = A.idEstoque INNER JOIN tblAlbum AS C ON C.idAlbum = A.Album INNER JOIN tblAutor AS D ON D.idAutor = C.Autor INNER JOIN tblGeneroMusic AS E ON E.idGeneroMusic = C.Genero WHERE A.Titulo LIKE '%" + nome + "%' OR A.ISMN = '" + nome + "'");
                        if (dt.Rows.Count > 0)
                        {
                            BindingSource bs = new BindingSource();
                            bs.DataSource = dt;
                            dataGridView1.DataSource = bs;
                        }
                        else
                        {
                            dt = conne.executarSQL("SELECT A.ISAN,b.CodigoBarras,A.Titulo,A.Estudio,C.Genero,B.DataLote,B.qtdeEstoque,B.Preco FROM tblFilmes AS A INNER JOIN tblEstoque AS B ON B.idEstoque = A.idEstoque INNER JOIN tblGenero AS C ON C.idGenero = A.Genero WHERE A.Titulo LIKE '%" + nome + "%' OR A.ISAN = '" + nome + "'");
                            if (dt.Rows.Count > 0)
                            {
                                BindingSource bs = new BindingSource();
                                bs.DataSource = dt;
                                dataGridView1.DataSource = bs;
                            }
                            else
                            {
                                MessageBox.Show("Não temos este produto");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não temos este produto");
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void sairtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Principal form = new Principal();
            form.Show();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string value1 = row.Cells[0].Value.ToString();
                SqlCommand delet = new SqlCommand("DELETE FROM tblLivros WHERE IdEstoque = '" + value1 + "'", conn);
                int i = delet.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Registro Deletado com sucesso!");
                
                
            }
        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {

        }

         private void button2_Click(object sender, EventArgs e)
        {
            CadastroLivro nuevo = new CadastroLivro();
            nuevo.Show();
            nuevo.hideUpdate();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string value1 = row.Cells[0].Value.ToString();
                SqlCommand delet = new SqlCommand("DELETE FROM tblLivros WHERE IdEstoque = '" + value1 + "'", conn);
                int i = delet.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Registro Deletado com sucesso!");


            }
        }
    }
}
