using PIM_WPF.Utilities;
using PIM_WPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

                tt_Home.Visibility = Visibility.Collapsed;
                tt_Introducao.Visibility = Visibility.Collapsed;
                tt_Mais.Visibility = Visibility.Collapsed;
                tt_Obras.Visibility = Visibility.Collapsed;
                tt_Questionario.Visibility = Visibility.Collapsed;
                tt_Resultados.Visibility = Visibility.Collapsed;

            }
            else
            {

                tt_Home.Visibility= Visibility.Visible;
                tt_Introducao.Visibility = Visibility.Visible;
                tt_Mais.Visibility = Visibility.Visible;
                tt_Obras.Visibility = Visibility.Visible;
                tt_Questionario.Visibility = Visibility.Visible;
                tt_Resultados.Visibility = Visibility.Visible;

            }


        }

        private void HomeButton_Click(object sender, MouseButtonEventArgs e)
        {
            // Navega de volta para a página Home no Frame
            FramePrincipal.Content = null;
            Logo.Visibility = Visibility.Visible; // Mostra a imagem quando na tela Introdução

        }

        private void tg_btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
            OverlayGrid.Visibility = Visibility.Collapsed;
        }

        private void tg_btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
            OverlayGrid.Visibility = Visibility.Visible;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tg_btn.IsChecked = false;
        }

        private void StackPanel_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            if (item != null)
            {
                // Identifica o texto associado ao ListViewItem
                TextBlock textBlock = item.FindVisualChild<TextBlock>();

                if (textBlock != null)
                {
                    switch (textBlock.Text)
                    {
                        case "Introdução":
                            FramePrincipal.Navigate(new Introducao()); // Chama a tela "Introdução"
                            Logo.Visibility = Visibility.Collapsed; // Mostra a imagem quando na tela Introdução
                            break;
                        case "Sobre":
                            FramePrincipal.Navigate(new Sobre()); // Chama a tela "Sobre"
                            Logo.Visibility = Visibility.Collapsed; // Oculta a imagem nas outras telas
                            break;
                        case "Obras":
                            FramePrincipal.Navigate(new Obras()); // Chama a tela "Obras"
                            Logo.Visibility = Visibility.Collapsed;
                            break;
                        case "Questionário":
                            FramePrincipal.Navigate(new Questionario()); // Chama a tela "Questionário"
                            Logo.Visibility = Visibility.Collapsed;
                            break;
                        case "Resultados":
                            FramePrincipal.Navigate(new Resultados()); // Chama a tela "Resultados"
                            Logo.Visibility = Visibility.Collapsed;
                            break;
                        case "Mais":
                            FramePrincipal.Navigate(new Mais()); // Chama a tela "Mais"
                            Logo.Visibility = Visibility.Collapsed;
                            break;
                    }
                }
            }
        }

        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Verifica se o menu está expandido
            if (tg_btn.IsChecked == true)
            {
                // Verifica se o clique foi fora do nav_pn1
                if (!nav_pn1.IsMouseOver)
                {
                    // Recolhe o menu
                    tg_btn.IsChecked = false;
                }
            }
        }

        private void FramePrincipal_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }

}




    
