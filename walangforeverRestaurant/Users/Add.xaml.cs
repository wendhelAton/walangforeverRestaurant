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
using walangforeverRestaurant.Domain.Model;

namespace walangforeverRestaurant.Users
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
       
        private Users.List _sender;

        public Add(Users.List sender)
        {
            InitializeComponent();
            //Code para mailagay ang mga role sa Filter tulad ng Chef,admin,waiter at iba pa.
            List<Role> roles = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
            cboRole.ItemsSource = roles;
            this._sender = sender;  
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //code for closing the window

            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Validate() == false)
            {
                return;
            }

            if (UsersBLL.GetUserByUserName(txtboxUserName.Text) != null)
            {
                MessageBox.Show("Username is already used");
            }
            else
            {
                User user = new User();
                user.Id = Guid.NewGuid();
                user.UserName = txtboxUserName.Text;
                user.LastName = txtboxLastName.Text;
                user.FirstName = txtboxFirstName.Text;

                Role role = new Role();
                if (cboRole.SelectedValue.ToString() == Role.Admin.ToString())
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

                user.Role = role;
                user.Password = this.RandomString(6);
                UsersBLL.Create(user);
                MessageBox.Show("User successfully created.");
                this._sender.showList();
                this.Close();
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtboxUserName.Text) ||
               string.IsNullOrEmpty(txtboxFirstName.Text) ||
               string.IsNullOrEmpty(txtboxLastName.Text) ||
               cboRole.SelectedValue == null)
            {
                MessageBox.Show("Please input correct values");
                return false;
            };

            return true;
        }

        private Random random = new Random();
        private string RandomString(int length)
         {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string (Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}


    

