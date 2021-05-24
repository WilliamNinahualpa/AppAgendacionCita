using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private ObservableCollection<AppAgendacionCita.WS.DatosDoctor> _post;
        public VistaDoctorModificar(int id)
        {
            InitializeComponent();
            getDoctor(id);
        }



        private async void getDoctor(int id)
        {
            try
            {
                String Url = "http://192.168.100.66/moviles/RestDoctor.php?codigo=" + id;
                var content = await client.GetStringAsync(Url);
                if (content.Equals("false"))
                {
                    await DisplayAlert("Alerta", "Datos incorrectos", "ok");
                }
                else
                {
                    List<AppAgendacionCita.WS.DatosDoctor> posts = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosDoctor>>("[" + content + "]");
                    foreach (var doctor1 in posts)
                    {
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
                DisplayAlert("Error", "Error" + ex.Message, "ok");
                //DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }
    }
}