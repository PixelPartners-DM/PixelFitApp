// Giver adgang til at sende og modtage JSON via HttpClient
using System.Net.Http.Json;

namespace PixelFit.Service
{
    // Service der står for kommunikationen mellem MAUI-appen
    // og API'et i forbindelse med brugerhåndtering
    public class AuthService
    {
        // HttpClient bruges til at sende HTTP requests til API'et
        private readonly HttpClient _httpClient;

        // Constructoren modtager HttpClient gennem Dependency Injection
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Sender email og adgangskode til API'et
        // for at oprette en ny bruger
        public async Task<bool> RegisterAsync(
            string email,
            string password)
        {
            // Opretter det objekt som skal sendes til API'et
            var user = new RegisterRequest
            {
                Email = email,
                Password = password
            };

            // Sender et POST request med brugerdata som JSON
            // til API'ets register endpoint
            var response = await _httpClient.PostAsJsonAsync(
                "api/users/register",
                user
            );

            // Returnerer true hvis API'et svarer med en succes-statuskode
            // og false hvis oprettelsen mislykkes
            return response.IsSuccessStatusCode;
        }
    }

    // Beskriver de oplysninger som MAUI-appen
    // sender til API'et ved oprettelse af en bruger
    public class RegisterRequest
    {
        // Brugerens email
        public string Email { get; set; } = string.Empty;

        // Brugerens adgangskode
        public string Password { get; set; } = string.Empty;
    }
}