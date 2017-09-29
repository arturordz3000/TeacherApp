using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TeacherHiring.Views.Sections.PageInstantiators
{
    public interface IPageInstatiator
    {
        Page Instantiate(object parameters);
    }
}
