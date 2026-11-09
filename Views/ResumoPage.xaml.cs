using AppHotelAgenda13.Models;
namespace AppHotelAgenda13.Views;
public partial class ResumoPage : ContentPage
{
    public ResumoPage(Reserva reserva) { InitializeComponent(); BindingContext = reserva; }
    private async void OnVoltarClicked(object sender, EventArgs e) => await Navigation.PopAsync();
    private async void OnConcluirClicked(object sender, EventArgs e)
    {
        await DisplayAlertAsync("Simulação concluída", "Resumo gerado com sucesso. Nenhuma reserva real foi efetuada.", "OK");
        await Shell.Current.GoToAsync("//inicio");
    }
}
