using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CapaEntidad
{
    public class ContactosCE
    {
        public int CodContacto { get; set; }
        public int CodCtaCte { get; set; }
        public string DatosPersonales { get; set; }
        public string Telefono { get; set; }
        public string Area { get; set; }
        public string Correo1 { get; set; }
        public string Correo2 { get; set; }
        public string Correo3 { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Celular3 { get; set; }
        public int CodEstado { get; set; }
        public int CodUsuario { get; set; }
        public int Flag_MostrarEnReporte { get; set; }
        public string MsgError { get; set; }

        public decimal D1 { get; set; }

        public decimal D2 { get; set; }

        public decimal D3 { get; set; }
    }
}
