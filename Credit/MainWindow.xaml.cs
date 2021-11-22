using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        void EX2()
        {
            int Month = Convert.ToInt32(MonthTB.Text);
            double[,] ex2TB = new double[Month, 4];
            double Percent = Convert.ToDouble(YearPerTB.Text);
            double PM = Percent / 12 / 100;
            double PLT = Convert.ToDouble(PlatiTB.Text);
            try
            {
                dataGrid.ItemsSource = null;
                for (int i = 0; i < Month; i++)
                {
                    ex2TB[i, 0] = (PLT - Convert.ToInt32(MoneyTB.Text) * PM) * Math.Pow(1 + PM, i - 1);
                    Trace.WriteLine(ex2TB[i, 0]);
                    //dataGrid.Rows.Add(ex2TB[i, 0]);
                }
                DataTable dataTable = new DataTable();
                dataTable.Rows.Add(ex2TB[,]);
                dataGrid.ItemsSource = ex2TB[,];//

                //DB_Payment.Rows[i + 1].Cells[1].Value = ex2TB[i, 0];
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
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
