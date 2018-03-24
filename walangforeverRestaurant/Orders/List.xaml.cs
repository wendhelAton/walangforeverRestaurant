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

namespace walangforeverRestaurant.Orders
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
        private OrderStatus? orderstatus = null;
        private string keyword = "";



        public List()
        {
            InitializeComponent();

            cboSortOrder.ItemsSource = Enum.GetValues(typeof(SortOrder)).Cast<SortOrder>();
            cboSortOrder.SelectedIndex = 0;

            List<OrderStatus> status = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>().ToList();
            List<string> orderstatusItems = new List<string>();
            orderstatusItems.Add("All");
            foreach (OrderStatus orderstatus in status)
            {
                orderstatusItems.Add(orderstatus.ToString());
            }

            cboOrderStatus.ItemsSource = orderstatusItems;

            
            cboSortOrder.SelectedIndex = 0;
            cboOrderStatus.SelectedIndex = 0;



            showList();


        }

        public void showList()
        {
            Page<walangforeverRestaurant.Domain.Model.Orders> order = OrderBLL.Search(pageSize, pageIndex, sortOrder, orderstatus);
            lblPages.Content = "page " + pageIndex + " of " + order.PageCount;
            lblResult.Content = "Search Result : " + order.QueryCount + " Categories";
            queryCount = order.QueryCount;
            pageCount = order.PageCount;
            grList.ItemsSource = order.Items;
            txtboxPageSize.Text = order.PageSize.ToString();
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

        private void cboOrderStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboOrderStatus.SelectedValue.ToString() == OrderStatus.New.ToString())
            {
                orderstatus = OrderStatus.New;
            }
            else if (cboOrderStatus.SelectedValue.ToString() == OrderStatus.Serving.ToString())
            {
                orderstatus = OrderStatus.Serving;
            }
            else if (cboOrderStatus.SelectedValue.ToString() == OrderStatus.Delivered.ToString())
            {
                orderstatus = OrderStatus.Delivered;
            }
            else if (cboOrderStatus.SelectedValue.ToString() == "All")
            {
                orderstatus = null;
            }
            showList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Orders.Add OrderAdd = new Orders.Add();
            OrderAdd.Show();
        }
    }
}
