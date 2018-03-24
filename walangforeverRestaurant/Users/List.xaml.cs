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
using System.Windows.Shapes;
using walangforeverRestaurant.Domain.BLL;
using walangforeverRestaurant.Domain.Enums;
using walangforeverRestaurant.Domain.Insfrastructure;
using walangforeverRestaurant.Domain.Model;

namespace walangforeverRestaurant.Users
{
    /// <summary>
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class List : Window
    {
       
        private long pageSize = 3;
        private long pageIndex = 1;
        private long queryCount = 0;
        private long pageCount = 0;
        private SortOrder sortOrder = SortOrder.Ascending;
        private UserSortOrder sortby = UserSortOrder.UserName;
        private Role? role = null;
        //adding a keyword to search
        private string keyword = "";
        
        public List()
        {
            InitializeComponent();
            //nag-add ng role na UserSortOrder at SortOrder para makilala ng nasa ibaba niya at code para mailagay ang mga role sa Sort By..
            cboSortby.ItemsSource = Enum.GetValues(typeof(UserSortOrder)).Cast<UserSortOrder>();
            cboSortOrder.ItemsSource = Enum.GetValues(typeof(SortOrder)).Cast<SortOrder>();
            //Code para mailagay ang mga role sa Filter tulad ng Chef,admin,waiter at iba pa.
            List<Role> roles = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
            //code for adding the role (All) in the CboRole.. and display all the other members
            List<string> roleItems = new List<string>();
            roleItems.Add("All");
            foreach (Role role in roles)
            {
                roleItems.Add(role.ToString());
            }

            cboRole.ItemsSource = roleItems;

            cboSortby.SelectedIndex = 0;
            cboSortOrder.SelectedIndex = 0;
            cboRole.SelectedIndex = 0;

            showList();
        }

        public void showList()
        {

            Page<User> users = UsersBLL.Search(pageSize, pageIndex,sortby,sortOrder,role, keyword);
            lblPages.Content = "page" + pageIndex + " of " + users.PageCount;
            lblResult.Content = "Search Result: " + users.QueryCount + " Users";
            queryCount = users.QueryCount;
            pageCount = users.PageCount;
            DgList.ItemsSource = users.Items;
           
            


        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {    
            //code para mapunta sa last Page
            pageIndex = pageCount;
            showList();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        { 
            //code para maprevious yung page
            pageIndex = pageIndex - 1;
            
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            showList();
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            //code para mapunta ka sa 1st page
            pageIndex = 1;
            showList();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            //code para sa next page.
            pageIndex = pageIndex + 1;

            if (pageIndex > pageCount)
            {
                pageIndex = pageCount;
            }

            showList();
        }

        private void cboSortby_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //code para lumabas ang Username,Lastname,Firstname sa ComboBox
            MessageBox.Show(cboSortby.SelectedValue.ToString());
            if (cboSortby.SelectedValue.ToString() == UserSortOrder.UserName.ToString())
            {
                sortby = UserSortOrder.UserName;

            }
            else if
                (cboSortby.SelectedValue.ToString() == UserSortOrder.FirstName.ToString())
            {
                sortby = UserSortOrder.FirstName;
            }
            else if
               (cboSortby.SelectedValue.ToString() == UserSortOrder.LastName.ToString())
            {
                sortby = UserSortOrder.LastName;
            }
            showList();
        }

        private void cboSortOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //code para lumabas ng Ascending,Descending sa ComboBox
            if (cboSortOrder.SelectedValue.ToString() ==  SortOrder.Ascending.ToString())
            {
                sortOrder = SortOrder.Ascending;

            }
            else if (cboSortOrder.SelectedValue.ToString() == SortOrder.Descending.ToString())
            {
                sortOrder = SortOrder.Descending;

            }
            showList();
        }

        private void cboRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //nilagay dito ang mga users na admin,cashier at ipa pa..
            if(cboRole.SelectedValue.ToString() == Role.Admin.ToString())
            {
                role = Role.Admin;
            }
            else if (cboRole.SelectedValue.ToString() == Role.Cashier.ToString())
            {
                role = Role.Cashier;
            }
            else if (cboRole.SelectedValue.ToString() == Role.Chef.ToString())
            {
                role = Role.Chef;
            }
            else if (cboRole.SelectedValue.ToString() == Role.InventoryController.ToString())
            {
                role = Role.InventoryController;
            }
            else if (cboRole.SelectedValue.ToString() == Role.Waiter.ToString())
            {
                role = Role.Waiter;
            }
            else if (cboRole.SelectedValue.ToString() == "All")
            {
                role = null;
            }
            showList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            keyword = txtBoxSearch.Text;
            showList();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            Users.Add addWindow = new Users.Add(this);
            addWindow.Show();
        }
        //naglagay ako sa datagrid ng button Update, code for UpdateButton
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            User user = ((FrameworkElement)sender).DataContext as User;
            Update updateWindow = new Update(user,this);
            updateWindow.Show();

        }
        //code for deleting record in datagrid
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            User user = ((FrameworkElement)sender).DataContext as User;
            if (MessageBox.Show("Are you sure you want to Delete " + user.FirstName + " " + user.LastName + "?","Delete User",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                UsersBLL.Delete(user);
                MessageBox.Show("User successfully deleted");
                showList();
            }
           
        }

        private void txtboxPageSize_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                int newPageSize = 3;
                bool result = Int32.TryParse(txtboxPageSize.Text, out newPageSize);

                if (result == false)
                {
                    newPageSize = 3;

                }

                pageSize = newPageSize;
                showList();
            }
        }

    }
}
