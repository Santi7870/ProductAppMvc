using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class ProductService
{
    private readonly string ApiUrl = "http://localhost:5248/api/product"; // Cambia esta URL

    // Método para enviar el producto a la API
    public async Task<bool> SendProductDataAsync(string productName, string description)
    {
        try
        {
            // Crear un objeto HttpClientHandler para deshabilitar la validación del certificado SSL
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            using (var client = new HttpClient(handler))
            {
                var jsonContent = new StringContent(
                    $"{{\"name\": \"{productName}\", \"description\": \"{description}\"}}",
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync(ApiUrl, jsonContent);

                return response.IsSuccessStatusCode;
            }
        }
        catch (HttpRequestException ex)
        {
            // Manejo de excepciones
            Console.WriteLine($"Error al enviar el producto: {ex.Message}");
            return false;
        }
    }
}

