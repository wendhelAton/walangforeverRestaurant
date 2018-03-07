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
using walangforeverRestaurant.Domain.CustomModels;
using walangforeverRestaurant.Domain.Enums;
using walangforeverRestaurant.Domain.Insfrastructure;
using walangforeverRestaurant.Domain.Model;

namespace walangforeverRestaurant.DeliveryItems
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
        private Guid? deliveryId = null;

        public List(Guid? deliveryId = null, string deliveryName = "")
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(deliveryName) == false)
            {
                lblTitle.Content = "DeliveryItems " + deliveryName;
            }

            cboSortOrder.ItemsSource = Enum.GetValues(typeof(SortOrder)).Cast<SortOrder>();
            cboSortOrder.SelectedIndex = 0;
            this.deliveryId = deliveryId;
            showList();
        }

        public void showList()
        {
            Page<walangforeverRestaurant.Domain.CustomModels.CustomDeliveryItems> deliveryItems = DeliveryItemsBLL.Search(pageSize, pageIndex, sortOrder, keyword, this.deliveryId);
            lblPages.Content = "page " + pageIndex + " of " + deliveryItems.PageCount;
            lblResult.Content = "Search Result : " + deliveryItems.QueryCount + " DeliveryItems";
            queryCount = deliveryItems.QueryCount;
            pageCount = deliveryItems.PageCount;
            grList.ItemsSource = deliveryItems.Items;
            txtboxPageSize.Text = deliveryItems.PageSize.ToString();
        }

       


        private void cboSortOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboSortOrder.SelectedValue.ToString() == SortOrder.Ascending.ToString())
            {
                sortOrder = SortOrder.Ascending;

            }
            else if (cboSortOrder.SelectedValue.ToString() == SortOrder.Descending.ToString())
            {
                sortOrder = SortOrder.Descending;

            }
            showList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            keyword = txtBoxSearch.Text;
            showList();
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DeliveryItems.Add deliveryItemsWindow = new DeliveryItems.Add(this);
            deliveryItemsWindow.Show();
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
    }
}
