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
using static MaterialDesignThemes.Wpf.Theme;

namespace PIM_WPF.View
{
    /// <summary>
    /// Interação lógica para Questionario.xam
    /// </summary>
    public partial class Questionario : UserControl
    {
        public Questionario()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbClassificacao.SelectedItem != null)
            {
                placeholder.Visibility = Visibility.Collapsed;
            }
            else
            {
                placeholder.Visibility = Visibility.Visible;
            }
        }

        private void cbClassificacao2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbClassificacao2.SelectedItem != null)
            {
                holder.Visibility = Visibility.Collapsed;
            }
            else
            {
                holder.Visibility = Visibility.Visible;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Oculta o placeholder quando a caixa de texto ganha foco e está vazia
            if (string.IsNullOrEmpty(textBoxMultiline.Text))
            {
                place.Visibility = Visibility.Hidden;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Mostra o placeholder novamente se a caixa de texto estiver vazia quando perder o foco
            if (string.IsNullOrEmpty(textBoxMultiline.Text))
            {
                place.Visibility = Visibility.Visible;
            }
        }

        private void TextBox_GotFocus2(object sender, RoutedEventArgs e)
        {
            // Oculta o placeholder quando a caixa de texto ganha foco e está vazia
            if (string.IsNullOrEmpty(textBoxMultiline2.Text))
            {
                place2.Visibility = Visibility.Hidden;
            }
        }

        private void TextBox_LostFocus2(object sender, RoutedEventArgs e)
        {
            // Mostra o placeholder novamente se a caixa de texto estiver vazia quando perder o foco
            if (string.IsNullOrEmpty(textBoxMultiline2.Text))
            {
                place2.Visibility = Visibility.Visible;
            }
        }
    }
}
        
