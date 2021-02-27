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
using System.IO;



namespace BBMS
{
    public partial class Form2 : Form
    {
        private Thread thread;
        private static int errorCount1 = 1;
        private static int errorCount2 = 1;
        private static int errorCount3 = 1;
        private static int errorCount4 = 1;
        private static int errorCount5 = 1;
        private static int errorCount6 = 1;
        private static int errorCount7 = 1;
        private static int errorCount8 = 1;
        private static int errorCount9 = 1;
        private static int errorCount10 = 1;
        private static int errorCount11 = 1;
        private static int errorCount12 = 1;
        private static int LID = 0;
        private string imageLocation;
        private string conString = "Data Source=DESKTOP-HU9VRD9;Initial Catalog=DbConnection;Integrated Security=True";

        public Form2()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button3_Click(object sender, EventArgs e)
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
            OpenFileDialog ofdObj = new OpenFileDialog();
            ofdObj.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|jpeg files(*.jpeg)|*.jpeg|All files(*.*)|*.*";
            if (ofdObj.ShowDialog() == DialogResult.OK)
            {

                imageLocation = ofdObj.FileName.ToString();
                pictureBox1.ImageLocation = imageLocation;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {


            if (String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.BackColor = Color.Tomato;
                MessageBox.Show("User id cant be empty...!");
                errorCount1 = 1;
            }
            else
            {
                checkUID(textBox1.Text);
            }




            if (String.IsNullOrEmpty(comboBox1.Text))
            {
                comboBox1.BackColor = Color.Tomato;
                MessageBox.Show("You need to select a userType...!");
                errorCount2 = 1;
            }
            else
            {
                if (comboBox1.Text == "Admin")
                {
                    comboBox1.Text = "Admin";
                    comboBox1.BackColor = Color.White;
                    errorCount2 = 0;
                }
                else if (comboBox1.Text == "Donor")
                {
                    comboBox1.Text = "Donor";
                    comboBox1.BackColor = Color.White;
                    errorCount2 = 0;
                }
                else
                {
                    comboBox1.Text = "";
                    comboBox1.BackColor = Color.Tomato;
                    MessageBox.Show("You need to select an user type...!");
                    errorCount2 = 1;
                } 
            }



            if (String.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.BackColor = Color.Tomato;
                MessageBox.Show("User name cant be empty...!");
                errorCount3 = 1;
            }
            else
            {
                textBox2.BackColor = Color.White;
                errorCount3 = 0;
                //good to go...
            }



            if (String.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Text = "0";
                textBox3.BackColor = Color.White;
            }
            else
            {
                checkLastDon(textBox3.Text);
            }

            
            if (String.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.BackColor = Color.Tomato;
                MessageBox.Show("You need to enter your age...!");
                errorCount5 = 1;
            }
            else
            {
                checkAge(textBox4.Text);
            }
            

            if (String.IsNullOrEmpty(comboBox3.Text))
            {
                comboBox3.BackColor = Color.Tomato;
                MessageBox.Show("You need to select a gender...!");
                errorCount6 = 1;
            }
            else
            {
                if (comboBox3.Text == "Male")
                {
                    comboBox3.BackColor = Color.White;
                    comboBox3.Text = "Male";
                    errorCount6 = 0;
                }
                else if (comboBox3.Text == "Female")
                {
                    comboBox3.BackColor = Color.White;
                    comboBox3.Text = "Female";
                    errorCount6 = 0;
                }
                else
                {
                    comboBox3.Text = "";
                    comboBox3.BackColor = Color.Tomato;
                    MessageBox.Show("You need to select an gender...!");
                    errorCount6 = 1;
                }
            }




            if (String.IsNullOrEmpty(textBox10.Text))
            {
                textBox10.Text = "NO CITY";
            }
            else
            {
                //no prob
            }



      
            if (String.IsNullOrEmpty(textBox11.Text))
            {
                textBox11.Text = "NO AREA";
            }
            else
            {
                //no prob
            }


            if (String.IsNullOrEmpty(comboBox2.Text))
            {
                comboBox2.BackColor = Color.Tomato;
                MessageBox.Show("You need to select a blood group...!");
                errorCount7 = 1;
            }
            else
            {
                if (comboBox2.Text == "A RhD positive (A+) ")
                {
                    comboBox2.BackColor = Color.White;
                    comboBox2.Text = "A RhD positive (A+) ";
                    errorCount7 = 0;
                }
                else if (comboBox2.Text == "A RhD negative (A-) ")
                {
                    comboBox2.BackColor = Color.White;
                    comboBox2.Text = "A RhD negative (A-) ";
                    errorCount7 = 0;
                }
                else if (comboBox2.Text == "B RhD positive (B+) ")
                {
                    comboBox2.BackColor = Color.White;
                    comboBox2.Text = "B RhD positive (B+) ";
                    errorCount7 = 0;
                }
                else if (comboBox2.Text == "B RhD negative (B-) ")
                {
                    comboBox2.BackColor = Color.White;
                    comboBox2.Text = "B RhD negative (B-) ";
                    errorCount7 = 0;
                }
                else if (comboBox2.Text == "O RhD positive (O+) ")
                {
                    comboBox2.BackColor = Color.White;
                    comboBox2.Text = "O RhD positive (O+) ";
                    errorCount7 = 0;
                }
                else if (comboBox2.Text == "O RhD negative (O-) ")
                {
                    comboBox2.BackColor = Color.White;
                    comboBox2.Text = "O RhD negative (O-) ";
                    errorCount7 = 0;
                }
                else if (comboBox2.Text == "AB RhD positive (AB+) ")
                {
                    comboBox2.BackColor = Color.White;
                    comboBox2.Text = "AB RhD positive (AB+) ";
                    errorCount7 = 0;
                }
                else if (comboBox2.Text == "AB RhD negative (AB-) ")
                {
                    comboBox2.BackColor = Color.White;
                    comboBox2.Text = "AB RhD negative (AB-) ";
                    errorCount7 = 0;
                }
                else
                {
                    //problem
                    comboBox2.BackColor = Color.Tomato;
                    MessageBox.Show("Select a blood group...!");
                    comboBox2.Text = "";
                    errorCount7 = 1;
                }
            }


            if (String.IsNullOrEmpty(textBox7.Text))
            {
                textBox7.Text = "NO DISEASE";
            }
            else
            {
                //nothing...
            }




            if (String.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.BackColor = Color.Tomato;
                MessageBox.Show("Contact number is mendatory...!");
                errorCount8 = 1;
            }
            else
            {
                checkNumber(textBox6.Text);
            }




            if (String.IsNullOrEmpty(textBox8.Text))
            {
                textBox8.BackColor = Color.Tomato;
                MessageBox.Show("Password is mendatory");
                errorCount9 = 1;
            }
            else
            {
                //nothing
                errorCount9 = 0;
                textBox8.BackColor = Color.White;
            }



            if (String.IsNullOrEmpty(textBox9.Text))
            {
                textBox9.BackColor = Color.Tomato;
                MessageBox.Show("Re-enter your password...!");
                errorCount10 = 1;
            }
            else
            {
                checkMatch(textBox9.Text);
            }

            
            if (String.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.BackColor = Color.Tomato;
                MessageBox.Show("Security number can't be empty...!");
                errorCount11 = 1;
            }
            else
            {
                int num = 0;
                try
                {
                    num = int.Parse(textBox5.Text);
                    textBox5.BackColor = Color.White;
                    //MessageBox.Show("It's an integer");
                    errorCount11 = 0;
                }
                catch (Exception ex)
                {
                    textBox5.BackColor = Color.Tomato;
                    MessageBox.Show("Security number should bean an integer number");
                    textBox5.Text = "";
                    //nothing
                    errorCount11 = 1;
                } 
            }

            
            if (pictureBox1.Image == null)
            {
                pictureBox1.BackColor = Color.Tomato;
                MessageBox.Show("Picture box can't be empty");
                errorCount12 = 1;
            }
            else
            {
                pictureBox1.BackColor = Color.White;
                errorCount12 = 0;
            }


            if ((errorCount1 == 0) && (errorCount2 == 0) && (errorCount3 == 0) && (errorCount4 == 0) && (errorCount5 == 0) && (errorCount6 == 0) &&
                (errorCount7 == 0) && (errorCount8 == 0) && (errorCount9 == 0) && (errorCount10 == 0) && (errorCount11 == 0) && (errorCount12 == 0))
            {
                executeQuery();
                MessageBox.Show("Query executed..!");
                this.Close();
                thread = new Thread(newForm1);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
            {
                MessageBox.Show("Query not executed..!");
            }
        }



        private void checkMatch(string text)
        {
            if (textBox8.Text == text)
            {
                //no prob
                errorCount10 = 0;
                textBox9.BackColor = Color.White;
            }
            else
            {
                textBox9.BackColor = Color.Tomato;
                MessageBox.Show("Password didn't match...!");
                errorCount10 = 1;
            }
        }

        private void checkNumber(string text)
        {
            long num = 0;
            try
            {
                num = long.Parse(text);
                //MessageBox.Show("It's an integer");
                if (text.Length == 11)
                {
                    textBox6.BackColor = Color.White;
                    //ok
                    errorCount8 = 0;
                }
                else
                {
                    textBox6.BackColor = Color.Tomato;
                    MessageBox.Show("Contact number should be 11 charecters...!");
                    errorCount8 = 1;
                }
            }
            catch (Exception e)
            {
                textBox6.BackColor = Color.Tomato;
                MessageBox.Show("It's not an integer");
                textBox6.Text = "";
                errorCount8 = 1;
            }
        }

        private void checkAge(string text)
        {
            int num = 0;
            try
            {
                num = int.Parse(text);
                //MessageBox.Show("It's an integer");
                if (num <= 0)
                {
                    textBox4.BackColor = Color.Tomato;
                    MessageBox.Show("Input cant be negetive or 0...!");
                    textBox4.Text = " ";
                    errorCount5 = 1;
                }
                else if (num < 18)
                {
                    textBox4.BackColor = Color.Tomato;
                    MessageBox.Show("You are not old enough to register...!");
                    errorCount5 = 1;
                }
                else if (num > 50)
                {
                    textBox4.BackColor = Color.Tomato;
                    MessageBox.Show("You are too old to donate blood...!");
                    errorCount5 = 1;
                }
                else
                {
                    textBox4.BackColor = Color.White;
                    errorCount5 = 0;
                }


            }
            catch (Exception e)
            {
                textBox4.BackColor = Color.Tomato;
                MessageBox.Show("Age should be an integer");
                textBox4.Text = " ";
                errorCount5 = 1;
            }
        }

        private void checkLastDon(string text)
        {
            int num = 0;
            try
            {
                num = int.Parse(text);
                //MessageBox.Show("It's an integer");
                if (num < 0)
                {
                    textBox3.BackColor = Color.Tomato;
                    MessageBox.Show("Input cant be negetive...!");
                    errorCount4 = 1;
                }
                else if (num > 12)
                {
                    textBox3.BackColor = Color.Tomato;
                    MessageBox.Show("Input cant be more than 12 months...!");
                    errorCount4 = 1;
                }
                else
                {
                    textBox3.BackColor = Color.White;
                    errorCount4 = 0;
                }
                
            }
            catch (Exception e)
            {
                textBox3.BackColor = Color.Tomato;
                MessageBox.Show("Last donation should be an integer");
                textBox3.Text = "";
                errorCount4 = 1;
            }
        }

        
        private void checkUID(string text)
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
                    textBox1.BackColor = Color.Tomato;
                    con.Close();
                    MessageBox.Show("UserID alredy taken....\nTry another one...");
                    errorCount1 = 1;
                }
                else
                {
                    //nothing
                    errorCount1 = 0;
                    textBox1.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                textBox1.BackColor = Color.Tomato;
                errorCount1 = 1;
            }
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Admin")
            {
                comboBox1.Text = "Admin";
            }
            else if (comboBox1.Text == "Donor")
            {
                comboBox1.Text = "Donor";
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Male")
            {
                comboBox3.Text = "Male";
            }
            else if (comboBox3.Text == "Female")
            {
                comboBox3.Text = "Female";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "A RhD positive (A+)")
            {
                comboBox2.Text = "A RhD positive (A+)";
            }
            else if (comboBox2.Text == "A RhD negative (A-)")
            {
                comboBox2.Text = "A RhD negative (A-)";
            }
            else if (comboBox2.Text == "B RhD positive (B+)")
            {
                comboBox2.Text = "B RhD positive (B+)";
            }
            else if (comboBox2.Text == "B RhD negative (B-)")
            {
                comboBox2.Text = "B RhD negative (B-)";
            }
            else if (comboBox2.Text == "O RhD positive (O+)")
            {
                comboBox2.Text = "O RhD positive (O+)";
            }
            else if (comboBox2.Text == "O RhD negative (O-)")
            {
                comboBox2.Text = "O RhD negative (O-)";
            }
            else if (comboBox2.Text == "AB RhD positive (AB+)")
            {
                comboBox2.Text = "AB RhD positive (AB+)";
            }
            else if (comboBox2.Text == "AB RhD negative (AB-)")
            {
                comboBox2.Text = "AB RhD negative (AB-)";
            }
            else
            {
                //problem
            }
        }


        
        private void executeQuery()
        {
            uploadToLogintable();
            uploadDonorTable();
            uploadToLocationTable();
            uploadToInformationTable();
            uploadBloodTable();
            uploadToHistoryTable();
            
        }

        
        
        private void uploadToInformationTable()
        {
            try
            {
                byte[] image = null;
                if (pictureBox1.Image != null)
                {
                    FileStream fileStream = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    image = binaryReader.ReadBytes((int)fileStream.Length);
                }
                else
                {
                    MessageBox.Show("No image selected");
                }
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "insert into INFORMATIONTABLE values('" + textBox1.Text.ToString() + "'," + LID + ",'" + textBox6.Text.ToString() + "','" + textBox5.Text.ToString() + "',@image)";
                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.Parameters.Add(new SqlParameter("@image",image));
                int n = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in uploadToInformationTable");
            }
        }

        
        private void uploadToLocationTable()
        {
            generateLocationID();
            LID += 1;
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "insert into LOCATIONTABLE values(" + LID + ",'" + textBox10.Text.ToString() + "','" + textBox11.Text.ToString() + "')";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    con.Close();
                    MessageBox.Show("LOCATIONTABLE UPDATED");
                }
                else
                {
                    //nothing

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in uploadToLocationTable");
            }

        }


