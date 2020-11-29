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

namespace Projekt_1
{
    /// <summary>
    /// Interaction logic for ChoosePlaylist.xaml
    /// </summary>
    public partial class ChoosePlaylist : Window
    {
        public ChoosePlaylist()
        {
            InitializeComponent();
        }


        private void oncloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void onAddClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
