public class Libro : Material, IPrestable
{
    public int NumeroPaginas { get; set; }

    public bool EstaDisponible { get; private set; } = true;
    public string? UsuarioPrestamo { get; private set; }

    public Libro(string titulo, string autor, int anioPublicacion, int numeroPaginas)
        : base(titulo, autor, anioPublicacion)
    {
        NumeroPaginas = numeroPaginas;
    }

    public override string ObtenerDescripcion()
    {
        return $"Libro: {Titulo} - {Autor} ({AnioPublicacion}) - {NumeroPaginas} páginas";
    }

    public void Prestar(string usuario)
    {
        if (!EstaDisponible)
        {
            throw new InvalidOperationException($"El libro '{Titulo}' ya está prestado a {UsuarioPrestamo}.");
        }

        EstaDisponible = false;
        UsuarioPrestamo = usuario;
    }

    public void Devolver()
    {
        if (EstaDisponible)
        {
            throw new InvalidOperationException($"El libro '{Titulo}' no está prestado.");
        }

        EstaDisponible = true;
        UsuarioPrestamo = null;
    }
}