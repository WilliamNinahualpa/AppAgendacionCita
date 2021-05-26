using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace AppAgendacionCita
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.100.66/moviles/RestUsuario.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppAgendacionCita.WS.DatosUsuario> _post;
        List<AppAgendacionCita.WS.ListarRoles> roles;
        public MainPage()
        {
            InitializeComponent();
            InitApp();
        }

        void InitApp() {
            roles = new List<AppAgendacionCita.WS.ListarRoles>();
            roles.Add(new AppAgendacionCita.WS.ListarRoles { rol="PACIENTE" });
            roles.Add(new AppAgendacionCita.WS.ListarRoles { rol = "DOCTOR" });
            roles.Add(new AppAgendacionCita.WS.ListarRoles { rol = "ADMINISTRADOR" });
            foreach (var rol1 in roles) {
                pickerrol.Items.Add(rol1.rol);
                
            }
        }
        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var seleccionrol = pickerrol.SelectedItem;
                var content = await client.GetStringAsync("http://192.168.100.66/moviles/RestLogin.php?usuario="+txtUsuario.Text+ "&clave="+txtClave.Text+ "&rol=" + pickerrol.SelectedItem  + "");
                if (content.Equals("false"))
                {                    
                    var mensaje = "Datos incorrectos";
                    DependencyService.Get<Mensaje>().LongAlert(mensaje);
                }
                else
                {                    
                    List<AppAgendacionCita.WS.DatosUsuario> posts = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosUsuario>>("[" + content + "]");
                    _post = new ObservableCollection<AppAgendacionCita.WS.DatosUsuario>(posts);                    
                    await Navigation.PushAsync(new MenuCabeceraPaciente(seleccionrol.ToString(), txtUsuario.Text, 0));
                    var mensaje = "Bienvenido";
                    DependencyService.Get<Mensaje>().LongAlert(mensaje);
                }
            }
            catch (Exception ex)
            {                
                DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }

        private async void btnRegistrarse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrarUsuarioPaciente());
        }
       
        private void pickerrol_SelectedIndexChanged(object sender, EventArgs e)
        {
           // await Navigation.PushAsync(new Paciente());
        }
    }
}
