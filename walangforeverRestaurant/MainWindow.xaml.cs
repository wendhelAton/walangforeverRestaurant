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

        private void btnMaterials_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUser_Click_1(object sender, RoutedEventArgs e)
        {
            Users.List usersWindow = new Users.List();
            usersWindow.Show();
        }

        private void btnMenu_Click_1(object sender, RoutedEventArgs e)
        {
            Category.List categoryWindow = new Category.List();
            categoryWindow.Show();
        }

        private void btnDelivery_Click(object sender, RoutedEventArgs e)
        {

            Delivery.List deliveryWindow = new Delivery.List();
            deliveryWindow.Show();
        }

        private void btnOrders_Click_1(object sender, RoutedEventArgs e)
        {

            Orders.List OrdersWindow = new Orders.List();
            OrdersWindow.Show();
        }

        private void btnOrdersItems_Click_1(object sender, RoutedEventArgs e)
        {

            OrderItems.List OrdersItemsWindow = new OrderItems.List();
            OrdersItemsWindow.Show();
        }

        private void btnRecipe_Click_1(object sender, RoutedEventArgs e)
        {

            Recipe.List RecipeWindow = new Recipe.List();
            RecipeWindow.Show();
        }

        private void btnSales_Click_1(object sender, RoutedEventArgs e)
        {
            Sales.List SalesWindow = new Sales.List();
            SalesWindow.Show();
        } 
    }
}
