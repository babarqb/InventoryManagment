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

        public OrderTabViewModel(IUnitOfWork context, MobileTabViewModel mobileModel, AccessoryTabViewModel accessoryModel)
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
            PurchaseLineItems = new BindableCollection<PurchaseLineItem>(_context.PurchaseLineItems.GetAll());
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
                //var acccesory = new Accessory()
                //{
                //    AccessoryId = 0,
                //    AccessoryType = new AccessoryType(),
                //    UnitPrice = 0,
                //    TotalPrice = 0,
                //    RetailUnitPrice = 0,
                //    Category = new Category(),
                //    CategoryId = 0,
                //    Brand = new Brand(),
                //    BrandId = 0,
                //    StockSize = 0,
                //    AccessoryModel = "Nill",
                //    Vendor = new Vendor(),
                //    VendorId = 0,
                //    AccessoryTypeId = 0
                //};
                var mobile = _context.Mobiles.Find(m => m.Imei1 == MobileModel.EditMobile.Imei1).First();
                var pOrder = _context.PurchaseOrders.Find(po => po.BillNo == EditPurchaseOrder.BillNo).First();
                var acccesory = _context.Accessories.Find(a => a.AccessoryModel == "Nill").First();
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

                PurchaseLineItems = new BindableCollection<PurchaseLineItem>(_context.PurchaseLineItems.GetAll());
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
                _context.PurchaseOrders.Add(new PurchaseOrder
                {
                    VendorId = MobileModel.SelectedVendor.VendorId,
                    AmountPay = EditPurchaseOrder.AmountPay,
                    BillNo = EditPurchaseOrder.BillNo,
                    Vendor = MobileModel.SelectedVendor,
                    PurchaseOrderDate = EditPurchaseOrder.PurchaseOrderDate
                });
                _context.Complete();
                CanEditPurchaseOrder = false;
            }

        }

    }
}