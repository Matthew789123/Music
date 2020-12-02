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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_1.Controls
{
    /// <summary>
    /// Interaction logic for StarRating.xaml
    /// </summary>
    /// 

    public partial class StarRating : UserControl
    {
        private List<CheckBox> CheckBoxes = new List<CheckBox>();
        public event EventHandler UserControlClick;
        public StarRating()
        {
            InitializeComponent();
            CheckBoxes.Add(CheckBox1);
            CheckBoxes.Add(CheckBox2);
            CheckBoxes.Add(CheckBox3);
            CheckBoxes.Add(CheckBox4);
            CheckBoxes.Add(CheckBox5);
        }

       private void CheckBoxClick(object sender, RoutedEventArgs e)
       {
            
            if(((CheckBox)e.Source).IsChecked==false)
            {
                int i = CheckBoxes.IndexOf((CheckBox)e.Source);
                CheckBoxes[i].IsChecked = true;
                i++;
                for (; i < 5; i++)
                {
                    CheckBoxes[i].IsChecked = false;
                }
            }
            else if(((CheckBox)e.Source).IsChecked == true)
            {
                int i = CheckBoxes.IndexOf((CheckBox)e.Source);
                for (; i >= 0; i--)
                {
                    CheckBoxes[i].IsChecked = true;
                }
            }
            if (UserControlClick != null)
            {
                UserControlClick(this, EventArgs.Empty);

            }
        }

    }

}
