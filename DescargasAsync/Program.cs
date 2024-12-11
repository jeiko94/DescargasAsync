class Program
{
    public static async Task Main(string[] args)
    {
        var urls = new List<string>()
    {
        "https://www.google.com",
        "https://www.microsoft.com",
        "https://www.github.com"
    };

        Console.WriteLine("Descargando paginas secuencialmente...");
        await DescargarTodasSecuencialmenteAsync(urls);
    }


    public static async Task<int> DescargarPaginaAsync(string url)
    {
        using (var httpClient = new HttpClient())
        {
            string contenido = await httpClient.GetStringAsync(url);

            return contenido.Length;
        };
    }

    public static async Task DescargarTodasSecuencialmenteAsync(List<string> urls)
    {
        foreach (var url in urls)
        {
            int length = await DescargarPaginaAsync(url);
            Console.WriteLine($"{url}: {length} caracteres descargados.");

        }
    }
}
