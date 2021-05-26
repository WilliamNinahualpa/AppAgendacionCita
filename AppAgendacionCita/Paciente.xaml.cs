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
    public partial class Paciente : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        public Paciente(String rol, string usuario)
        {
            InitializeComponent();
            lblrol.Text = rol;
            lblusuario.Text = usuario;
            lblrol.IsVisible = false;
            lblusuario.IsVisible = false;
            txtId.IsVisible = false;
            get();
        }

        private async void get()
        {
            try
            {                
                var content = await client.GetStringAsync("http://192.168.100.66/moviles/RestPaciente.php?usuario=" + lblusuario.Text + "&rol=" + lblrol.Text + "");
                if (content.Equals("false"))
                {
                    var mensaje = "Datos incorrectos";
                    DependencyService.Get<Mensaje>().LongAlert(mensaje);
                }
                else
                {
                    List<AppAgendacionCita.WS.DatosPaciente> posts = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosPaciente>>("[" + content + "]");
                    foreach (var rol1 in posts)
                    {
                        txtId.Text = rol1.pac_id;
                        txtCedula.Text = rol1.pac_cedula;
                        txtCorreo.Text = rol1.pac_correo;
                        txtPrimerNombre.Text = rol1.pac_primer_nombre;
                        txtSegundoNombre.Text = rol1.pac_segundo_nombre;
                        txtPrimerApellido.Text = rol1.pac_primer_apellido;
                        txtSegundoApellido.Text = rol1.pac_segundo_apellido;
                        txtTelefono.Text = rol1.pac_telefono;
                    }                   
                }
                
            }
            catch (Exception ex)
            {
                
                DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnModificarPaciente_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametro = new System.Collections.Specialized.NameValueCollection();
                parametro.Add("codigo", txtId.Text);
                
                cliente.UploadValues("http://192.168.100.66/moviles/RestPaciente.php?pac_id=" + txtId.Text + "&PAC_PRIMER_NOMBRE=" + txtPrimerNombre.Text + "&PAC_SEGUNDO_NOMBRE=" + txtSegundoNombre.Text + "&PAC_PRIMER_APELLIDO=" + txtPrimerApellido.Text + "&PAC_SEGUNDO_APELLIDO=" + txtSegundoApellido.Text + "&PAC_CEDULA=" + txtCedula.Text + "&PAC_CORREO=" + txtCorreo.Text + "&PAC_TELEFONO=" + txtTelefono.Text, "PUT", parametro);


                
                var mensaje = "Registro modificado exitosamnte";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);

               


            }
            catch (Exception ex)
            {
               
                DependencyService.Get<Mensaje>().ShortAlert(ex.Message);
            }
        }
    }
}