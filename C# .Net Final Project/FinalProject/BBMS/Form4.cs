using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace BBMS
{
    public partial class Form4 : Form
    {
        private Thread thread;
        private int errorCount1, errorCount2, errorCount3, errorCount4;
        private string conString = "Data Source=DESKTOP-HU9VRD9;Initial Catalog=DbConnection;Integrated Security=True";

        public Form4()
        {
            InitializeComponent();
            errorCount1 = errorCount2 = errorCount3 = errorCount4 = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(newForm1);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }

        private void newForm1()
        {
            Application.Run(new Form1());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.BackColor = Color.Tomato;
                errorCount1 = 1;
            }
            else
            {
                checkUserID();
            }
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.BackColor = Color.Tomato;
                errorCount2 = 1;
            }
            else
            {
                checkSecurityNumber();
            }
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.BackColor = Color.Tomato;
                errorCount3 = 1;
            }
            else
            {
                textBox3.BackColor = Color.White;
                errorCount3 = 0;
            }
            if (String.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.BackColor = Color.Tomato;
                errorCount4 = 1;
            }
            else
            {
                checkMatch(textBox4.Text);
            }
            if ((errorCount1 == 0) && (errorCount2 == 0) && (errorCount3 == 0) && (errorCount4 == 0))
            {
                updatePassword();
            }
            else
            {
                //error
            }
        }

        private void updatePassword()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "update LOGINTABLE set PASSWORD='"+textBox4.Text.ToString()+"' where USERID='"+textBox1.Text.ToString()+"'";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Password has been updated succesfully...!");
                    this.Close();
                    thread = new Thread(newForm1);
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                }
                else
                {
                    MessageBox.Show("Somthing went wrong...!");  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in update password method...!");
            }
        }

        private void checkMatch(string str)
        {
            if (textBox3.Text==str)
            {
                textBox4.BackColor = Color.White;
                errorCount4 = 0;
            }
            else
            {
                textBox4.BackColor = Color.Tomato;
                errorCount4 = 1;
            }
        }

        private void checkSecurityNumber()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select SECURITYNUMBER from INFORMATIONTABLE where USERID='"+textBox1.Text.ToString()+"' AND SECURITYNUMBER="+textBox2.Text.ToString();
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    //oke
                    errorCount2 = 0;
                    textBox2.BackColor = Color.White;
                    //MessageBox.Show("Found");
                }
                else
                {
                    //MessageBox.Show("Not Found");
                    errorCount2 = 1;
                    textBox2.BackColor = Color.Tomato;
                }


            }
            catch (Exception ex)
            {
                errorCount2 = 1;
                textBox2.BackColor = Color.Tomato;
            }
        }

        private void checkUserID()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select * from LOGINTABLE where USERID = '" + textBox1.Text.ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    //oke
                    errorCount1 = 0;
                    textBox1.BackColor = Color.White;
                    //MessageBox.Show("Found");
                }
                else
                {
                    //MessageBox.Show("Not Found");
                    errorCount1 = 1;
                    textBox1.BackColor = Color.Tomato;
                }


            }
            catch (Exception ex)
            {
                errorCount1 = 1;
                textBox1.BackColor = Color.Tomato;
            }
        }


        
    }
}
