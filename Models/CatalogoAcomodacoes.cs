namespace AppHotelAgenda13.Models;
public static class CatalogoAcomodacoes
{
    public static IReadOnlyList<Acomodacao> Todas { get; } = new List<Acomodacao>
    {
        new("Quarto Standard", 250m, 2),
        new("Quarto Família", 370m, 5),
        new("Suíte Premium", 490m, 3)
    }.AsReadOnly();
}
