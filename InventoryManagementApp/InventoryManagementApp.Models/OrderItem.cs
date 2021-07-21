using InventoryManagementApp.Models.Base;

namespace InventoryManagementApp.Models
{
    public class OrderItem : NotifyPropertyChangedBase
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Product
        /// </summary>
        public Product Product { get; set; }

        private int _orderQuantity;
        /// <summary>
        /// Gets or sets the Order Quantity
        /// </summary>
        public int OrderQuantity
        {
            get { return _orderQuantity; }
            set
            {
                _orderQuantity = value;
                OnPropertyChanged(nameof(OrderQuantity));
            }
        }
    }
}
