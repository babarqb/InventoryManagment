using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using InventoryManagment.DataTypes.Repositories;
using InventoryManagment.Models.Domains;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace InventoryManagment.Startup.ViewModels
{

    public class CategoryTabViewModel : TabViewModelBase
    {
        private readonly IUnitOfWork _context;
        private Category _editCategory;
        private BindableCollection<Category> _categories;


        public CategoryTabViewModel(IUnitOfWork context)
        {
            _context = context;
            DisplayName = "Categories";
            Categories = new BindableCollection<Category>(_context.Categories.GetAll());

            if (Categories.Count > 0)
                EditCategory = Categories[0];
        }

        public BindableCollection<Category> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                NotifyOfPropertyChange(() => Categories);
            }
        }

        public void AddNewCategory()
        {
            //EditCategory = new Category();
            _context.Categories.Add(new Category() {CategoryName = EditCategory.CategoryName});
            _context.Complete();
            Categories = new BindableCollection<Category>(_context.Categories.GetAll());

        }

        public Category EditCategory
        {
            get { return _editCategory; }
            set
            {
                _editCategory = value;
                NotifyOfPropertyChange(() => EditCategory);
            }
        }

        public async void DeleteCategory()
        {
            if (EditCategory != null)
            {
                MessageDialogResult result =
                    await DialogService.ShowMessage(
                        "Are you sure you want to delete the selected category: " + EditCategory.CategoryName +
                        "?\nPlease prudently, as undoing changes will not be possible!\n\nIf the selected category has bindings in the database, the deletion will not be possible.",
                        "Deleting " + EditCategory.CategoryName, MessageDialogStyle.AffirmativeAndNegative);

                if (result == MessageDialogResult.Affirmative)
                {
                    try
                    {
                        _context.Categories.Remove(EditCategory);
                        _context.Complete();
                        Categories = new BindableCollection<Category>(_context.Categories.GetAll());
                        EditCategory = new Category();
                    }
                    catch (Exception e)
                    {
                        DialogService.ShowMessage(
                            "Deleting the category is impossible! The category has bindings in the database!",
                            "Removal - error", MessageDialogStyle.Affirmative);
                    }

                }

            }
        }
        public void UpdateCategory()
        {
            if (EditCategory != null && EditCategory.CategoryId != 0 && !String.IsNullOrWhiteSpace(EditCategory.CategoryName))
            {
                _context.Categories.UpdateCategory(EditCategory);
                _context.Complete();
            }
            else if (EditCategory != null && EditCategory.CategoryId == 0 && !String.IsNullOrWhiteSpace(EditCategory.CategoryName))
            {
                _context.Categories.Add(EditCategory);

                _context.Complete();
            }
            else
            {
                DialogService.ShowMessage("Type the category name",
                    "Error", MessageDialogStyle.Affirmative);

            }


            Categories = new BindableCollection<Category>(_context.Categories.GetAll());
            NotifyOfPropertyChange(() => Categories);

        }


    }
}