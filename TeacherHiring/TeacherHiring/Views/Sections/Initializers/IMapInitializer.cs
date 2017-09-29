using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace TeacherHiring.Views.Sections.Initializers
{
    public interface IMapInitializer
    {
        void Initialize(ref Map map, double latitude, double longitude, float distanceInKilometers);
    }
}
