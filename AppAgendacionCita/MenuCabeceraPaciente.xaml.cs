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
        public MenuCabeceraPaciente(string rol, string paciente)
        {
            InitializeComponent();
            this.Master = new MenuPacienteMaster(rol, paciente);
            this.Detail = new NavigationPage(new MenuInicialPaciente());
            App.MasterDet = this;
        }
    }
}