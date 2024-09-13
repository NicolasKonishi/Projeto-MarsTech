using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PIM_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // set tooltip visibility

            if(tg_btn.IsChecked == true)
            {

                tt_home.Visibility = Visibility.Collapsed;
                tt_Introducao.Visibility = Visibility.Collapsed;
                tt_Mais.Visibility = Visibility.Collapsed;
                tt_Obras.Visibility = Visibility.Collapsed;
                tt_Questionario.Visibility = Visibility.Collapsed;
                tt_Resultados.Visibility = Visibility.Collapsed;

            }
            else
            {

                tt_home.Visibility= Visibility.Visible;
                tt_Introducao.Visibility = Visibility.Visible;
                tt_Mais.Visibility = Visibility.Visible;
                tt_Obras.Visibility = Visibility.Visible;
                tt_Questionario.Visibility = Visibility.Visible;
                tt_Resultados.Visibility = Visibility.Visible;

            }


        }

        private void tg_btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void tg_btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tg_btn.IsChecked = false;
        }
    }
}