public abstract class Material
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnioPublicacion { get; set; }

    public Material(string titulo, string autor, int anioPublicacion)
    {
        Titulo = titulo;
        Autor = autor;
        AnioPublicacion = anioPublicacion;
    }

    public abstract string ObtenerDescripcion();
}