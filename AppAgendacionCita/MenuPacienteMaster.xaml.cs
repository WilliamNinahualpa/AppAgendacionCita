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
            if (rol.Equals("DOCTOR"))
            {
                btnPaciente.IsVisible = false;
                btnCita.IsVisible = false;
                btnDoctor.IsVisible = true;
            }
            if (rol.Equals("PACIENTE"))
            {
                btnCita.IsVisible = true;
                btnPaciente.IsVisible = true;
                btnDoctor.IsVisible = false;
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

        private void btnDoctor_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnVistaClinica_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new VistaClinica());
        }

        private async void btnVistaArea_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new VistaArea());
        }

        private async void btnVistaUsuario_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new VistaUsuario());
        }

        private async void btnVistaDoctor_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new VistaDoctor());
        }
    }
}