using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS
{
    public partial class Form5 : Form
    {
        private string conString = "Data Source=DESKTOP-HU9VRD9;Initial Catalog=DbConnection;Integrated Security=True";
        private object dr;
        private int errorCount1 = 0;
        private int errorCount2 = 0;
        private int errorCount3 = 0;
        private int errorCount4 = 0;
        private int errorCount5 = 0;
        private int errorCount6 = 0;
        private int errorCount7 = 0;
        private int errorCount8 = 0;
        private int errorCount9 = 0;
        private int errorCount10 = 0;
        private int errorCount11 = 0;
        private int errorCount12 = 0;
        private string currentUserID;
        private Thread thread;
        private int LID;
        private byte[] image;
        private string imageLocation;

        public Form5()
        {
            InitializeComponent();
        }

        public Form5(string currentUserID)
        {
            InitializeComponent();
            this.currentUserID = currentUserID;
            textBox1.Text = currentUserID;
            //MessageBox.Show(currentUserID);
            executeQuery1();
            textBox1.Enabled = false;
            comboBox1.Enabled = false;
            comboBox3.Enabled = false;
            comboBox2.Enabled = false;
        }

        private void executeQuery1()
        {
            try
            {
                searchData1();
                searchData2();
                searchData3();
                searchData4();
                searchData5();
                searchData6();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in execute query 1...!");
            }
        }

        private void searchData6()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select CITY,AREA from LOCATIONTABLE where LOCATIONID =" + LID;
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    textBox10.Text = dr["CITY"].ToString();
                    textBox11.Text = dr["AREA"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in search data 6...!");
            }
        }

        private void searchData5()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select LOCATIONID,CONTACTNO,SECURITYNUMBER,PICTURE from INFORMATIONTABLE where USERID = '" + currentUserID + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    LID = (int)dr["LOCATIONID"];
                    textBox6.Text = dr["CONTACTNO"].ToString();
                    textBox5.Text = dr["SECURITYNUMBER"].ToString();
                    image = (byte[])dr["PICTURE"];
                    if (image == null)
                    {
                        //nothing
                    }
                    else
                    {
                        MemoryStream memoeyStream = new MemoryStream(image);
                        pictureBox1.Image = Image.FromStream(memoeyStream);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error in search data 5...!\nNo image found");
            }
        }

        private void searchData4()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select BLOODGROUP,DISEASE from BLOODTABLE where USERID = '" + currentUserID + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox2.Text = dr["BLOODGROUP"].ToString();
                    textBox7.Text = dr["DISEASE"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in search data 4...!");
            }
        }

        private void searchData3()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select LATDONATEDBLOOD from HISTORYTABLE where USERID = '" + currentUserID + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    textBox3.Text = dr["LATDONATEDBLOOD"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in search data 3...!");
            }
        }

        private void searchData2()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select USERNAME,AGE,GENDER from DONORTABLE where USERID = '" + currentUserID + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr["USERNAME"].ToString();
                    textBox4.Text = dr["AGE"].ToString();
                    comboBox3.Text = dr["GENDER"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in search data 2...!");
            }
        }

        private void searchData1()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "select PASSWORD,USERTYPE from LOGINTABLE where USERID = '" + currentUserID + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    textBox8.Text = textBox9.Text = dr["PASSWORD"].ToString();
                    comboBox1.Text = dr["USERTYPE"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in search data 1...!");
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
                //checkUID(textBox1.Text);
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
                executeQuery2();
                MessageBox.Show("Query executed..!");
                this.Close();
                thread = new Thread(newForm3);
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
            int num = 0;
            try
            {
                num = int.Parse(text);
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





        private void executeQuery2()
        {
            try
            {
                updateOnLogintable();
                updateOnDonorTable();
                updateOnHistoryTable();
                updateOnBloodTable();
                updateOnInformationTable();
                updateOnLocationTable();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in execute query 2...!");
            }
        }

        private void updateOnLocationTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "update LOCATIONTABLE set CITY='" + textBox10.Text.ToString() + "',AREA='"+textBox11.Text.ToString()+"' where LOCATIONID=" + LID;
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in updateOnLocationTable...!");
            }
        }

        private void updateOnInformationTable()
        {
            try
            {
                byte[] image = null;
                if (pictureBox1.Image != null)
                {
                    FileStream fileStream = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    image = binaryReader.ReadBytes((int)fileStream.Length);
                    //MessageBox.Show(image.ToString());
                }
                else
                {
                    MessageBox.Show("No image selected");
                }
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "update INFORMATIONTABLE set CONTACTNO='" + textBox6.Text.ToString() + "',SECURITYNUMBER='"+textBox5.Text.ToString()+ "',PICTURE=@image where USERID='" + currentUserID + "'";
                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.Parameters.Add(new SqlParameter("@image", image));
                int n = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                //error occures but don't know why...
                //MessageBox.Show("Error in updateOnInformationTable...!");
            }
        }

        private void updateOnBloodTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "update BLOODTABLE set DISEASE='" + textBox7.Text.ToString() + "' where USERID='" + currentUserID + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in updateOnBloodTable...!");
            }
        }

        private void updateOnHistoryTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "update HISTORYTABLE set LATDONATEDBLOOD='" + textBox3.Text.ToString() + "' where USERID='" + currentUserID + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in updateOnHistoryTable...!");
            }
        }

        private void updateOnDonorTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "update DONORTABLE set USERNAME='" + textBox2.Text.ToString() + "',AGE='"+textBox4.Text.ToString()+"' where USERID='" + currentUserID + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in updateOnDonorTable...!");
            }
        }

        private void updateOnLogintable()
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query1 = "update LOGINTABLE set PASSWORD='" + textBox8.Text.ToString() + "' where USERID='" + currentUserID + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in updateOnLogintable...!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
    }
}
