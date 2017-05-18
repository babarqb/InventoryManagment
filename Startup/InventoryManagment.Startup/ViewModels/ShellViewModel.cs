using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using InventoryManagment.DataTypes;
using InventoryManagment.Models.Domains;

namespace InventoryManagment.Startup.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        private IEnumerable<Category> _category;
        private IEnumerable<Vendor> _vendors;

        public ShellViewModel()
        {
            var db = new UnitOfWork(new AppDbContext());



            Categories = db.Categories.GetAll();
            Vendors = db.Vendors.GetAll();

        }

        public IEnumerable<Category> Categories
        {
            get { return _category; }
            set
            {
                _category = value;
                NotifyOfPropertyChange(() => Categories);

            }
        }
        public IEnumerable<Vendor> Vendors
        {
            get { return _vendors; }
            set
            {
                _vendors = value;
                NotifyOfPropertyChange(() => Vendors);
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
