using System;
using System.IO;
using System.Threading.Tasks;

namespace MauiApp2.Repositories
{
    internal class FilesRepository
    {
        private string filePath = Path.Combine(FileSystem.AppDataDirectory, "Archivo1.txt");

        // Método para generar archivo
        public async Task<bool> GenerarArchivoAsync(string texto)
        {
            try
            {
                await File.WriteAllTextAsync(filePath, texto);
                return File.Exists(filePath);  // Verifica si el archivo existe
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar el error o loguearlo si es necesario
                Console.WriteLine($"Error al generar el archivo: {ex.Message}");
                return false;
            }
        }

        // Método para devolver el contenido del archivo
        public async Task<string> DevuelveInformacionArchivoAsync()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string texto = await File.ReadAllTextAsync(filePath);
                    return texto;
                }
                return "No existe el archivo";  // Mensaje de error mejorado
            }
            catch (Exception ex)
            {
                // Manejo de error
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                throw;  // Vuelve a lanzar la excepción, o podrías devolver un valor de error si prefieres
            }
        }
    }
}
