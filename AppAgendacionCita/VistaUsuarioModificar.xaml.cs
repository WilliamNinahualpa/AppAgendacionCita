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
    public partial class VistaUsuarioModificar : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        
        public VistaUsuarioModificar(int id, string rol, string usuario)
        {
            InitializeComponent();
            getUsuario(id);
            txtId.IsVisible = false;
            lblrol.Text = rol;
            lblusuario.Text = usuario;
            lblrol.IsVisible = false;
            lblusuario.IsVisible = false;
        }

        private async void getUsuario(int id)
        {
            try
            {
                String Url = "http://192.168.100.66/moviles/RestUsuario.php?codigo=" + id;
                var content = await client.GetStringAsync(Url);
                if (content.Equals("false"))
                {
                    var mensaje = "Datos incorrectos";
                    DependencyService.Get<Mensaje>().LongAlert(mensaje);
                }
                else
                {
                    List<AppAgendacionCita.WS.DatosUsuario> posts = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosUsuario>>("[" + content + "]");
                    foreach (var usuario1 in posts)
                    {
                        txtId.Text = usuario1.usu_id.ToString();
                        txtRol.Text = usuario1.usu_rol;
                        txtUsuario.Text = usuario1.usu_usuario;
                        txtClave.Text = usuario1.usu_clave;
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
                parametro.Add("codigo", txtId.Text);             

                cliente.UploadValues("http://192.168.100.66/moviles/RestUsuario.php?usu_id=" + txtId.Text + "&usu_usuario=" + txtUsuario.Text + "&usu_clave=" + txtClave.Text, "PUT", parametro);
                
                var mensaje = "Registro modificado exitosamnte";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);

                await Navigation.PushAsync(new MenuCabeceraPaciente(lblrol.Text, lblusuario.Text, 3));

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


                cliente.UploadValues("http://192.168.100.66/moviles/RestUsuario.php?usu_id=" + txtId.Text + "", "DELETE", parametro);
                
                var mensaje = "Registro eliminado exitosamnte";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);

                await Navigation.PushAsync(new MenuCabeceraPaciente(lblrol.Text, lblusuario.Text, 3));
            }
            catch (Exception ex)
            {
                DependencyService.Get<Mensaje>().ShortAlert(ex.Message);
            }

        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuCabeceraPaciente(lblrol.Text, lblusuario.Text, 3));
        }
    }
}