using InventoryManagementApp.Models.Base;
using System;
using System.Collections.ObjectModel;

namespace InventoryManagementApp.Models
{
    /// <summary>
    /// Order Model
    /// </summary>
    public class Order : NotifyPropertyChangedBase
    {
        public Order()
        {
            OrderList = new ObservableCollection<OrderItem>();
        }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the OrderTitle
        /// </summary>
        public string OrderTitle { get; set; }

        private ObservableCollection<OrderItem> _orderList;
        /// <summary>
        /// Gets or sets the list of Orders
        /// </summary>
        public ObservableCollection<OrderItem> OrderList
        {
            get { return _orderList; }
            set
            {
                _orderList = value;
                OnPropertyChanged(nameof(OrderList));
            }
        }

        /// <summary>
        /// Gets the total amount of order
        /// </summary>
        public double ToatlAmount
        {
            get
            {
                double total = 0;
                foreach (var item in OrderList)
                {
                    total += (item.OrderQuantity * item.Product.UnitPrice);
                }
                return total;
            }
        }
        public DateTime Date { get; set; } = DateTime.Now;

        private bool _isOrderPlaced;
        /// <summary>
        /// Gets or sets the IsOrderPlaced
        /// </summary>
        public bool IsOrderPlaced
        {
            get { return _isOrderPlaced; }
            set
            {
                _isOrderPlaced = value;
                OnPropertyChanged(nameof(IsOrderPlaced));
            }
        }

        /// <summary>
        /// Adds the orderitem to the OrderList
        /// </summary>
        /// <param name="product"></param>
        public void AddOrderItem(Product product)
        {
            var localProduct = product.Copy();
            OrderList.Add(new OrderItem()
            {
                Id = OrderList.Count + 1,
                Product = localProduct
            });
        }

        /// <summary>
        /// Removes the orderitem from the OrderList
        /// </summary>
        /// <param name="orderItem"></param>
        public void RemoveOrderItem(OrderItem orderItem)
        {
            if (orderItem != null)
                OrderList.Remove(orderItem);
        }


    }
}
