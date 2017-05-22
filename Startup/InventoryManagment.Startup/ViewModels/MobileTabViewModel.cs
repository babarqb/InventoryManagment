using System;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using InventoryManagment.DataTypes;
using InventoryManagment.DataTypes.Repositories;
using InventoryManagment.Models.Domains;

namespace InventoryManagment.Startup.ViewModels
{
    public class MobileTabViewModel : TabViewModelBase
    {
        private readonly IUnitOfWork _context;
        private CategoryTabViewModel _categoryModel;
        private Mobile _editMobile;

        private VendorTabViewModel _vendorModel;
        private BindableCollection<PhoneCondition> _phoneConditions;
        private BindableCollection<PhoneType> _phoneTypes;
        private bool _canEditMobile;
        private BrandTabViewModel _brandModel;
        private Vendor _selectedVendor;
        private bool _canPhoneTypes;
        private PhoneType _selectedPhoneType;
        private Category _selectedCategory;
        private Brand _selectedBrand;
        private PhoneCondition _selectedCondition;

        public MobileTabViewModel(IUnitOfWork context,
            CategoryTabViewModel categoryModel,
            VendorTabViewModel vendorModel,
            BrandTabViewModel brandModel)
        {
            _context = context;
            CategoryModel = categoryModel;
            VendorModel = vendorModel;
            BrandModel = brandModel;
            DisplayName = "Mobiles";
            MobileFromQuery = new BindableCollection<Mobile>(_context.Mobiles.GetAll());
            EditMobile = new Mobile();
            SelectedPhoneType = new PhoneType() { TypeName = "SmartPhone" };
            _editMobile.Cpu = "0";
            _editMobile.Battary = "0";
            _editMobile.RearCamera = "0";
            _editMobile.FrontCamera = "0";
            _editMobile.Os = "0";
            _editMobile.Display = "0";
            _editMobile.Battary = "0";
            _editMobile.Ram = "0";
            _editMobile.Rom = "0";
        }

        public BrandTabViewModel BrandModel
        {
            get
            {
                return _brandModel;
            }
            set
            {
                _brandModel = value;
                NotifyOfPropertyChange(() => BrandModel);
            }
        }
        public CategoryTabViewModel CategoryModel
        {
            get
            {
                return _categoryModel;
            }
            set
            {
                _categoryModel = value;
                NotifyOfPropertyChange(() => CategoryModel);
            }
        }
        public VendorTabViewModel VendorModel
        {
            get { return _vendorModel; }
            set
            {
                _vendorModel = value;
                NotifyOfPropertyChange(() => VendorModel);
            }
        }
        private BindableCollection<Mobile> _mobileFromQuery;

        public BindableCollection<Mobile> MobileFromQuery
        {
            get { return _mobileFromQuery; }
            set
            {
                _mobileFromQuery = value;
                NotifyOfPropertyChange(() => MobileFromQuery);
            }
        }

        public Mobile EditMobile
        {
            get { return _editMobile; }
            set
            {
                _editMobile = value;
                NotifyOfPropertyChange(() => EditMobile);
                NotifyOfPropertyChange(() => CanEditMobile);
            }
        }
        public bool CanEditMobile
        {
            get
            {
                //if (EditMobile.Type == "SmartPhone")
                //{
                //_canEditMobile = true;
                //}
                return SelectedPhoneType.TypeName == "SmartPhone";
            }
            set
            {

                _canEditMobile = value;
                NotifyOfPropertyChange(() => CanEditMobile);
            }
        }
        public bool CanPhoneTypes
        {
            get { return EditMobile.Type == "FeaturePhone"; }
            set
            {
                _canPhoneTypes = value;
                NotifyOfPropertyChange(() => CanPhoneTypes);
            }
        }

        public PhoneType SelectedPhoneType
        {
            get { return _selectedPhoneType; }
            set
            {
                _selectedPhoneType = value;
                NotifyOfPropertyChange(() => SelectedPhoneType);
                NotifyOfPropertyChange(() => CanEditMobile);
            }
        }
        public Vendor SelectedVendor
        {
            get { return _selectedVendor; }
            set
            {
                _selectedVendor = value;
                NotifyOfPropertyChange(() => SelectedVendor);
            }
        }

        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                NotifyOfPropertyChange(() => SelectedCategory);
            }
        }
        public Brand SelectedBrand
        {
            get { return _selectedBrand; }
            set
            {
                _selectedBrand = value;
                NotifyOfPropertyChange(() => SelectedBrand);
            }
        }

        public PhoneCondition SelectedCondition
        {
            get { return _selectedCondition; }
            set
            {
                _selectedCondition = value;
                NotifyOfPropertyChange(() => SelectedCondition);
            }
        }
        public BindableCollection<PhoneType> PhoneTypes
        {
            get
            {
                return new BindableCollection<PhoneType>()
                {
                    new PhoneType() {PhoneTypeId = 1, TypeName = "FeaturePhone"},
                    new PhoneType() {PhoneTypeId = 2, TypeName = "SmartPhone"}
                };
            }
            set
            {
                _phoneTypes = value;
                NotifyOfPropertyChange(() => PhoneTypes);
            }
        }
        public BindableCollection<PhoneCondition> PhoneConditions
        {
            get
            {
                return new BindableCollection<PhoneCondition>()
                {
                    new PhoneCondition() {ConditionId = 1, ConditionName = "New"},
                    new PhoneCondition() {ConditionId = 2, ConditionName = "Used"},
                };
            }
            set
            {
                _phoneConditions = value;
                NotifyOfPropertyChange(() => PhoneConditions);
            }
        }

        public void AddMobile()
        {


            _context.Mobiles.Add(new Mobile()
            {
                Imei1 = EditMobile.Imei1,
                Imei2 = EditMobile.Imei2,
                VendorId = SelectedVendor.VendorId,
                CategoryId = SelectedCategory.CategoryId,
                BrandId = SelectedBrand.BrandId,
                Type = SelectedPhoneType.TypeName,
                WarrantyVoid = EditMobile.WarrantyVoid,
                MobileModel = EditMobile.MobileModel,
                RearCamera = EditMobile.RearCamera + "mp",
                FrontCamera = EditMobile.FrontCamera + "mp",
                Ram = EditMobile.Ram + "gb",
                Rom = EditMobile.Rom + "gb",
                Display = EditMobile.Display + "inch",
                StockSize = EditMobile.StockSize,
                Os = EditMobile.Os,
                MobilePrice = EditMobile.MobilePrice,
                Cpu = EditMobile.Cpu + "mhz",
                Condition = SelectedCondition.ConditionName,
                Brand = SelectedBrand,
                Category = SelectedCategory,
                Vendor = SelectedVendor,
                Battary = EditMobile.Battary + "mhz"
            });
            _context.Complete();
            MobileFromQuery = new BindableCollection<Mobile>(_context.Mobiles.GetAll());
            EditMobile = new Mobile();
        }

    }

    public class PhoneType
    {
        public int PhoneTypeId { get; set; }
        public string TypeName { get; set; }
    }
    public class PhoneCondition
    {
        public int ConditionId { get; set; }
        public string ConditionName { get; set; }
    }
}