using System.Collections.Generic;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class ExpediteDataManager : ViewModel
    {
        private List<Order> _orderItems;

        protected override void OnDataLoaded()
        {
            OrderItems = Repository.Orders;
        }

        public List<Order> OrderItems
        {
            get
            {
                return _orderItems;
            }

            set
            {
                if(value != null)
                _orderItems = value;
                this.NotifyPropertyChanged();
            }
        }
    }
}
