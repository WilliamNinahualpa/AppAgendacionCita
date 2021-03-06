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
    public partial class RegistrarDoctor : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        public RegistrarDoctor(string rol, string usuario)
        {
            InitializeComponent();
            lblrol.Text = rol;
            lblusuario.Text = usuario;
            lblrol.IsVisible = false;
            lblusuario.IsVisible = false;
            get();
        }


        private async void get()
        {
            try
            {
                var content = await client.GetStringAsync("http://192.168.100.66/moviles/RestDoctor.php?usuario=" + lblusuario.Text + "&rol=" + lblrol.Text + "");
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
                        txtPrimerNombre.Text = doctor1.doc_primer_nombre;
                        txtSegundoNombre.Text = doctor1.doc_segundo_nombre;
                        txtPrimerApellido.Text = doctor1.doc_primer_apellido;
                        txtSegundoApellido.Text = doctor1.doc_segundo_apellido;
                        txtTelefono.Text = doctor1.doc_telefono;
                    }
                }

            }
            catch (Exception ex)
            {
               
                DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }



        private void btnModificar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametro = new System.Collections.Specialized.NameValueCollection();
                parametro.Add("codigo", txtiddoctor.Text);

                cliente.UploadValues("http://192.168.100.66/moviles/RestDoctor.php?doc_id=" + txtiddoctor.Text + "&DOC_PRIMER_NOMBRE=" + txtPrimerNombre.Text + "&DOC_SEGUNDO_NOMBRE=" + txtSegundoNombre.Text + "&DOC_PRIMER_APELLIDO=" + txtPrimerApellido.Text + "&DOC_SEGUNDO_APELLIDO=" + txtSegundoApellido.Text + "&DOC_CEDULA=" + txtCedula.Text + "&DOC_CORREO=" + txtCorreo.Text + "&DOC_TELEFONO=" + txtTelefono.Text, "PUT", parametro);


                
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