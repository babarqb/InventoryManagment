using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using InventoryManagment.DataTypes;
using InventoryManagment.DataTypes.Repositories;
using InventoryManagment.Models.Domains;

namespace InventoryManagment.Startup.ViewModels
{
    public class BrandTabViewModel : TabViewModelBase, ITab
    {
        private IUnitOfWork _context;
        private BindableCollection<Brand> _brands;
        private Brand _editBrand;

        public BrandTabViewModel(IUnitOfWork context)
        {
            _context = context;
            //context = new UnitOfWork(new AppDbContext());
            DisplayName = "Brands";
            Brands = new BindableCollection<Brand>(context.Brands.GetAll());
            if (Brands.Count > 0)
                EditBrand = Brands[0];
        }

        public BindableCollection<Brand> Brands
        {
            get { return _brands; }
            set
            {
                _brands = value;
                NotifyOfPropertyChange(() => Brands);
            }
        }
        public Brand EditBrand
        {
            get { return _editBrand; }
            set
            {
                _editBrand = value;
                NotifyOfPropertyChange(() => EditBrand);
            }
        }
    }
}
