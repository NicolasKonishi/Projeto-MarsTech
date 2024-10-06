using System;
using System.Windows;
using System.Windows.Controls;

namespace PIM_WPF.View
{
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

        private void Q_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "Q" : "q");
        private void W_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "W" : "w");
        private void E_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "E" : "e");
        private void R_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "R" : "r");
        private void T_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "T" : "t");
        private void Y_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "Y" : "y");
        private void U_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "U" : "u");
        private void I_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "I" : "i");
        private void O_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "O" : "o");
        private void P_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "P" : "p");

        private void A_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "A" : "a");
        private void S_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "S" : "s");
        private void D_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "D" : "d");
        private void F_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "F" : "f");
        private void G_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "G" : "g");
        private void H_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "H" : "h");
        private void J_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "J" : "j");
        private void K_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "K" : "k");
        private void L_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "L" : "l");

        private void Z_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "Z" : "z");
        private void X_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "X" : "x");
        private void C_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "C" : "c");
        private void V_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "V" : "v");
        private void B_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "B" : "b");
        private void N_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "N" : "n");
        private void M_Click(object sender, RoutedEventArgs e) => AdicionarLetra(shiftAtivado ? "M" : "m");

        private void Numero_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                AdicionarLetra(button.Content.ToString());
            }
        }

        private void Shift_Click(object sender, RoutedEventArgs e) => shiftAtivado = !shiftAtivado;

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

        private void Space_Click(object sender, RoutedEventArgs e) => AdicionarLetra(" ");
        private void Underline_Click(object sender, RoutedEventArgs e) => AdicionarLetra("_");
        private void Arroba_Click(object sender, RoutedEventArgs e) => AdicionarLetra("@");
        private void PontoCom_Click(object sender, RoutedEventArgs e) => AdicionarLetra(".com");

        private void Numerico_Click(object sender, RoutedEventArgs e)
        {
            // Alterna para o teclado numérico
            TecladoAlfabeto.Visibility = Visibility.Collapsed;
            TecladoNumerico.Visibility = Visibility.Visible;
        }

        private void Alfabetico_Click(object sender, RoutedEventArgs e)
        {
            // Alterna para o teclado alfabético
            TecladoNumerico.Visibility = Visibility.Collapsed;
            TecladoAlfabeto.Visibility = Visibility.Visible;
        }

        private void Run_Click(object sender, RoutedEventArgs e) => this.Hide();
    }
}
