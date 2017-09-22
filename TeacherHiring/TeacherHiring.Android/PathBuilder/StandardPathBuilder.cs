using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DataAccess.Implementations;
using System.IO;

namespace TeacherHiring.Droid.PathBuilder
{
    public class StandardPathBuilder : IPathBuilder
    {
        public string Build(string fileName)
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}