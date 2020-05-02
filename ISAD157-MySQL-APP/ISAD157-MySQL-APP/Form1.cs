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

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
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


                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable UserDataTable = new DataTable();
                    sqlDA.Fill(UserDataTable);

                    dataGridView1.DataSource = UserDataTable;

                }
            }
            
            else if (comboBox1.SelectedIndex == 1)
            {


                string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";



                using (MySqlConnection connection =
                    new MySqlConnection(connectionString))
                {

                    string query = "SELECT * FROM ISAD157_Mcaine.friendships";


                    connection.Open();


                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable FriendshipDataTable = new DataTable();
                    sqlDA.Fill(FriendshipDataTable);


                    dataGridView1.DataSource = FriendshipDataTable;
                }
            }
            
            else if (comboBox1.SelectedIndex == 2)
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

                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable MsgDataTable = new DataTable();
                    sqlDA.Fill(MsgDataTable);


                    dataGridView1.DataSource = MsgDataTable;
                }
            }
            
            else if (comboBox1.SelectedIndex == 3)
            {


                string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";



                using (MySqlConnection connection =
                    new MySqlConnection(connectionString))
                {

                    string query = "SELECT * FROM ISAD157_MCaine.universities";


                    connection.Open();


                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable UniversitiesDataTable = new DataTable();
                    sqlDA.Fill(UniversitiesDataTable);


                    dataGridView1.DataSource = UniversitiesDataTable;
                }
            }
            
            else if (comboBox1.SelectedIndex == 4)
            {


                string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";



                using (MySqlConnection connection =
                    new MySqlConnection(connectionString))
                {

                    string query = "SELECT * FROM ISAD157_MCaine.workplaces";


                    connection.Open();


                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable WorkplaceDataTable = new DataTable();
                    sqlDA.Fill(WorkplaceDataTable);


                    dataGridView1.DataSource = WorkplaceDataTable;
                }
            } 

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
