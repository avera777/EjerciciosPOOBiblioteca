public interface IPrestable
{
    bool EstaDisponible { get; }
    void Prestar(string usuario);
    void Devolver();
}