using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

public class User
{
    public Guid Id { get; private set; }
      public string Name { get; set; } = string.Empty;  // Default value
    public string Email { get; set; } = string.Empty; // Default value
}

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("📡 Conectando con la API de Clean Architecture...");

        // URL base de la API
        string apiUrl = "http://localhost:5226/api/users";

        // Consumir la API usando HttpClient
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Realizar la petición GET
                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta como JSON
                    string json = await response.Content.ReadAsStringAsync();
                    //List<User> users = JsonSerializer.Deserialize<List<User>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    var users = JsonConvert.DeserializeObject<List<User>>(json);

                    Console.WriteLine("\n✅ Lista de usuarios obtenida:");
                    foreach (var user in users)
                    {
                        Console.WriteLine($"- ID: {user.Id}, Nombre: {user.Name}, Email: {user.Email}");
                    }
                }
                else
                {
                    Console.WriteLine($"⚠️ Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error de conexión: {ex.Message}");
            }
        }
    }
}