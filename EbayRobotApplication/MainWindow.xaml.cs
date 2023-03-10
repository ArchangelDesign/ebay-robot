using Ebay_Connector;
using Ebay_Connector.Pages;
using Storage;
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

namespace EbayRobotApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EbayConnector _connector;

        private Provider provider;
        public MainWindow()
        {
            InitializeComponent();
            provider = new Provider();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _connector = new EbayConnector();
            } catch (Exception)
            {
                MessageBox.Show(this, "Update your Chrome to latest version.", "Incompatible Chrome version.");
                return;
            }
            _connector.GoToPage(new LoginPage(_connector));
            MessageBoxResult result = MessageBox.Show(this, "Click OK once you logged in.", "eBay Login Process", MessageBoxButton.OKCancel);
            if (result != MessageBoxResult.OK)
            {
                return;
            }
            ActiveListings activeListings = new ActiveListings(_connector);
            _connector.GoToPage(activeListings);
        }

        private void LoadOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            _connector.UpdateOrders();
            UpdateOrderList();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateOrderList();
        }

        private void UpdateOrderList()
        {
            List<Order> allOrders = provider.fetchOrders();
            OrderList.Items.Clear();

            foreach (Order order in allOrders)
            {
                OrderList.Items.Add(order);
            }
        }
    }
}
