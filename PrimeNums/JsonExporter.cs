using System.Text.Json;

public class JsonExporter
{
    public static void ExportPrimesToJSON(
    List<int> Primes,
    string StoringDirectory = "primes",
    string BaseFilename = "primes",
    int PaginationNum = 1000000)
    {
        Directory.CreateDirectory(StoringDirectory);

        var IndexedPrimes = new Dictionary<int, int>();
        int NumOfPages = 0;

        for (int i = 0; i < Primes.Count; i++)
        {
            IndexedPrimes[i] = Primes[i];

            bool IsPageFull = (i + 1) % PaginationNum == 0;
            bool IsLastItem = i == Primes.Count - 1;

            if (IsPageFull || IsLastItem)
            {
                string FilePath = $"{StoringDirectory}/{BaseFilename + NumOfPages++}.json";
                File.WriteAllText(FilePath, JsonSerializer.Serialize(IndexedPrimes));
                Console.WriteLine($"Primes exported to {FilePath}.");
                IndexedPrimes.Clear();
            }
        }
    }
}