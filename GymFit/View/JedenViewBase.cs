using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GymFit.View
{
    public class JedenViewBase : UserControl
    {
        static JedenViewBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(JedenViewBase), new FrameworkPropertyMetadata(typeof(JedenViewBase)));
        }
    }
}
