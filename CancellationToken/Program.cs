



    CancellationTokenSource source = new();
    Console.WriteLine(source.Token.IsCancellationRequested);
    await GetAllDataFromDatabaseAsync(source.Token);
    
    source.Cancel();
   Console.WriteLine(source.Token.IsCancellationRequested);

    await GetAllDataFromDatabaseAsync(source.Token);


static async Task GetAllDataFromDatabaseAsync(CancellationToken cancellationToken)
{
        HttpClient client = new();
        var result = await client.GetAsync("https://google.com", cancellationToken);
        
    Console.WriteLine(result);
}