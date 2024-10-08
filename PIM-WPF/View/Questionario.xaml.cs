using PIM_WPF.Entities;
using PIM_WPF.Service;
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
        private Teclado teclado;

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

       



        private async void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            var visitante = new QuestionarioResposta
            {
                SatisfacaoGeral = cbClassificacao.Text,
                QualidadeExposicao = cbClassificacao2.Text,
                Comentario = textBoxMultiline.Text,
                Email = textBoxMultiline2.Text
            };

            var apiService = new APIService();

            bool sucesso = await apiService.EnviarDadosAsync(visitante);

            if (sucesso)
            {
                MessageBox.Show("Dados enviados com sucesso!");
            }
            else
            {
                MessageBox.Show("Falha ao enviar dados.");
            }

        }
        private void textBoxMultiline_GotFocus(object sender, RoutedEventArgs e)
        {
            // Exibe o teclado virtual apenas se ainda não estiver aberto
            if (teclado == null)
            {
                teclado = new Teclado();
                teclado.SetTargetTextBox(textBoxMultiline);
                teclado.Show();
            }

            // Remove o placeholder ao ganhar foco
            if (textBoxMultiline.Text == "D e i x e  s u a  m e n s a g e m  a q u i")
            {
                textBoxMultiline.Text = string.Empty;
                textBoxMultiline.Foreground = Brushes.Black; // Muda a cor do texto para preto
            }
        }

        private void textBoxMultiline_LostFocus(object sender, RoutedEventArgs e)
        {
            // Fechar o teclado quando a caixa de texto perder o foco
            if (teclado != null)
            {
                teclado.Close();
                teclado = null;
            }

            // Restaurar o placeholder se o campo estiver vazio ao perder o foco
            if (string.IsNullOrWhiteSpace(textBoxMultiline.Text))
            {
                textBoxMultiline.Text = "D e i x e  s u a  m e n s a g e m  a q u i";
                textBoxMultiline.Foreground = Brushes.Gray; // Muda a cor do texto para cinza
            }
        }

        private void textBoxMultiline2_GotFocus(object sender, RoutedEventArgs e)
        {
            // Exibe o teclado virtual apenas se ainda não estiver aberto
            if (teclado == null)
            {
                teclado = new Teclado();
                teclado.SetTargetTextBox(textBoxMultiline2);
                teclado.Show();
            }

            // Remove o placeholder ao ganhar foco
            if (textBoxMultiline.Text == "E m a i l")
            {
                textBoxMultiline.Text = string.Empty;
                textBoxMultiline.Foreground = Brushes.Black; // Muda a cor do texto para preto
            }
        }

        private void textBoxMultiline2_LostFocus(object sender, RoutedEventArgs e)
        {
            // Fechar o teclado quando a caixa de texto perder o foco
            if (teclado != null)
            {
                teclado.Close();
                teclado = null;
            }

            // Restaurar o placeholder se o campo estiver vazio ao perder o foco
            if (string.IsNullOrWhiteSpace(textBoxMultiline.Text))
            {
                textBoxMultiline.Text = "E m a i l";
                textBoxMultiline.Foreground = Brushes.Gray; // Muda a cor do texto para cinza
            }
        }

    }


}
        
