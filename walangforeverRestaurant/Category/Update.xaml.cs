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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        private walangforeverRestaurant.Domain.Model.Category _category;
        private Category.List _sender;
        

        public Update(walangforeverRestaurant.Domain.Model.Category category, Category.List sender)
        {
            InitializeComponent();
            this.txtboxName.Text = category.Name;
            this._category = category;
            this._sender = sender;
            
        }
  
        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            if (Validate() == false)
            {
                return;
            }

            if (CategoryBLL.GetDuplicateName(txtboxName.Text, this._category.Id) != null)
            {
                MessageBox.Show("Categoryname is already used");
            }
            else
            {
                walangforeverRestaurant.Domain.Model.Category category = new walangforeverRestaurant.Domain.Model.Category();
                category.Id = Guid.NewGuid();
                category.Name = txtboxName.Text;




                category.Id = this._category.Id;
                CategoryBLL.Update(category);
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
            };

            return true;
        }
    }
}
