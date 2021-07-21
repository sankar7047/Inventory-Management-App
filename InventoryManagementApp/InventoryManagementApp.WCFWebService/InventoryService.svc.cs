using InventoryManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.WCFWebService
{
    public class InventoryService : IInventoryService
    {

        // Persisted products list
        IList<Product> products = new List<Product>
        {
            new Product() { Id = 001, Name = "Keyboard", Description = "101-Key basic keyboard", UnitPrice = 18.99, Quantity = 24, ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/81wRXdAOmkL._SL1500_.jpg" },
            new Product() { Id = 002, Name = "Mouse", Description = "Optical mouse, Black", UnitPrice = 11.99, Quantity = 43, ImageUrl = "https://support.content.office.net/en-us/media/e8384959-ad1a-1b95-762b-2861496b886e.png" },
            new Product() { Id = 003, Name = "Keyboard", Description = "101-Key Mac keyboard", UnitPrice = 34.99, Quantity = 22 },
            new Product() { Id = 004, Name = "Mouse", Description = "Optical mouse, White", UnitPrice = 11.99, Quantity = 45, ImageUrl = "https://www.kmart.com.au/wcsstore/Kmart/images/ncatalog/f/8/42900948-1-f.jpg" },
            new Product() { Id = 005, Name = "Mouse", Description = "Optical mouse, Pink", UnitPrice = 11.99, Quantity = 45, ImageUrl = "https://www.kmart.com.au/wcsstore/Kmart/images/ncatalog/f/5/42900955-1-f.jpg" },
            new Product() { Id = 006, Name = "Mouse", Description = "Optical mouse for Mac, Black", UnitPrice = 23.99, Quantity = 14 },
            new Product() { Id = 007, Name = "Mouse", Description = "Optical mouse for Mac, White", UnitPrice = 23.99, Quantity = 15 },
            new Product() { Id = 008, Name = "Mouse", Description = "Optical mouse for Mac, Gray", UnitPrice = 23.99, Quantity = 0 },
            new Product() { Id = 009, Name = "24\" LCD Monitor", Description = "An LCD monitor, built-in keyboard and touch pad in 1U of rack space - 24-inch", UnitPrice = 158.99, Quantity = 10, ImageUrl = "https://images.philips.com/is/image/PhilipsConsumer/243V7QJAB_75-IMS-en_AU?$jpglarge$&wid=1250" },
            new Product() { Id = 010, Name = "27\" LCD Monitor", Description = "An LCD monitor, built-in keyboard and touch pad in 1U of rack space - 27-inch", UnitPrice = 198.99, Quantity = 8 },
        };

        /// <summary>
        /// Gets the Products
        /// </summary>
        /// <returns></returns>
        public IList<Product> GetProducts()
        {
            // Delays the result by 1500 milliseconds
            Task.Delay(1500);
            return products;
        }
    }
}
