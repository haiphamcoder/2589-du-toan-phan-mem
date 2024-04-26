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
using System.Windows.Shapes;
using DuToanPhanMem.Model;

namespace DuToanPhanMem
{
    /// <summary>
    /// Interaction logic for BangDinhGiaPhanMem.xaml
    /// </summary>
    public partial class BangDinhGiaPhanMem : Window
    {
        
        
        public GiaTriPhanMem Data { get; set; }
        public MainWindow preWindow;
        public BangTinhDiemTacNhan window1;
        public BangTinhDiemUseCase window2;
        public BangHeSoPhucTapKTCN window3;
        public BangHeSoPhucTapMTKN window4;

        public bool CanClose { get; set; }
        public BangDinhGiaPhanMem()
        {
            InitializeComponent();
            
        }

        public BangDinhGiaPhanMem(MainWindow window)
        {
            InitializeComponent();
            preWindow = window;
            Data = new GiaTriPhanMem(preWindow.Data);
            this.DataContext = Data;
            CanClose = false;
            window1 = new BangTinhDiemTacNhan(this);
            window2 = new BangTinhDiemUseCase(this);
            window3 = new BangHeSoPhucTapKTCN(this);
            window4 = new BangHeSoPhucTapMTKN(this);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        

        private void HlTAW_OnClick(object sender, RoutedEventArgs e)
        {
            window1.Show();
        }

        private void HlTBF_OnClick(object sender, RoutedEventArgs e)
        {
            window2.Show();
        }

        private void HlTCF_OnClick(object sender, RoutedEventArgs e)
        {
            window3.Show();
        }

        private void HlEF_OnClick(object sender, RoutedEventArgs e)
        {
            window4.Show();
        }

        private void BtnNext_OnClick(object sender, RoutedEventArgs e)
        {
            window1.Show();
        }

        

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!CanClose)
            {
                e.Cancel = true;
                this.Hide();
            }
                
        }
    }
}
