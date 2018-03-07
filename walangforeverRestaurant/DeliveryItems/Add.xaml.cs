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

namespace walangforeverRestaurant.DeliveryItems
{
    
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        private DeliveryItems.List _sender;

        public Add(DeliveryItems.List sender)
        {
            InitializeComponent();
            this._sender = sender;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Validate() == false)
            {
                return;
            }

            if (DeliveryItemsBLL.GetDeliveryItemsByMaterialName(txtMaterialName.Text) != null)
            {
                MessageBox.Show("MaterialName is already used");
            }
            else
            {
                walangforeverRestaurant.Domain.CustomModels.CustomDeliveryItems deliveryItems = new walangforeverRestaurant.Domain.CustomModels.CustomDeliveryItems();
                deliveryItems.Id = Guid.NewGuid();
                deliveryItems.MaterialName = txtMaterialName.Text;


                MessageBox.Show("MaterialName successfully created.");
                this._sender.showList();
                this.Close();
            }
        }

        private bool Validate()
        {

            if (string.IsNullOrEmpty(txtMaterialName.Text))
            {
                MessageBox.Show("Please input correct values");
                return false;
            }

            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Please input correct values");
                return false;

                return true;
            }
            int i = -1;
            int.TryParse(txtQuantity.Text, out i);
            if (i < 0)
            {
                MessageBox.Show("Please input correct values");
                return false;
            }

            return true;
        }
        private Random random = new Random();
        private string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
