using System.Security.Cryptography;
using System.Text;

namespace CentroEventos.Aplicacion.Servicios;

public static class ServicioHash
{
    public static string ConvertirASha256(string textoPlano)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(textoPlano);
        byte[] hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}