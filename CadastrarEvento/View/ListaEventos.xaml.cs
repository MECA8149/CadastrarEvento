using Microsoft.Maui.Controls;
using CadastrarEvento.Data;
using CadastrarEvento.Model;

namespace CadastrarEvento.View
{
    public partial class ListaEventos : ContentPage
    {
        public ListaEventos()
        {
            InitializeComponent();

            // Carrega a lista de eventos
            cv_Eventos.ItemsSource = BancoFake.Eventos;
        }
    }
}
