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
    public partial class Form7 : Form
    {
        private string currentUserID;
        private Thread thread;
        private string conString = "Data Source=DESKTOP-HU9VRD9;Initial Catalog=DbConnection;Integrated Security=True";
        private string replyID;

        public Form7()
        {
            InitializeComponent();
        }

        public Form7(string currentUserID)
        {
            this.currentUserID = currentUserID;
            InitializeComponent();
            richTextBox1.Enabled = false;
            textBox1.Enabled = false;
            loadMessenger();
        }

        private void loadMessenger()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "Select USERIDONE from NOTIFICATIONTABLE where USERIDTWO='"+currentUserID+"'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                dataGridView1.DataSource = dt1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in load data...!");
            }
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                string temp = selectedRow.Cells[0].Value.ToString();
                textBox1.Text = temp;
                replyID = textBox1.Text;
                //MessageBox.Show(temp);
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "Select MESSAGE from NOTIFICATIONTABLE where USERIDONE='" + temp + "' and USERIDTWO='"+currentUserID+"'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    richTextBox1.Text = dr["MESSAGE"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(newForm8);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void newForm8()
        {
            Application.Run(new Form8(currentUserID,replyID));
        }
    }
}
