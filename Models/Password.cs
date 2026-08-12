namespace GestorContraseñas.Models;

public class Password
{
    public int Id { get; set; }

    public string Nombre { get; set; } = "";

    public string Usuario { get; set; } = "";

    public string Clave { get; set; } = "";

    public string Sitio { get; set; } = "";
}
