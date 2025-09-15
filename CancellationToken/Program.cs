// نقش سیستم هشدار را دارد، وقتی کاربر در خواست یک httprequest را میدهد
// asp.net core به صورت پیش فرض یک cancellationToken میسازد و به handler پاس میدهد
// اگر به هر دلیلی عملیات لغو شودمثل یک سیستم هشدار عمل میکند و سبب آزاد سازی thread به شیوه درست میشود.



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
