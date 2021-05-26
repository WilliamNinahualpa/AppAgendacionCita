using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAgendacionCita
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaCitaDoctorDetalle : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        public VistaCitaDoctorDetalle(int id, string rol, string usuario)
        {
            InitializeComponent();
            lblrol.Text = rol;
            lblusuario.Text = usuario;
            lblidcita.Text = id.ToString();
            lblrol.IsVisible = false;
            lblusuario.IsVisible = false;
            lblidcita.IsVisible = false;
            getCita();
            txtNombre1.IsVisible = false;
            txtLatitud.IsVisible = false;
            txtLongitud.IsVisible = false;
        }

        private async void getCita()
        {
            try
            {
                var content = await client.GetStringAsync("http://192.168.100.66/moviles/RestCitasDoctor.php?codigo=" + lblidcita.Text + "&usuario1=" + lblusuario.Text + "&rol=" + lblrol.Text + "");
                List<AppAgendacionCita.WS.DatosCita> clinica = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosCita>>(content);
                foreach (var rol1 in clinica)
                {
                    txtfecha.Text = rol1.cit_fecha;
                    txtHora.Text = rol1.cit_hora;
                    txtDoctor.Text = rol1.doc_primer_nombre + " " + rol1.doc_segundo_nombre + " " + rol1.doc_primer_apellido + " " + rol1.doc_segundo_apellido;
                    txtPaciente.Text = rol1.pac_primer_nombre + " " + rol1.pac_segundo_nombre + " " + rol1.pac_primer_apellido + " " + rol1.doc_segundo_apellido;
                    txtArea.Text = rol1.are_nombre;
                    txtClinica.Text = rol1.cli_nombre;
                }
            }
            catch (Exception ex)
            {                
                DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }

        private async void btnAbrir_Clicked(object sender, EventArgs e)
        {
            if (!double.TryParse(txtLatitud.Text, out double lat))
                return;
            if (!double.TryParse(txtLongitud.Text, out double lng))
                return;
            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                Name = txtNombre1.Text,
                NavigationMode = NavigationMode.None
            });
        }
    }
}