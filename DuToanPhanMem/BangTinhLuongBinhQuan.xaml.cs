using DuToanPhanMem.Model;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace DuToanPhanMem
{
    /// <summary>
    /// Interaction logic for BangTinhLuongBinhQuan.xaml
    /// </summary>
    public partial class BangTinhLuongBinhQuan : Window
    {
        public LuongBinhQuan Data { get; set; }
        private BangDinhGiaPhanMem preWindow;
        public bool CanClose { get; set; }

        public BangTinhLuongBinhQuan(BangDinhGiaPhanMem window)
        {
            InitializeComponent();
            preWindow = window;
            Data = new LuongBinhQuan(preWindow.Data);
            this.DataContext = Data;
            CanClose = false;
        }

        private void BtnNext_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
