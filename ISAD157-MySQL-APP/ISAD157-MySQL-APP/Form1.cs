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

namespace ISAD157_MySQL_APP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showUserInfo();
            showallMsgs();
        }

        private void showUserInfo()
        {
            string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";
            using (MySqlConnection connection =
                new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM ISAD157_MCaine.users";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter sqlAA = new MySqlDataAdapter(cmd);
                DataTable UserDataTable = new DataTable();
                sqlAA.Fill(UserDataTable);
                userdataGridView1.DataSource = UserDataTable;
                connection.Close();
            }
        }

        private void showallMsgs()
        {
            string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";
            using (MySqlConnection connection =
                new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM ISAD157_MCaine.messages";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter sqlAB = new MySqlDataAdapter(cmd);

                DataTable MSGDataTable = new DataTable();
                sqlAB.Fill(MSGDataTable);
                MsgdataGridView1.DataSource = MSGDataTable;
                connection.Close();
            }
        }
        private bool firsttime = true;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (firsttime)
            {
                usersearch.Clear();
                firsttime = false;
            }
            string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";
            using (MySqlConnection connection =
                new MySqlConnection(connectionString))
            {
                if (usersearch != null && !string.IsNullOrWhiteSpace(usersearch.Text))
                {
                    MessageBox.Show("Now Filtering for User ID: " + usersearch.Text);

                }
                connection.Open();
                MySqlCommand da = new MySqlCommand("SELECT * FROM Users WHERE UserID LIKE '" + usersearch.Text + "'", connection);
                MySqlDataAdapter sqlAC = new MySqlDataAdapter(da);
                DataTable FF = new DataTable();
                sqlAC.Fill(FF);
                userdataGridView1.DataSource = FF;
                connection.Close();

            }


        }

        private void msgsearch_TextChanged(object sender, EventArgs e)
        {
            
            if (firsttime)
            {
                msgsearch.Clear();
                firsttime = false;
            }
            string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                   "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                   DBConnect.USER_NAME + ";" + "PASSWORD=" +
                   DBConnect.PASSWORD + ";" + "SslMode=" +
                   DBConnect.SslMode + ";";
            using (MySqlConnection connection =
                new MySqlConnection(connectionString))
            {
                if (msgsearch != null && !string.IsNullOrWhiteSpace(msgsearch.Text))
                {
                    MessageBox.Show("Now Filtering for Sender User ID: " + msgsearch.Text);

                }
                connection.Open();
                MySqlCommand da = new MySqlCommand("SELECT * FROM messages WHERE sender LIKE '" + msgsearch.Text + "'", connection);
                MySqlDataAdapter sqlAD = new MySqlDataAdapter(da);
                DataTable FF = new DataTable();
                sqlAD.Fill(FF);
                MsgdataGridView1.DataSource = FF;
                connection.Close();

            }
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add User");
        }



        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit User");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete User");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete Msg");
        }
       
    }
}
