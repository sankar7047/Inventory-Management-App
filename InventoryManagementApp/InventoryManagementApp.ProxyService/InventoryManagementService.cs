using InventoryManagementApp.Models;
using InventoryManagementApp.ProxyService.InventoryServiceReference;
using InventoryManagementApp.SDKs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagementApp.ProxyService
{
    class InventoryManagementService : IInventoryManagementService
    {
        readonly InventoryServiceClient client;
        
        public InventoryManagementService()
        {
            client = new InventoryServiceClient();
        }

        /// <summary>
        /// Gets the Products from the Server
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Product>> GetProducts()
        {
            var client = new InventoryServiceClient();
            var request = new GetProductsRequest();
            var products = await client.GetProductsAsync(request);
            return products.GetProductsResult;
        }
    }
}
