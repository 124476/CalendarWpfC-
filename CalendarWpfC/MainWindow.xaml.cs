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

namespace CalendarWpfC
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime dateNow;
        public MainWindow()
        {
            InitializeComponent();
            dateNow = DateTime.Now;

            Refresh();
        }

        private void Refresh()
        {
            GridPanel.Children.Clear();

            var dateStart = new DateTime(dateNow.Year, dateNow.Month, 1);
            var dateEnd = dateStart.AddMonths(1);

            int dat = (int)(dateStart.DayOfWeek - 1);

            if (dat == -1)
                dat = 5;

            var date = new DateTime();

            for (int i = 0; i < 7; i++)
            {
                TextBlock textDate = new TextBlock()
                {
                    Text = date.DayOfWeek.ToString().Substring(0, 2)
                };
                GridPanel.Children.Add(textDate);
                Grid.SetColumn(textDate, i);
            }

            while (dateStart < dateEnd)
            {
                TextBlock textNow = new TextBlock();
                textNow.Text = dateStart.Day.ToString();
                GridPanel.Children.Add(textNow);

                var dateN = dateStart.Day + dat - 1;
                Grid.SetColumn(textNow, dateN % 7);
                Grid.SetRow(textNow, dateN / 7 + 1);

                dateStart = dateStart.AddDays(1);
            }
            TextDate.Text = dateNow.ToString("MMMM yyyy");
        }

        private void DownBtn_Click(object sender, RoutedEventArgs e)
        {
            dateNow = dateNow.AddMonths(-1);
            Refresh();
        }

        private void UpBtn_Click(object sender, RoutedEventArgs e)
        {
            dateNow = dateNow.AddMonths(1);
            Refresh();
        }
    }
}
