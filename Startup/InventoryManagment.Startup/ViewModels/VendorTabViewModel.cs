using Caliburn.Micro;
using InventoryManagment.DataTypes.Repositories;
using InventoryManagment.Models.Domains;

namespace InventoryManagment.Startup.ViewModels
{
    public class VendorTabViewModel : TabViewModelBase
    {
        private BindableCollection<Vendor> _vendors;
        private Vendor _editVendor;

        public VendorTabViewModel(IUnitOfWork context)
        {
            DisplayName = "Vendors";
            Vendors = new BindableCollection<Vendor>(context.Vendors.GetAll());
        }

        public BindableCollection<Vendor> Vendors
        {
            get { return _vendors; }
            set
            {
                _vendors = value;
                NotifyOfPropertyChange(() => Vendors);
            }
        }

        public Vendor EditVendor
        {
            get { return _editVendor; }
            set
            {
                _editVendor = value;
                NotifyOfPropertyChange(() => EditVendor);
            }
        }
    }
}