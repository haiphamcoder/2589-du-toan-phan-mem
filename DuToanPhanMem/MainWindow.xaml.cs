using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using DuToanPhanMem.Model;

namespace DuToanPhanMem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public ChiPhiPhanMem Data { get; set; }

        private BangDinhGiaPhanMem nextWindow;

        public MainWindow()
        {
            
            InitializeComponent();
            Data = new ChiPhiPhanMem();
            this.DataContext = Data;
            nextWindow = new BangDinhGiaPhanMem(this);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void HlGiaTri_OnClick(object sender, RoutedEventArgs e)
        {
            nextWindow.Show();
        }
        

        private void BtnNext_OnClick(object sender, RoutedEventArgs e)
        {
            nextWindow.Show();
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            nextWindow.window1.CanClose = true;
            nextWindow.window2.CanClose = true;
            nextWindow.window3.CanClose = true;
            nextWindow.window4.CanClose = true;
            nextWindow.CanClose = true;

            nextWindow.window1.Close();
            nextWindow.window2.Close();
            nextWindow.window3.Close();
            nextWindow.window4.Close();
            nextWindow.Close();
            base.OnClosing(e);
        }
    }
}
