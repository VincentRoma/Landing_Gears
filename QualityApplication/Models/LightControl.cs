using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QualityApplication.Models
{
    class LightControl
    {
        public LightControl(PictureBox lightBox)
        {
            this.lightState = 0;
            this.lightBox = lightBox;
            this.lights = new Image[4];
            this.lights[0] = Image.FromFile("../../img/feu_vide.jpg");
            this.lights[1] = Image.FromFile("../../img/feu_orange.jpg");
            this.lights[2] = Image.FromFile("../../img/feu_vert.jpg");
            this.lights[3] = Image.FromFile("../../img/feu_rouge.jpg");
        }

        private int lightState;
        private PictureBox lightBox;
        private Image[] lights;

        public void updateLightState(int state, bool error)
        {
            if (!error)
            {
                this.lightBox.Image = this.lights[state];
                this.lightBox.Refresh();
                this.lightState = state;
            }
            else
            {
                this.lightBox.Image = this.lights[3];
                this.lightBox.Refresh();
                this.lightState = 3;
            }
        }
    }
}
