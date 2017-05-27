using System;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using InventoryManagment.DataTypes;
using InventoryManagment.DataTypes.Repositories;
using InventoryManagment.Models.Domains;
using MahApps.Metro.Controls.Dialogs;

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
            MobileFromQuery = new BindableCollection<Mobile>(_context.Mobiles.GetAllMobiles());
            EditMobile = new Mobile();
            SelectedPhoneType = new PhoneType() { TypeName = "SmartPhone" };
            _editMobile.StockSize = 1;
            //_editMobile.Battary = "";
            //_editMobile.RearCamera = "";
            //_editMobile.FrontCamera = "";
            //_editMobile.Os = "";
            //_editMobile.Display = "";
            //_editMobile.Battary = "";
            //_editMobile.Ram = "";
            //_editMobile.Rom = "";

            SelectedCategory = new Category();
            SelectedBrand = new Brand();
            SelectedVendor = new Vendor();
        }

        public BrandTabViewModel BrandModel
        {
            get { return _brandModel; }
            set
            {
                _brandModel = value;
                NotifyOfPropertyChange(() => BrandModel);
            }
        }

        public CategoryTabViewModel CategoryModel
        {
            get { return _categoryModel; }
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
                NotifyOfPropertyChange(() => CanDatePickerShow);
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

        private Mobile _selectedMobile;
        private bool _canDatePickerShow;

        public Mobile SelectedMobile
        {
            get { return _selectedMobile; }
            set
            {
                _selectedMobile = value;
                NotifyOfPropertyChange(() => SelectedMobile);
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

        public async void AddMobile()
        {
            if (EditMobile != null)
            {
                MessageDialogResult result =
                    await DialogService.ShowMessage(
                        "Are you sure you want to Add the selected Mobile: " + EditMobile.MobileModel +
                        "?\nPlease prudently, as editing changes will be possible!\n\nFor save editing later modify changes and press Edit/Save button",
                        "Adding " + EditMobile.MobileModel, MessageDialogStyle.AffirmativeAndNegative);

                if (result == MessageDialogResult.Affirmative)
                {
                    try
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
                            RearCamera = string.IsNullOrEmpty(EditMobile.RearCamera)
                                ? "--"
                                : EditMobile.RearCamera + "MP",
                            FrontCamera = string.IsNullOrEmpty(EditMobile.FrontCamera)
                                ? "--"
                                : EditMobile.FrontCamera + "MP",
                            Ram = string.IsNullOrEmpty(EditMobile.Ram) ? "--" : EditMobile.Ram + "GB",
                            Rom = string.IsNullOrEmpty(EditMobile.Rom) ? "--" : EditMobile.Rom + "GB",
                            Display = string.IsNullOrEmpty(EditMobile.Display) ? "--" : EditMobile.Display + " inch",
                            StockSize = 1,
                            Os = string.IsNullOrEmpty(EditMobile.Os) ? "--" : EditMobile.Os,
                            MobilePrice = EditMobile.MobilePrice,
                            Cpu = string.IsNullOrEmpty(EditMobile.Cpu) ? "--" : EditMobile.Cpu + "Ghz",
                            Condition = SelectedCondition.ConditionName,
                            MobileRetailPrice = EditMobile.MobileRetailPrice,
                            Brand = SelectedBrand,
                            Category = SelectedCategory,
                            Vendor = SelectedVendor,
                            Battary = string.IsNullOrEmpty(EditMobile.Battary) ? "--" : EditMobile.Battary + "mAh"
                        });
                        _context.Complete();
                        MobileFromQuery = new BindableCollection<Mobile>(_context.Mobiles.GetAll());
                        //NotifyOfPropertyChange(()=> );
                        await DialogService.ShowMessage(
                            "Adding Successfully: " + EditMobile.MobileModel + " into database.!!!", "Result",
                            MessageDialogStyle.Affirmative);
                        EditMobile = new Mobile();
                    }
                    catch (Exception e)
                    {
                        await DialogService.ShowMessage(
                            "Adding the new Mobile is not possible! Please fill all the filed carefully and try agian.",
                            "Adding " + EditMobile.MobileModel + "have some issue - Error",
                            MessageDialogStyle.Affirmative);
                    }
                }
            }


        }

        public void SearchByModel()
        {
            if (!string.IsNullOrEmpty(EditMobile.MobileModel))
            {
                MobileFromQuery = new BindableCollection<Mobile>(_context.Mobiles.Find(m => m.MobileModel.ToUpper()
                    .Contains(EditMobile.MobileModel.ToUpper()) && m.MobileModel != "--"));
                EditMobile.MobileModel = "";

            }
            else
            {
                MobileFromQuery = new BindableCollection<Mobile>(_context.Mobiles.GetAllMobiles());
                NotifyOfPropertyChange(() => EditMobile);
            }
        }

        public bool CanDatePickerShow
        {
            get { return !CanEditMobile; }
            set
            {
                _canDatePickerShow = value;
                NotifyOfPropertyChange(() => CanDatePickerShow);

            }
        }

        public void SearchByCategory()
        {
            if (!string.IsNullOrEmpty(SelectedCategory.CategoryName))
            {
                MobileFromQuery =
                    new BindableCollection<Mobile>(
                        _context.Mobiles.Find(m => m.Category.CategoryName == SelectedCategory.CategoryName && m.MobileModel != "--"));
                NotifyOfPropertyChange(() => MobileFromQuery);
            }
            else
            {
                MobileFromQuery = new BindableCollection<Mobile>(_context.Mobiles.GetAllMobiles());
                NotifyOfPropertyChange(() => SelectedCategory);
            }
        }

        public void SearchByVendor()
        {
            if (!string.IsNullOrEmpty(SelectedVendor.VendorName))
            {
                MobileFromQuery =
                    new BindableCollection<Mobile>(
                        _context.Mobiles.Find(m => m.Vendor.VendorName == SelectedVendor.VendorName && m.MobileModel != "--"));
                NotifyOfPropertyChange(() => MobileFromQuery);
            }
            else
            {
                MobileFromQuery = new BindableCollection<Mobile>(_context.Mobiles.GetAllMobiles());
                NotifyOfPropertyChange(() => SelectedVendor);
            }
        }

        public void SearchByBrand()
        {
            if (!string.IsNullOrEmpty(SelectedBrand.BrandName))
            {
                MobileFromQuery =
                    new BindableCollection<Mobile>(
                        _context.Mobiles.Find(m => m.Brand.BrandName == SelectedBrand.BrandName && m.MobileModel != "--"));
                NotifyOfPropertyChange(() => MobileFromQuery);
            }
            else
            {
                MobileFromQuery = new BindableCollection<Mobile>(_context.Mobiles.GetAllMobiles());
                NotifyOfPropertyChange(() => SelectedBrand);
            }
        }

        public void AllMobiles()
        {
            MobileFromQuery = new BindableCollection<Mobile>(_context.Mobiles.GetAllMobiles());
        }

        public async void UpdateMobile()
        {
            if (EditMobile != null)
            {

                MessageDialogResult result =
                    await DialogService.ShowMessage(
                        "Are you sure you want to save update the selected Mobile: " + EditMobile.MobileModel +
                        "?\nPlease prudently, as editing changes will be possible!\n\nFor save editing later modify changes and press Edit/Save button",
                        "Adding " + EditMobile.MobileModel, MessageDialogStyle.AffirmativeAndNegative);
                if (result == MessageDialogResult.Affirmative)
                {
                    try
                    {
                        EditMobile.CategoryId = SelectedCategory.CategoryId;
                        EditMobile.BrandId = SelectedBrand.BrandId;
                        EditMobile.VendorId = SelectedVendor.VendorId;
                        EditMobile.Type = SelectedPhoneType.TypeName;
                        EditMobile.Condition = SelectedCondition.ConditionName;
                        _context.Mobiles.UpdateEditMobile(EditMobile.MobileId);
                        _context.Complete();
                        MobileFromQuery = new BindableCollection<Mobile>(_context.Mobiles.GetAllMobiles());
                        NotifyOfPropertyChange(() => SelectedMobile);
                        //NotifyOfPropertyChange(()=>SelectedBrand);
                        //NotifyOfPropertyChange(()=>SelectedVendor);
                        //NotifyOfPropertyChange(()=>SelectedPhoneType);
                        //NotifyOfPropertyChange(()=>SelectedCondition);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }

            }
        }

        public void GetProductByImei1()
        {
            EditMobile = _context.Mobiles.Find(m => m.Imei1.Contains(EditMobile.Imei1))
                .FirstOrDefault();
            //EditMobile.CategoryId = SelectedCategory.CategoryId;
            //EditMobile.BrandId = SelectedBrand.BrandId;
            //EditMobile.VendorId = SelectedVendor.VendorId;

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