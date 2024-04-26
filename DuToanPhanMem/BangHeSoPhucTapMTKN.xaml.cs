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
    /// Interaction logic for BangHeSoMTKN.xaml
    /// </summary>
    public partial class BangHeSoPhucTapMTKN : Window
    {
        public HeSoPhucTapMTKN Data { get; set; }
        private BangDinhGiaPhanMem preWindow;
        public bool CanClose { get; set; }

        public BangHeSoPhucTapMTKN()
        {
            InitializeComponent();
        }

        public BangHeSoPhucTapMTKN(BangDinhGiaPhanMem window)
        {
            InitializeComponent();
            preWindow = window;
            Data = new HeSoPhucTapMTKN(preWindow.Data);
            this.DataContext = Data;
            CanClose = false;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnNext_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            
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