        private void generateLocationID()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select LOCATIONID from LOCATIONTABLE";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    LID = (int)dr["LOCATIONID"];
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in generateLocationID");
            }
        }


        private void uploadBloodTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "insert into BLOODTABLE values('" + textBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + textBox7.Text.ToString() + "')";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    con.Close();
                    MessageBox.Show("BLOODTABLE UPDATED");
                }
                else
                {
                    //nothing
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in uploadBloodTable");
            }
        }


        private void uploadDonorTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "insert into DONORTABLE values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "'," + textBox4.Text + ",'" + comboBox3.Text.ToString() + "')";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    con.Close();
                    MessageBox.Show("DONORTABLE UPDATED");
                }
                else
                {
                    //nothing
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in uploadDonorTable");
            }
        }


        private void uploadToHistoryTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "insert into HISTORYTABLE values('" + textBox1.Text.ToString() + "','" + textBox3.Text.ToString() + "',0)";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    con.Close();
                    MessageBox.Show("HISTORYTABLE UPDATED");
                }
                else
                {
                    //nothing
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in uploadToHistoryTable");
            }
        }


        private void uploadToLogintable()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "insert into LOGINTABLE values('" + textBox1.Text.ToString() + "','" + textBox9.Text.ToString() + "','" + comboBox1.Text.ToString() + "',0)";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    con.Close();
                    MessageBox.Show("LOGINTABLE UPDATED");
                }
                else
                {
                    //nothing
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in uploadToLogintable");
            }
        }
    }
}
