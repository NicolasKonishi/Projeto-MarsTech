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
using System.Windows.Shapes;

namespace PIM_WPF.View
{
    /// <summary>
    /// Lógica interna para TecladoNumerico.xaml
    /// </summary>
    public partial class TecladoNumerico : Window
    {
        private TextBox targetTextBox;
        private Teclado teclado; // Referência à janela principal do teclado

        public TecladoNumerico(TextBox targetTextBox, Teclado teclado)
        {
            InitializeComponent();
            this.targetTextBox = targetTextBox;
            this.teclado = teclado;
            this.Deactivated += TecladoNumerico_Deactivated;
        }

        private void TecladoNumerico_Deactivated(object sender, EventArgs e)
        {
            // Oculta a janela numérica quando perde o foco
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Centraliza a janela na parte inferior da tela
            double screenWidth = SystemParameters.WorkArea.Width;
            double screenHeight = SystemParameters.WorkArea.Height;

            double windowWidth = this.Width;
            double windowHeight = this.Height;

            this.Left = (screenWidth - windowWidth) / 2;
            this.Top = screenHeight - windowHeight;
        }

        private void BtnTecla_Click(object sender, RoutedEventArgs e)
        {
            // Evento para adicionar números ou caracteres especiais ao TextBox alvo
            Button btn = sender as Button;
            if (btn != null && targetTextBox != null)
            {
                string character = btn.Content.ToString();
                int cursorPosition = targetTextBox.SelectionStart;
                targetTextBox.Text = targetTextBox.Text.Insert(cursorPosition, character);
                targetTextBox.SelectionStart = cursorPosition + character.Length;
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            // Combina as funcionalidades dos botões Del e Back
            if (!string.IsNullOrEmpty(targetTextBox.Text))
            {
                int cursorPosition = targetTextBox.SelectionStart;
                if (cursorPosition > 0)
                {
                    // Remove o caractere antes do cursor (simulando Backspace)
                    targetTextBox.Text = targetTextBox.Text.Remove(cursorPosition - 1, 1);
                    targetTextBox.SelectionStart = cursorPosition - 1;
                }
            }
        }

        private void BtnRun_Click(object sender, RoutedEventArgs e)
        {
            // Evento para fechar o teclado numérico e retornar ao teclado principal
            teclado.Show();
            this.Close();
        }
    }
}
