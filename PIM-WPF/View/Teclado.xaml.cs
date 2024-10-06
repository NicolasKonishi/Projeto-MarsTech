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
    /// Lógica interna para Teclado.xaml
    /// </summary>
    public partial class Teclado : Window
    {
        private bool shiftAtivado = false;
        private TextBox targetTextBox;

        public Teclado()
        {
            InitializeComponent();
            this.Loaded += Teclado_Load;
            this.Deactivated += Teclado_Deactivate;
        }

        public void SetTargetTextBox(TextBox textBox)
        {
            targetTextBox = textBox;
            targetTextBox.Focus();
        }

        private void Teclado_Load(object sender, RoutedEventArgs e)
        {
            // Centraliza o teclado na parte inferior da tela
            this.Left = (SystemParameters.WorkArea.Width - this.Width) / 2;
            this.Top = SystemParameters.WorkArea.Height - this.Height;
        }

        private void Teclado_Deactivate(object sender, EventArgs e)
        {
            // Oculta o teclado quando ele perde o foco
            this.Hide();
        }

        private void AdicionarLetra(string letra)
        {
            if (targetTextBox != null)
            {
                int cursorPosition = targetTextBox.SelectionStart;
                targetTextBox.Text = targetTextBox.Text.Insert(cursorPosition, letra);
                targetTextBox.SelectionStart = cursorPosition + letra.Length;
            }
        }

        private void Letra_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string letra = button.Content.ToString();
                AdicionarLetra(shiftAtivado ? letra.ToUpper() : letra.ToLower());
                shiftAtivado = false;
            }
        }

        private void Shift_Click(object sender, RoutedEventArgs e)
        {
            shiftAtivado = !shiftAtivado;
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (targetTextBox != null && targetTextBox.Text.Length > 0)
            {
                int cursorPosition = targetTextBox.SelectionStart;
                if (cursorPosition > 0)
                {
                    targetTextBox.Text = targetTextBox.Text.Remove(cursorPosition - 1, 1);
                    targetTextBox.SelectionStart = cursorPosition - 1;
                }
            }
        }

        private void Space_Click(object sender, RoutedEventArgs e)
        {
            AdicionarLetra(" ");
        }

        private void Underline_Click(object sender, RoutedEventArgs e)
        {
            AdicionarLetra("_");
        }

        private void Arroba_Click(object sender, RoutedEventArgs e)
        {
            AdicionarLetra("@");
        }

        private void PontoCom_Click(object sender, RoutedEventArgs e)
        {
            AdicionarLetra(".com");
        }

        private void Numerico_Click(object sender, RoutedEventArgs e)
        {
            // Abrir teclado numérico
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
