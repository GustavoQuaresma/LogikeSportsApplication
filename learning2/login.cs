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
    public partial class Login : Form
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string strSQL;

        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = logikeSports; Uid = root; Pwd = bandtec;");
                strSQL = "SELECT count(*) FROM usuario WHERE login = '" + txtLogin.Text + "'and senha = '" + txtSenha.Text + "';";
                comando = new MySqlCommand(strSQL, conexao);
                conexao.Open();
                DataTable dataTable = new DataTable();
                da = new MySqlDataAdapter(comando);
                da.Fill(dataTable);
                foreach (DataRow list in dataTable.Rows)
                {
                    if (Convert.ToInt32(list.ItemArray[0]) > 0)
                    {
                        Home home = new Home(txtLogin.Text, txtSenha.Text);
                        home.Show();
                        this.SetVisibleCore(false);
                    }
                    else
                    {
                        MessageBox.Show("Usuário Invalido");
                    }
                }
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

        private void btnCad_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.Show();
        }
    }
}
