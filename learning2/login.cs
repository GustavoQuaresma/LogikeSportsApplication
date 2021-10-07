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
    public partial class login : Form
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string strSQL;

        public login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = logikgames; Uid = root; Pwd = bandtec;");
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
                        MessageBox.Show("Usuario Valido");
                        home home = new home(txtLogin.Text, txtSenha.Text);
                        home.Show();
                        this.SetVisibleCore(false);
                    }
                    else
                    {
                        MessageBox.Show("Usuario Invalido");
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
    }
}
