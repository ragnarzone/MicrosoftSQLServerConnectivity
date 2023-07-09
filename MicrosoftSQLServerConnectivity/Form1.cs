using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MicrosoftSQLServerConnectivity
{
    public partial class LoginForm : Form
    {
        
        DataBase dataBase = new DataBase();

        public LoginForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginUser = tb_login.Text;
            var passwordUser = tb_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querryString = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passwordUser}'";

            SqlCommand sqlCommand = new SqlCommand(querryString, dataBase.GetConnection());

            adapter.SelectCommand = sqlCommand;
            adapter.Fill(table);

            if(table.Rows.Count == 1)
            {
                MessageBox.Show("You are authorized", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information ); 
            } else
            {
                MessageBox.Show("This account does not exist", "Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
