using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

public class Gear
{
	public Gear()
	{
        this.speed = 5000;
        this.state = 0;
        this.pictures = new Image[3];
        this.pictures[0] = Image.FromFile("../../img/gear2_retracted.jpg");
        this.pictures[1] = Image.FromFile("../../img/gear2_moving.jpg");
        this.pictures[2] = Image.FromFile("../../img/gear2_extracted.jpg");
       
        this.backgroundWorker = new BackgroundWorker();
    }

    private int speed;
    private Image[] pictures;
    private PictureBox gearBox; 
    private int state;
    private BackgroundWorker backgroundWorker;

    /// <summary>
    /// Update the Gear PictureBox status during extraction
    /// </summary>
    /// <param name="picture">The Picture Box to be updated</param>
    public void extractGear(PictureBox picture)
    {
        this.gearBox = picture;
        while (this.state < 3)
        {
            Thread.Sleep(1000);
            picture.Image = this.pictures[this.state];
            backgroundWorker.RunWorkerAsync();
            this.state++;
        }
        this.state = 0;
    }

    /// <summary>
    /// Update the Gear PictureBox status during retractation
    /// </summary>
    /// <param name="picture">The PictureBox to be update</param>
    public void retractGear(PictureBox picture)
    {
        this.gearBox = picture;
        while (this.state < 3)
        {
            Thread.Sleep(1000);
            picture.Image = this.pictures[2 - this.state];
            backgroundWorker.RunWorkerAsync();
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
        this.gearBox.Refresh();
    }
}
