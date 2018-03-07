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

namespace walangforeverRestaurant.Category
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
        public Guid? parentId = null;

        public List(Guid? parentId = null, string parentName = "")

        {
            InitializeComponent();
            if (string.IsNullOrEmpty(parentName) == false)
            {
                lblTitle.Content = "Categories under " + parentName;
            }

            cboSortOrder.ItemsSource = Enum.GetValues(typeof(SortOrder)).Cast<SortOrder>();
            cboSortOrder.SelectedIndex = 0;
            this.parentId = parentId;
            showList();
        }

        public void showList()
        {
            Page<CustomCategory> categories = CategoryBLL.Search(pageSize, pageIndex, sortOrder, keyword, this.parentId);
            lblPages.Content = "page " + pageIndex + " of " + categories.PageCount;
            lblResult.Content = "Search Result : " + categories.QueryCount + " Categories";
            queryCount = categories.QueryCount;
            pageCount = categories.PageCount;
            grList.ItemsSource = categories.Items;
            txtboxPageSize.Text = categories.PageSize.ToString();
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

        private void btnNext_Click_1(object sender, RoutedEventArgs e)
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

        private void btnFirst_Click_1(object sender, RoutedEventArgs e)
        {
            pageIndex = 1;
            showList();
        }

        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            keyword = txtBoxSearch.Text;
            showList();
        }

        private void btnViewChildren_Click(object sender, RoutedEventArgs e)
        {

            CustomCategory category = ((FrameworkElement)sender).DataContext as CustomCategory;
            Category.List categoryWindow = new Category.List(category.Id, category.Name);
            categoryWindow.Show();
        }

        private void btnViewProducts_Click(object sender, RoutedEventArgs e)
        {
            CustomCategory category = ((FrameworkElement)sender).DataContext as CustomCategory;
            Products.List productWindow = new Products.List(category.Id, category.Name);
            productWindow.Show();
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = pageCount;
            showList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //lahat ng code dito ay mapupunta sa Add dahil sa code na Category.Add(this)
            //kilala na ni Add Window lahat ng code sa List Window 
            Category.Add categoryWindow = new Category.Add(this);
            categoryWindow.Show();
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            walangforeverRestaurant.Domain.Model.Category category = ((FrameworkElement)sender).DataContext as walangforeverRestaurant.Domain.Model.Category;
            Update updateWindow = new Update(category,this);
            updateWindow.Show();

        }
    }

}

