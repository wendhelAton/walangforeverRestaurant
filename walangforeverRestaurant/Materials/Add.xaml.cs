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

namespace walangforeverRestaurant.Materials
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        private Materials.List _sender;

        public Add(Materials.List sender)
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

            if (MaterialsBLL.GetMaterialByName(txtName.Text) != null)
            {
                MessageBox.Show("Materialname is already used");
            }
            else
            {
                walangforeverRestaurant.Domain.Model.Materials materials = new walangforeverRestaurant.Domain.Model.Materials();
                materials.Id = Guid.NewGuid();
                materials.Name = txtName.Text;
                materials.UOM = txtUOM.Text;

                int i = 0;
                int.TryParse(txtQuantity.Text, out i);
                if (i < 0)


                 MaterialsBLL.Create(materials);
                MessageBox.Show("Material successfully created.");
                this._sender.showlist();
                this.Close();
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please input correct values");
                return false;
            }

            if (string.IsNullOrEmpty(txtUOM.Text))
            {
                MessageBox.Show("Please input correct values");
                return false;
            }
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Please input correct values");
                return false;
            }

            //tinanong kung may value ba na nilagay :D
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

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
