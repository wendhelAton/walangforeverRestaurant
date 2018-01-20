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
using walangforeverRestaurant.Domain.BLL;
using walangforeverRestaurant.Domain.Model;

namespace walangforeverRestaurant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            List<User> users = UsersBLL.GetAll();
            InitializeComponent();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            Users.List usersWindow = new Users.List();
            usersWindow.Show();
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            Category.List CategoryWindow = new Category.List();
            CategoryWindow.Show();
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            Products.List ProductsWindow = new Products.List();
            ProductsWindow.Show();
        }

        private void btnDelivery_Click(object sender, RoutedEventArgs e)
        {
            Delivery.List DeliveryWindow = new Delivery.List();
            DeliveryWindow.Show();
        }

        private void btnDeliveryItems_Click(object sender, RoutedEventArgs e)
        {
            DeliveryItems.List DeliveryItemsWindow = new DeliveryItems.List();
            DeliveryItemsWindow.Show();
        }


        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            Orders.List OrdersWindow = new Orders.List();
            OrdersWindow.Show();
        }

        private void btnOrdersItems_Click(object sender, RoutedEventArgs e)
        {
            OrderItems.List OrdersItemsWindow = new OrderItems.List();
            OrdersItemsWindow.Show();
        }

        private void btnRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe.List RecipeWindow = new Recipe.List();
            RecipeWindow.Show();
        }

        private void btnSales_Click(object sender, RoutedEventArgs e)
        {
            Sales.List SalesWindow = new Sales.List();
            SalesWindow.Show();
        }

        private void btnMaterials_Click(object sender, RoutedEventArgs e)
        {
            Materials.List MaterialsWindow = new Materials.List();
            MaterialsWindow.Show();
        }
    }
}
