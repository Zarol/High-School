using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;
using System.Net.Sockets;
using System.Threading;

namespace DSEServer
{
    public partial class Home : Form
    {
        MySqlConnection connection;
        Thread server;
        ServerThread s;
        delegate void SetTextCallback(string text);
        public Home()
        {
            InitializeComponent();
            AppendText("Thank you for Launching DSE's Server, Please Wait...");
            AppendText("Attempting to connect...");
            string MyConString = "SERVER=209.200.229.220;" +" Convert Zero Datetime=True; "+"default command timeout=3600;" + "DATABASE=junio15_LunchMoneyMatch;" + "user=junio15_lmm;" + "password=lasvegas;";
            connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            try
            {
             
                connection.Open();
                AppendText("We Have Connected / : = " + GC.GetTotalMemory(true));
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                MessageBox.Show("SHITWENTWRONG");
                switch (ex.Number)
                {
                    case 0:
                        AppendText("Cannot connect to server.  Contact administrator");
                        break;
                    case 1042:
                        AppendText("INVALID CONNECTION");
                        break;
                    case 1045:
                        AppendText("Invalid username/password, please try again");
                        break;
                }
                //  return false;
            }
            s = new ServerThread(this);
            server = new Thread(new ThreadStart(s.listen));
            server.Start();


        }
        //INSERT INTO UserInfo (email, DateCreated, FirstName, LastName) VALUES ('phasecode',08/08/12,'Jay','Jon Simpson');
        public int CreateAccount(string FirstName, string LastName, string DOB, string Email, string password, string Sex, string IPCreated)
        {
            String command = "INSERT INTO UserInfo(FirstName,LastName,Gender,DOB,Email,Password,DateCreated,IPCreated) VALUES ('" + 
                                                    FirstName + "','" + LastName + "','" + Sex + "','" + DOB + "','" + Email + "','" + password + "',CURDATE(),'" + IPCreated + "');";
            AppendText(command);
            return new MySqlCommand(command, connection).ExecuteNonQuery();
            // return 0;
        }
        public void AppendText(string text)
        {
            if (this.txtBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(AppendText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                txtBox.Text = txtBox.Text + DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo) + " " + text + "\r\n";
            }

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string field = txtField.Text;
                txtField.Clear();
                ExecuteCommand(field);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commands"></param>
        private void ExecuteCommand(string commands)
        {
            if (commands.Contains("/mysql"))
            {
                string query = commands.Remove(commands.IndexOf("/mysql"), 7);
                if (query.Contains("SHOW"))
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader read = command.ExecuteReader();
                    String store = "";
                    while (read.Read())
                    {
                        store += read.GetString(0) + ",";
                    }
                    read.Close();
                    AppendText("Column Names:" + store);
                    //AppendText("Current Columns:" + Convert.ToString(command.ExecuteScalar()));
                }
                else if (query.Contains("ALTER"))
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    AppendText("Modified Table New Table:");
                    ExecuteCommand("/mysql SHOW COLUMNS FROM `UserInfo`");
                }
                else if (query.Contains("SELECT"))
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader read = command.ExecuteReader();
                    String store = "";
                    while (read.Read())
                    {
                        store += read.GetString(0) + ",";
                    }
                    read.Close();
                    AppendText(store);
                }
            }
        }
        public string CheckUsernameAndPassword(string username, string password)
        {
            String query = "SELECT * FROM UserInfo WHERE email='" + username + "' and password='" + password + "';";
            AppendText(query);
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader read = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (read.Read())
            {
                sb.Append("FirstName:" + read.GetString(0) + ";");
                sb.Append("LastName:" + read.GetString(1) + ";");
                sb.Append("Gender" + read.GetString(2) + ";");
                sb.Append("DOB" + read.GetDateTime(3) + ";");
                sb.Append("EMAIL" + read.GetString(4) + ";");
                sb.Append("Password" + read.GetString(5) + ";");
                AppendText(sb.ToString());
            }
            read.Close();
            if (sb.ToString().Length == 0)
            {
                return "";
            }
            return sb.ToString();
        }
        private void descToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteCommand("/mysql SHOW COLUMNS FROM `UserInfo`");
        }

        private void insertColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtField.Text = "/mysql ALTER TABLE UserInfo ADD [NAME] [TYPE];";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void createAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtField.Text = "";
        }

        private void checkAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppendText(CheckUsernameAndPassword("phasecode@live.com", "Ilovejay123456").ToString());
            //                                                         Ilovejay123456
            //  txtField.Text = "SELECT * FROM userinfo WHERE email='" + "USERNAME" + "' and password='" + "PASSWORD" + "';";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            connection.Close();
            server.Abort();
            Environment.Exit(0);
            //this.Dispose();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
