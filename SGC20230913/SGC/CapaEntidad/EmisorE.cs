using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class EmisorE
    {
        public int ID_Emisor { get; set; }
        public int ID_Area_Empresa { get; set; }
        public string T_Correo { get; set; }
        public string T_SmtpHost { get; set; }
        public int N_Puerto { get; set; }
        public string T_Clave { get; set; }
        public string T_Descripcion_Area { get; set; }
    }
}
