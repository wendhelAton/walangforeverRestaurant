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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        private walangforeverRestaurant.Domain.Model.Materials _materials;
        private Materials.List _sender;


        public Update(walangforeverRestaurant.Domain.Model.Materials materials, Materials.List sender)
        {
            InitializeComponent();
            this.txtName.Text = materials.Name;
            this.txtUOM.Text = materials.UOM;
            this._materials = materials;
            this._sender = sender;

        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (Validate() == false)
            {
                return;
            }

            if (MaterialsBLL.GetDuplicateName(txtName.Text, this._materials.Id) != null)
            {
                MessageBox.Show("Materialname is already used");
            }
            else
            {
                walangforeverRestaurant.Domain.Model.Materials materials = new walangforeverRestaurant.Domain.Model.Materials();
                materials.Id = Guid.NewGuid();
                materials.Name = txtName.Text;
                materials.UOM = txtName.Text;

                int i = 0;
                int.TryParse(txtQuantity.Text, out i);
                if (i < 0)

                    materials.Id = this._materials.Id;
                MaterialsBLL.Update(materials);
                MessageBox.Show("Material successfully Updated.");
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
    }
}
