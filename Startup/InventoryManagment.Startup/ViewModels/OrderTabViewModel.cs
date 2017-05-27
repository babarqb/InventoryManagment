using System;
using System.Linq;
using Caliburn.Micro;
using InventoryManagment.DataTypes.Repositories;
using InventoryManagment.Models.Domains;

namespace InventoryManagment.Startup.ViewModels
{
    public class OrderTabViewModel : TabViewModelBase
    {


        private readonly IUnitOfWork _context;

        private MobileTabViewModel _mobileModel;
        private AccessoryTabViewModel _accessoryModel;
        private BindableCollection<PurchaseLineItem> _purchasseLineItems;

        public OrderTabViewModel(IUnitOfWork context, MobileTabViewModel mobileModel,
            AccessoryTabViewModel accessoryModel)
        {
            MobileModel = mobileModel;
            _context = context;
            AccessoryModel = accessoryModel;
            DisplayName = "Orders";
            MobileModel.SelectedPhoneType = new PhoneType() { TypeName = "SmartPhone" };
            MobileModel.EditMobile.Category = new Category();
            MobileModel.EditMobile.Brand = new Brand();
            MobileModel.EditMobile.Vendor = new Vendor();
            //MobileModel.SelectedVendor = new Vendor();
            //MobileModel.SelectedCategory = new Category();
            //MobileModel.SelectedBrand = new Brand();
            MobileModel.EditMobile = new Mobile();
            EditPurchaseOrder = new PurchaseOrder();


            //PurchaseLineItems = new BindableCollection<PurchaseLineItem>(_context.PurchaseLineItems.Find(po => po.PurchaseOrder.BillNo == EditPurchaseOrder.BillNo));
            PurchaseLineItems = new BindableCollection<PurchaseLineItem>(_context.PurchaseLineItems.GetAllItems());
            PurchaseOrders = new BindableCollection<PurchaseOrder>(_context.PurchaseOrders.GetAll());
        }
        public MobileTabViewModel MobileModel
        {
            get { return _mobileModel; }
            set
            {
                _mobileModel = value;
                NotifyOfPropertyChange(() => MobileModel);
            }
        }

        public AccessoryTabViewModel AccessoryModel
        {
            get { return _accessoryModel; }
            set
            {
                _accessoryModel = value;
                NotifyOfPropertyChange(() => AccessoryModel);
            }
        }

        public void AddMobileIntoPurchaseOrderLineItems()
        {
            if (MobileModel.EditMobile != null)
            {

                _context.Mobiles.Add(new Mobile()
                {
                    Imei1 = MobileModel.EditMobile.Imei1,
                    Imei2 = MobileModel.EditMobile.Imei2,
                    VendorId = MobileModel.SelectedVendor.VendorId,
                    CategoryId = MobileModel.SelectedCategory.CategoryId,
                    BrandId = MobileModel.SelectedBrand.BrandId,
                    Type = MobileModel.SelectedPhoneType.TypeName,
                    WarrantyVoid = MobileModel.EditMobile.WarrantyVoid,
                    MobileModel = MobileModel.EditMobile.MobileModel,
                    RearCamera = string.IsNullOrEmpty(MobileModel.EditMobile.RearCamera)
                        ? "--"
                        : MobileModel.EditMobile.RearCamera + "MP",
                    FrontCamera = string.IsNullOrEmpty(MobileModel.EditMobile.FrontCamera)
                        ? "--"
                        : MobileModel.EditMobile.FrontCamera + "MP",
                    Ram = string.IsNullOrEmpty(MobileModel.EditMobile.Ram) ? "--" : MobileModel.EditMobile.Ram + "GB",
                    Rom = string.IsNullOrEmpty(MobileModel.EditMobile.Rom) ? "--" : MobileModel.EditMobile.Rom + "GB",
                    Display = string.IsNullOrEmpty(MobileModel.EditMobile.Display)
                        ? "--"
                        : MobileModel.EditMobile.Display + " inch",
                    StockSize = 1,
                    Os = string.IsNullOrEmpty(MobileModel.EditMobile.Os) ? "--" : MobileModel.EditMobile.Os,
                    MobilePrice = MobileModel.EditMobile.MobilePrice,
                    Cpu = string.IsNullOrEmpty(MobileModel.EditMobile.Cpu) ? "--" : MobileModel.EditMobile.Cpu + "Ghz",
                    Condition = MobileModel.SelectedCondition.ConditionName,
                    MobileRetailPrice = MobileModel.EditMobile.MobileRetailPrice,
                    Brand = MobileModel.SelectedBrand,
                    Category = MobileModel.SelectedCategory,
                    Vendor = MobileModel.SelectedVendor,
                    Battary = string.IsNullOrEmpty(MobileModel.EditMobile.Battary)
                        ? "--"
                        : MobileModel.EditMobile.Battary + "mAh"
                });

                _context.Complete();

                var mobile = _context.Mobiles.Find(m => m.Imei1 == MobileModel.EditMobile.Imei1).First();
                var pOrder = _context.PurchaseOrders.Find(po => po.BillNo == EditPurchaseOrder.BillNo).First();
                var acccesory = _context.Accessories.Find(a => a.AccessoryModel == "--").First();
                if (EditPurchaseOrder.BillNo != null && mobile.Imei1 == MobileModel.EditMobile.Imei1)
                {
                    _context.PurchaseLineItems.Add(new PurchaseLineItem
                    {
                        PurchaseOrderId = pOrder.PurchaseOrderId,
                        AccessoryId = acccesory.AccessoryId,
                        MobileId = mobile.MobileId,
                        Quantity = mobile.StockSize,
                        UnitPrice = mobile.MobilePrice,
                        RetailPrice = mobile.MobileRetailPrice,
                        TotalPrice = mobile.MobilePrice * mobile.StockSize,
                        Accessory = acccesory,
                        Mobile = mobile,
                        PurchaseOrder = pOrder
                    });
                    _context.Complete();
                }
                PurchaseLineItems = new BindableCollection<PurchaseLineItem>(_context.PurchaseLineItems.Find(po => po.PurchaseOrder.BillNo == EditPurchaseOrder.BillNo));

            }
        }

