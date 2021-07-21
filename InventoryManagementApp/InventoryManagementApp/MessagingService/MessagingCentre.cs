using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryManagementApp.MessagingService
{
    /// <summary>
    /// Concrete class implementation of IMessagingCentre
    /// </summary>
    class MessagingCentre : IMessagingCentre
    {
        public void ShowDialog(string message, string caption = "")
        {
            MessageBox.Show(message, caption);
        }
    }
}
