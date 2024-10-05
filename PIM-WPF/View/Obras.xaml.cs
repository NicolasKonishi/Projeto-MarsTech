using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PIM_WPF.View
{
    /// <summary>
    /// Interação lógica para Obras.xaml
    /// </summary>
    public partial class Obras : UserControl
    {
        public Obras()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;

            if (radioButton != null)
            {
                switch (radioButton.Content.ToString())
                {
                    case "1":
                        // Alterar para a imagem e o texto padrão
                        BackgroundImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Obra1Blur.png"));
                        ArtworkImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Obra1.png"));
                        TitleTextBlock.Text = "V i d a  e m  ";
                        TitleTextBlock2.Text = "M a r t e ";
                        DescriptionTextBlock.Text = "Oferece uma visão artística da possibilidade de vida no planeta vermelho. A obra apresenta uma interpretação imaginativa dos tipos de organismos que poderiam existir nas condições extremas de Marte, explorando conceitos de biologia astrobiológica e adaptações a ambientes inóspitos.";
                        DescriptionTextBlock.Foreground = new SolidColorBrush(Colors.White);
                        TitleTextBlock.Foreground = new SolidColorBrush(Colors.White);
                        TitleTextBlock2.Foreground = new SolidColorBrush(Colors.White);
                        break;

                    case "2":
                        // Alterar para a imagem e o texto do RadioButton 2
                        BackgroundImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Obra2Blur.png"));
                        ArtworkImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Obra2.png"));
                        TitleTextBlock.Text = "A  P r i m e i r a  ";
                        TitleTextBlock2.Text = "C o l ô n i a";
                        DescriptionTextBlock.Text = "Retrata a instalação pioneira dos primeiros colonizadores humanos em Marte. A arte explora a arquitetura futurística e o design das habitações e instalações que permitiriam a sobrevivência e o desenvolvimento de uma comunidade em um ambiente alienígena.";
                        DescriptionTextBlock.Foreground = new SolidColorBrush(Colors.White);
                        TitleTextBlock.Foreground = new SolidColorBrush(Colors.White);
                        TitleTextBlock2.Foreground = new SolidColorBrush(Colors.White);
                        break;

                    case "3":
                        // Alterar para a imagem e o texto do RadioButton 3
                        BackgroundImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Obra3Blur.png"));
                        ArtworkImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Obra3.png"));
                        TitleTextBlock.Text = "O  E n i g m a  ";
                        TitleTextBlock2.Text = "V e r m e l h o";
                        DescriptionTextBlock.Text = "Esta obra explora a cor marcante de Marte, causada pela oxidação do ferro em sua superfície, criando um vasto deserto de poeira vermelha. O Enigma Vermelho simboliza mistério e a busca por compreender o desconhecido.";
                        DescriptionTextBlock.Foreground = new SolidColorBrush(Colors.White);
                        TitleTextBlock.Foreground = new SolidColorBrush(Colors.White);
                        TitleTextBlock2.Foreground = new SolidColorBrush(Colors.White);
                        break;

                    case "4":
                        // Alterar para a imagem e o texto do RadioButton 4
                        BackgroundImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Obra4Blur.png"));
                        ArtworkImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Obra4.png"));
                        TitleTextBlock.Text = "S o b r e v i v ê n c i a  ";
                        TitleTextBlock2.Text = "E x t r e m a";
                        DescriptionTextBlock.Text = "Esta obra retrata os desafios de viver em Marte, um ambiente árido e inóspito. Com temperaturas extremas e uma atmosfera imprópria para a vida humana, a obra nos faz refletir sobre a viabilidade de sobreviver em Marte e a necessidade de inovação para superar esses obstáculos.";
                        DescriptionTextBlock.Foreground = new SolidColorBrush(Colors.Black);
                        TitleTextBlock.Foreground = new SolidColorBrush(Colors.Black);
                        TitleTextBlock2.Foreground = new SolidColorBrush(Colors.Black);
                        break;
                }
            }
        }
    }
}
