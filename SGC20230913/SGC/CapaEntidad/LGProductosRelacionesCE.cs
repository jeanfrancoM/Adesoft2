using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

    public class LGProductosRelacionesCE
    {
        public int IdProductosRelaciones { get; set; }
	    public string CodAlternoPrincipal { get; set; }
	    public string CodAlternoRelacionado { get; set; }
        public int CodAlmacen { get; set; }
        public int CodUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string MsgError { get; set; }
    }
