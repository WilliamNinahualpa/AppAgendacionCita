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
    public partial class VistaUsuarioIngresar : ContentPage
    {
        List<AppAgendacionCita.WS.ListarRoles> roles;
        public VistaUsuarioIngresar(string rol, string usuario)
        {
            InitializeComponent();
            CargarRoles();
            lblrol.Text = rol;
            lblusuario.Text = usuario;
            lblrol.IsVisible = false;
            lblusuario.IsVisible = false;
        }

        void CargarRoles()
        {
            roles = new List<AppAgendacionCita.WS.ListarRoles>();
            roles.Add(new AppAgendacionCita.WS.ListarRoles { rol = "PACIENTE" });
            roles.Add(new AppAgendacionCita.WS.ListarRoles { rol = "DOCTOR" });
            roles.Add(new AppAgendacionCita.WS.ListarRoles { rol = "ADMINISTRADOR" });
            foreach (var rol1 in roles)
            {
                pickerRol.Items.Add(rol1.rol);
            }
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("usuario", txtUsuario.Text);
                parametros.Add("clave", txtClave.Text);
                parametros.Add("rol", pickerRol.SelectedItem.ToString());
                
                cliente.UploadValues("http://192.168.100.66/moviles/RestUsuario.php", "POST", parametros);
                
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
            await Navigation.PushAsync(new MenuCabeceraPaciente(lblrol.Text, lblusuario.Text, 3));
        }
    }
}