using System.Collections.Generic;
using CadastrarEvento.Model;

namespace CadastrarEvento.Data
{
    public static class BancoFake
    {
        public static List<Evento> Eventos { get; } = new();
    }
}
