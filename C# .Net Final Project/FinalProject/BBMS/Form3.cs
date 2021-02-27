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
    public partial class Form3 : Form
    {
        private int gap = 5;
        private Thread thread;
        public static List<string> listObj = new List<string>();
        private string userName;
        private string city;
        private string bloodGroup;
        private string contactNO;
        private byte[] image;
        private UserControl2 conObj1;
        private UserControl2 oldConObj;
        private string conString = "Data Source=DESKTOP-HU9VRD9;Initial Catalog=DbConnection;Integrated Security=True";
        private string currentUserID;


        public Form3(string currentUserID)
        {
            InitializeComponent();
            this.currentUserID = currentUserID;
            executeQuery();
            //comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        
        private void executeQuery()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                //string query1 = "select USERID from BLOODTABLE where BLOODGROUP like '%"+comboBox1.Text.ToString()+"%'";
                string query2 = "select BLOODTABLE.USERID from DONORTABLE, BLOODTABLE, INFORMATIONTABLE, LOGINTABLE, LOCATIONTABLE where BLOODTABLE.USERID = DONORTABLE.USERID and BLOODTABLE.USERID!='" + currentUserID+"' and BLOODTABLE.BLOODGROUP like '%" + comboBox1.Text.ToString() + "%' and (INFORMATIONTABLE.USERID = DONORTABLE.USERID and INFORMATIONTABLE.LOCATIONID = LOCATIONTABLE.LOCATIONID and LOGINTABLE.USERID=INFORMATIONTABLE.USERID and LOGINTABLE.ACTIVE = 1 and upper(LOCATIONTABLE.CITY) like upper('%"+textBox1.Text.ToString()+"%') and upper(LOCATIONTABLE.AREA) like upper('%"+textBox2.Text.ToString()+"%'))";
                SqlDataAdapter sda = new SqlDataAdapter(query2, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    listObj.Add(dr["USERID"].ToString());
                    //MessageBox.Show("UserID : "+dr["USERID"].ToString());
                }
                for (int i = 0; i < listObj.Count; i += 1)
                {
                    //MessageBox.Show("USERID : "+listObj[i]);
                    loadAll(listObj[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in form3 (this)executeQuery() method...");
                
            }
        }




        private void loadAll(string userID)
        {
            try
            {
                loadData1(userID);
                loadData2(userID);
                loadData3(userID);
                loadData4(userID);
                loadData5(userID);
                conObj1 = new UserControl2(userID, userName, city, bloodGroup, contactNO, image);
                image = null;
                panel2.Controls.Add(conObj1);
                if (panel2.Controls.Count == 1)
                {
                    conObj1.Location = new Point(5, 5);
                }
                else
                {
                    oldConObj = (UserControl2)panel2.Controls[panel2.Controls.Count - 2];
                    conObj1.Location = new Point(5, oldConObj.Location.Y + oldConObj.Height + gap);
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void loadData5(string userID)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = "select PICTURE from INFORMATIONTABLE where USERID='"+userID+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                sqlDataReader.Read();
                if (sqlDataReader[0] == null)
                {
                    image = null;
                }
                else
                {
                    image = (byte[])sqlDataReader[0];
                }
            }
            catch(Exception ex)
            {
                image = null;
                //MessageBox.Show("Error in loadData5 method...!\nImage not found...!");
            }
        }

        public void RemoveMethod()
        {
            try
            {
                for (int i = (listObj.Count - 1); i >= 0; i -= 1)
                {
                    panel2.Controls.RemoveAt(i);
                }
                conObj1.Location = new Point(5, 5);
            }
            catch (Exception ex)
            {
                //nothing
            }
        }




        private void loadData1(string userID)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select USERNAME from DONORTABLE where USERID='"+userID+"'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    userName = dr1["USERNAME"].ToString();
                }
                

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in data retrive in load Data method 1....");
            }
        }


        private void loadData2(string userID)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select CITY from LOCATIONTABLE, INFORMATIONTABLE where LOCATIONTABLE.LOCATIONID = INFORMATIONTABLE.LOCATIONID and INFORMATIONTABLE.USERID ='"+userID+"'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    city = dr1["CITY"].ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in data retrive in load Data method 2....");
            }
        }

        private void loadData3(string userID)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select BLOODGROUP from BLOODTABLE where USERID='" + userID + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    bloodGroup = dr1["BLOODGROUP"].ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in data retrive in load Data method 3....");
            }
        }

        private void loadData4(string userID)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select CONTACTNO from INFORMATIONTABLE where USERID='" + userID + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    contactNO = dr1["CONTACTNO"].ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in data retrive in load Data method 4....");
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            RemoveMethod();
            listObj.Clear();
            try
            {
                this.Close();
                thread = new Thread(newForm1);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            catch(Exception ex)
            {

            }
        }

        private void newForm1()
        {
            Application.Run(new Form1());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "A RhD positive (A+)")
            {
                comboBox1.Text = "A RhD positive (A+)";
            }
            else if (comboBox1.Text == "A RhD negative (A-)")
            {
                comboBox1.Text = "A RhD negative (A-)";
            }
            else if (comboBox1.Text == "B RhD positive (B+)")
            {
                comboBox1.Text = "B RhD positive (B+)";
            }
            else if (comboBox1.Text == "B RhD negative (B-)")
            {
                comboBox1.Text = "B RhD negative (B-)";
            }
            else if (comboBox1.Text == "O RhD positive (O+)")
            {
                comboBox1.Text = "O RhD positive (O+)";
            }
            else if (comboBox1.Text == "O RhD negative (O-)")
            {
                comboBox1.Text = "O RhD negative (O-)";
            }
            else if (comboBox1.Text == "AB RhD positive (AB+)")
            {
                comboBox1.Text = "AB RhD positive (AB+)";
            }
            else if (comboBox1.Text == "AB RhD negative (AB-)")
            {
                comboBox1.Text = "AB RhD negative (AB-)";
            }
            else
            {
                //problem
            }

            RemoveMethod();
            listObj.Clear();
            executeQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            RemoveMethod();
            listObj.Clear();
            executeQuery();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            RemoveMethod();
            listObj.Clear();
            executeQuery();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            RemoveMethod();
            listObj.Clear();
            executeQuery();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RemoveMethod();
            listObj.Clear();
            executeQuery();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            RemoveMethod();
            listObj.Clear();
            executeQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveMethod();
            listObj.Clear();
            this.Close();
            thread = new Thread(newForm5);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }

        private void newForm5()
        {
            Application.Run(new Form5(currentUserID));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkAdmin())
            {
                //MessageBox.Show("Admin");
                RemoveMethod();
                listObj.Clear();
                this.Close();
                thread = new Thread(newForm6);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();

            }
            else
            {
                MessageBox.Show("Donor can not manage the system..");
            }
        }

        private void newForm6()
        {
            Application.Run(new Form6(currentUserID));
        }

        private bool checkAdmin()
        {
            bool val = false; ;
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select USERTYPE from LOGINTABLE where USERID='"+currentUserID+"'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    if (dr1["USERTYPE"].ToString() == "Admin")
                    {
                        val = true;
                    }
                    else
                    {
                        val = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in check Admin...!");
                return false;
            }
            return val;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RemoveMethod();
            listObj.Clear();
            this.Close();
            thread = new Thread(newForm7);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void newForm7()
        {
            Application.Run(new Form7(currentUserID));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            RemoveMethod();
            listObj.Clear();
            this.Close();
            thread = new Thread(newForm8);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void newForm8()
        {
            Application.Run(new Form8(currentUserID));
        }
    }
}
