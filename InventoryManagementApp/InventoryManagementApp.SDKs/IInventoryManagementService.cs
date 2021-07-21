using InventoryManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.SDKs
{
    public interface IInventoryManagementService
    {
        /// <summary>
        /// Gets the list of Products
        /// </summary>
        /// <returns></returns>
        Task<IList<Product>> GetProducts();
    }
}
