using InventoryManagementApp.Base;
using InventoryManagementApp.MessagingService;
using InventoryManagementApp.Models;
using InventoryManagementApp.Models.Base;
using InventoryManagementApp.ProxyService;
using InventoryManagementApp.SDKs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryManagementApp.ViewModel
{
    public class MainViewModel : NotifyPropertyChangedBase
    {
        #region Local variables
        const string _orderTitleConst = "Order";
        const string appName = "Inventory Management App";
        readonly IInventoryManagementService inventoryService;
        readonly IMessagingCentre messagingCentre;
        #endregion

        #region Ctor
        public MainViewModel()
        {
            try
            {
                IsBusy = true;
                inventoryService = ProxyFactoryService.GetInventoryService();
                messagingCentre = MessagingFactoryService.GetMessagingCentre();
                _orders = new ObservableCollection<Order>() { new Order() { OrderTitle = _orderTitleConst + 1 } };
                
                // Init the commands
                _createOrderCommand = new Command(OnCreateOrderCommandExcute);
                _removeOrderCommand = new Command(OnRemoveOrderCommandExcute, OnCanRemoveOrderCommandExcute);
                _removeProductCommand = new Command(OnRemoveProductCommandExcute);
                _addToOrderCommand = new Command(OnAddToOrderCommand);
                _orderQuantityDecrementedCommand = new Command(OnOrderQuantityDecrementedCommandExcute);
                _orderQuantityIncrementedCommand = new Command(OnOrderQuantityIncrementedCommandExcute);
                _ordersSelectionChangedCommand = new Command(OnOrdersSelectionChangedCommandExcute);
                _placeOrderCommand = new Command(OnPlaceOrderCommandExcute);

                Task.Run(async () =>
                {
                    ProductList = await inventoryService.GetProducts();
                });
            }
            catch (Exception)
            {
                // Log exception.
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion

        #region Properties

        private bool _isBusy;
        /// <summary>
        /// Gets or sets IsBusy Property
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        IList<Product> _products;
        public IList<Product> ProductList
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(ProductList));
            }
        }

        ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        private int _selectedTabItemIndex;        
        public int SelectedTabItemIndex
        {
            get { return _selectedTabItemIndex; }
            set
            {
                _selectedTabItemIndex = value;
                OnPropertyChanged(nameof(SelectedTabItemIndex));
            }
        }

        #endregion

        #region Commands

        private ICommand _createOrderCommand;
        public ICommand CreateOrderCommand
        {
            get { return _createOrderCommand; }
        }

        private ICommand _removeOrderCommand;
        public ICommand RemoveOrderCommand
        {
            get { return _removeOrderCommand; }
        }

        private ICommand _addToOrderCommand;
        public ICommand AddToOrderCommand
        {
            get { return _addToOrderCommand; }
        }

        private ICommand _removeProductCommand;
        public ICommand RemoveProductCommand
        {
            get { return _removeProductCommand; }
        }

        private ICommand _orderQuantityDecrementedCommand;
        public ICommand OrderQuantityDecrementedCommand
        {
            get { return _orderQuantityDecrementedCommand; }
        }

        private ICommand _orderQuantityIncrementedCommand;
        public ICommand OrderQuantityIncrementedCommand
        {
            get { return _orderQuantityIncrementedCommand; }
        }

        private ICommand _ordersSelectionChangedCommand;
        public ICommand OrdersSelectionChangedCommand
        {
            get { return _ordersSelectionChangedCommand; }
        }

        private ICommand _placeOrderCommand;
        public ICommand PlaceOrderCommand
        {
            get { return _placeOrderCommand; }
        }

        #endregion

        #region Command Callbacks

        private void OnCreateOrderCommandExcute(object param)
        {
            // Creates a new Order
            Orders.Add(new Order() 
            {
                Id = Orders.Count + 1,
                OrderTitle = _orderTitleConst + (Orders.Count + 1),
                Date = DateTime.Now
            });
        }

        private void OnRemoveOrderCommandExcute(object param)
        {
            // Removes the Order and resets the product quanities
            if(SelectedTabItemIndex < 0)
            {
                messagingCentre.ShowDialog("Please select an order to remove.", appName);
                return;
            }
            var order = Orders.ElementAt(SelectedTabItemIndex);
            if(order != null)
            {
                if(order.IsOrderPlaced)
                {
                    messagingCentre.ShowDialog("The current order is placed and so it cannot be removed.", appName);
                }
                else
                {
                    foreach (var orderItem in order.OrderList)
                    {
                        var rootProduct = ProductList.FirstOrDefault(p => p.Id == orderItem.Product.Id);
                        if (rootProduct != null)
                            rootProduct.Quantity += orderItem.OrderQuantity;
                    }
                    Orders.Remove(order);
                }
            }
            
        }

        private bool OnCanRemoveOrderCommandExcute(object param)
        {
            return Orders.Any();
        }

        private void OnRemoveProductCommandExcute(object param)
        {
            // Removes the product from order's list and reset the root product quanity
            var orderItem = (OrderItem)param;
            if (orderItem != null)
            {
                var orderListItem = Orders.ElementAt(SelectedTabItemIndex);
                orderListItem.RemoveOrderItem(orderItem);

                var rootProduct = ProductList.FirstOrDefault(p => p.Id == orderItem.Product.Id);
                if (rootProduct != null)
                    rootProduct.Quantity += orderItem.OrderQuantity;
            }
        }

        private void OnAddToOrderCommand(object param)
        {
            // Adds the product to the current order
            if(Orders.Any() && SelectedTabItemIndex >= 0)
            {
                var product = (Product)param;
                if (product != null)
                {
                    var order = Orders.ElementAt(SelectedTabItemIndex);
                    if(!order.IsOrderPlaced)
                    {
                        if (!order.OrderList.Any(o => o.Product.Id == product.Id))
                        {
                            order.AddOrderItem(product);
                            var rootProduct = ProductList.FirstOrDefault(p => p.Id == product.Id);
                            if (rootProduct != null)
                                rootProduct.Quantity -= 1;
                        }
                    }
                    else
                    {
                        messagingCentre.ShowDialog("The current order is already placed, Please create or select another Order to add the product.", appName);
                    }   
                }
            }
            else
            {
                messagingCentre.ShowDialog("Please select an Order to add the product.", appName);
            }
        }

        private void OnOrderQuantityDecrementedCommandExcute(object param)
        {
            // Updating the root product's quantity count based on the Order quanity
            var orderItem = (OrderItem)param;
            if(orderItem != null)
            {
                var rootProduct = ProductList.FirstOrDefault(p => p.Id == orderItem.Product.Id);
                if(rootProduct != null)
                    rootProduct.Quantity += 1;
            }
        }

        private void OnOrderQuantityIncrementedCommandExcute(object param)
        {
            // Updating the root product's quantity count based on the Order quanity
            var orderItem = (OrderItem)param;
            if (orderItem != null)
            {
                var rootProduct = ProductList.FirstOrDefault(p => p.Id == orderItem.Product.Id);
                if (rootProduct != null)
                    rootProduct.Quantity -= 1;
            }
        }

        private void OnOrdersSelectionChangedCommandExcute(object param)
        {
            // Recalculating the available quantity of the products already added to the order list
            if(SelectedTabItemIndex >= 0)
            {
                var orderListItem = Orders.ElementAt(SelectedTabItemIndex);
                if (orderListItem != null)
                {
                    foreach (var orderItem in orderListItem.OrderList)
                    {
                        var rootProduct = ProductList.FirstOrDefault(p => p.Id == orderItem.Product.Id);
                        orderItem.Product.Quantity = rootProduct.Quantity + orderItem.OrderQuantity;
                    }
                }
            }
        }

        private void OnPlaceOrderCommandExcute(object param)
        {
            var order = (Order)param;
            if(order != null)
                order.IsOrderPlaced = true;
            
            messagingCentre.ShowDialog("Your Order has been placed successfully!", appName);

        }

        #endregion
    }
}