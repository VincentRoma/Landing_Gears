using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QualityApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            pictureBox2.Image = Image.FromFile("../../img/gear2_moving.jpg");
            pictureBox2.Refresh();
            Thread.Sleep(3000);
            pictureBox2.Image = Image.FromFile("../../img/gear2_extracted.jpg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 33;
            pictureBox2.Image = Image.FromFile("../../img/gear2_moving.jpg");
            pictureBox2.Refresh();
            Thread.Sleep(1000);
            progressBar1.Value = 66;
            Thread.Sleep(2000);
            progressBar1.Value = 100;
            pictureBox2.Image = Image.FromFile("../../img/gear2_retracted.jpg");
            pictureBox2.Refresh();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
