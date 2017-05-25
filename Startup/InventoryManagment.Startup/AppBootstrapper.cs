using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using InventoryManagment.DataTypes;
using InventoryManagment.DataTypes.Repositories;
using InventoryManagment.Startup.ViewModels;


namespace InventoryManagment.Startup
{
    public class AppBootstrapper : BootstrapperBase
    {
        private SimpleContainer _container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container = new SimpleContainer();

            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();
            _container.Singleton<IUnitOfWork, UnitOfWork>();
            _container.Singleton<AppDbContext>();
            _container.PerRequest<IShell, ShellViewModel>();
            _container.PerRequest<CategoryTabViewModel>();
            _container.PerRequest<BrandTabViewModel>();
            _container.PerRequest<VendorTabViewModel>();
            _container.PerRequest<MobileTabViewModel>();
            _container.PerRequest<OrderTabViewModel>();
            _container.PerRequest<AccessoryTabViewModel>();
            

            _container.PerRequest<ITab, MobileTabViewModel>();
            _container.PerRequest<ITab, VendorTabViewModel>();
            _container.PerRequest<ITab, OrderTabViewModel>();
            _container.PerRequest<ITab, BrandTabViewModel>();
            _container.PerRequest<ITab, CategoryTabViewModel>();

            //_container = new SimpleContainer();

            //_container.Singleton<IWindowManager, WindowManager>();

            //_container.PerRequest<ShellViewModel>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<IShell>();
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = _container.GetInstance(service, key);
            if (instance != null)
                return instance;

            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }

}