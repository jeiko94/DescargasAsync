class Program
{
    public static async Task Main(string[] args)
    {
        var urls = new List<string>()
    {
        "https://www.google.com",
        "https://www.microsoft.com",
        "https://www.github.com",
        "https://www.facebook.com",
        "https://www.apple.com"
    };

        Console.WriteLine("Descargando paginas en paralelo...");
        await DescargaTodasEnParaleloAsync(urls);

        Console.WriteLine("\nDescargando paginas secuencialmente...");
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

    public static async Task DescargaTodasEnParaleloAsync(List<string> urls)
    {
        var tarea = urls.Select(url => DescargarPaginaAsync(url)).ToList();

        int[] resultados = await Task.WhenAll(tarea);

        for (int i = 0; i < urls.Count; i ++)
        {
            Console.WriteLine($"{urls[i]}: {resultados[i]} caracteres descargados.");
        }
    }
}
