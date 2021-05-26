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
    public partial class VistaArea : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppAgendacionCita.WS.DatosArea> _post;
        public VistaArea(string rol, string usuario)
        {
            InitializeComponent();
            getArea();
            lblrol.Text = rol;
            lblusuario.Text = usuario;
            lblrol.IsVisible = false;
            lblusuario.IsVisible = false;
        }

        private async void getArea()
        {
            try
            {
                var content = await client.GetStringAsync("http://192.168.100.66/moviles/RestArea.php");
                List<AppAgendacionCita.WS.DatosArea> areas = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosArea>>(content);
                _post = new ObservableCollection<AppAgendacionCita.WS.DatosArea>(areas);


                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                
                DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }

        private async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (AppAgendacionCita.WS.DatosArea)e.SelectedItem;
            var item = Obj.are_id.ToString();
            int id = Convert.ToInt32(item);

            await Navigation.PushAsync(new VistaAreaModificar(id, lblrol.Text, lblusuario.Text));
        }

        private async void btnArea_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaAreaIngresar(lblrol.Text, lblusuario.Text));
        }
    }
}