namespace AppHotelAgenda13.Models;
public sealed class Acomodacao
{
    public string Nome { get; }
    public decimal ValorDiaria { get; }
    public int Capacidade { get; }
    public Acomodacao(string nome, decimal valorDiaria, int capacidade)
    {
        if (string.IsNullOrWhiteSpace(nome) || valorDiaria <= 0 || capacidade < 1)
            throw new ArgumentException("Dados da acomodação inválidos.");
        Nome = nome;
        ValorDiaria = valorDiaria;
        Capacidade = capacidade;
    }
    public override string ToString() => Nome;
}
