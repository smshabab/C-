using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS
{
    public partial class Form8 : Form
    {
        private string currentUserID;
        private Thread thread;
        private int errorCount1 = 1;
        private int errorCount2 = 1;
        private string conString = "Data Source=DESKTOP-HU9VRD9;Initial Catalog=DbConnection;Integrated Security=True";

        public Form8()
        {
            InitializeComponent();
        }

        public Form8(string currentUserID)
        {
            this.currentUserID = currentUserID;
            InitializeComponent();
        }

        public Form8(string currentUserID, string receiverID)
        {
            this.currentUserID = currentUserID;
            InitializeComponent();
            textBox1.Text = receiverID;
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(newForm3);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void newForm3()
        {
            Application.Run(new Form3(currentUserID));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter an user ID...!");
                errorCount1 = 1;
                textBox1.BackColor = Color.Tomato;
            }
            else
            {
                checkReceiverID(textBox1.Text);
            }

            if (String.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Message box is empty...!");
                errorCount2 = 1;
                richTextBox1.BackColor = Color.Tomato;
            }
            else
            {
                errorCount2 = 0;
                richTextBox1.BackColor = Color.White;
            }

            if ((errorCount1==0)&&(errorCount2==0))
            {
                executeQuery();
            }
            else
            {
                MessageBox.Show("Errors are not clear...!");
            }
        }

        private void executeQuery()
        {
            try
            {
                deleteOldMessage();
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "insert into NOTIFICATIONTABLE values('"+currentUserID+"','"+textBox1.Text.ToString()+"','"+richTextBox1.Text.ToString()+"',1)";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                
                MessageBox.Show("Message Sent..!");
                this.Close();
                thread = new Thread(newForm3);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in execute query...!\nOR MESSAGE LENGTH IS 200 CHARECTERS");
            }
        }

        private void deleteOldMessage()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "delete from NOTIFICATIONTABLE where USERIDONE='"+currentUserID+"' and USERIDTWO='"+textBox1.Text.ToString()+"'";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
            }
            catch (Exception ex)
            {

            }
        }

        private void checkReceiverID(string text)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select * from LOGINTABLE where USERID = '" + text + "' and USERID!='"+currentUserID+"'";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    textBox1.BackColor = Color.White;
                    con.Close();
                    //MessageBox.Show("UserID valid...!");
                    errorCount1 = 0;
                }
                else
                {
                    MessageBox.Show("You can't send message to yourself...!");
                    textBox1.BackColor = Color.Tomato;
                    errorCount1 = 1;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in checkReceiverID");
                textBox1.BackColor = Color.Tomato;
                errorCount1 = 1;
            }
        }
    }
}
