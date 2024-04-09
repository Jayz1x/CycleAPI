using System.Reflection.Metadata.Ecma335;

namespace CycleAPI.Utils
{

    //funcionalidad para convertir imagenes a formato base64
    public static class Base64Converter
    {
        public static string ConvertImageToBase64(string imagePath)
        {
            try
            {
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al convertir la imagen a base64: {ex.Message}");
                return null;
            }
        }
    }
}
