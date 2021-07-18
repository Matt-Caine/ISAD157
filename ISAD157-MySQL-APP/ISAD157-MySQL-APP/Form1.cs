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

        //On Form load

        private void Form1_Load(object sender, EventArgs e)
        {   
            ShowUserInfo(); //Onload Show All Users
            ShowallMsgs(); //Onload Show All Msgs
            Showallunis(); //Onload Show All unis
            Showalljobs(); //Onload Show All jobs
        }
        
        //deafult show all

        private void ShowUserInfo()   //Function all Users
        {
            string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";
            using (MySqlConnection connection =
                new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM users";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter sqlAA = new MySqlDataAdapter(cmd);
                DataTable UserDataTable = new DataTable();
                sqlAA.Fill(UserDataTable);
                userdataGridView1.DataSource = UserDataTable;
                connection.Close();
            }
        }
        private void ShowallMsgs()      //Function all Msgs
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

        private void Showallunis()      //Function all schools
        {
            string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";
            using (MySqlConnection connection =
                new MySqlConnection(connectionString))
            {
                string query = "SELECT UserID, University, Start_date, End_date  FROM ISAD157_MCaine.universities";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter sqlAB = new MySqlDataAdapter(cmd);

                DataTable UniDataTable = new DataTable();
                sqlAB.Fill(UniDataTable);
                unidataGridView2.DataSource = UniDataTable;
                connection.Close();
            }
        }

        private void Showalljobs()      //Function all jobs
        {
            string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";
            using (MySqlConnection connection =
                new MySqlConnection(connectionString))
            {
                string query = "SELECT UserID, Workplace, Start_Date, End_Date FROM ISAD157_MCaine.workplaces";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter sqlAB = new MySqlDataAdapter(cmd);

                DataTable JobDataTable = new DataTable();
                sqlAB.Fill(JobDataTable);
                jobdataGridView1.DataSource = JobDataTable;
                connection.Close();
            }
        }

        //Search

        private bool firsttime = true; //Simple type for new text Check
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (firsttime) //Simple Check
            {
                usersearch.Clear();
                firsttime = false;
            }

            //show user
            string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";
            using (MySqlConnection connection =
                new MySqlConnection(connectionString))
            {

                connection.Open();
                MySqlCommand da = new MySqlCommand("SELECT * FROM Users WHERE UserID LIKE '" + usersearch.Text + "'", connection);
                MySqlDataAdapter sqlAC = new MySqlDataAdapter(da);
                DataTable FF = new DataTable();
                sqlAC.Fill(FF);
                userdataGridView1.DataSource = FF;
                connection.Close();
            }
            //show users sent
            string connectionString2 = "SERVER=" + DBConnect.SERVER + ";" +
                 "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                 DBConnect.USER_NAME + ";" + "PASSWORD=" +
                 DBConnect.PASSWORD + ";" + "SslMode=" +
                 DBConnect.SslMode + ";";
            using (MySqlConnection connection =
                new MySqlConnection(connectionString2))
            {

                connection.Open();
                MySqlCommand da = new MySqlCommand("SELECT * FROM messages WHERE sender LIKE '" + usersearch.Text + "'", connection);
                MySqlDataAdapter sqlAC = new MySqlDataAdapter(da);
                DataTable FF = new DataTable();
                sqlAC.Fill(FF);
                MsgdataGridView1.DataSource = FF;
                connection.Close();
            }
            //show users jobs
            string connectionString3 = "SERVER=" + DBConnect.SERVER + ";" +
                 "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                 DBConnect.USER_NAME + ";" + "PASSWORD=" +
                 DBConnect.PASSWORD + ";" + "SslMode=" +
                 DBConnect.SslMode + ";";
            using (MySqlConnection connection =
                new MySqlConnection(connectionString3))
            {

                connection.Open();
                MySqlCommand da = new MySqlCommand("SELECT Workplace, Start_Date, End_Date FROM workplaces WHERE UserID LIKE '" + usersearch.Text + "'", connection);
                MySqlDataAdapter sqlAC = new MySqlDataAdapter(da);
                DataTable FF = new DataTable();
                sqlAC.Fill(FF);
                jobdataGridView1.DataSource = FF;
                connection.Close();
            }

            //show users unis
            string connectionString4 = "SERVER=" + DBConnect.SERVER + ";" +
                 "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                 DBConnect.USER_NAME + ";" + "PASSWORD=" +
                 DBConnect.PASSWORD + ";" + "SslMode=" +
                 DBConnect.SslMode + ";";
            using (MySqlConnection connection =
                new MySqlConnection(connectionString4))
            {

                connection.Open();
                MySqlCommand da = new MySqlCommand("SELECT University, Start_Date, End_Date FROM universities WHERE UserID LIKE '" + usersearch.Text + "'", connection);
                MySqlDataAdapter sqlAC = new MySqlDataAdapter(da);
                DataTable FF = new DataTable();
                sqlAC.Fill(FF);
                unidataGridView2.DataSource = FF;
                connection.Close();
            }

        } //search for user by id and show Msgs user sent and work and uni
        
        private void Msgsearch_TextChanged(object sender, EventArgs e)
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
               
                connection.Open();
                MySqlCommand da = new MySqlCommand("SELECT * FROM messages WHERE sender LIKE '" + msgsearch.Text + "'", connection);
                MySqlDataAdapter sqlAD = new MySqlDataAdapter(da);
                DataTable FF = new DataTable();
                sqlAD.Fill(FF);
                MsgdataGridView1.DataSource = FF;
                connection.Close();

            }

            string connectionString2 = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";
            using (MySqlConnection connection =
                new MySqlConnection(connectionString2))
            {

                connection.Open();
                MySqlCommand db = new MySqlCommand("SELECT * FROM Users WHERE UserID LIKE '" + msgsearch.Text + "'", connection);
                MySqlDataAdapter sqlAC = new MySqlDataAdapter(db);
                DataTable FA = new DataTable();
                sqlAC.Fill(FA);
                userdataGridView1.DataSource = FA;
                connection.Close();
            }
        }//search for Msg by sender id and show user that sent Msg


        //Buttons
        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add User");
        } //Add User
        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit User");
        } //Edit User
        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete User");
        } //Delete User
        private void Button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete Msg");
        } //Delete Msg
        private void Button5_Click(object sender, EventArgs e)
        {
            ShowUserInfo();
            ShowallMsgs();
        } //Reload - laggy....


    }
    
}
