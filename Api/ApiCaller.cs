using DadJokes.Models;
using Newtonsoft.Json;

namespace DadJokes.Api
{
    public class ApiCaller
    {
        public async Task<RootModel?> GetJoke()
        {
            // Skcika ett get-request till bas-adressen
            HttpResponseMessage response = await ApiInitializer.Client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                // läs responset och omvandla till en json-sträng
                string jsonData = await response.Content.ReadAsStringAsync();

                // Läs json-data och konvertera den till C#-objekt
                RootModel? data = JsonConvert.DeserializeObject<RootModel>(jsonData);
                return data;
            }
            return null;
        }
    }
}
