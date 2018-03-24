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
using walangforeverRestaurant.Domain.Enums;

namespace walangforeverRestaurant.Recipe
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
        private UserSortOrder sortby = UserSortOrder.UserName;
        
        //adding a keyword to search
        private string keyword = "";

        public List()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cboSortOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtboxPageSize_KeyDown(object sender, KeyEventArgs e)
        {

        }

      
        private void btnLast_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
