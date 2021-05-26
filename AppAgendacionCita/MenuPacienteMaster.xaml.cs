using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAgendacionCita
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPacienteMaster : ContentPage
    {
        public MenuPacienteMaster(string rol, string usuario)
        {
            InitializeComponent();
            lblrol.Text = rol;
            lblusuario.Text = usuario;
            lblrol.IsVisible = false;
            lblusuario.IsVisible = false;
            if (rol.Equals("DOCTOR"))
            {
                btnPaciente.IsVisible = false;
                btnCita.IsVisible = false;
                btnDoctor.IsVisible = true;
                btnVistaClinica.IsVisible = false;
                btnVistaArea.IsVisible = false;
                btnVistaDoctor.IsVisible = false;
                btnVistaUsuario.IsVisible = false;
                btnVerCitaDoctor.IsVisible = true;
                btnVerCita.IsVisible = false;
            }
            if (rol.Equals("PACIENTE"))
            {
                btnCita.IsVisible = true;
                btnPaciente.IsVisible = true;
                btnDoctor.IsVisible = false;
                btnVistaClinica.IsVisible = false;
                btnVistaArea.IsVisible = false;
                btnVistaDoctor.IsVisible = false;
                btnVistaUsuario.IsVisible = false;
                btnVerCitaDoctor.IsVisible = false;
                btnVerCita.IsVisible = true;
            }
            if (rol.Equals("ADMINISTRADOR"))
            {
                btnCita.IsVisible = false;
                btnPaciente.IsVisible = false;
                btnDoctor.IsVisible = false;
                btnVistaClinica.IsVisible = true;
                btnVistaArea.IsVisible = true;
                btnVistaDoctor.IsVisible = true;
                btnVistaUsuario.IsVisible = true;
                btnVerCitaDoctor.IsVisible = false;
                btnVerCita.IsVisible = false;
            }
        }

        private async void btnPaciente_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new Paciente(lblrol.Text, lblusuario.Text));
        }

        private async void btnCita_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new RegistrarCita(lblrol.Text, lblusuario.Text));
        }

        private async void btnDoctor_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new RegistrarDoctor(lblrol.Text, lblusuario.Text));
        }

        private async void btnVistaClinica_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new VistaClinica(lblrol.Text, lblusuario.Text));
        }

        private async void btnVistaArea_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new VistaArea(lblrol.Text, lblusuario.Text));
        }

        private async void btnVistaUsuario_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new VistaUsuario(lblrol.Text, lblusuario.Text));
        }

        private async void btnVistaDoctor_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new VistaDoctor(lblrol.Text, lblusuario.Text));
        }

        private async void btnCerrar_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await Navigation.PushAsync(new MainPage());
        }

        private async void btnVerCita_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new VistaCitasUsuario(lblrol.Text, lblusuario.Text));
        }

        private async void btnVerCitaDoctor_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new VistaCitasDoctor(lblrol.Text, lblusuario.Text));
        }
    }
}