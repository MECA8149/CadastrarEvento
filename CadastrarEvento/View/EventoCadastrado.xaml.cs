using Microsoft.Maui.Controls;
using System;

namespace CadastrarEvento.View
{
    public partial class EventoCadastrado : ContentPage
    {
        // Propriedades para receber os dados
        private string tipoEvento;
        private DateTime dataInicio;
        private DateTime dataFim;
        private int quantidadeParticipantes;
        private decimal custoTotal;

        // Construtor que recebe os dados do evento
        public EventoCadastrado(string tipoEvento, DateTime dataInicio, DateTime dataFim, int quantidadeParticipantes, decimal custoTotal)
        {
            InitializeComponent();

            this.tipoEvento = tipoEvento;
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
            this.quantidadeParticipantes = quantidadeParticipantes;
            this.custoTotal = custoTotal;

            PreencherLabels();
        }

        private void PreencherLabels()
        {
            lbl_TipoEvento.Text = $"Tipo de Evento: {tipoEvento}";
            lbl_DataInicio.Text = $"Data Início: {dataInicio:dd/MM/yyyy}";
            lbl_DataFim.Text = $"Data Fim: {dataFim:dd/MM/yyyy}";
            lbl_Quantidade.Text = $"Quantidade de Participantes: {quantidadeParticipantes}";
            lbl_CustoTotal.Text = $"Custo Total: R$ {custoTotal:N2}";
        }

        private async void OnCadastrarNovoEventoClicked(object sender, EventArgs e)
        {
            // Navega de volta para a página de cadastro
            await Navigation.PopAsync();
        }
    }
}
