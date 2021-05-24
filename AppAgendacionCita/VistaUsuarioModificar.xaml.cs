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
    public partial class VistaUsuarioModificar : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppAgendacionCita.WS.DatosUsuario> _post;
        public VistaUsuarioModificar(int id)
        {
            InitializeComponent();
            getUsuario(id);
        }

        private async void getUsuario(int id)
        {
            try
            {
                String Url = "http://192.168.100.66/moviles/RestUsuario.php?codigo=" + id;
                var content = await client.GetStringAsync(Url);
                if (content.Equals("false"))
                {
                    await DisplayAlert("Alerta", "Datos incorrectos", "ok");
                }
                else
                {
                    List<AppAgendacionCita.WS.DatosUsuario> posts = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosUsuario>>("[" + content + "]");
                    foreach (var usuario1 in posts)
                    {
                        txtUsuario.Text = usuario1.usu_usuario;
                        txtClave.Text = usuario1.usu_clave;
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