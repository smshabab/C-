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
using System.Threading;

namespace BBMS
{
    public partial class Form1 : Form
    {
        private Thread thread;
       
        public Form1()
        {
            InitializeComponent();
        }

        private string conString = "Data Source=DESKTOP-HU9VRD9;Initial Catalog=DbConnection;Integrated Security=True";
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select * from LOGINTABLE where USERID = '" + textBox1.Text.ToString() + "'and PASSWORD = '" + textBox2.Text.ToString() + "' and ACTIVE=1";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    con.Close();
                    this.Hide();
                    thread = new Thread(newForm3);
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    textBox1.BackColor = textBox2.BackColor = Color.White;

                }
                else
                {
                    textBox1.BackColor = textBox2.BackColor = Color.Tomato;
                    MessageBox.Show("Wrong username or password\nOR ID NOT ACTIVATED");
                }
                

            }
            catch (Exception ex)
            {
                textBox1.BackColor = textBox2.BackColor = Color.Tomato;
                MessageBox.Show("Error...\nEnter userName and password");
            }



        }

        private void newForm3()
        {
            //MessageBox.Show(textBox1.Text.ToString());
            Application.Run(new Form3(textBox1.Text.ToString()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                thread = new Thread(newForm2);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                

            }
            catch (Exception ex)
            {
                
            }
        }

        private void newForm2()
        {
            Application.Run(new Form2());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                thread = new Thread(newForm4);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();

            }
            catch (Exception ex)
            {

            }
        }

        private void newForm4()
        {
            Application.Run(new Form4());
            
        }
    }
}
