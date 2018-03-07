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

namespace walangforeverRestaurant.Materials
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
       


        public List()
        {
            InitializeComponent();

            cboSortOrder.ItemsSource = Enum.GetValues(typeof(SortOrder)).Cast<SortOrder>();
            cboSortOrder.SelectedIndex = 0;
            showlist();
        }
        public void showlist()
        {
            Page<walangforeverRestaurant.Domain.Model.Materials> Materials = MaterialsBLL.Search(pageSize, pageIndex , sortOrder ,keyword);
            lblPages.Content = "page " + pageIndex + " of " + Materials.PageCount;
            lblResult.Content = "Search Result : " + Materials.QueryCount + " Materials";
            queryCount = Materials.QueryCount;
            pageCount = Materials.PageCount;
            grList.ItemsSource = Materials.Items;
            txtboxPageSize.Text = Materials.PageSize.ToString();
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
                showlist();
            }
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = pageCount;
            showlist();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = pageIndex + 1;

            if (pageIndex > pageCount)
            {
                pageIndex = pageCount;
            }

            showlist();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = pageIndex - 1;

            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            showlist();
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = 1;
            showlist();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            keyword = txtBoxSearch.Text;
            showlist();
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
            showlist();
        
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            walangforeverRestaurant.Domain.Model.Materials materials = ((FrameworkElement)sender).DataContext as walangforeverRestaurant.Domain.Model.Materials;
            Update updateWindow = new Update(materials, this);
            updateWindow.Show();

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //lahat ng code dito ay mapupunta sa Add dahil sa code na Category.Add(this)
            //kilala na ni Add Window lahat ng code sa List Window 
            Materials.Add materialsWindow = new Materials.Add(this);
            materialsWindow.Show();
        }
    }
}
