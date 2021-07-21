using InventoryManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace InventoryManagementApp.WCFWebService
{
    /// <summary>
    /// Service Contract Interface
    /// </summary>
    [ServiceContract]
    public interface IInventoryService
    {
        /// <summary>
        /// Gets the list of Products
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<Product> GetProducts();
    }
}
