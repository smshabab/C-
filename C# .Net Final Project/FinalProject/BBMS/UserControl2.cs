using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace BBMS
{
    public partial class UserControl2 : UserControl
    {
        public int index;
        private Thread thread;
        private string userID;
        private byte[] image;
        

        public UserControl2()
        {
            InitializeComponent();
        }

        public UserControl2(string userID, string userName, string city, string bloodGroup, string contactNO, byte[] image)
        {
            InitializeComponent();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            this.userID = userID;
            this.image = image;
            conToImage(image);
            textBox5.Text = "ID : " + userID;
            textBox1.Text = userName;
            textBox2.Text = city;
            textBox3.Text = bloodGroup;
            textBox4.Text = contactNO;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
        }

        private void conToImage(byte[] image)
        {
            if (image == null)
            {
                pictureBox1.Image = null;
            }
            else
            {
                MemoryStream memoeyStream = new MemoryStream(image);
                pictureBox1.Image = Image.FromStream(memoeyStream);
            }
        }



    }
}
