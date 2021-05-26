using System;
using System.Collections.Generic;
using System.Text;

namespace AppAgendacionCita.WS
{
    class DatosCita
    {
        public string cit_id { get; set; }
        public string idarea { get; set; }
        public string iddoctor { get; set; }
        public string cit_fecha { get; set; }
        public string cit_hora { get; set; }
        public string cli_nombre { get; set; }
        public string are_nombre{ get; set; }
        public string doc_primer_nombre { get; set; }
        public string doc_segundo_nombre { get; set; }
        public string doc_primer_apellido { get; set; }
        public string doc_segundo_apellido { get; set; }
        public string pac_primer_nombre { get; set; }
        public string pac_segundo_nombre { get; set; }
        public string pac_primer_apellido { get; set; }
        public string pac_segundo_apellido { get; set; }
    }
}
