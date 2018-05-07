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

namespace Chess
{
    /// <summary>
    /// Interaction logic for Choose.xaml
    /// </summary>
    public partial class Choose : Window
    {
        public string pawnCategory = "queen";
        public Choose()
        {            
            InitializeComponent();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (radio_btn_bishop.IsChecked == true)
            {
                pawnCategory = "bishop";
            }
            else if (radio_btn_queen.IsChecked == true)
            {
                pawnCategory = "queen";
            }
            else if (radio_btn_rook.IsChecked == true)
            {
                pawnCategory = "rook";
            }
            else if (radio_btn_knight.IsChecked == true)
            {
                pawnCategory = "knight";
            }
            Close();
        }
    }
}
