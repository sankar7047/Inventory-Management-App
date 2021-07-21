using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.MessagingService
{
    /// <summary>
    /// Interface for accessing the Message dialog box
    /// </summary>
    public interface IMessagingCentre
    {
        void ShowDialog(string message, string caption = "");
    }
}
