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
    public partial class MenuCabeceraPaciente : MasterDetailPage
    {
        public MenuCabeceraPaciente(string rol, string paciente, int pagina)
        {
            InitializeComponent();
            
            this.Master = new MenuPacienteMaster(rol, paciente);
            // vista inicial
            if (pagina == 0)
            {
                this.Detail = new NavigationPage(new MenuInicialPaciente());
            }
            // Redirecciona a vista de clínica
            if (pagina == 1)
            {
                this.Detail = new NavigationPage(new VistaClinica(rol, paciente));
            }
            //redireccion a la vista de area
            if (pagina == 2)
            {
                this.Detail = new NavigationPage(new VistaArea(rol, paciente));
            }
            //redireccion a la vista de usuario
            if (pagina == 3)
            {
                this.Detail = new NavigationPage(new VistaUsuario(rol, paciente));
            }
            //redireccion a la vista de doctor
            if (pagina == 4)
            {
                this.Detail = new NavigationPage(new VistaDoctor(rol, paciente));
            }
            //redireccion a la vista de citas usuario
            if (pagina == 6)
            {
                this.Detail = new NavigationPage(new VistaCitasUsuario(rol, paciente));
            }

            App.MasterDet = this;
        }
    }
}