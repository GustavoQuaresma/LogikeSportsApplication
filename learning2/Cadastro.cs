using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace learning2
{
    public partial class Cadastro : Form
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string strSQL;
        int num;
        public Cadastro()
        {
            InitializeComponent();

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {

                string curItem = listBox1.GetItemText(listBox1.SelectedItem);
                if (curItem == "League of Legends")
                    num = 1;
                else if (curItem == "CS:GO")
                    num = 2;
                else if (curItem == "Valorant")
                    num = 3;
                conexao = new MySqlConnection("Server = localhost; Database = logikeSports; Uid = root; Pwd = bandtec;");
                strSQL = "INSERT INTO usuario VALUES (null, '" + txtNome.Text + "', '" + txtLogin.Text + "', '" + txtSenha.Text + "', '" + txtEmail.Text + "', '" + dateTimePicker1.Text + "', " + num + ");";
                comando = new MySqlCommand(strSQL, conexao);
                conexao.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Usuário Cadastrado");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
