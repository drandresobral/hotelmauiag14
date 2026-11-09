using AppHotelAgenda13.Models;
using System.Globalization;
namespace AppHotelAgenda13.Views;
public partial class MainPage : ContentPage
{
    private bool _inicializando;
    public MainPage()
    {
        _inicializando = true;
        InitializeComponent();
        QuartoPicker.ItemsSource = CatalogoAcomodacoes.Todas.ToList();
        var hoje = DateTime.Today;
        EntradaPicker.MinimumDate = hoje;
        EntradaPicker.Date = hoje;
        SaidaPicker.MinimumDate = hoje.AddDays(1);
        SaidaPicker.Date = hoje.AddDays(1);
        QuartoPicker.SelectedIndex = 0;
        _inicializando = false;
        AtualizarPrevia();
    }
    private void OnHospedesChanged(object sender, ValueChangedEventArgs e)
    {
        if (HospedesLabel is null) return;
        HospedesLabel.Text = $"{(int)e.NewValue} hóspede(s)";
        AtualizarPrevia();
    }
    private void OnQuartoChanged(object sender, EventArgs e)
    {
        if (QuartoPicker.SelectedItem is Acomodacao quarto)
        {
            HospedesStepper.Maximum = quarto.Capacidade;
            if (HospedesStepper.Value > quarto.Capacidade) HospedesStepper.Value = quarto.Capacidade;
            CapacidadeLabel.Text = $"Capacidade máxima: {quarto.Capacidade} hóspede(s)";
        }
        AtualizarPrevia();
    }
    private void OnEntradaChanged(object sender, DateChangedEventArgs e)
    {
        if (SaidaPicker is null || EntradaPicker.Date is not DateTime entrada) return;
        var minimo = entrada.AddDays(1);
        SaidaPicker.MinimumDate = minimo;
        if (SaidaPicker.Date is not DateTime saida || saida < minimo) SaidaPicker.Date = minimo;
        AtualizarPrevia();
    }
    private void OnSaidaChanged(object sender, DateChangedEventArgs e) => AtualizarPrevia();
    private void AtualizarPrevia()
    {
        if (_inicializando || PreviaLabel is null || DiariasLabel is null) return;
        if (QuartoPicker.SelectedItem is not Acomodacao quarto || EntradaPicker.Date is not DateTime entrada || SaidaPicker.Date is not DateTime saida) return;
        int dias = Math.Max(0, (saida.Date - entrada.Date).Days);
        PreviaLabel.Text = (dias * quarto.ValorDiaria).ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
        DiariasLabel.Text = $"{dias} diária(s) × {quarto.ValorDiaria.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}";
    }
    private async void OnReservarClicked(object sender, EventArgs e)
    {
        try
        {
            if (QuartoPicker.SelectedItem is not Acomodacao quarto || EntradaPicker.Date is not DateTime entrada || SaidaPicker.Date is not DateTime saida)
                throw new ArgumentException("Selecione a acomodação e as datas.");
            var reserva = new Reserva { Nome = NomeEntry.Text ?? "", Acomodacao = quarto, Hospedes = (int)HospedesStepper.Value, Entrada = entrada, Saida = saida };
            reserva.Validar();
            await Navigation.PushAsync(new ResumoPage(reserva));
        }
        catch (ArgumentException ex) { await DisplayAlertAsync("Verifique os dados", ex.Message, "OK"); }
    }
    private void OnLimparClicked(object sender, EventArgs e)
    {
        NomeEntry.Text = "";
        QuartoPicker.SelectedIndex = 0;
        HospedesStepper.Value = 2;
        EntradaPicker.Date = DateTime.Today;
        SaidaPicker.Date = DateTime.Today.AddDays(1);
        AtualizarPrevia();
    }
}
