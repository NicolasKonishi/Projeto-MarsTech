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

namespace PIM_WPF.View
{
    /// <summary>
    /// Interação lógica para Resultados.xam
    /// </summary>
    public partial class Resultados : UserControl
    {
        private readonly APIService _apiService;

        public Resultados()
        {
            InitializeComponent();
            _apiService = new APIService();
            CarregarMediaExposicao();
            ObterMediaQualidadeoAsync();
            CarregarComentariosAsync();
        }

        private async void CarregarMediaExposicao()
        {
            try
            {
                var mediaExposicao = await _apiService.ObterMediaExposicaoAsync();

                txtMediaExposicao.Text = mediaExposicao.ToString("N2"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a média da exposição: {ex.Message}");
            }
        }
        private async void ObterMediaQualidadeoAsync()
        {
            try
            {
                var mediaQualidade= await _apiService.ObterMediaQualidadeoAsync();

                txtMediaServicos.Text = mediaQualidade.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a média da exposição: {ex.Message}");
            }
        }

        private async Task CarregarComentariosAsync()
        {
            try
            {
                var comentarioResponse = await _apiService.ObterComentarioAleatorioAsync();

                txtComentario.Text = comentarioResponse?.Comentario ?? "Nenhum comentário disponível.";

                txtEmail.Text = comentarioResponse?.Email ?? "Nenhum email disponível.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar comentários: {ex.Message}");
            }
        }



    }
}
