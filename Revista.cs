public class Revista : Material, IPrestable
{
    public int NumeroEdicion { get; set; }

    public bool EstaDisponible { get; private set; } = true;
    public string? UsuarioPrestamo { get; private set; }

    public Revista(string titulo, string autor, int anioPublicacion, int numeroEdicion)
        : base(titulo, autor, anioPublicacion)
    {
        NumeroEdicion = numeroEdicion;
    }

    public override string ObtenerDescripcion()
    {
        return $"Revista: {Titulo} - {Autor} ({AnioPublicacion}) - Edición #{NumeroEdicion}";
    }

    public void Prestar(string usuario)
    {
        if (!EstaDisponible)
        {
            throw new InvalidOperationException($"La revista '{Titulo}' ya está prestada a {UsuarioPrestamo}.");
        }

        EstaDisponible = false;
        UsuarioPrestamo = usuario;
    }

    public void Devolver()
    {
        if (EstaDisponible)
        {
            throw new InvalidOperationException($"La revista '{Titulo}' no está prestada.");
        }

        EstaDisponible = true;
        UsuarioPrestamo = null;
    }
}