namespace CadastrarEvento.Model
{
    public class Evento
    {
        public string Tipo { get; set; }
        public int QuantidadeParticipantes { get; set; }
        public decimal CustoPorParticipante { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal CustoTotal => QuantidadeParticipantes * CustoPorParticipante;
    }
}
