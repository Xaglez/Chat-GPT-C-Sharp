using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OpenAIChatExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var question = Console.ReadLine();
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Adicione sua autorização", "e sua chave");

            var json = JsonConvert.SerializeObject(new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = question }
                },
                temperature = 0.7
            });

            var httpResponse = await client.PostAsync("https://api.openai.com/v1/chat/completions", new StringContent(json, Encoding.UTF8, "application/json"));
            var data = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<dynamic>(data);
            Console.WriteLine(response);
        }
    }
}
