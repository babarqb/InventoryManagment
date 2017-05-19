using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Caliburn.Micro;
using InventoryManagment.Startup.Events;

namespace InventoryManagment.Startup.ViewModels
{
    [Export(typeof(ColorViewModel))]
    public class ColorViewModel : PropertyChangedBase
    {
        private readonly IEventAggregator _events;

        [ImportingConstructor]
        public ColorViewModel(IEventAggregator events)
        {
            _events = events;
        }

        public void Red()
        {
            _events.Publish(new ColorEvent(new SolidColorBrush(Colors.Red)), action => Task.Factory.StartNew(action));
        }
        public void Green()
        {
            _events.Publish(new ColorEvent(new SolidColorBrush(Colors.Green)), action => Task.Factory.StartNew(action));
        }
        public void Blue()
        {
            //Second Paremeter is for marshling the event on thread 
            _events.Publish(new ColorEvent(new SolidColorBrush(Colors.Blue)), action => Task.Factory.StartNew(action));
        }
    }
}
