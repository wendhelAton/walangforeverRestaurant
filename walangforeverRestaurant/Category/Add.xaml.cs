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

namespace walangforeverRestaurant.Category
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {

   
        private Category.List _sender;

        public Add(Category.List sender)
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

            if (CategoryBLL.GetCategoryByName(txtboxName.Text) != null)
            {
                MessageBox.Show("Categoryname is already used");
            }
            else
            {
                walangforeverRestaurant.Domain.Model.Category category = new walangforeverRestaurant.Domain.Model.Category();
                category.Id = Guid.NewGuid();
                category.ParentId = this._sender.parentId;
                category.Name = txtboxName.Text;

               
                MessageBox.Show("CategoryName successfully created.");
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
            };

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
