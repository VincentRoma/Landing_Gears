using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QualityApplication.Models
{
    class GearSet
    {
        public GearSet(PictureBox gearBox, PictureBox doorBox)
        {
            this.door = new Door();
            this.gear = new Gear();
            this.gearSetState = 0;
            this.gearBox = gearBox;
            this.doorBox = doorBox;
        }

        private Door door;
        private Gear gear;
        private int gearSetState;
        private PictureBox gearBox;
        private PictureBox doorBox;

        public bool actionGearSet()
        {
            if (this.gearSetState == 0)
            {
                this.door.openDoor(this.doorBox);
                this.gear.extractGear(this.gearBox);
                this.door.closeDoor(this.doorBox);
                this.gearSetState = 1;
            }
            else
            {
                this.door.openDoor(this.doorBox);
                this.gear.retractGear(this.gearBox);
                this.door.closeDoor(this.doorBox);
                this.gearSetState = 0;
            }
            return false;
        }
    }
}
