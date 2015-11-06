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

        /// <summary>
        /// Trigger the extractation of the 3 GearSets and update the lightControl status
        /// </summary>
        public void landing()
        {
            //Creating the array of handles.
            this.lightControl.updateLightState(1, false);
            bool error = doActionGearSet();
            this.lightControl.updateLightState(2, error);
        }

        /// <summary>
        /// Trigger the retraction of the 3 GearSets and update the lightControl status
        /// </summary>
        public void takeOff()
        {
            this.lightControl.updateLightState(1, false);
            bool error = doActionGearSet();
            this.lightControl.updateLightState(0, error);
        }

        /// <summary>
        /// Thread the 3 GearSets in order for them to execute simultaneously 
        /// </summary>
        /// <returns>Boolean for error check</returns>
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

            error = this.gearsetLeftState || this.gearsetMiddleState || this.gearsetRightState;

            return error;
        }
    }
}
