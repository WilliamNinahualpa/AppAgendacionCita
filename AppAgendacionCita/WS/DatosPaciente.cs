using System;
using System.Collections.Generic;
using System.Text;

namespace AppAgendacionCita.WS
{
    class DatosPaciente
    {
        public string pac_id { get; set; }
        public int usu_id { get; set; }
        public string pac_primer_nombre { get; set; }
        public string pac_segundo_nombre { get; set; }
        public string pac_primer_apellido { get; set; }
        public string pac_segundo_apellido { get; set; }
        public string pac_cedula { get; set; }
        public string pac_correo { get; set; }
        public string pac_telefono { get; set; }
        public string pac_estado { get; set; }

    }
}