        private void InsertDefaultMobileAndAccesory()
        {
            var tempAccessory = new Accessory()
            {
                //AccessoryType = new AccessoryType(),
                UnitPrice = 0,
                TotalPrice = 0,
                RetailUnitPrice = 0,
                //Category = new Category(),
                CategoryId = _context.Categories.Get(1).CategoryId,
                //Brand = new Brand(),
                BrandId = _context.Brands.Get(1).BrandId,
                StockSize = 0,
                AccessoryModel = "--",
                //Vendor = new Vendor(),
                VendorId = _context.Vendors.Get(1).VendorId,
                AccessoryTypeId = _context.AccessoryTypes.Get(1).AccessoryTypeId,
                AccessoryCode = "--"
            };
            var tempMob = new Mobile()
            {
                MobileModel = "--",
                //Category = new Category(),
                CategoryId = _context.Categories.Get(1).CategoryId,
                //Brand = new Brand(),
                BrandId = _context.Brands.Get(1).BrandId,
                //Vendor = new Vendor(),
                VendorId = _context.Vendors.Get(1).VendorId,
                Imei1 = "--",
                Imei2 = "--",
                Condition = "--",
                Type = "--",
                Ram = "--",
                Rom = "--",
                Battary = "--",
                Cpu = "--",
                MobilePrice = 0,
                MobileRetailPrice = 0,
                StockSize = 0,
                Display = "--",
                Os = "--",
                RearCamera = "--",
                FrontCamera = "--",
                WarrantyVoid = DateTime.Now,
            };
            if (_context.Accessories.Find(m => m.AccessoryModel == "--").FirstOrDefault() == null &&
                _context.Mobiles.Find(m => m.MobileModel == "--").FirstOrDefault() == null)
            {
                _context.Accessories.Add(tempAccessory);
                _context.Mobiles.Add(tempMob);
                _context.Complete();
            }
        }

        public BindableCollection<PurchaseLineItem> PurchaseLineItems
        {
            get { return _purchasseLineItems; }
            set
            {
                _purchasseLineItems = value;
                NotifyOfPropertyChange(() => PurchaseLineItems);
            }
        }
        private PurchaseOrder _editPurchaseOrder;

        public PurchaseOrder EditPurchaseOrder
        {
            get { return _editPurchaseOrder; }
            set
            {
                _editPurchaseOrder = value;
                NotifyOfPropertyChange(() => EditPurchaseOrder);
            }
        }
        private bool _canEditPurchaseOrder = true;

        public bool CanEditPurchaseOrder
        {
            get { return _canEditPurchaseOrder; }
            set
            {
                _canEditPurchaseOrder = value;
                NotifyOfPropertyChange(() => CanEditPurchaseOrder);
            }
        }

        public void CreatePOrder()
        {
            if (EditPurchaseOrder != null)
            {
                InsertDefaultMobileAndAccesory();
                if (_context.PurchaseOrders.Find(po => po.BillNo == EditPurchaseOrder.BillNo).FirstOrDefault() != null)
                {
                   var oldOrder = _context.PurchaseOrders.Find(po => po.BillNo == EditPurchaseOrder.BillNo).FirstOrDefault();

                    if (oldOrder != null)
                    {
                        oldOrder.VendorId = MobileModel.SelectedVendor.VendorId;
                        oldOrder.AmountPay = EditPurchaseOrder.AmountPay;
                        oldOrder.BillNo = EditPurchaseOrder.BillNo;
                        oldOrder.Vendor = MobileModel.SelectedVendor;
                        oldOrder.PurchaseOrderDate = EditPurchaseOrder.PurchaseOrderDate;
                    }
                    _context.Complete();
                }
                else { 
                _context.PurchaseOrders.Add(new PurchaseOrder
                {
                    VendorId = MobileModel.SelectedVendor.VendorId,
                    AmountPay = EditPurchaseOrder.AmountPay,
                    BillNo = EditPurchaseOrder.BillNo,
                    Vendor = MobileModel.SelectedVendor,
                    PurchaseOrderDate = EditPurchaseOrder.PurchaseOrderDate
                });
                _context.Complete();
                }
                CanEditPurchaseOrder = false;
                CanAddPurchaseOrder = true;
            }

        }

