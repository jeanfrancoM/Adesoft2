using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class TCAlmacenesExternosCE
    {
        public int idAlmacen { get; set; }
        public string almacen { get; set; }
        public string conexionAlmacen { get; set; }
        public string conexionAPI { get; set; }
        public string estado { get; set; }
        public Deudas deudas { get; set; }

        public int CodEmpresa { get; set; }
    }
