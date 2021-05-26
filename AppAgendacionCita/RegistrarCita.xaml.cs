using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAgendacionCita
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarCita : ContentPage
    {
        private HttpClient client = new HttpClient();
        List<AppAgendacionCita.WS.ListarHora> hora;
        List<AppAgendacionCita.WS.DatosDoctor> doctors;
        List<AppAgendacionCita.WS.DatosClinica> clinicas;
        List<AppAgendacionCita.WS.DatosArea> area;
        public RegistrarCita(string rol, string usuario)
        {
            InitializeComponent();
            lblRol.Text = rol;
            lblUsuario.Text = usuario;
            txtIdDoctor.IsVisible = false;
            txtCodigo.IsVisible = false;
            getPaciente();
            clinica();
            txtNombre1.IsVisible = false;
            txtLatitud.IsVisible = false;
            txtLongitud.IsVisible = false;
            lblUsuario.IsVisible = false;
            lblRol.IsVisible = false;
          
        }



        private async void getPaciente()
        {
            try
            {
                var content = await client.GetStringAsync("http://192.168.100.66/moviles/RestPaciente.php?usuario=" + lblUsuario.Text + "&rol=" + lblRol.Text + "");
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
                        txtCodigo.Text = rol1.pac_id;
                        txtNombre.Text = rol1.pac_primer_nombre +" "+ rol1.pac_segundo_nombre + " " + rol1.pac_primer_apellido + " " + rol1.pac_segundo_apellido;
                    }
                }
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


     



        private async void btnHorario_Clicked(object sender, EventArgs e)
        {
            var hora = pickerHora.SelectedItem;
            var fecha = dpDia.Date.ToString("yyyy-MM-dd");
            var paciente = txtCodigo.Text;
            var doctor = pickerDoctor.SelectedItem.ToString();
            //txtIdDoctor.Text = doctor;

            var content = await client.GetStringAsync("http://192.168.100.66/moviles/RestDoctor.php?nombre=" + doctor + "");
            doctors = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosDoctor>>(content);
            foreach (var doctor1 in doctors)
            {
                txtIdDoctor.Text = doctor1.doc_id;
            }
            

            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();

            parametros.Add("idclinica", "1");
            parametros.Add("idarea", "1");
            parametros.Add("idpaciente", txtCodigo.Text);
            parametros.Add("iddoctor", txtIdDoctor.Text);
            parametros.Add("fecha", fecha);
            parametros.Add("hora", hora.ToString());

            cliente.UploadValues("http://192.168.100.66/moviles/RestCita.php", "POST", parametros);

            Vibration.Vibrate(TimeSpan.FromMilliseconds(300));


            var mensaje = "Cita generada correctamente";
            DependencyService.Get<Mensaje>().LongAlert(mensaje);

            await Navigation.PushAsync(new VistaCitasUsuario(lblRol.Text, lblUsuario.Text));
            
        }

        public void pickerDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private async void pickerClinica_SelectedIndexChanged(object sender, EventArgs e)
        {
            pickerArea.Items.Clear();
            int position = pickerClinica.SelectedIndex;
            if (position > -1)
            {
                var d = clinicas[position].cli_nombre;
                try
                {
                    var content = await client.GetStringAsync("http://192.168.100.66/moviles/RestClinicaArea.php?clinica=" + d.ToString() + "");
                    if (content.Equals("false"))
                    {
                        var mensaje = "Datos incorrectos";
                        DependencyService.Get<Mensaje>().LongAlert(mensaje);
                    }
                    else
                    {
                        area = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosArea>>(content);
                        foreach (var area1 in area)
                        {
                            pickerArea.Items.Add(area1.are_nombre);

                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
                }
            }
           
        }

        private async void pickerArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            pickerDoctor.Items.Clear();
            int position = pickerArea.SelectedIndex;
            if (position > -1)
            {
                var d = area[position].are_nombre;
                try
                {
                    var content = await client.GetStringAsync("http://192.168.100.66/moviles/RestAreaDoctor.php?doctor=" + d.ToString() + "");
                    if (content.Equals("false"))
                    {
                        var mensaje = "Datos incorrectos";
                        DependencyService.Get<Mensaje>().LongAlert(mensaje);
                    }
                    else
                    {
                        doctors = JsonConvert.DeserializeObject<List<AppAgendacionCita.WS.DatosDoctor>>(content);
                        foreach (var doctor1 in doctors)
                        {

                            pickerDoctor.Items.Add(doctor1.doc_primer_apellido);
                            //pickerDoctor.Items.IndexOf(doctor1.doc_id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    DependencyService.Get<Mensaje>().ShortAlert(ex.ToString());
                }
            }
        }



        private async void btnAbrir_Clicked(object sender, EventArgs e)
        {
            if (!double.TryParse(txtLatitud.Text, out double lat))
                return;
            if (!double.TryParse(txtLongitud.Text, out double lng))
                return;
            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                Name = txtNombre1.Text,
                NavigationMode = NavigationMode.None
            });
        }

        private void dpDia_DateSelected(object sender, DateChangedEventArgs e)
        {
            hora = new List<AppAgendacionCita.WS.ListarHora>();
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "9:00" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "9:30" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "10:00" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "10:30" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "11:00" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "11:30" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "12:00" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "12:30" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "13:00" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "13:30" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "14:00" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "14:30" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "15:00" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "15:30" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "16:00" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "16:30" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "17:00" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "17:30" });
            hora.Add(new AppAgendacionCita.WS.ListarHora { horainicio = "18:00" });
            foreach (var hora1 in hora)
            {
                pickerHora.Items.Add(hora1.horainicio);
            }
        }
    }
}