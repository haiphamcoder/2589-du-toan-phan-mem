using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using DuToanPhanMem.Model;

namespace DuToanPhanMem
{
    /// <summary>
    /// Interaction logic for BangHeSoPhucTapKTCN.xaml
    /// </summary>
    public partial class BangHeSoPhucTapKTCN : Window
    {
        public HeSoPhucTapKTCN Data { get; set; }
        private BangDinhGiaPhanMem preWindow;
        public bool CanClose { get; set; }
        public BangHeSoPhucTapKTCN()
        {
            InitializeComponent();
            
        }

        public BangHeSoPhucTapKTCN(BangDinhGiaPhanMem window)
        {
            InitializeComponent();
            preWindow = window;
            Data = new HeSoPhucTapKTCN(preWindow.Data);
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
            preWindow.window4.Show();
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
