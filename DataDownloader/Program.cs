using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var result = await DownloadDataAsync();
        Console.WriteLine(result);
    }

    static async Task<string> DownloadDataAsync()
    {
        await Task.Delay(2000); 
        return "Data downloaded";
    }
}