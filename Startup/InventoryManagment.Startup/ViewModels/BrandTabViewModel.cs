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
    public class BrandTabViewModel : TabViewModelBase,ITab
    {
        private BindableCollection<Brand> _brands;

        public BrandTabViewModel(IUnitOfWork context)
        {
            //context = new UnitOfWork(new AppDbContext());
            DisplayName = "Brands";
            Brands = new BindableCollection<Brand>(context.Brands.GetAll());

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
    }
}
