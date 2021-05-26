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
    public partial class VistaDoctor : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppAgendacionCita.WS.DatosDoctor> _post;
        public VistaDoctor(string rol, string usuario)
        {
            InitializeComponent();
            getDoctor();

            lblrol.Text = rol;
            lblusuario.Text = usuario;
            lblrol.IsVisible = false;
            lblusuario.IsVisible = false;
        }

        private async void getDoctor()
        {
            try
            {
                var content = await client.GetStringAsync("http://192.168.100.66/moviles/RestDoctor.php");
                List<AppAgendacionCita.WS.DatosDoctor> doctors = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosDoctor>>(content);
                _post = new ObservableCollection<AppAgendacionCita.WS.DatosDoctor>(doctors);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {                
                DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }

        private async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (AppAgendacionCita.WS.DatosDoctor)e.SelectedItem;
            var item = Obj.doc_id.ToString();
            int id = Convert.ToInt32(item);

            await Navigation.PushAsync(new VistaDoctorModificar(id, lblrol.Text, lblusuario.Text));
        }
    }
}