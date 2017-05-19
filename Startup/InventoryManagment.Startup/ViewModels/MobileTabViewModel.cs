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
        [ImportingConstructor]
        public MobileTabViewModel(IUnitOfWork context, CategoryTabViewModel categoryModel, VendorTabViewModel vendorModel)
        {

            CategoryModel = categoryModel;
            VendorModel = vendorModel;
            DisplayName = "Mobiles";
            //CategoryModel = new CategoryTabViewModel(new UnitOfWork(new AppDbContext()));
            //LoadTypeAndCondition();
            EditMobile = new Mobile();
        }

        //private void LoadTypeAndCondition()
        //{
        //    PhoneTypes = new BindableCollection<PhoneType>()
        //    {
        //        new PhoneType() {PhoneTypeId = 1, TypeName = "FeaturePhone"},
        //        new PhoneType() {PhoneTypeId = 2, TypeName = "SmartPhone"}
        //    };
        //    PhoneConditions = new BindableCollection<PhoneCondition>
        //    {
        //        new PhoneCondition() {ConditionId = 1, ConditionName = "NewPhone"},
        //        new PhoneCondition() {ConditionId = 2, ConditionName = "BrandPhone"},
        //    };
        //}

        public BindableCollection<Mobile> MobilesFromQuery { get; set; }

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
                    new PhoneCondition() {ConditionId = 1, ConditionName = "NewPhone"},
                    new PhoneCondition() {ConditionId = 2, ConditionName = "BrandPhone"},
                };
            }
            set
            {
                _phoneConditions = value;
                NotifyOfPropertyChange(() => PhoneConditions);
            }
        }

        public Mobile EditMobile
        {
            get { return _editMobile; }
            set
            {
                _editMobile = value;
                NotifyOfPropertyChange(() => EditMobile);
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

        public PhoneType SelectedPhoneType { get; set; }

        public void AddMobile()
        {

            //var ne = new Mobile()
            //{
            //    Imei1 = EditMobile.Imei1,
            //    Imei2 = EditMobile.Imei2,
            //    CategoryId = CategoryModel.EditCategory.CategoryId,
            //    VendorId = VendorModel.EditVendor.VendorId,
            //    Type = SelectedPhoneType.TypeName,
            //    WarrantyVoid = DateTime.Now,
            //    Os = "Android 6",
            //    StockSize = 2,
            //    RearCamera = "12mp",
            //    FrontCamera = "6mp",
            //    Ram = "2GB",
            //    Rom = "8GB",
            //    Battary = "2000mhz",
            //    MobileModel = "j500",
            //    BrandId = 1,


            //};


            _context.Mobiles.Add(new Mobile()
            {
                Imei1 = EditMobile.Imei1,
                Imei2 = EditMobile.Imei2,
                CategoryId = CategoryModel.EditCategory.CategoryId,
                VendorId = VendorModel.EditVendor.VendorId,

                Type = SelectedPhoneType.TypeName,

                MobileModel = EditMobile.MobileModel,

            });

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