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

namespace walangforeverRestaurant.Products
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        private walangforeverRestaurant.Domain.Model.Products _products;
        private Products.List _sender;



        public Update(walangforeverRestaurant.Domain.Model.Products products, Products.List sender)
        {
            InitializeComponent();
            this.txtboxName.Text = products.Name;
            this._products = products;
            this._sender = sender;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (Validate() == false)
            {
                return;
            }

            if (ProductBLL.GetDuplicateName(txtboxName.Text, this._products.Id) != null)
            {
                MessageBox.Show("Username is already used");
            }
            else
            {
                walangforeverRestaurant.Domain.Model.Products products = new walangforeverRestaurant.Domain.Model.Products();
                products.Id = Guid.NewGuid();
                products.Name = txtboxName.Text;

                decimal dec = 0;
                decimal.TryParse(txtboxPrice.Text, out dec);
                products.Price = dec;

                products.Id = this._products.Id;
                ProductBLL.Update(products);
                MessageBox.Show("User successfully Updated.");
                this._sender.showList();
                this.Close();
            }
        }
        
        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtboxName.Text))
            {
                MessageBox.Show("Please input correct values");
                return false;
            }

            if (string.IsNullOrEmpty(txtboxPrice.Text))
            {
                MessageBox.Show("Please input correct values");
                return false;
            }

            decimal dec = -1;
            decimal.TryParse(txtboxPrice.Text, out dec);
            if(dec < 0)
            {
                MessageBox.Show("Please input correct values");
                return false;
            }

            return true;
        }
    }
}


