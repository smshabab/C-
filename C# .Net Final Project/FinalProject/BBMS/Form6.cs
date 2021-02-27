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
    public partial class Form6 : Form
    {
        private string currentUserID;
        private Thread thread;
        private string conString = "Data Source=DESKTOP-HU9VRD9;Initial Catalog=DbConnection;Integrated Security=True";
        private static int LID = 0;

        public Form6()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            loadData();
        }

        public Form6(string currentUserID)
        {
            this.currentUserID = currentUserID;
            InitializeComponent();
            textBox1.Enabled = false;
            loadData();
        }




        private void loadData()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "Select USERID,USERTYPE,ACTIVE from LOGINTABLE where USERID!='"+currentUserID+"'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("No id is selected..\nSelect an ID please");
            }
            else
            {
                activeID();
            }
        }

        private void activeID()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "update LOGINTABLE set ACTIVE="+1+" where USERID='"+textBox1.Text.ToString()+"'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                MessageBox.Show("User Activated");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in activation...!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                textBox1.Text = selectedRow.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {

            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("No id is selected..\nSelect an ID please");
            }
            else
            {
                deactiveID();
            }
        }

        private void deactiveID()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "update LOGINTABLE set ACTIVE=" + 0 + " where USERID='" + textBox1.Text.ToString() + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                MessageBox.Show("User Deactivated");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in deactivation...!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("No id is selected..\nSelect an ID please");
            }
            else
            {
                deleteUser();
                MessageBox.Show("User Deleted..!");
            }
        }

        private void deleteUser()
        {
            deleteFromHistoryTable();
            deleteBloodTable();
            deleteInformationTable();
            deleteLocationTable();
            deleteDonorTable();
            deleteLoginTable();
        }

        private void deleteLoginTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "delete from LOGINTABLE where USERID='" + textBox1.Text.ToString() + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                //MessageBox.Show("Data deleted from login table...");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in deleteLoginTable...!");
            }
        }

        private void deleteDonorTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "delete from DONORTABLE where USERID='" + textBox1.Text.ToString() + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                //MessageBox.Show("Data deleted from donor table...");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in deleteDonorTable...!");
            }
        }

        private void deleteLocationTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "delete from LOCATIONTABLE where LOCATIONID=" + LID;
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                //MessageBox.Show("Data deleted from location table...");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in deleteLocationTable...!");
            }
        }

        private void getLID()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select LOCATIONID from INFORMATIONTABLE where USERID='" + textBox1.Text.ToString() + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    LID = (int)dr["LOCATIONID"];
                }
                //MessageBox.Show(LID.ToString());
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getID...!");
            }
           
        }

        private void deleteInformationTable()
        {
            try
            {
                getLID();
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "delete from INFORMATIONTABLE where USERID='" + textBox1.Text.ToString() + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                //MessageBox.Show("Data deleted from information table...");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in deleteInformationTable...!");
            }
        }

        private void deleteBloodTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "delete from BLOODTABLE where USERID='" + textBox1.Text.ToString() + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                //MessageBox.Show("Data deleted from blood table...");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in deleteBloodTable...!");
            }
        }

        private void deleteFromHistoryTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "delete from HISTORYTABLE where USERID='" + textBox1.Text.ToString() + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                //MessageBox.Show("Data deleted from history table...");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in deleteFromHistoryTable...!");
            }
        }
    }
}
