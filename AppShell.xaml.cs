namespace AppHotelAgenda13;
public partial class AppShell : Shell { public AppShell() { InitializeComponent(); Routing.RegisterRoute(nameof(Views.ResumoPage), typeof(Views.ResumoPage)); } }
