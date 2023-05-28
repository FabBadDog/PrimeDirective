using System.Diagnostics;

namespace FabioSoft.PrimeDirective;

public static class Factorizer
{
    public static IEnumerable<uint> Factorize(uint number)
    {
        if(number < 2)
        {
            throw new Exception("Dumm? Nix da, Kollege!");
        }
        
        var upperLimit = Math.Sqrt(number);

        if (IsPrime(number))
        {
            return new[] { number };
        }

        for (uint i = 1; i <= upperLimit; i++)
        {
            if (!IsPrime(i))
            {
                continue;
            }

            if (number % i != 0)
            {
                continue;
            }

            return new[] { i }.Concat(Factorize(number / i));
        }

        throw new UnreachableException("WTF!");
    }

    private static bool IsPrime(uint number)
    {
        if(number == 1)
        {
            return false;
        }
        
        if(number is 2 or 3 or 5)
        {
            return true;
        }
        
        var lastDigit = number % 10;
        if(lastDigit is 0 or 2 or 4 or 5 or 6 or 8)
        {
            return false;
        }

        for (var i = 2; i < number; i++)
        {
            if(number % i == 0)
            {
                return false;
            }
        }
        
        return true;
    }
}