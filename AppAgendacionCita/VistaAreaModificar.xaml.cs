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
    public partial class VistaAreaModificar : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        
        public VistaAreaModificar(int id, string rol, string usuario)
        {
            InitializeComponent();
            getArea(id);
            txtIdArea.IsVisible = false;
            lblrol.Text = rol;
            lblusuario.Text = usuario;
            lblrol.IsVisible = false;
            lblusuario.IsVisible = false;
        }
        private async void getArea(int id)
        {
            try
            {
                String Url = "http://192.168.100.66/moviles/RestArea.php?codigo=" + id;
                var content = await client.GetStringAsync(Url);
                if (content.Equals("false"))
                {
                    var mensaje = "Datos incorrectos";
                    DependencyService.Get<Mensaje>().LongAlert(mensaje);
                }
                else
                {
                    List<AppAgendacionCita.WS.DatosArea> posts = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosArea>>("[" + content + "]");
                    foreach (var area1 in posts)
                    {
                        txtIdArea.Text = area1.are_id;
                        txtClinica.Text = area1.cli_nombre;
                        txtNombre.Text = area1.are_nombre;
                    }
                }
            }
            catch (Exception ex)
            {
                
                DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }

        private async void btnModificar_Clicked(object sender, EventArgs e)
        {
            try
            {


                WebClient cliente = new WebClient();
                var parametro = new System.Collections.Specialized.NameValueCollection();
                parametro.Add("codigo", txtIdArea.Text);               

                cliente.UploadValues("http://192.168.100.66/moviles/RestArea.php?are_id=" + txtIdArea.Text + "&are_nombre=" + txtNombre.Text, "PUT", parametro);

                

                await Navigation.PushAsync(new MenuCabeceraPaciente(lblrol.Text, lblusuario.Text, 2));
                var mensaje = "Registro modificado exitosamnte";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);                

            }
            catch (Exception ex)
            {
             
                DependencyService.Get<Mensaje>().ShortAlert(ex.Message);
            }

        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametro = new System.Collections.Specialized.NameValueCollection();
                parametro.Add("codigo", "0");


               cliente.UploadValues("http://192.168.100.66/moviles/RestArea.php?are_id=" + txtIdArea.Text + "", "DELETE", parametro);


                
                var mensaje = "Registro eliminado exitosamnte";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);
                await Navigation.PushAsync(new MenuCabeceraPaciente(lblrol.Text, lblusuario.Text, 2));
            }
            catch (Exception ex)
            {                
                DependencyService.Get<Mensaje>().ShortAlert(ex.Message);
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuCabeceraPaciente(lblrol.Text, lblusuario.Text, 2));
        }
    }
}