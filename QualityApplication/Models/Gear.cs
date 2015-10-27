using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

public class Gear
{
	public Gear()
	{
        this.speed = 5000;
        this.pictureStepOne = "../../img/gear2_moving.jpg";
        this.pictureStepTwo = "../../img/gear2_extracted.jpg";
    }

    private int speed;

    private String pictureStepOne;

    private String pictureStepTwo;

    /// Methodes
    /// 

    /// Change picturebox image and refresh display
    /// 
    private void changePictureState(PictureBox picture)
    {
        Thread.Sleep(1000);
        picture.Image = Image.FromFile("../../img/gear2_moving.jpg");
        picture.Refresh();
        Thread.Sleep(3000);
        picture.Image = Image.FromFile("../../img/gear2_extracted.jpg");
    }
}
