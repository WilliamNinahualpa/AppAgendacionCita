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
    public partial class VistaDoctorModificar : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        
        public VistaDoctorModificar(int id, string rol, string usuario)
        {
            InitializeComponent();
            getDoctor(id);
            lblrol.Text = rol;
            lblusuario.Text = usuario;
            lblrol.IsVisible = false;
            lblusuario.IsVisible = false;
            txtiddoctor.IsVisible = false;
        }



        private async void getDoctor(int id)
        {
            try
            {
                String Url = "http://192.168.100.66/moviles/RestDoctor.php?codigo=" + id;
                var content = await client.GetStringAsync(Url);
                if (content.Equals("false"))
                {
                    var mensaje = "Datos incorrectos";
                    DependencyService.Get<Mensaje>().LongAlert(mensaje);
                }
                else
                {
                    List<AppAgendacionCita.WS.DatosDoctor> posts = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosDoctor>>("[" + content + "]");
                    foreach (var doctor1 in posts)
                    {
                        txtiddoctor.Text = doctor1.doc_id;
                        txtCedula.Text = doctor1.doc_cedula;
                        txtCorreo.Text = doctor1.doc_correo;
                        txtPrimerApellido.Text = doctor1.doc_primer_apellido;
                        txtSegundoApellido.Text = doctor1.doc_segundo_apellido;
                        txtPrimerNombre.Text = doctor1.doc_primer_nombre;
                        txtSegundoNombre.Text = doctor1.doc_segundo_nombre;
                        txtTelefono.Text = doctor1.doc_telefono;
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
                parametro.Add("codigo", "0");

                cliente.UploadValues("http://192.168.100.66/moviles/RestDoctor.php?doc_id=" + txtiddoctor.Text + "&doc_primer_nombre=" + txtPrimerNombre.Text + "&doc_segundo_nombre=" + txtSegundoNombre.Text + "&doc_primer_apellido=" + txtPrimerApellido.Text + "&doc_segundo_apellido=" + txtSegundoApellido.Text + "&doc_cedula=" + txtCedula.Text + "&doc_correo=" + txtCorreo.Text + "&doc_telefono=" + txtTelefono.Text + "&doc_primer_apellido=" + txtPrimerApellido.Text, "PUT", parametro);
                
                var mensaje = "Registro modificado exitosamnte";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);
                
                await Navigation.PushAsync(new MenuCabeceraPaciente(lblrol.Text, lblusuario.Text, 4));

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


                cliente.UploadValues("http://192.168.100.66/moviles/RestDoctor.php?doc_id=" + txtiddoctor.Text + "", "DELETE", parametro);

               
                var mensaje = "Registro eliminado exitosamnte";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);

                await Navigation.PushAsync(new MenuCabeceraPaciente(lblrol.Text, lblusuario.Text, 4));
            }
            catch (Exception ex)
            {
                DependencyService.Get<Mensaje>().ShortAlert(ex.Message);
            }
        }

        private async void btnRegreso_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuCabeceraPaciente(lblrol.Text, lblusuario.Text, 4));
        }
    }
}