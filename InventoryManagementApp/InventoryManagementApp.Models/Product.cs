using InventoryManagementApp.Models.Base;

namespace InventoryManagementApp.Models
{
    public class Product : NotifyPropertyChangedBase
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the UnitPrice
        /// </summary>
        public double UnitPrice { get; set; }

        private int _quantity;
        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        /// <summary>
        /// Gets or sets the ImageUrl
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Copy the Product class and returns a new instance of Product with the values.
        /// </summary>
        /// <returns></returns>
        public Product Copy()
        {
            return new Product()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                UnitPrice = this.UnitPrice,
                Quantity = this.Quantity,
                ImageUrl = this.ImageUrl
            };
        }
    }
}
