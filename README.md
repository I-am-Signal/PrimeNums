# Prime Number Generator

Included in this repository are prime numbers up to the 10 millionth, paginated every million numbers with zero-based indexing in a directory named `primes/` all in JSON format along with the companion code that generated them. You are free to use or modify the code or files in any way you deem fit. In fact, I encourage this and hope this can save you some time.

## Companion Code
The provided companion code will generate prime numbers up to the `BiggestPrimeToGet` specified in the main method.

### Prerequisites for Use
- **C# SDK**
- **Time** (or idle use of computing power)

### Running the Program
- `dotnet run` from the `PrimeNums/PrimeNums` directory.

### Expected Output
The following is the expected output assuming you utilize the default parameters.
```ps1
> dotnet run
1.96 seconds have passed, 1000000 primes found.
5.30 seconds have passed, 2000000 primes found.
9.32 seconds have passed, 3000000 primes found.
13.98 seconds have passed, 4000000 primes found.
19.16 seconds have passed, 5000000 primes found.
24.76 seconds have passed, 6000000 primes found.
30.75 seconds have passed, 7000000 primes found.
37.05 seconds have passed, 8000000 primes found.
43.46 seconds have passed, 9000000 primes found.
This search took 50.22 seconds, 10000000 primes found.
Primes exported to primes/primes0.json.
Primes exported to primes/primes1.json.
Primes exported to primes/primes2.json.
Primes exported to primes/primes3.json.
Primes exported to primes/primes4.json.
Primes exported to primes/primes5.json.
Primes exported to primes/primes6.json.
Primes exported to primes/primes7.json.
Primes exported to primes/primes8.json.
Primes exported to primes/primes9.json.
```

### Method Rationale
The trial division method was selected as this allows for the specification of a specific number of primes to find instead of just the largest number of the primes. This does, however, take a not insignificant amount of time longer than if you were to use a Sieve of Eratosthenes because of its worse big Oh value of `O(n*sqrt(n))` compared with SoE's `O(nlog(log(n)))`.

Additionally, a 32-bit integer was selected as if you are going to be calculating larger than that, you really should be using the SoE as it's simply faster, albeit you have to estimate to get a specific number of primes.