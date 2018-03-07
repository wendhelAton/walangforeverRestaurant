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

namespace walangforeverRestaurant.Products
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
        private string keyword = "";
        public Guid? categoryId = null;

        public List(Guid? categoryId = null,string categoryName= "")
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(categoryName) == false)
            {
                lblTitle.Content = "Products under " + categoryName;
            }

            cboSortOrder.ItemsSource = Enum.GetValues(typeof(SortOrder)).Cast<SortOrder>();
            cboSortOrder.SelectedIndex = 0;
            this.categoryId = categoryId;
            showList();
        }
        public void showList()
        {
            Page<walangforeverRestaurant.Domain.Model.Products> products = ProductBLL.Search(pageSize, pageIndex, sortOrder, keyword, this.categoryId);
            lblPages.Content = "page " + pageIndex + " of " + products.PageCount;
            lblResult.Content = "Search Result : " + products.QueryCount + " Categories";
            queryCount = products.QueryCount;
            pageCount = products.PageCount;
            grList.ItemsSource = products.Items;
            txtboxPageSize.Text = products.PageSize.ToString();
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

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = pageCount;
            showList();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = pageIndex + 1;

            if (pageIndex > pageCount)
            {
                pageIndex = pageCount;
            }

            showList();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = pageIndex - 1;

            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            showList();
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = 1;
            showList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            keyword = txtBoxSearch.Text;
            showList();
        }

        private void bntAdd_Click(object sender, RoutedEventArgs e)
        {
            Products.Add productWindow = new Products.Add(this);
            productWindow.Show();
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            walangforeverRestaurant.Domain.Model.Products products = ((FrameworkElement)sender).DataContext as walangforeverRestaurant.Domain.Model.Products;
            Update updateWindow = new Update(products, this);
            updateWindow.Show();

        }
    }
}
