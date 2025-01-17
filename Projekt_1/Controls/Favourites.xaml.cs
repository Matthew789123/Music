﻿using System;
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
    /// Interaction logic for Favourites.xaml
    /// </summary>
    public partial class Favourites : UserControl
    {
        public event EventHandler onCheck;
        public event EventHandler onUncheck;
        public Favourites()
        {
            InitializeComponent();
        }

        private void addArtistToFavourites(object sender, RoutedEventArgs e)
        {
            if (onCheck != null)
            {
                onCheck(this, EventArgs.Empty);

            }
        }

        private void removeArtistFromFavourites(object sender, RoutedEventArgs e)
        {
            if (onUncheck != null)
            {
                onUncheck(this, EventArgs.Empty);

            }
        }
    }
}
