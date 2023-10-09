namespace DadJokes.Api
{
    public static class ApiInitializer
    {
        public static HttpClient Client { get; set; } = new();

        public static void InitializeClient()
        {
            Client.BaseAddress = new Uri("https://icanhazdadjoke.com/");

            // Sätt en Accept-header till 'application/json'
            Client.DefaultRequestHeaders.Add("Accept", "application/json");
        }
    }
}
