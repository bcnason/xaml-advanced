using System.Collections.Generic;
using RestaurantManager.Models;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using RestaurantManager.ViewModels;


namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        public OrderViewModel()
        {
            AddItemCommand = new DelegateCommand(AddMenuItem);
            SubmitOrderCommand = new DelegateCommand(SubmitOrder);
            CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
        }

        private List<MenuItem> _menuItems;
        private MenuItem _selectedMenuItem;

        public List<MenuItem> MenuItems
        {
            get
            { return _menuItems; }

            set
            {
                if (value != null)
                {
                    _menuItems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems { get; private set; }

        public DelegateCommand AddItemCommand { get; private set; }
        
        public DelegateCommand SubmitOrderCommand { get; private set; }

        public MenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }

            set
            {
                _selectedMenuItem = value;
                NotifyPropertyChanged();
            }
        }

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

        }

        public void AddMenuItem()
        {
            this.CurrentlySelectedMenuItems.Add(this.SelectedMenuItem);
        }

        public async void SubmitOrder()
        {
            base.Repository.Orders.Add(
                new Order
                {
                    Items = this.CurrentlySelectedMenuItems.ToList(),
                    Table = base.Repository.Tables.First(),
                    Expedite = false

                }
        );
            this.CurrentlySelectedMenuItems.Clear();


            await new Windows.UI.Popups.MessageDialog("Order has been submitted").ShowAsync();

        }
        
        
        
    }
}
