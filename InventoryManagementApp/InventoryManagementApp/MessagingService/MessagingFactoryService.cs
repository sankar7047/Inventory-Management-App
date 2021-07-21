using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.MessagingService
{
    public class MessagingFactoryService
    {
        /// <summary>
        /// Returns an instance of Concrete implementation of IMessagingCentre
        /// </summary>
        /// <returns></returns>
        public static IMessagingCentre GetMessagingCentre()
        {
            return new MessagingCentre();
        }
    }
}
