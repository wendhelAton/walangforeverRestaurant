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
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        private Products.List _sender;

        public Add(Products.List sender)
        {
            InitializeComponent();
            this._sender = sender;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Validate() == false)
            {
                return;
            }

            if (ProductBLL.GetProductByName(txtboxName.Text) != null)
            {
                MessageBox.Show("Productname is already used");
            }
            else
            {
                walangforeverRestaurant.Domain.Model.Products products = new walangforeverRestaurant.Domain.Model.Products();
                products.Id = Guid.NewGuid();
                products.Name = txtboxName.Text;
                products.CategoryId = this._sender.categoryId;



                decimal dec = 0;
                decimal.TryParse(txtboxPrice.Text, out dec);
                products.Price = dec;


                MessageBox.Show("Productname successfully created.");
                ProductBLL.Create(products);
                this._sender.showList();
                this.Close();
            }
        }

        private bool Validate()
        {
            //nagtatanong kung may inilagay ba siya :D
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
            //tinanong kung may value ba na nilagay :D
            decimal dec = -1;
            decimal.TryParse(txtboxPrice.Text, out dec);
            if (dec < 0)
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

        private void btnCancel_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
