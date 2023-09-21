using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public partial class Deudas
    {
        public string sede { get; set; }
        public string nroRuc { get; set; }
        public List<Documento> documentos { get; set; }
        public decimal totalDeudaSoles { get; set; }
        public decimal totalDeudaDolares { get; set; }
        public string mensaje { get; set; }
    }

    public partial class Documento
    {
        public string vendedor { get; set; }
        public string nroDocumento { get; set; }
        public string nroRuc { get; set; }
        public string razonSocial { get; set; }
        public string emision { get; set; }
        public string vencimiento { get; set; }
        public int retraso { get; set; }
        public decimal total { get; set; }
        public string moneda { get; set; }
        public decimal montoDeudaSoles { get; set; }
        public decimal montoDeudaDolares { get; set; }
    }
