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

namespace walangforeverRestaurant.Delivery
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


        public List()
        {
            InitializeComponent();
            cboSortOrder.ItemsSource = Enum.GetValues(typeof(SortOrder)).Cast<SortOrder>();
            showList();

        }

        public void showList()
        {
            Page<walangforeverRestaurant.Domain.Model.Delivery> deliveries = DeliveryBLL.Search(pageSize, pageIndex, sortOrder, "");
            lblPages.Content = "page " + pageIndex + " of " + deliveries.PageCount;
            lblResults.Content = "Search Result : " + deliveries.QueryCount + " Deliveries";
            queryCount = deliveries.QueryCount;
            pageCount = deliveries.PageCount;
            grList.ItemsSource = deliveries.Items;
            txtPageSize.Text = deliveries.PageSize.ToString();
        }

        private void cboSortOrder_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
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

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            Delivery.Add addWindow = new Delivery.Add(this);
            addWindow.Show();
        }

        private void txtPageSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                int newPageSize = 3;
                bool result = Int32.TryParse(txtPageSize.Text, out newPageSize);

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
