using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
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
            preWindow.window5.Show();
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
