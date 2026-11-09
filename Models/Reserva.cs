using System.Globalization;
namespace AppHotelAgenda13.Models;
public sealed class Reserva
{
    private string _nome = "";
    public string Nome { get => _nome; set => _nome = !string.IsNullOrWhiteSpace(value) ? value.Trim() : throw new ArgumentException("Informe o nome do hóspede."); }
    public Acomodacao Acomodacao { get; set; } = CatalogoAcomodacoes.Todas[0];
    public string Quarto => Acomodacao.Nome;
    public int Hospedes { get; set; } = 1;
    public DateTime Entrada { get; set; } = DateTime.Today;
    public DateTime Saida { get; set; } = DateTime.Today.AddDays(1);
    public int Diarias => (Saida.Date - Entrada.Date).Days;
    public decimal ValorDiaria => Acomodacao.ValorDiaria;
    public decimal Total => Diarias * ValorDiaria;
    public string Periodo => $"{Entrada:dd/MM/yyyy} a {Saida:dd/MM/yyyy}";
    public string TotalFormatado => Total.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
    public string ValorDiariaFormatado => ValorDiaria.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
    public void Validar()
    {
        if (string.IsNullOrWhiteSpace(Nome)) throw new ArgumentException("Informe o nome do hóspede.");
        if (Entrada.Date < DateTime.Today) throw new ArgumentException("A entrada não pode ser anterior à data atual.");
        if (Saida.Date <= Entrada.Date) throw new ArgumentException("A saída deve ser posterior à entrada.");
        if (Hospedes < 1 || Hospedes > Acomodacao.Capacidade) throw new ArgumentException($"A acomodação aceita de 1 a {Acomodacao.Capacidade} hóspede(s).");
    }
}
