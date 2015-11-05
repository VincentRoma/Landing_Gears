using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;

namespace QualityApplication.Models
{
    class Door
    {
        public Door()
        {
            this.state = 0;
            this.pictures = new Image[3];
            this.pictures[0] = Image.FromFile("../../img/door2_closed.jpg");
            this.pictures[1] = Image.FromFile("../../img/door2_moving.jpg");
            this.pictures[2] = Image.FromFile("../../img/door2_opened.jpg");

            this.backgroundWorker = new BackgroundWorker();
        }

        private Image[] pictures;
        private PictureBox doorBox;
        private int state;

        private BackgroundWorker backgroundWorker;

        /// <summary>
        /// Update the door picture status with async thread safe method
        /// </summary>
        /// <param name="picture">The PictureBox to be updated</param>
        public void openDoor(PictureBox picture)
        {
            this.doorBox = picture;
            while (this.state < 3)
            {
                Thread.Sleep(1000);
                this.doorBox.Image = this.pictures[this.state];
                this.backgroundWorker.RunWorkerAsync();
                this.state++;
            }
            this.state = 0;
        }

        /// <summary>
        /// Update the door picture status with async thread safe method
        /// </summary>
        /// <param name="picture">The PictureBox to be updated</param>
        public void closeDoor(PictureBox picture)
        {
            this.doorBox = picture;
            while (this.state < 3)
            {
                Thread.Sleep(1000);
                this.doorBox.Image = this.pictures[2 - this.state];
                this.backgroundWorker.RunWorkerAsync();
                this.state++;
            }
            this.state = 0;
        }

        /// <summary>
        /// Async method that update PictureBox in a thread sage way
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e)
        {
            this.doorBox.Refresh();
        }
    }
}
