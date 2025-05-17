using System.Diagnostics;

class Program
{
    /// <summary>
    /// Finds the NumOfPrimes via Trail Division. If ReportProgress is true, progress on finding 
    /// the primes is reported on in the console.
    /// </summary>
    /// <param name="NumOfPrimes"></param>
    /// <param name="MaxNum"></param>
    /// <returns></returns>
    public static List<int> GetPrimesUpTo(
        int NumOfPrimes = 100,
        bool ReportProgress = true)
    {
        int MaxNum = 2147483647; // largest 32 bit int

        var SW = Stopwatch.StartNew();
        int ReportInterval = NumOfPrimes / 10;
        int RecentReport = 0;

        List<int> PrimeList = [2]; // preload and skip 2
        for (int i = 3; i < MaxNum; i += 2) // all even numbers are not prime (by definition)
        {
            if (PrimeList.Count % ReportInterval == 0 && RecentReport != PrimeList.Count)
            {
                RecentReport = PrimeList.Count;
                if (ReportProgress)
                {
                    Console.Write($"{SW.ElapsedMilliseconds / 1000.00:0.00} seconds have ");
                    Console.WriteLine($"passed, {PrimeList.Count} primes found.");
                }
            }

            bool IsDivisible = false;
            int Sqrt = (int)Math.Sqrt(i);
            for (int j = 0; j < PrimeList.Count; j++)
            {
                if (PrimeList[j] > Sqrt) break;

                if (i % PrimeList[j] == 0)
                {
                    IsDivisible = true;
                    break;
                }
            }
            if (!IsDivisible)
                PrimeList.Add(i);

            if (PrimeList.Count == NumOfPrimes)
                break;
        }
        
        if (ReportProgress)
        {
            Console.Write($"This search took {SW.ElapsedMilliseconds / 1000.00:0.00} seconds, ");
            Console.WriteLine($"{PrimeList.Count} primes found.");
        }
        SW.Stop();
        return PrimeList;
    }

    public static void Main()
    {
        // Find Primes
        int BiggestPrimeToFind = 10000000;
        bool DisplayProgress = true;
        var Primes = GetPrimesUpTo(BiggestPrimeToFind, ReportProgress: DisplayProgress);

        // Export Primes to JSON
        int MaxPrimesPerFile = 1000000;
        string StoringDirectory = "primes";
        string BaseFilename = "primes";
        JsonExporter.ExportPrimesToJSON(
            Primes,
            StoringDirectory: StoringDirectory,
            BaseFilename: BaseFilename,
            PaginationNum: MaxPrimesPerFile);
    }
}