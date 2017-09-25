using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace TeacherHiring.CustomControls
{
    public class CenteredPinMap : Map
    {
        private Pin centeredPin;
        private bool isInitialize = false;

        public CenteredPinMap()
            : base()
        {

        }

        public void Initialize()
        {
            if (!isInitialize)
            {
                initializePin();
                initializeChangeEvent();
                isInitialize = true;
            }
        }

        private void initializePin()
        {
            centeredPin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(0, 0),
                Label = "Lugar",
                Address = "En este lugar se impartirá la asesoría"
            };

            Pins.Add(centeredPin);
        }

        private void initializeChangeEvent()
        {
            PropertyChanged += CenteredPinMap_PropertyChanged;
        }

        private void CenteredPinMap_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (VisibleRegion != null)
            {
                centeredPin.Position = ((CenteredPinMap)sender).VisibleRegion.Center;

                Pins.Clear();
                Pins.Add(centeredPin);
            }
        }
    }
}
