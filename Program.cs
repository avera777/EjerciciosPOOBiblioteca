Biblioteca biblioteca = new Biblioteca();

Libro libro1 = new Libro("Cien años de soledad", "Gabriel García Márquez", 1967, 496);
Libro libro2 = new Libro("Don Quijote de la Mancha", "Miguel de Cervantes", 1605, 863);
Revista revista1 = new Revista("National Geographic", "Varios autores", 2024, 125);

biblioteca.AgregarMaterial(libro1);
biblioteca.AgregarMaterial(libro2);
biblioteca.AgregarMaterial(revista1);

biblioteca.MostrarDisponibles();

Console.WriteLine("\n=== Préstamo de un libro ===");
biblioteca.PrestarMaterial("Cien años de soledad", "Alejo");

Console.WriteLine("\n=== Intento de prestar el mismo libro otra vez ===");
try
{
    biblioteca.PrestarMaterial("Cien años de soledad", "María");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error controlado: {ex.Message}");
}

Console.WriteLine("\n=== Devolución del libro ===");
biblioteca.DevolverMaterial("Cien años de soledad");

biblioteca.MostrarDisponibles();