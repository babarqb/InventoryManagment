using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace InventoryManagment.Startup.Events
{
    public class ColorEvent
    {
        public SolidColorBrush Color { get; }

        public ColorEvent(SolidColorBrush color)
        {
            Color = color;
        }
    }
}
