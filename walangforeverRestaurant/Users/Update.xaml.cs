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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        private User _user;
        private Users.List _sender;

        public Update(User user,Users.List sender)
        {
            InitializeComponent();
            this.txtboxFirstName.Text = user.FirstName;
            this.txtboxLastName.Text = user.LastName;
            this.txtboxUserName.Text = user.UserName;
            this._user = user;
            this._sender = sender;


            cboRole.ItemsSource = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (Validate() == false)
            {
                return;
            }

            if (UsersBLL.GetDuplicateUserName(txtboxUserName.Text, this._user.Id) != null)
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
                user.Id = this._user.Id;
                UsersBLL.Update(user);
                MessageBox.Show("User successfully Updated.");
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

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
