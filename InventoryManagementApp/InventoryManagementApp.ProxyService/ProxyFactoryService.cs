using InventoryManagementApp.SDKs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.ProxyService
{
    public class ProxyFactoryService
    {
        /// <summary>
        /// Returns an instance of Concrete implementation of IInventoryManagementService
        /// </summary>
        /// <returns></returns>
        public static IInventoryManagementService GetInventoryService()
        {
            return new InventoryManagementService();
        }
    }
}
