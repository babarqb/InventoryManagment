using Caliburn.Micro;
using InventoryManagment.DataTypes.Repositories;
using InventoryManagment.Models.Domains;

namespace InventoryManagment.Startup.ViewModels
{
    public class AccessoryTabViewModel : TabViewModelBase
    {
        private readonly IUnitOfWork _context;
        private Accessory _editAccessory;
        private BindableCollection<AccessoryType> _accessories;
        private AccessoryType _selectedAccessory;

        public AccessoryTabViewModel(IUnitOfWork context)
        {
            _context = context;
            DisplayName = "Accessory";
            Accessories = new BindableCollection<AccessoryType>(_context.AccessoryTypes.GetAll());
            EditAccessory = new Accessory();
            SelectedAccessory = new AccessoryType();
        }

        public Accessory EditAccessory
        {
            get { return _editAccessory; }
            set
            {
                _editAccessory = value;
                NotifyOfPropertyChange(() => EditAccessory);
            }
        }

        public BindableCollection<AccessoryType> Accessories
        {
            get { return _accessories; }
            set
            {
                _accessories = value;
                NotifyOfPropertyChange(() => Accessories);
            }
        }

        public AccessoryType SelectedAccessory
        {
            get { return _selectedAccessory; }
            set
            {
                _selectedAccessory = value;
                NotifyOfPropertyChange(() => SelectedAccessory);
            }
        }
    }
}