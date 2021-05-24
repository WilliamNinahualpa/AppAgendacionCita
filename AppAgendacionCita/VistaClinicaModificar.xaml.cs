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
    public partial class VistaClinicaModificar : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppAgendacionCita.WS.DatosClinica> _post;
        public VistaClinicaModificar(int id)
        {
            InitializeComponent();
            getClinica(id);
           
        }

        private async void getClinica(int id)
        {
            try
            {
                String Url = "http://192.168.100.66/moviles/RestClinica.php?codigo=" + id;
                var content = await client.GetStringAsync(Url);
                if (content.Equals("false"))
                {
                    await DisplayAlert("Alerta", "Datos incorrectos", "ok");
                }
                else
                {
                    List<AppAgendacionCita.WS.DatosClinica> posts = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosClinica>>("[" + content + "]");                    
                    foreach (var clinica1 in posts)
                    {
                        txtCodigo.Text = clinica1.cli_id;
                        txtNombre.Text = clinica1.cli_nombre;
                        txtDireccion.Text = clinica1.cli_direccion;
                        txtCorreo.Text = clinica1.cli_correo;
                        txtTelefono.Text = clinica1.cli_correo;
                        txtPagina.Text = clinica1.cli_pagina_web;
                        txtRepresentante.Text = clinica1.cli_representante_legal;
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Error" + ex.Message, "ok");
                //DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
            }
        }

       

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametro = new System.Collections.Specialized.NameValueCollection();
                parametro.Add("codigo", "0");


                cliente.UploadValues("http://192.168.100.66/moviles/RestClinica.php?cli_id=" + txtCodigo.Text + "", "DELETE", parametro);


                await DisplayAlert("Alerta", "Ingreso Exitoso", "Ok");
                //var mensaje = "Registro eliminado exitosamnte";
                //DependencyService.Get<Mensaje>().LongAlert(mensaje);

                await Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                //DependencyService.Get<Mensaje>().ShortAlert(ex.Message);
            }
        }

        private async void btnModificar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametro = new System.Collections.Specialized.NameValueCollection();
                parametro.Add("codigo", txtCodigo.Text);
               


                cliente.UploadValues("http://192.168.100.66/moviles/RestClinica.php?cli_id=" + txtCodigo.Text + "&cli_nombre=" + txtNombre.Text + "&cli_direccion=" + txtDireccion.Text + "&cli_correo=" + txtCorreo.Text + "&cli_telefono=" + txtTelefono.Text + "&cli_pagina_web=" + txtPagina.Text + "&cli_representante_legal=" + txtRepresentante.Text, "PUT", parametro);


                await DisplayAlert("Alerta", "Ingreso Exitoso", "Ok");
                //var mensaje = "Registro modificado exitosamnte";
                //DependencyService.Get<Mensaje>().LongAlert(mensaje);

                await Navigation.PushAsync(new MainPage());


            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Error" );
                //DependencyService.Get<Mensaje>().ShortAlert(ex.Message);
            }

        }
    }
}