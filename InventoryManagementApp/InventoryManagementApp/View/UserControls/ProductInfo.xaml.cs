using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryManagementApp.View.UserControls
{
    /// <summary>
    /// Interaction logic for ProductInfo.xaml
    /// </summary>
    public partial class ProductInfo : UserControl
    {
        public ProductInfo()
        {
            InitializeComponent();
        }


        #region DependencyProperties
        public ICommand AddToOrderCommand
        {
            get { return (ICommand)GetValue(AddToOrderCommandProperty); }
            set { SetValue(AddToOrderCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddToOrderCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddToOrderCommandProperty =
            DependencyProperty.Register("AddToOrderCommand", typeof(ICommand), typeof(ProductInfo), new PropertyMetadata(default(ICommand)));

        #endregion

    }
}
