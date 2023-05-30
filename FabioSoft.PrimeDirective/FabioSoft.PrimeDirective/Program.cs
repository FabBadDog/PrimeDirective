namespace FabioSoft.PrimeDirective;

public static class Program
{
    public static void Main(string[] args)
    {
        if(args.Length != 1)
        {
            PrintUsage();
            return;
        }

        if(!ulong.TryParse(args[0], out var number))
        {
            PrintUsage();
            return;
        }
      
        var result = Factorizer.Default.Factorize(number);
      
        var primeFactors = string.Join(" x ", result);
        Console.WriteLine($"Prime factors of {number}: {primeFactors}");
    }

    private static void PrintUsage() => Console.Error.WriteLine("Usage: fact <number>");
}