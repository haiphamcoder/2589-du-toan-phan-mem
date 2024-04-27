using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using DuToanPhanMem.Model;

namespace DuToanPhanMem
{
    /// <summary>
    /// Interaction logic for BangTinhDiemTacNhan.xaml
    /// </summary>
    public partial class BangTinhDiemTacNhan : Window
    {
        
        public DiemTacNhan Data { get; set; }
        private BangDinhGiaPhanMem preWindow;
        public bool CanClose { get; set; }
        public BangTinhDiemTacNhan()
        {
            InitializeComponent();
        }

        public BangTinhDiemTacNhan(BangDinhGiaPhanMem window)
        {
            InitializeComponent();
            preWindow = window;
            Data = new DiemTacNhan(preWindow.Data);
            this.DataContext = Data;
            CanClose = false;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_Closing(object sender, CancelEventArgs cancelEventArgs)
        {
            if (!CanClose)
            {
                cancelEventArgs.Cancel = true;
                this.Hide();
            }

        }

        private void BtnNext_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            preWindow.window2.Show();
        }
    }
}
