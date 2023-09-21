using System.Collections.Generic;

public class UsuarioCE
{
	public int CodUsuario {get ;set ; }
    public string NombreUsuario { get; set; }
    public string Clave { get; set; }
    public string Apellidos { get; set; }
    public string Nombre { get; set; }
    public int CodAlmacen { get; set; }
    public int CodEstado { get; set; }
    public string Perfil { get; set; }
    public string Tipo { get; set; }
    public int CodCargo { get; set; }
    public string NroDni { get; set; }
    public int CodCajaFisica { get; set; }
    public string ClavePrecio { get; set; }

    public string UltSesion { get; set; }
    public string AccesoWeb { get; set; }
    public int CodCliente { get; set; }
    public string Pagina { get; set; }
    public string Mensaje { get; set; }
    public string MsgError { get; set; }
    public int CodUsuarioAuxiliar { get; set; }

    public string Almacen { get; set; }
    public string Empresa { get; set; }

    public byte Foto { get; set; }

    public bool SesionActiva { get; set; }

    public int CodEmpresa { get; set; }

    public int IdImagen { get; set; }
    public string ImagenNombre { get; set; }

    public string ClaveOperacionesEspeciales { get; set; }

    public byte[] ImagenUsuario { get; set; }

    public List<UsuariosPermisosCE> UsuariosPermisos { get; set; }


    public object CodUsuarioCopiar { get; set; }

    public object XmlAlmacen { get; set; }

    public string Descripcion { get; set; }
}
