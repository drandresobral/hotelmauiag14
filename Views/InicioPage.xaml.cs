namespace AppHotelAgenda13.Views;
public partial class InicioPage : ContentPage
{
    public InicioPage() => InitializeComponent();
    private async void OnReservarClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("//reserva");
}
