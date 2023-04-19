using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GymFit.View
{
    public class WszystkieViewBase : UserControl
    {
        static WszystkieViewBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WszystkieViewBase), new FrameworkPropertyMetadata(typeof(WszystkieViewBase)));
        }
    }
}
