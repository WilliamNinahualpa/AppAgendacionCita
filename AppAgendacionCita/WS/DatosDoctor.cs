using System;
using System.Collections.Generic;
using System.Text;

namespace AppAgendacionCita.WS
{
    class DatosDoctor
    {
        public string doc_id { get; set; }
        public string cli_id { get; set; }
        public string are_id { get; set; }
        public string usu_id { get; set; }
        public string doc_primer_nombre { get; set; }
        public string doc_segundo_nombre { get; set; }
        public string doc_primer_apellido { get; set; }
        public string doc_segundo_apellido { get; set; }
        public string doc_cedula { get; set; }
        public string doc_correo { get; set; }
        public string doc_telefono { get; set; }
    }
}
