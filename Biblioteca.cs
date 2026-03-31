using System;
using System.Collections.Generic;
using System.Linq;

public class Biblioteca
{
    private List<Material> materiales = new List<Material>();

    public void AgregarMaterial(Material material)
    {
        materiales.Add(material);
    }

    public void MostrarDisponibles()
    {
        Console.WriteLine("\n=== Materiales disponibles ===");

        var disponibles = materiales
            .Where(m => m is IPrestable prestable && prestable.EstaDisponible)
            .ToList();

        if (disponibles.Count == 0)
        {
            Console.WriteLine("No hay materiales disponibles.");
            return;
        }

        foreach (var material in disponibles)
        {
            Console.WriteLine(material.ObtenerDescripcion());
        }
    }

    public void PrestarMaterial(string titulo, string usuario)
    {
        var material = materiales.FirstOrDefault(m =>
            m.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (material == null)
        {
            throw new InvalidOperationException($"No se encontró el material con título '{titulo}'.");
        }

        if (material is not IPrestable prestable)
        {
            throw new InvalidOperationException($"El material '{titulo}' no se puede prestar.");
        }

        prestable.Prestar(usuario);
        Console.WriteLine($"Se prestó '{titulo}' a {usuario}.");
    }

    public void DevolverMaterial(string titulo)
    {
        var material = materiales.FirstOrDefault(m =>
            m.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (material == null)
        {
            throw new InvalidOperationException($"No se encontró el material con título '{titulo}'.");
        }

        if (material is not IPrestable prestable)
        {
            throw new InvalidOperationException($"El material '{titulo}' no admite devolución.");
        }

        prestable.Devolver();
        Console.WriteLine($"Se devolvió '{titulo}' correctamente.");
    }
}