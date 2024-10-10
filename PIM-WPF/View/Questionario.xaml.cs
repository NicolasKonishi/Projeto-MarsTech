using PIM_WPF.Entities;
using PIM_WPF.Service;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
            placeholder.Visibility = cbClassificacao.SelectedItem != null ? Visibility.Collapsed : Visibility.Visible;
        }

        private void cbClassificacao2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            holder.Visibility = cbClassificacao2.SelectedItem != null ? Visibility.Collapsed : Visibility.Visible;
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

            bool sucesso = await EnviarDadosAsync(apiService, visitante);

            MessageBox.Show(sucesso ? "Dados enviados com sucesso!" : "Falha ao enviar dados.");
        }

        private async Task<bool> EnviarDadosAsync(APIService apiService, QuestionarioResposta visitante)
        {
            try
            {
                return await apiService.EnviarDadosAsync(visitante);
            }
            catch (Exception ex)
            {
                // Logar ou tratar a exceção conforme necessário
                MessageBox.Show($"Erro ao enviar dados: {ex.Message}");
                return false;
            }
        }

        private void textBoxMultiline_GotFocus(object sender, RoutedEventArgs e)
        {
            HandleTextBoxGotFocus(textBoxMultiline, "D e i x e  s u a  m e n s a g e m  a q u i");
        }

        private void textBoxMultiline_LostFocus(object sender, RoutedEventArgs e)
        {
            HandleTextBoxLostFocus(textBoxMultiline, "D e i x e  s u a  m e n s a g e m  a q u i");
        }

        private void textBoxMultiline2_GotFocus(object sender, RoutedEventArgs e)
        {
            HandleTextBoxGotFocus(textBoxMultiline2, "E m a i l");
        }

        private void textBoxMultiline2_LostFocus(object sender, RoutedEventArgs e)
        {
            HandleTextBoxLostFocus(textBoxMultiline2, "E m a i l");
        }

        private void HandleTextBoxGotFocus(System.Windows.Controls.TextBox textBox, string placeholderText)
        {
            // Exibe o teclado virtual apenas se ainda não estiver aberto
            if (teclado == null)
            {
                teclado = new Teclado();
                teclado.SetTargetTextBox(textBox);
                teclado.Show();
            }

            // Remove o placeholder ao ganhar foco
            if (textBox.Text == placeholderText)
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black; // Muda a cor do texto para preto
            }
        }

        private void HandleTextBoxLostFocus(System.Windows.Controls.TextBox textBox, string placeholderText)
        {
            // Verifica se o teclado deve ser fechado apenas se a TextBox perder foco de um elemento diferente
            if (teclado != null && !textBox.IsFocused)
            {
                teclado.Close();
                teclado = null;
            }

            // Restaurar o placeholder se o campo estiver vazio ao perder o foco
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholderText;
                textBox.Foreground = Brushes.Gray; // Muda a cor do texto para cinza
            }
        }
    }
}
