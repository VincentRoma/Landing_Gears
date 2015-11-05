using QualityApplication.Models;
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
            this.gearsetLeft = new GearSet(pictureBox2, pictureBox5);
            this.gearsetMiddle = new GearSet(pictureBox4, pictureBox6);
            this.gearsetRight = new GearSet(pictureBox3, pictureBox7);
            this.lightControl = new LightControl(pictureBox1);
            this.controlPanel = new ControlPanel(gearsetLeft, gearsetMiddle, gearsetRight, lightControl);
        }

        GearSet gearsetRight;
        GearSet gearsetMiddle;
        GearSet gearsetLeft;
        LightControl lightControl;
        ControlPanel controlPanel;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            controlPanel.takeOff();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controlPanel.landing();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
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
    }
}