        private PurchaseLineItem _purchaseLineItem;

        public PurchaseLineItem PurchaseLineItem
        {
            get { return _purchaseLineItem; }
            set
            {
                _purchaseLineItem = value;
                NotifyOfPropertyChange(() => PurchaseLineItem);
            }
        }
        private bool _canAddPurchaseOrder = false;
        private BindableCollection<PurchaseOrder> _purchaseOrders;
        private PurchaseOrder _selectedPurchaseOrder;

        public bool CanAddPurchaseOrder
        {
            get { return _canAddPurchaseOrder; }
            set
            {
                _canAddPurchaseOrder = value;
                NotifyOfPropertyChange(() => CanAddPurchaseOrder);
            }
        }

        public void NewPurchaseOrder()
        {
            EditPurchaseOrder = new PurchaseOrder();
            MobileModel.EditMobile = new Mobile();
            MobileModel.SelectedCategory = MobileModel.EditMobile.Category;
            MobileModel.SelectedBrand = MobileModel.EditMobile.Brand;

            MobileModel.SelectedVendor = MobileModel.EditMobile.Vendor;
            MobileModel.SelectedPhoneType = MobileModel.SelectedPhoneType;
            MobileModel.SelectedCondition = MobileModel.SelectedCondition;
            PurchaseLineItem = new PurchaseLineItem();
            CanEditPurchaseOrder = true;
            CanAddPurchaseOrder = false;
            PurchaseLineItems = new BindableCollection<PurchaseLineItem>(_context.PurchaseLineItems.GetAllItems());

        }

        public void AddAccessory()
        {
            if (AccessoryModel.EditAccessory != null)
            {
                _context.Accessories.Add(new Accessory
                {
                    AccessoryType = AccessoryModel.SelectedAccessory,
                    AccessoryTypeId = AccessoryModel.EditAccessory.AccessoryTypeId,
                    UnitPrice = AccessoryModel.EditAccessory.UnitPrice,
                    TotalPrice = AccessoryModel.EditAccessory.UnitPrice * AccessoryModel.EditAccessory.StockSize,
                    RetailUnitPrice = AccessoryModel.EditAccessory.RetailUnitPrice,
                    StockSize = AccessoryModel.EditAccessory.StockSize,
                    AccessoryModel = AccessoryModel.EditAccessory.AccessoryModel,
                    AccessoryCode = AccessoryModel.EditAccessory.AccessoryCode,
                    BrandId = MobileModel.SelectedBrand.BrandId,
                    VendorId = MobileModel.SelectedVendor.VendorId,
                    CategoryId = MobileModel.SelectedCategory.CategoryId,
                    Brand = MobileModel.SelectedBrand,
                    Vendor = MobileModel.SelectedVendor,
                    Category = MobileModel.SelectedCategory
                });
                _context.Complete();
                var mob = _context.Mobiles.Find(m => m.MobileModel == "--").First();
                var accessory = _context.Accessories.Find(a => a.AccessoryCode == AccessoryModel.EditAccessory.AccessoryCode).First();
                var pOrder = _context.PurchaseOrders.Find(po => po.BillNo == EditPurchaseOrder.BillNo).First();

                if (EditPurchaseOrder.BillNo != null && mob.MobileModel == "--")
                {
                    _context.PurchaseLineItems.Add(new PurchaseLineItem
                    {
                        PurchaseOrderId = pOrder.PurchaseOrderId,
                        AccessoryId = accessory.AccessoryId,
                        MobileId = mob.MobileId,
                        Quantity = accessory.StockSize,
                        UnitPrice = accessory.UnitPrice,
                        RetailPrice = accessory.RetailUnitPrice,
                        TotalPrice = accessory.UnitPrice * accessory.StockSize,
                        Accessory = accessory,
                        Mobile = mob,
                        PurchaseOrder = pOrder
                    });
                    _context.Complete();
                }
                PurchaseLineItems = new BindableCollection<PurchaseLineItem>(_context.PurchaseLineItems.Find(po => po.PurchaseOrder.BillNo == EditPurchaseOrder.BillNo));
            }
        }

        public BindableCollection<PurchaseOrder> PurchaseOrders
        {
            get { return _purchaseOrders; }
            set
            {
                _purchaseOrders = value;
                NotifyOfPropertyChange(() => PurchaseOrders);
            }
        }

        public PurchaseOrder SelectedPurchaseOrder
        {
            get { return _selectedPurchaseOrder; }
            set
            {
                _selectedPurchaseOrder = value;
                NotifyOfPropertyChange(() => SelectedPurchaseOrder);
            }
        }
    }
}