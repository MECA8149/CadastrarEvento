using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace CadastrarEvento.View
{
    public partial class CadastrarEvento : ContentPage
    {
        public CadastrarEvento()
        {
            InitializeComponent();

            // Inicializa o Picker com tipos de evento
            pck_Tipo.ItemsSource = new List<string>
            {
                "Palestra",
                "Workshop",
                "Conferência",
                "Oficina",
                "Seminário"
            };

            // Assina eventos para recalcular o custo sempre que um campo mudar
            entry_QuantidadeParticipantes.TextChanged += OnInputChanged;
            entry_CustoPorParticipante.TextChanged += OnInputChanged;
            dtpck_inicio.DateSelected += dtpck_inicio_DateSelected;
            dtpck_fim.DateSelected += dtpck_fim_DateSelected;

            // Define datas padrão para hoje
            dtpck_inicio.Date = DateTime.Today;
            dtpck_fim.Date = DateTime.Today;

            AtualizarCustoTotal();
        }

        private void OnInputChanged(object sender, EventArgs e)
        {
            AtualizarCustoTotal();
        }

        private void dtpck_inicio_DateSelected(object sender, DateChangedEventArgs e)
        {
            AtualizarCustoTotal();
        }

        private void dtpck_fim_DateSelected(object sender, DateChangedEventArgs e)
        {
            AtualizarCustoTotal();
        }

        private void AtualizarCustoTotal()
        {
            bool quantidadeValida = int.TryParse(entry_QuantidadeParticipantes.Text, out int quantidade);
            bool custoValido = decimal.TryParse(entry_CustoPorParticipante.Text, out decimal custoPorParticipante);

            DateTime dataInicio = dtpck_inicio.Date;
            DateTime dataFim = dtpck_fim.Date;

            if (!quantidadeValida || quantidade <= 0 || !custoValido || custoPorParticipante < 0 || dataFim < dataInicio)
            {
                lbl_CustoTotal.Text = "Custo Total: R$ 0,00";
                return;
            }

            int diasEvento = (dataFim - dataInicio).Days + 1;

            decimal custoTotal = quantidade * custoPorParticipante * diasEvento;

            lbl_CustoTotal.Text = $"Custo Total: R$ {custoTotal:N2} (em {diasEvento} dia(s))";
        }

        private async void On_Clicked(object sender, EventArgs e)
        {
            string tipoEvento = pck_Tipo.SelectedItem?.ToString() ?? "Não selecionado";

            if (!int.TryParse(entry_QuantidadeParticipantes.Text, out int quantidade) || quantidade <= 0)
            {
                await DisplayAlert("Erro", "Informe uma quantidade válida de participantes.", "OK");
                return;
            }

            if (!decimal.TryParse(entry_CustoPorParticipante.Text, out decimal custoPorParticipante) || custoPorParticipante < 0)
            {
                await DisplayAlert("Erro", "Informe um valor válido para o custo por participante.", "OK");
                return;
            }

            DateTime dataInicio = dtpck_inicio.Date;
            DateTime dataFim = dtpck_fim.Date;

            if (dataFim < dataInicio)
            {
                await DisplayAlert("Erro", "A data de fim deve ser posterior à data de início.", "OK");
                return;
            }

            int diasEvento = (dataFim - dataInicio).Days + 1;
            decimal custoTotal = quantidade * custoPorParticipante * diasEvento;

            Console.WriteLine("Evento cadastrado:");
            Console.WriteLine($"Tipo: {tipoEvento}");
            Console.WriteLine($"Participantes: {quantidade}");
            Console.WriteLine($"Custo por participante: {custoPorParticipante}");
            Console.WriteLine($"Data de início: {dataInicio:dd/MM/yyyy}");
            Console.WriteLine($"Data de fim: {dataFim:dd/MM/yyyy}");
            Console.WriteLine($"Quantidade de dias: {diasEvento}");
            Console.WriteLine($"Custo total: R$ {custoTotal:N2}");

            await Navigation.PushAsync(new EventoCadastrado(tipoEvento, dataInicio, dataFim, quantidade, custoTotal));

            LimparCampos();
        }

        private void LimparCampos()
        {
            pck_Tipo.SelectedIndex = -1;
            entry_QuantidadeParticipantes.Text = string.Empty;
            entry_CustoPorParticipante.Text = string.Empty;
            dtpck_inicio.Date = DateTime.Today;
            dtpck_fim.Date = DateTime.Today;
            lbl_CustoTotal.Text = "Custo Total: R$ 0,00";
        }
    }
}
