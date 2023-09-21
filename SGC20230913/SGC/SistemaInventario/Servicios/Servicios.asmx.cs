using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using CapaEntidad;
using CapaNegocios;
using System.Data;

namespace SistemaInventario.App_Code
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]

    public class Servicios : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public UsuarioCE KeepActiveSession()
        {
            bool SesionActiva = true;
            if (HttpContext.Current.Session["datos"] == null | Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]) == 0)
                SesionActiva = false;

            UsuarioCE Usuario = new UsuarioCE();

            if (Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]) > 0)
            {
                Usuario = (new UsuarioCN()).F_Usuario_Obtener(Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]));

                HttpContext.Current.Session["Usuario"] = Usuario.NombreUsuario;
                HttpContext.Current.Session["Apellidos"] = Usuario.Apellidos;
                HttpContext.Current.Session["Nombre"] = Usuario.Nombre;
                HttpContext.Current.Session["Perfil"] = Usuario.Perfil;
                HttpContext.Current.Session["CodCajaFisica"] = Usuario.CodCajaFisica.ToString();

                DataTable dtEmpresa = (new TCAlmacenCN()).F_TCAlmacen_ObtenerDatos(Convert.ToInt32(HttpContext.Current.Session["CodSede"]));

                HttpContext.Current.Session["CodEmpresa"] = Convert.ToInt32(dtEmpresa.Rows[0]["CodEmpresa"]);
                Usuario.CodEmpresa = Convert.ToInt32(dtEmpresa.Rows[0]["CodEmpresa"]);

                HttpContext.Current.Session["Empresa"] = dtEmpresa.Rows[0]["RazonSocial"];
                Usuario.Empresa = dtEmpresa.Rows[0]["RazonSocial"].ToString();

                HttpContext.Current.Session["Almacen"] = dtEmpresa.Rows[0]["DscAlmacen"];
                Usuario.Almacen = dtEmpresa.Rows[0]["DscAlmacen"].ToString();

                if (Usuario.IdImagen > 0)
                {
                    Session["ImagenUsuario"] = Usuario.ImagenUsuario;
                    Utilitarios.Menu.ImagenUsuario = (byte[])Usuario.ImagenUsuario;
                    Utilitarios.Menu.ImagenUsuarioNombre = Usuario.NombreUsuario + ".jpg";
                    Usuario.ImagenNombre = Usuario.NombreUsuario + ".jpg";
                    Utilitarios.Menu.F_ImagenUsuario();
                }
                else
                {
                    Utilitarios.Menu.ImagenUsuario = null;
                    Utilitarios.Menu.ImagenUsuarioNombre = "../Asset/images/mainuser.png";
                }
            }

            Usuario.ImagenUsuario = null; //debido a que el json no acepta una longitud de cadena demasiado grande
            Usuario.SesionActiva = SesionActiva;
            return Usuario;
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarClientes_AutoComplete(string NroRuc, string RazonSocial, int CodTipoCtaCte, int CodTipoCliente)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.NroRuc = NroRuc;
            objEntidad.RazonSocial = RazonSocial;
            if (CodTipoCtaCte > 0) objEntidad.CodTipoCtaCte = CodTipoCtaCte;
            objEntidad.CodTipoCliente = CodTipoCliente;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18}", dtTabla.Rows[i]["CodCtaCte"], dtTabla.Rows[i]["RazonSocial"], dtTabla.Rows[i]["Direccion"],
                        dtTabla.Rows[i]["DireccionEnvio"], dtTabla.Rows[i]["Distrito"], dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDistrito"],
                        dtTabla.Rows[i]["NroRuc"], dtTabla.Rows[i]["ApePaterno"], dtTabla.Rows[i]["ApeMaterno"], dtTabla.Rows[i]["Nombres"], dtTabla.Rows[i]["SaldoCreditoFavor"], dtTabla.Rows[i]["CodTipoCtaCte"],
                        dtTabla.Rows[i]["CodDireccion"], dtTabla.Rows[i]["CodVendedor"], dtTabla.Rows[i]["CodCategoria"], dtTabla.Rows[i]["NombreComercial"], dtTabla.Rows[i]["CodEmpresa"]));
                }
            }
            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarClientes_AutoComplete_Alvarado(string NroRuc, string RazonSocial, int CodTipoCtaCte, int CodTipoCliente)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.NroRuc = NroRuc;
            objEntidad.RazonSocial = RazonSocial;
            if (CodTipoCtaCte > 0) objEntidad.CodTipoCtaCte = CodTipoCtaCte;
            objEntidad.CodTipoCliente = CodTipoCliente;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22}", dtTabla.Rows[i]["CodCtaCte"], dtTabla.Rows[i]["RazonSocial"], dtTabla.Rows[i]["Direccion"],
                        dtTabla.Rows[i]["DireccionEnvio"], dtTabla.Rows[i]["Distrito"], dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDistrito"],
                        dtTabla.Rows[i]["NroRuc"], dtTabla.Rows[i]["ApePaterno"], dtTabla.Rows[i]["ApeMaterno"], dtTabla.Rows[i]["Nombres"], dtTabla.Rows[i]["SaldoCreditoFavor"], dtTabla.Rows[i]["CodTipoCtaCte"],
                        dtTabla.Rows[i]["CodDireccion"], dtTabla.Rows[i]["CodVendedor"], dtTabla.Rows[i]["CodCategoria"], dtTabla.Rows[i]["NombreComercial"], dtTabla.Rows[i]["CodEmpresa"], dtTabla.Rows[i]["D1"], dtTabla.Rows[i]["D2"]
                        , dtTabla.Rows[i]["D3"], dtTabla.Rows[i]["CATEGORIA"]));
                }
            }
            return Lista.ToArray();

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarClientes_AutoComplete2(string NroRuc, string RazonSocial, int CodTipoCtaCte, int CodTipoCliente)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.NroRuc = NroRuc;
            objEntidad.RazonSocial = RazonSocial;
            if (CodTipoCtaCte > 0) objEntidad.CodTipoCtaCte = CodTipoCtaCte;
            objEntidad.CodTipoCliente = CodTipoCliente;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", dtTabla.Rows[i]["CodCtaCte"], dtTabla.Rows[i]["RazonSocial"], dtTabla.Rows[i]["Direccion"],
                        dtTabla.Rows[i]["DireccionEnvio"], dtTabla.Rows[i]["Distrito"], dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDistrito"],
                        dtTabla.Rows[i]["NroRuc"], dtTabla.Rows[i]["ApePaterno"], dtTabla.Rows[i]["ApeMaterno"], dtTabla.Rows[i]["Nombres"], dtTabla.Rows[i]["SaldoCreditoFavor"], dtTabla.Rows[i]["CodTipoCtaCte"],
                        dtTabla.Rows[i]["CodDireccion"]));
                }
            }
            return Lista.ToArray();

        }

        //nueva lista de clients para consumir en listas multiples
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TCCuentaCorrienteCE> F_ListarClientes_AutoComplete_toList(string NroRuc, string RazonSocial, int CodTipoCtaCte, int CodTipoCliente)
        {
            List<TCCuentaCorrienteCE> lClientes = new List<TCCuentaCorrienteCE>();
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.NroRuc = NroRuc;
            objEntidad.RazonSocial = RazonSocial;
            if (CodTipoCtaCte > 0) objEntidad.CodTipoCtaCte = CodTipoCtaCte;
            objEntidad.CodTipoCliente = CodTipoCliente;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            List<string> Lista = new List<string>();

            foreach (DataRow r in dtTabla.Rows)
            {
                TCCuentaCorrienteCE nCli = new TCCuentaCorrienteCE();
                nCli.CodCtaCte = Convert.ToInt32(r["CodCtaCte"].ToString());
                nCli.RazonSocial = r["RazonSocial"].ToString();
                nCli.Direccion = r["Direccion"].ToString();
                nCli.DireccionEnvio = r["DireccionEnvio"].ToString();
                nCli.Distrito = r["Distrito"].ToString();
                nCli.CodDepartamento = Convert.ToInt32(r["CodDepartamento"].ToString());
                nCli.CodProvincia = Convert.ToInt32(r["CodProvincia"].ToString());
                nCli.CodDistrito = Convert.ToInt32(r["CodDistrito"].ToString());
                nCli.NroRuc = r["NroRuc"].ToString();
                nCli.CodTipoCtaCte = Convert.ToInt32(r["CodTipoCtaCte"].ToString());
                nCli.CodDireccion = Convert.ToInt32(r["CodDireccion"]);
                lClientes.Add(nCli);
            }
            return lClientes;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarClientes_Ruc_AutoComplete(string NroRuc, string RazonSocial, int CodTipoCtaCte, int CodTipoCliente)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.NroRuc = NroRuc;
            objEntidad.RazonSocial = RazonSocial;
            if (CodTipoCtaCte > 0) objEntidad.CodTipoCtaCte = CodTipoCtaCte;
            objEntidad.CodTipoCliente = CodTipoCliente;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_TCCuentaCorriente_Ruc_ListarClientes(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", dtTabla.Rows[i]["CodCtaCte"], dtTabla.Rows[i]["RazonSocial"], dtTabla.Rows[i]["Direccion"],
                    dtTabla.Rows[i]["DireccionEnvio"], dtTabla.Rows[i]["Distrito"], dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDistrito"],
                    dtTabla.Rows[i]["NroRuc"], dtTabla.Rows[i]["ApePaterno"], dtTabla.Rows[i]["ApeMaterno"], dtTabla.Rows[i]["Nombres"], dtTabla.Rows[i]["SaldoCreditoFavor"]));
            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ValidacionCliente F_ValidarClienteCambioPrecio(string NroRuc)
        {
            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_ValidarClienteCambioPrecio(NroRuc);
            ValidacionCliente Val = new ValidacionCliente() { Resultado = Convert.ToInt32(dtTabla.Rows[0]["Valor"].ToString()) };

            return Val;
        }
        public class ValidacionCliente
        {
            public int Resultado { get; set; }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCCuentaCorriente_PadronSunat(string NroRuc, int CodTipoCtaCte)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = CodTipoCtaCte;
                      
            decimal SaldoCreditoFavor = 0;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
            {
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],R["NroRuc"], R["ApePaterno"],
                R["ApeMaterno"], R["Nombres"], SaldoCreditoFavor, R["CodTipoCtaCte"], R["CodDireccion"],R["CodCategoria"], R["NombreComercial"]));                
            }
            return Lista.ToArray();
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCCuentaCorriente_PadronSunat_Alvarado(string NroRuc, int CodTipoCtaCte)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = CodTipoCtaCte;

            decimal SaldoCreditoFavor = 0;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
            {
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"], R["NroRuc"], R["ApePaterno"],
                R["ApeMaterno"], R["Nombres"], SaldoCreditoFavor, R["CodTipoCtaCte"], R["CodDireccion"], R["CodCategoria"], R["NombreComercial"], R["D1"], R["D2"]
                        , R["D3"]));
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCCuentaCorriente_PadronSunat_VersionAntigua(string NroRuc, int CodTipoCtaCte)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = CodTipoCtaCte;

            //si es cliente busca saldo en azure
            TCCuentaCorrienteCE dtSaldosAzure = null;
            if (CodTipoCtaCte == 1)
            {
                //dtSaldosAzure = objOperacion.F_ClientesSaldos_AZURE(NroRuc);
                if (dtSaldosAzure != null)
                    if (dtSaldosAzure.Saldo == 0)
                        dtSaldosAzure = null;
            }

            decimal SaldoCreditoFavor = 0;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
            {
                if (dtSaldosAzure != null)
                    SaldoCreditoFavor = dtSaldosAzure.Saldo;
                else
                    SaldoCreditoFavor = Convert.ToDecimal(R["SaldoCreditoFavor"].ToString());

                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                R["NroRuc"], R["ApePaterno"], R["ApeMaterno"], R["Nombres"], SaldoCreditoFavor, R["CodTipoCtaCte"], R["CodDireccion"]));
            }


            //Si no encuentra nada en la tabla TCCuentaCorriente, prosigue a buscarlo en el padron sunat
            if (dtTabla.Rows.Count == 0)
            {
                dtTabla = objOperacion.F_TCCuentaCorriente_PadronSunat(objEntidad);

                foreach (DataRow R in dtTabla.Rows)
                {
                    if (dtSaldosAzure != null)
                        SaldoCreditoFavor = dtSaldosAzure.Saldo;
                    else
                        SaldoCreditoFavor = 0;

                    //Busca El CodDistrito que corresponde en la base de datos local por medio del UBIGEO
                    //Si no existe debe seguir con el mismo error
                    DataTable dtDistrito = objOperacion.F_TCDistritoBuscarXUbigeo(dtTabla.Rows[0]["CodigoUbigeo"].ToString());
                    string CodDepartamento = "0"; string CodProvincia = "0"; string CodDistrito = "0"; string Distrito = "";
                    if (dtDistrito.Rows.Count > 0)
                    {
                        CodDepartamento = dtDistrito.Rows[0]["CodDepartamento"].ToString();
                        CodProvincia = dtDistrito.Rows[0]["CodProvincia"].ToString();
                        CodDistrito = dtDistrito.Rows[0]["CodDistrito"].ToString();
                        Distrito = dtDistrito.Rows[0]["DscDistrito"].ToString();
                    }

                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", 0, R["RazonSocial"], R["Direccion"],
                        R["Direccion"], Distrito, CodDepartamento, CodProvincia, CodDistrito,
                        R["Ruc"], "", "", "", SaldoCreditoFavor, 0, 0));


                }
            }


            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCCuentaCorriente_PadronSunatSinSaldo(string NroRuc, int CodTipoCtaCte)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = CodTipoCtaCte;

            decimal SaldoCreditoFavor = 0;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_TCCuentaCorriente_ListarClientes(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
            {
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                R["NroRuc"], R["ApePaterno"], R["ApeMaterno"], R["Nombres"], SaldoCreditoFavor, R["CodTipoCtaCte"], R["CodDireccion"]));
            }


            //Si no encuentra nada en la tabla TCCuentaCorriente, prosigue a buscarlo en el padron sunat
            if (dtTabla.Rows.Count == 0)
            {
                dtTabla = objOperacion.F_TCCuentaCorriente_PadronSunat(objEntidad);

                foreach (DataRow R in dtTabla.Rows)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", 0, R["RazonSocial"], R["Direccion"],
                        R["Direccion"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                        R["Ruc"], "", "", "", SaldoCreditoFavor, 0, 0));
                }
            }


            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_BuscarDatosPorRucDni(string NroRuc)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_BuscarDatosPorRucDni(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                    R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                    R["NroRuc"], R["SaldoCreditoFavor"]));

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_BuscarClientesPorRucDni(string NroRuc)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = 1;

            //si es cliente busca saldo en azure
            TCCuentaCorrienteCE dtSaldosAzure = null;
            if (objEntidad.CodTipoCtaCte == 1)
            {
                //dtSaldosAzure = objOperacion.F_ClientesSaldos_AZURE(NroRuc);
                //if (dtSaldosAzure != null && dtSaldosAzure.Saldo == 0)
                dtSaldosAzure = null;
            }

            decimal SaldoCreditoFavor = 0;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_BuscarDatosPorRucDni(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
            {
                if (dtSaldosAzure != null)
                    SaldoCreditoFavor = dtSaldosAzure.Saldo;
                else
                    SaldoCreditoFavor = Convert.ToDecimal(R["SaldoCreditoFavor"].ToString());


                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                    R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                    R["NroRuc"], SaldoCreditoFavor, R["CodTipoCtaCte"], R["CodDireccion"], R["CodCategoria"], R["NombreComercial"]));

            }

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_BuscarClientesPorRucDniSinSaldo(string NroRuc)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = 1;

            decimal SaldoCreditoFavor = 0;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_BuscarDatosPorRucDni(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
            {
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                    R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                    R["NroRuc"], SaldoCreditoFavor, R["CodTipoCtaCte"], R["CodDireccion"]));
            }

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_BuscarProveedoresPorRucDni(string NroRuc)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            List<string> Lista = new List<string>();
            DataTable dtTabla = null;
            objEntidad.RazonSocial = NroRuc;
            objEntidad.NroRuc = NroRuc;
            objEntidad.CodTipoCtaCte = 2;

            //Primero hago una busqueda en el propio sistema, no vaya a ser que ya
            //los datos existan y se haga una consulta en balde
            dtTabla = objOperacion.F_BuscarDatosPorRucDni(objEntidad);
            foreach (DataRow R in dtTabla.Rows)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", R["CodCtaCte"], R["RazonSocial"], R["Direccion"],
                    R["DireccionEnvio"], R["Distrito"], R["CodDepartamento"], R["CodProvincia"], R["CodDistrito"],
                    R["NroRuc"], R["SaldoCreditoFavor"]));

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_LGProductos_Select(string Descripcion, int CodAlmacen)
        {
            LGProductosCE objEntidad = new LGProductosCE();

            objEntidad.DscProducto = Descripcion;
            objEntidad.CodAlmacen = CodAlmacen;

            DataTable dtTabla = null;
            LGProductosCN objOperacion = new LGProductosCN();
            dtTabla = objOperacion.F_LGProductos_Select(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6}", dtTabla.Rows[i]["CodAlterno"], dtTabla.Rows[i]["DscProducto"], dtTabla.Rows[i]["StockActual"], dtTabla.Rows[i]["Costo"], dtTabla.Rows[i]["Moneda"], dtTabla.Rows[i]["CodProducto"], dtTabla.Rows[i]["NroSerie"]));

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarDepartamento_AutoComplete(string Descripcion)
        {
            TCDepartamentoCE objEntidad = new TCDepartamentoCE();

            objEntidad.DscDepartamento = Descripcion;

            DataTable dtTabla = null;
            TCDepartamentoCN objOperacion = new TCDepartamentoCN();
            dtTabla = objOperacion.F_Departamento_Autocomplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["Codigo"], dtTabla.Rows[i]["Descripcion"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarProvincia_AutoComplete(string Descripcion, int Codigo)
        {
            TCProvinciaCE objEntidad = new TCProvinciaCE();

            objEntidad.CodDepartamento = Codigo;
            objEntidad.DscProvincia = Descripcion;
            DataTable dtTabla = null;
            TCProvinciaCN objOperacion = new TCProvinciaCN();
            dtTabla = objOperacion.F_Provincia_Autocomplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["Codigo"], dtTabla.Rows[i]["Descripcion"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarDistrito_AutoComplete(string Descripcion, int Codigo)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.CodProvincia = Codigo;
            objEntidad.DscDistrito = Descripcion;
            DataTable dtTabla = null;
            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_Distrito_Autocomplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["Codigo"], dtTabla.Rows[i]["Descripcion"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCDistrito_Listar(string Descripcion)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.Descripcion = Descripcion;
            DataTable dtTabla = null;
            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDistrito_Listar(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3}", dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDistrito"], dtTabla.Rows[i]["DscDistrito"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCDistrito_ListarXCodDistrito(int CodDistrito)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.CodDistrito = CodDistrito;
            DataTable dtTabla = null;
            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDistrito_ListarXCodDistrito(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3}", dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDistrito"], dtTabla.Rows[i]["DscDistrito"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCDireccion_ListarXCodDistrito(string Descripcion)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.Descripcion = Descripcion;
            DataTable dtTabla = null;
            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCodDistrito(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0}", dtTabla.Rows[i]["Direccion"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //'Direccion':'','CodDepartamento':'','CodProvincia':'','CodDistrito':'','CodCtaCte':''}
        public string[] F_TCDireccion_ListarXCodDistrito_AutoComplete(string Direccion, int CodDepartamento, int CodProvincia, int CodDistrito, int CodCtaCte)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.CodDepartamento = CodDepartamento;
            objEntidad.CodProvincia = CodProvincia;
            objEntidad.CodDistrito = CodDistrito;
            objEntidad.CodCtaCte = CodCtaCte;
            objEntidad.Direccion = Direccion;
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCodDistrito_AutoComplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", dtTabla.Rows[i]["CodDireccion"], dtTabla.Rows[i]["Direccion"]
                                , dtTabla.Rows[i]["CodDistrito"], dtTabla.Rows[i]["CodProvincia"], dtTabla.Rows[i]["CodDepartamento"]
                                , dtTabla.Rows[i]["Email"], dtTabla.Rows[i]["Email2"], dtTabla.Rows[i]["Email3"]
                                , dtTabla.Rows[i]["Email4"], dtTabla.Rows[i]["Email5"], dtTabla.Rows[i]["Email6"]
                                ));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqProformasResult F_TCDireccion_ListarXCodDistritoCliente_AutoComplete(string Direccion, int CodDepartamento, int CodProvincia, int CodDistrito, int CodCtaCte)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();
            objEntidad.CodDepartamento = CodDepartamento;
            objEntidad.CodProvincia = CodProvincia;
            objEntidad.CodDistrito = CodDistrito;
            objEntidad.CodCtaCte = CodCtaCte;
            objEntidad.Direccion = Direccion;
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCodDistrito_AutoComplete(objEntidad);

            jqProformasResult data = new jqProformasResult();
            data.rows = new List<TCDireccionCE>();

            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {

                data.rows.Add(
                    new TCDireccionCE()
                    {
                        CodDireccion = int.Parse(dtTabla.Rows[i]["CodDireccion"].ToString()),
                        Direccion = dtTabla.Rows[i]["Direccion"].ToString(),
                        Email = dtTabla.Rows[i]["Email"].ToString()
                    }
                    );

            }

            return data;
        }
        public class jqProformasResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<TCDireccionCE> rows { get; set; }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqDireccionesClientesResult F_TCDireccion_ListarXCliente_AutoComplete(int CodCtaCte)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();
            objEntidad.CodCtaCte = CodCtaCte;
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCliente_AutoComplete(objEntidad);

            jqDireccionesClientesResult data = new jqDireccionesClientesResult();
            data.rows = new List<TCDireccionCE>();

            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {

                data.rows.Add(
                    new TCDireccionCE()
                    {
                        CodDireccion = int.Parse(dtTabla.Rows[i]["CodDireccion"].ToString()),
                        Direccion = dtTabla.Rows[i]["Direccion"].ToString(),
                        Email = dtTabla.Rows[i]["Email"].ToString()
                    }
                    );

            }

            return data;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqDireccionesClientesResult F_TCDireccion_ListarXCliente_AutoComplete_Conexion(int CodCtaCte)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();
            objEntidad.CodCtaCte = CodCtaCte;
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCliente_AutoComplete_Conexion(objEntidad);

            jqDireccionesClientesResult data = new jqDireccionesClientesResult();
            data.rows = new List<TCDireccionCE>();

            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {

                data.rows.Add(
                    new TCDireccionCE()
                    {
                        CodDireccionConexion = dtTabla.Rows[i]["CodDireccion"].ToString(),
                        Direccion = dtTabla.Rows[i]["Direccion"].ToString(),
                        Email = dtTabla.Rows[i]["Email"].ToString()
                    }
                    );

            }

            return data;
        }
        public class jqDireccionesClientesResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<TCDireccionCE> rows { get; set; }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCDireccion_ListarXCodTransportista_AutoComplete(string Direccion, int CodCtaCte)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.CodCtaCte = CodCtaCte;
            objEntidad.Direccion = Direccion;
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_TCDireccion_ListarXCodCtaCte_AutoComplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodDireccion"], dtTabla.Rows[i]["Direccion"].ToString().Trim()));

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_TCDireccion_ObtenerAlmacen(int CodAlmacen)
        {
            TCAlmacenCE objEntidad = new TCAlmacenCE();
            objEntidad.CodEmpresa = 3;
            objEntidad.CodAlmacen = CodAlmacen;
            DataTable dtTabla = null;

            TCAlmacenCN objOperacion = new TCAlmacenCN();
            dtTabla = objOperacion.F_TCAlmacen_Actual(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodAlmacen"], dtTabla.Rows[i]["Direccion"].ToString().Trim()));

            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_DocumentoVentaCab_Placas_AutoComplete(int CodCtaCte, string Placa)
        {
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            objEntidad.CodCliente = CodCtaCte;
            objEntidad.Placa = Placa;

            DataTable dtTabla = null;

            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            dtTabla = objOperacion.F_DocumentoVentaCab_Placas_Listar(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0}", dtTabla.Rows[i]["PLACA"]));

            return Lista.ToArray();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_Vehiculo_Placas_AutoComplete(string Placa)
        {
            VehiculoCE objEntidad = new VehiculoCE();
            objEntidad.Placa = Placa;

            DataTable dtTabla = null;

            VehiculoCN objOperacion = new VehiculoCN();

            dtTabla = objOperacion.F_Vehiculo_Placas_AutoComplete(objEntidad);
            List<string> Lista = new List<string>();


            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", dtTabla.Rows[i]["PLACA"], dtTabla.Rows[i]["CodVehiculo"], dtTabla.Rows[i]["Cliente"], dtTabla.Rows[i]["Anio"],
                        dtTabla.Rows[i]["Marca"], dtTabla.Rows[i]["Modelo"], dtTabla.Rows[i]["Color"], dtTabla.Rows[i]["CodTipoVehiculo"], dtTabla.Rows[i]["CodCliente"], dtTabla.Rows[i]["CodTipoCliente"], dtTabla.Rows[i]["Chasis"], dtTabla.Rows[i]["CodTipoPlan"]));
                }
            }
            return Lista.ToArray();

        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_LINEA_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_LINEA_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodLinea"], dtTabla.Rows[i]["Descripcion"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_MODELOVEHICULO_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_MODELOVEHICULO_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodModeloVehiculo"], dtTabla.Rows[i]["Modelo"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_MARCAPRODUCTO_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_MARCAPRODUCTO_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodMarcaProducto"], dtTabla.Rows[i]["Descripcion"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_Familia_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_Familia_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1},{2},{3}", dtTabla.Rows[i]["IDFamilia"], dtTabla.Rows[i]["DscFamilia"], dtTabla.Rows[i]["CodFamilia"], dtTabla.Rows[i]["Descripcion"]));
                }
            }
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_Procedencia_AUTOCOMPLETE(string Descripcion)
        {
            TCCuentaCorrienteCE objEntidad = new TCCuentaCorrienteCE();

            objEntidad.Descripcion = Descripcion;

            DataTable dtTabla = null;
            TCCuentaCorrienteCN objOperacion = new TCCuentaCorrienteCN();
            dtTabla = objOperacion.F_Procedencia_AUTOCOMPLETE(objEntidad);
            List<string> Lista = new List<string>();

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["CodProcedencia"], dtTabla.Rows[i]["Descripcion"]));
                }
            }
            return Lista.ToArray();
        }
                
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //'Direccion':'','CodDepartamento':'','CodProvincia':'','CodDistrito':'','CodCtaCte':''}
                   
            //Joel Buscar el distrito del Api
        public string[] F_Direccion_Buscar(string Ubigeo)
        {
            TCDistritoCE objEntidad = new TCDistritoCE();

            objEntidad.Ubigeo = Ubigeo;
            
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_Direccion_Buscar(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2}", dtTabla.Rows[i]["CodDepartamento"], dtTabla.Rows[i]["CodProvincia"]
                                , dtTabla.Rows[i]["CodDistrito"]
                                ));

            return Lista.ToArray();

        }
                
        //nueva lista de clients para consumir en listas multiples
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<LineaCreditoCE> F_TCCuentaCorriente_SaldosLineaCredito_Cliente(int CodCtaCte, int CodMoneda)
        {

            List<LineaCreditoCE> lParametros = new List<LineaCreditoCE>();
            TCCuentaCorrienteCE par = new TCCuentaCorrienteCE()
            {
                CodCtaCte = CodCtaCte,
                CodMonedaLineaCredito = CodMoneda
            };

            try
            {
                DataTable dtPermisos = (new TCCuentaCorrienteCN()).F_TCCuentaCorriente_SaldosLineaCredito_Cliente(par);

                foreach (DataRow r in dtPermisos.Rows)
                {
                    LineaCreditoCE p = new LineaCreditoCE();
                    p.Tipo = Convert.ToInt32(r["Tipo"].ToString());
                    p.Concepto = r["Concepto"].ToString();
                    p.Moneda = r["Moneda"].ToString();
                    p.Monto = Convert.ToDecimal(r["Monto"].ToString());
                    p.MontoStr = Convert.ToDecimal(r["Monto"].ToString()).ToString("##,####,##0.00");
                    p.CodMonedaLineaCredito = Convert.ToInt32(r["CodMonedaLineaCredito"].ToString());
                    lParametros.Add(p);
                }
            }
            catch (Exception)
            {
            }

            return lParametros;
        }
        
        //nueva lista de clients para consumir en listas multiples
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<ParametrosCE> F_ParametrosListar(string Parametro, int CodigoMenu, int CodigoInterno)
        {
            List<ParametrosCE> lParametros = new List<ParametrosCE>();
            DataTable dtPermisos = (new TCEmpresaCN()).F_ParametrosSistemas_Listar(Parametro, CodigoMenu, CodigoInterno);

            foreach (DataRow r in dtPermisos.Rows)
            {
                ParametrosCE p = new ParametrosCE();
                p.Parametro = r["Parametro"].ToString();
                p.Valor = r["Valor"].ToString();
                lParametros.Add(p);
            }
            return lParametros;
        }
        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<BancosCE> F_ListarBancos()
        {
            BancosCN objOperacionBancos = new BancosCN();
            DataTable dtTabla = null;
            dtTabla = objOperacionBancos.F_Listar_Bancos();
            List<BancosCE> bancos = new List<BancosCE>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {
                BancosCE banco = new BancosCE();
                banco.CodBanco = int.Parse(dtTabla.Rows[i]["CodBanco"].ToString());
                banco.DscBanco = dtTabla.Rows[i]["DscBanco"].ToString();
                bancos.Add(banco);
            }
            return bancos;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TCAlmacenCE> F_ListarAlmacenesExternos()
        {
            TCAlmacenCN objN = new TCAlmacenCN();
            DataTable dtTabla = objN.F_ListarAlmacenesExternos();
            List<TCAlmacenCE> almacenes = new List<TCAlmacenCE>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {
                TCAlmacenCE almacen = new TCAlmacenCE();
                almacen.CodAlmacen = int.Parse(dtTabla.Rows[i]["IdAlmacen"].ToString());
                almacen.DBDataBase = dtTabla.Rows[i]["DBDataBase"].ToString();
                almacenes.Add(almacen);
            }
            return almacenes;
        }
        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Planilla_CargoCE> F_Listar_Planilla_Cargo()
        {
            Planilla_CargoCN objOperacion = new Planilla_CargoCN();
            DataTable dtTabla = null;
            dtTabla = objOperacion.F_Listar_Planilla_Cargo();
            List<Planilla_CargoCE> cargos = new List<Planilla_CargoCE>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {
                Planilla_CargoCE cargo = new Planilla_CargoCE();
                cargo.CodCargo = int.Parse(dtTabla.Rows[i]["CodCargo"].ToString());
                cargo.DscCargo = dtTabla.Rows[i]["DscCargo"].ToString();
                cargos.Add(cargo);
            }
            return cargos;
        }
        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqTCAlmacenStockResult F_Consulta_Stock_Azure_NET(int CodProductoAzure, string CodigoInterno)
        {
            jqTCAlmacenStockResult data = new jqTCAlmacenStockResult();
            data.rows = new List<TCAlmacenCE>();
            TCAlmacenCE objEntidad = new TCAlmacenCE();
            TCAlmacenCN objOperacion = new TCAlmacenCN();

            //primero se buscan los datos de conexion faltantes
            try
            {
                TCAlmacenCE par = new TCAlmacenCE();
                DataTable dtAlmacenes = (new TCAlmacenCN()).F_TCAlmacenesExternos_Listar(0);
                DataTable dtStocksAzure = (new TCAlmacenCN()).F_Consulta_Stock_Azure(CodProductoAzure, CodigoInterno);
                foreach (DataRow i in dtAlmacenes.Rows)
                {
                    if (i["FlagAlmacenLocal"].ToString() == "0")
                    {
                        TCAlmacenCE newpr = new TCAlmacenCE();
                        newpr.Empresa = i["DscEmpresa"].ToString();
                        newpr.Almacen = i["DscAlmacen"].ToString();
                        newpr.Clave = newpr.Empresa.Replace(" ", "") + "_" + newpr.Almacen.Replace(" ", "");
                        newpr.ConsultadoSN = 0;
                        newpr.Stock = 0;
                        if (dtStocksAzure.Rows.Count > 0)
                        {
                            newpr.ConsultadoSN = 1;
                            newpr.Stock = decimal.Parse(dtStocksAzure.Rows[0][i["NombreClaveAzure"].ToString()].ToString());
                        }
                        data.rows.Add(newpr);
                    }
                }


            }
            catch (Exception ex)
            { }
            finally
            { objOperacion = null; }

            return data;
        }
        public class jqTCAlmacenStockResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<TCAlmacenCE> rows { get; set; }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqTCAlmacenStockResult F_Consulta_Stock_Azure_NET_Salcedo(int CodProductoAzure, string CodigoInterno)
        {
            jqTCAlmacenStockResult data = new jqTCAlmacenStockResult();
            data.rows = new List<TCAlmacenCE>();
            TCAlmacenCE objEntidad = new TCAlmacenCE();
            TCAlmacenCN objOperacion = new TCAlmacenCN();

            //primero se buscan los datos de conexion faltantes
            try
            {
                TCAlmacenCE par = new TCAlmacenCE();
                DataTable dtAlmacenes = (new TCAlmacenCN()).F_TCAlmacenesExternos_Listar(0);
                DataTable dtStocksAzure = (new TCAlmacenCN()).F_Consulta_Stock_Azure_Salcedo(CodProductoAzure, CodigoInterno);
                foreach (DataRow i in dtAlmacenes.Rows)
                {
                    if (i["FlagAlmacenLocal"].ToString() == "0")
                    {
                        TCAlmacenCE newpr = new TCAlmacenCE();
                        newpr.Empresa = i["DscEmpresa"].ToString();
                        newpr.Almacen = i["DscAlmacen"].ToString();
                        newpr.Clave = newpr.Empresa.Replace(" ", "") + "_" + newpr.Almacen.Replace(" ", "");
                        newpr.ConsultadoSN = 0;
                        newpr.Stock = 0;
                        if (dtStocksAzure.Rows.Count > 0)
                        {
                            newpr.ConsultadoSN = 1;
                            newpr.Stock = decimal.Parse(dtStocksAzure.Rows[0][i["NombreClaveAzure"].ToString()].ToString());
                        }
                        data.rows.Add(newpr);
                    }
                }


            }
            catch (Exception ex)
            { }
            finally
            { objOperacion = null; }

            return data;
        }

       
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool F_SUNAT_MarcaDocumento(int CodMovimiento, int CodRespuesta)
        {
            bool hecho = false;

            NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();
            objEntidad.CodMovimiento = CodMovimiento;
            objEntidad.CodEstadoSunat = CodRespuesta;

            hecho = (new NotaIngresoSalidaCabCN()).F_SUNAT_MarcaDocumento(objEntidad);

            return hecho;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public OrdenPedidoCabCE F_Aprobar_OrdenPedido(int CodOrdenPedido, string Observacion)
        {
            var CodUsuario = Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]);
            return (new OrdenPedidoCabCN()).F_OrdenPedido_Aprobacion(CodOrdenPedido, Observacion, CodUsuario);
                        
        }



        //nueva lista de clients para consumir en listas multiples
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<FormatoImpresionCE> F_FormatoImpresion_Listar(int CodTipoDoc, string SerieDoc)
        {
            List<FormatoImpresionCE> lParametros = new List<FormatoImpresionCE>();
            FormatoImpresionCE entidadFormatoImpresion = new FormatoImpresionCE();
            entidadFormatoImpresion.CodTipoDoc = CodTipoDoc;
            entidadFormatoImpresion.SerieDoc = SerieDoc;
            DataTable datos = (new FormatoImpresionCN()).F_FormatoImpresion_Listar_X_CodTipoDoc(entidadFormatoImpresion);

            foreach (DataRow r in datos.Rows)
            {
                FormatoImpresionCE p = new FormatoImpresionCE();
                p.Formato = r["Formato"].ToString();
                p.CodFormatoImpresion = Convert.ToInt32(r["CodFormatoImpresion"].ToString());
                p.CodTipoFormato = Convert.ToInt32(r["CodTipoFormato"].ToString());
                p.CodTipoDoc = Convert.ToInt32(r["CodTipoDoc"].ToString());
                p.SerieDoc = r["SerieDoc"].ToString();
                p.NombreArchivo = r["NombreArchivo"].ToString();
                p.Impresora = r["Impresora"].ToString();
                p.DataTable = r["DataTable"].ToString();
                p.NroCopias = Convert.ToInt32(r["NroCopias"].ToString());
                p.FlagDefecto = Convert.ToInt32(r["FlagDefecto"].ToString());
                lParametros.Add(p);
            }
            return lParametros;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<FormatoImpresionCE> F_FormatoImpresion_Listar_NotaIngreso(int CodTipoDoc)
        {
            List<FormatoImpresionCE> lParametros = new List<FormatoImpresionCE>();
            FormatoImpresionCE entidadFormatoImpresion = new FormatoImpresionCE();
            entidadFormatoImpresion.CodTipoDoc = CodTipoDoc;
            DataTable datos = (new FormatoImpresionCN()).F_FormatoImpresion_Listar_X_CodTipoDoc(entidadFormatoImpresion);

            foreach (DataRow r in datos.Rows)
            {
                FormatoImpresionCE p = new FormatoImpresionCE();
                p.Formato = r["Formato"].ToString();
                p.CodFormatoImpresion = Convert.ToInt32(r["CodFormatoImpresion"].ToString());
                p.CodTipoFormato = Convert.ToInt32(r["CodTipoFormato"].ToString());
                p.CodTipoDoc = Convert.ToInt32(r["CodTipoDoc"].ToString());
                p.SerieDoc = r["SerieDoc"].ToString();
                p.NombreArchivo = r["NombreArchivo"].ToString();
                p.Impresora = r["Impresora"].ToString();
                p.DataTable = r["DataTable"].ToString();
                p.NroCopias = Convert.ToInt32(r["NroCopias"].ToString());
                p.FlagDefecto = Convert.ToInt32(r["FlagDefecto"].ToString());
                lParametros.Add(p);
            }
            return lParametros;
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarFamilias_AutoComplete(string DscFamilia)
        {
            LGFamiliasCE objEntidad = new LGFamiliasCE();

            objEntidad.DscFamilia = DscFamilia;


            DataTable dtTabla = null;
            LGFamiliasCN objOperacion = new LGFamiliasCN();
            dtTabla = objOperacion.F_ListarFamilias_AutoComplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3},{4},{5}",
                    dtTabla.Rows[i]["IDFamilia"], dtTabla.Rows[i]["CodFamilia"], dtTabla.Rows[i]["DscFamilia"],
                    dtTabla.Rows[i]["CodEmpresa"], dtTabla.Rows[i]["CodEstado"], dtTabla.Rows[i]["CodUsuario"]));
            return Lista.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_ListarMarca_AutoComplete(string DescripcionMarcaProducto)
        {
            LGProductosCE objEntidad = new LGProductosCE();

            objEntidad.DescripcionMarcaProducto = DescripcionMarcaProducto;


            DataTable dtTabla = null;
            LGProductosCN objOperacion = new LGProductosCN();
            dtTabla = objOperacion.F_ListarMarca_AutoComplete(objEntidad);
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1},{2},{3}",
                    dtTabla.Rows[i]["CodMarcaProducto"], dtTabla.Rows[i]["CodigoMarcaProducto"], dtTabla.Rows[i]["Descripcion"],
                    dtTabla.Rows[i]["CodEstado"]));
            return Lista.ToArray();
        }


        //Joel Buscar el url y el token
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] F_API_RUC_Buscar()
        {
            TCDistritoCE objEntidad = new TCDistritoCE();
            DataTable dtTabla = null;

            TCDistritoCN objOperacion = new TCDistritoCN();
            dtTabla = objOperacion.F_API_RUC_Buscar(Convert.ToInt32(HttpContext.Current.Session["CodEmpresa"]));
            List<string> Lista = new List<string>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
                Lista.Add(string.Format("{0},{1}", dtTabla.Rows[i]["urlapisunat"], dtTabla.Rows[i]["tokenapisunat"]
                                ));

            return Lista.ToArray();
        }    
    }
}
