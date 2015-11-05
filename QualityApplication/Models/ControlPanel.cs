using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QualityApplication.Models
{
    class ControlPanel
    {
        public ControlPanel(GearSet gearsetLeft, GearSet gearsetMiddle, GearSet gearsetRight, LightControl lightControl)
        {
            this.lightControl = lightControl;
            this.gearsetLeft = gearsetLeft;
            this.gearsetMiddle = gearsetMiddle;
            this.gearsetRight = gearsetRight;
        }

        private LightControl lightControl;
        private GearSet gearsetLeft;
        private GearSet gearsetMiddle;
        private GearSet gearsetRight;
        private bool gearsetLeftState;
        private bool gearsetRightState;
        private bool gearsetMiddleState;

        public void landing()
        {
            //Creating the array of handles.
            this.lightControl.updateLightState(1, false);
            bool error = doActionGearSet();
            this.lightControl.updateLightState(2, error);
        }

        public void takeOff()
        {
            this.lightControl.updateLightState(1, false);
            bool error = doActionGearSet();
            this.lightControl.updateLightState(0, error);
        }

        private bool doActionGearSet()
        {
            bool error = false;

            Task gearsetLeftTread = Task.Factory.StartNew(() =>
            {
                this.gearsetLeftState = gearsetLeft.actionGearSet();
            });
            Task gearsetMiddleTread = Task.Factory.StartNew(() =>
            {
                this.gearsetMiddleState = gearsetMiddle.actionGearSet();
            });
            Task gearsetRightTread = Task.Factory.StartNew(() =>
            {
                this.gearsetRightState = gearsetRight.actionGearSet();
            });
            Task.WaitAll(gearsetLeftTread, gearsetMiddleTread, gearsetRightTread);

            return error;
        }
    }
}
