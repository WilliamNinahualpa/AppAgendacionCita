using System;
using System.Collections.Generic;
using System.Text;

namespace AppAgendacionCita.WS
{
    public class DatosUsuario
    {
        public int usu_id { get; set; }
        public string usu_usuario { get; set; }
        public string usu_clave { get; set; }
        public string usu_rol { get; set; }
        public string usu_estado { get; set; }
    }
}
