﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Credit
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool Round;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        public void Counting()
        {
            double Money = Convert.ToDouble(MoneyTB.Text);
            int M = Convert.ToInt32(MonthTB.Text);
            double PM = Convert.ToDouble(YearPerTB.Text) / 12 / 100;
            MonthPerTB.Text = Convert.ToString(Rounding(PM));
            double KA = (PM * (Math.Pow((1 + PM), M))) / ((Math.Pow((1 + PM), M)) - 1);
            KATB.Text = Convert.ToString(Rounding(KA));
            double PLT = KA * Money;
            PlatiTB.Text = Convert.ToString(Rounding(PLT));
        }

        public double Rounding(double obj)
        {
            if(Round)
            {
                return Math.Round(obj);
            }
            else
            {
                return obj;
            }


        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Counting();
        }

        private void RoundCB_Click(object sender, RoutedEventArgs e)
        {
            Round = Convert.ToBoolean(RoundCB.IsChecked);
            Counting();
        }
    }
}
