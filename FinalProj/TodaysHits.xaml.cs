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
using System.Windows.Shapes;

namespace FinalProj
{
    /// <summary>
    /// Interaction logic for TodaysHits.xaml
    /// </summary>
    public partial class TodaysHits : Window
    {
        public TodaysHits()
        {
            InitializeComponent();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Playlist p = new Playlist();
            p.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            idk d = new idk();
            d.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            idk d = new idk();
            d.Show();
            this.Close();
        }
    }
}
