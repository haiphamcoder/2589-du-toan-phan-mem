using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
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
            nextWindow.window5.CanClose = true;
            nextWindow.CanClose = true;

            nextWindow.window1.Close();
            nextWindow.window2.Close();
            nextWindow.window3.Close();
            nextWindow.window4.Close();
            nextWindow.window5.Close();
            nextWindow.Close();
            base.OnClosing(e);
        }
    }
}
