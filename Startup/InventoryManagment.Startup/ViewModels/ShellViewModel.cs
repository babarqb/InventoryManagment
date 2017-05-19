using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Caliburn.Micro;
using InventoryManagment.DataTypes;
using InventoryManagment.Models.Domains;
using InventoryManagment.Startup.Events;

namespace InventoryManagment.Startup.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<ITab>.Collection.OneActive, IShell
    {

        public ShellViewModel(IEnumerable<ITab> tabItems)
        {
            DisplayName = "Inventory Managment System";
            Items.AddRange(tabItems);
        }
        //[Import]
        //private IShell _shell;

        //public IShell Shell
        //{
        //    get { return _shell; }
        //    private set
        //    {
        //        _shell = value;
        //        NotifyOfPropertyChange(() => Shell);
        //    }
        //}
    }
    //[Export(typeof(IShell))]
    //public class ShellViewModel : PropertyChangedBase, IShell, IHandle<ColorEvent>
    //{
    //    private IEnumerable<CategoryModel> _category;
    //    private IEnumerable<Vendor> _vendors;

    //    public ShellViewModel()
    //    {
    //        var db = new UnitOfWork(new AppDbContext());



    //        Categories = db.Categories.GetAll();
    //        Vendors = db.Vendors.GetAll();

    //    }

    //    public IEnumerable<CategoryModel> Categories
    //    {
    //        get { return _category; }
    //        set
    //        {
    //            _category = value;
    //            NotifyOfPropertyChange(() => Categories);

    //        }
    //    }
    //    public IEnumerable<Vendor> Vendors
    //    {
    //        get { return _vendors; }
    //        set
    //        {
    //            _vendors = value;
    //            NotifyOfPropertyChange(() => Vendors);
    //        }
    //    }




    //    private int _count = 0;

    //    public int Count
    //    {
    //        get { return _count; }
    //        set
    //        {
    //            _count = value;
    //            NotifyOfPropertyChange(() => Count);
    //            NotifyOfPropertyChange(() => CanIncrementCount);
    //        }
    //    }


    //    public bool CanIncrementCount => Count < 10;

    //    public void IncrementCount()
    //    {
    //        Count++;
    //    }
    //    public void IncrementCount(int delta)
    //    {
    //        Count += delta;
    //    }

    //    [ImportingConstructor]
    //    public ShellViewModel(ColorViewModel colorModel, IEventAggregator events)
    //    {
    //        ColorModel = colorModel;
    //        events.Subscribe(this);
    //    }

    //    public ColorViewModel ColorModel { get; private set; }

    //    private SolidColorBrush _color;

    //    public SolidColorBrush Color
    //    {
    //        get { return _color; }
    //        set
    //        {
    //            _color = value;
    //            NotifyOfPropertyChange(() => Color);
    //        }
    //    }


    //    //public event PropertyChangedEventHandler PropertyChanged;

    //    //[NotifyPropertyChangedInvocator]
    //    //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    //{
    //    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    //}
    //    public void Handle(ColorEvent message)
    //    {
    //        Color = message.Color;
    //    }
    //}
}
