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
    public partial class VistaAreaModificar : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppAgendacionCita.WS.DatosArea> _post;
        public VistaAreaModificar(int id)
        {
            InitializeComponent();
            getArea(id);
        }
        private async void getArea(int id)
        {
            try
            {
                String Url = "http://192.168.100.66/moviles/RestArea.php?codigo=" + id;
                var content = await client.GetStringAsync(Url);
                if (content.Equals("false"))
                {
                    await DisplayAlert("Alerta", "Datos incorrectos", "ok");
                }
                else
                {
                    List<AppAgendacionCita.WS.DatosArea> posts = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosArea>>("[" + content + "]");
                    foreach (var area1 in posts)
                    {
                        txtNombre.Text = area1.are_nombre;
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Error" + ex.Message, "ok");
                //DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }
    }
}