// ColorService.cs
using System;
using System.IO;
using System.Threading.Tasks;
using Colorinweb.Models;
using Newtonsoft.Json;

namespace Colorinweb.Servicio
{
    public class ColorService
    {
        private readonly string folderPath = "datax";

        public async Task<DatosColores> CargarDatosAsync(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var datosJson = await File.ReadAllTextAsync(filePath);
                    return JsonConvert.DeserializeObject<DatosColores>(datosJson) ?? new DatosColores();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar datos: {ex.Message}");
            }

            return new DatosColores();
        }

        public void GuardarDatos(DatosColores datos, string filePath)
        {
            try
            {
                var datosJson = JsonConvert.SerializeObject(datos);
                File.WriteAllText(filePath, datosJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar datos: {ex.Message}");
            }
        }

        public DatosColores CargarDatos(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var datosJson = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<DatosColores>(datosJson) ?? new DatosColores();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar datos: {ex.Message}");
            }

            return new DatosColores();
        }
    }
}
