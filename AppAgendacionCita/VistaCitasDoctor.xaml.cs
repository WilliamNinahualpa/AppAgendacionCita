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
    public partial class VistaCitasDoctor : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppAgendacionCita.WS.DatosCita> _post;
        public VistaCitasDoctor(string rol, string usuario)
        {
            InitializeComponent();
            lblrol.Text = rol;
            lblusuario.Text = usuario;
            lblrol.IsVisible = false;
            lblusuario.IsVisible = false;
            txtiddoctor.IsVisible = false;
            getDoctor();
            getCitas();
        }


        private async void getDoctor()
        {
            try
            {
                var content = await client.GetStringAsync("http://192.168.100.66/moviles/RestDoctor.php?usuario=" + lblusuario.Text + "&rol=" + lblrol.Text + "");
                if (content.Equals("false"))
                {
                    var mensaje = "Datos incorrectos";
                    DependencyService.Get<Mensaje>().LongAlert(mensaje);
                }
                else
                {
                    List<AppAgendacionCita.WS.DatosDoctor> posts = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosDoctor>>("[" + content + "]");
                    foreach (var doctor1 in posts)
                    {
                        txtiddoctor.Text = doctor1.doc_id;
                       
                    }
                }

            }
            catch (Exception ex)
            {
                
                DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }


        private async void getCitas()
        {
            try
            {
                var content = await client.GetStringAsync("http://192.168.100.66/moviles/RestCitasDoctor.php?usuario=" + lblusuario.Text + "&rol=" + lblrol.Text + "");
                List<AppAgendacionCita.WS.DatosCita> clinica = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosCita>>(content);
                _post = new ObservableCollection<AppAgendacionCita.WS.DatosCita>(clinica);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                
                DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }

        private async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (AppAgendacionCita.WS.DatosCita)e.SelectedItem;
            var item = Obj.cit_id.ToString();
            int id = Convert.ToInt32(item);

            await Navigation.PushAsync(new VistaCitaDoctorDetalle(id, lblrol.Text, lblusuario.Text));
        }
    }
}