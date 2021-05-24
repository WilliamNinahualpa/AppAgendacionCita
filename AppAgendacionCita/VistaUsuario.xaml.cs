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
    public partial class VistaUsuario : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppAgendacionCita.WS.DatosUsuario> _post;
        public VistaUsuario()
        {
            InitializeComponent();
            getUsuario();
        }

        private async void getUsuario()
        {
            try
            {
                var content = await client.GetStringAsync("http://192.168.100.66/moviles/RestUsuario.php");
                List<AppAgendacionCita.WS.DatosUsuario> usuarios = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosUsuario>>(content);
                _post = new ObservableCollection<AppAgendacionCita.WS.DatosUsuario>(usuarios);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error" + ex.Message, "ok");
                //DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }

        private async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (AppAgendacionCita.WS.DatosUsuario)e.SelectedItem;
            var item = Obj.usu_id.ToString();
            int id = Convert.ToInt32(item);

            await Navigation.PushAsync(new VistaUsuarioModificar(id));
        }
    }
}