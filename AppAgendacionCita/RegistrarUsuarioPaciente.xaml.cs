using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAgendacionCita
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarUsuarioPaciente : ContentPage
    {
        public RegistrarUsuarioPaciente()
        {
            InitializeComponent();
        }

        private async void btnGuardarUsuarioP_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("usuario", txtUsuario.Text);
                parametros.Add("clave", txtClave.Text);
                parametros.Add("rol", "PACIENTE");

                cliente.UploadValues("http://192.168.100.66/moviles/RestUsuario.php", "POST", parametros);
                await DisplayAlert("Alerta", "ingresado corectamente", "ok");
                //var mensaje = "dato ingresado con éxito";
                //DependencyService.Get<Mensaje>().LongAlert(mensaje);

                txtUsuario.Text = "";
                txtClave.Text = "";


            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "ok");
                //DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }
    }
}