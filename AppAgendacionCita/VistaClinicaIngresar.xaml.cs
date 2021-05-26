using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAgendacionCita
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaClinicaIngresar : ContentPage
    {

        private readonly HttpClient client = new HttpClient();
        
        public VistaClinicaIngresar(string rol, string usuario)
        {
            InitializeComponent();
            getPaises();
            lblrol.Text = rol;
            lblusuario.Text = usuario;
            lblrol.IsVisible = false;
            lblusuario.IsVisible = false;
        }

        private async void getPaises()
        {
            try
            {
                String Url = "https://restcountries.eu/rest/v2/all";
                var content = await client.GetStringAsync(Url);
                List<AppAgendacionCita.WS.ListarPaises> paises = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.ListarPaises>>(content);                
                foreach (var paises1 in paises)
                {
                    pickerPaises.Items.Add(paises1.name);
                }
            }
            catch (Exception ex)
            {                
                DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient clinica = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("direccion", txtDireccion.Text);
                parametros.Add("correo", txtCorreo.Text);
                parametros.Add("telefono", txtTelefono.Text);
                parametros.Add("paginaweb", txtPagina.Text);
                parametros.Add("representante", txtRepresentante.Text);
                parametros.Add("pais", pickerPaises.SelectedItem.ToString());

                clinica.UploadValues("http://192.168.100.66/moviles/RestClinica.php", "POST", parametros);
                
                var mensaje = "dato ingresado con éxito";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);

            }
            catch (Exception ex)
            {                
                DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuCabeceraPaciente(lblrol.Text, lblusuario.Text, 1));

        }
    }
}