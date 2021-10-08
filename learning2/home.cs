using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace learning2
{
    public partial class Home : Form

    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string strSQL;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect,     // x-coordinate of upper-left corner
        int nTopRect,      // y-coordinate of upper-left corner
        int nRightRect,    // x-coordinate of lower-right corner
        int nBottomRect,   // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
         );
        public Home(String txtLogin, String txtSenha)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = logikeSports; Uid = root; Pwd = bandtec;");
                strSQL = "SELECT nome FROM usuario WHERE login = '" + txtLogin + "'and senha = '" + txtSenha + "';";
                comando = new MySqlCommand(strSQL, conexao);
                conexao.Open();

                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    lblName.Text = Convert.ToString(dr["nome"]);
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
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = logikeSports; Uid = root; Pwd = bandtec;");
                strSQL = "SELECT estilo FROM usuario WHERE login = '" + txtLogin + "'and senha = '" + txtSenha + "';";
                comando = new MySqlCommand(strSQL, conexao);
                conexao.Open();
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    switch (dr["estilo"])
                    {
                        case 1:
                            lblSub.Text = "Jogador de League of Legends";
                            break;
                        case 2:
                            lblSub.Text = "Jogador de CS:GO";
                            break;
                        case 3:
                            lblSub.Text = "Jogador de Valorant";
                            break;
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
