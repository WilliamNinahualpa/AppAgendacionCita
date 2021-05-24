using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAgendacionCita
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaClinica : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppAgendacionCita.WS.DatosClinica> _post;
        public VistaClinica()
        {
            InitializeComponent();
            getClinica();
        }

        private async void getClinica()
        {
            try
            {              
                var content = await client.GetStringAsync("http://192.168.100.66/moviles/RestClinica.php");
                List<AppAgendacionCita.WS.DatosClinica> clinica = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosClinica>>(content);
                _post = new ObservableCollection<AppAgendacionCita.WS.DatosClinica>(clinica);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error" + ex.Message, "ok");
                //DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }

        private async  void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (AppAgendacionCita.WS.DatosClinica)e.SelectedItem;
            var item = Obj.cli_id.ToString();            
            int id = Convert.ToInt32(item);

            await Navigation.PushAsync(new VistaClinicaModificar(id));
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaClinicaIngresar());
        }
    }
}