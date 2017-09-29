using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace TeacherHiring.Views.Sections.Initializers
{
    public class MapWithPinInitializer : IMapInitializer
    {
        public void Initialize(ref Map map, double latitude, double longitude, float distanceInKilometers)
        {
            Position center = new Position(latitude, longitude);
            Distance distance = Distance.FromKilometers(distanceInKilometers);
            Pin pin = new Pin
            {
                Position = center,
                Type = PinType.Place,
                Label = "Lugar",
                Address = "En este lugar se impartirá la asesoría"
            };

            map.MoveToRegion(MapSpan.FromCenterAndRadius(center, distance));
            map.Pins.Add(pin);
        }
    }
}
