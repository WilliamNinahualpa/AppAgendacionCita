using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    public partial class VistaAreaIngresar : ContentPage
    {
        private HttpClient client = new HttpClient();
        List<AppAgendacionCita.WS.DatosClinica> clinicas;
        public VistaAreaIngresar(string rol, string usuario)
        {
            InitializeComponent();
            clinica();
            lblrol.Text = rol;
            lblusuario.Text = usuario;
            lblrol.IsVisible = false;
            lblusuario.IsVisible = false;
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var d = pickerClinica.SelectedItem.ToString();                            

                  var parametros = new System.Collections.Specialized.NameValueCollection();

                  parametros.Add("idclinica", "1");
                  parametros.Add("nombrearea", txtNombre.Text);

                  cliente.UploadValues("http://192.168.100.66/moviles/RestArea.php", "POST", parametros);
                  
                   var mensaje = "dato ingresado con éxito";
                   DependencyService.Get<Mensaje>().LongAlert(mensaje);                

            }
            catch (Exception ex)
            {             
                DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }

        }

        public async void clinica()
        {
            try
            {
                var content = await client.GetStringAsync("http://192.168.100.66/moviles/RestClinica.php");
                if (content.Equals("false"))
                {
                    var mensaje = "Datos incorrectos";
                    DependencyService.Get<Mensaje>().LongAlert(mensaje);
                }
                else
                {
                    clinicas = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosClinica>>(content);
                    foreach (var clinica1 in clinicas)
                    {

                        pickerClinica.Items.Add(clinica1.cli_nombre);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                
                DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuCabeceraPaciente(lblrol.Text, lblusuario.Text, 2));
        }
    }
}