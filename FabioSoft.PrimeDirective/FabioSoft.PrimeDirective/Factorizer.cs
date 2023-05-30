using System.Diagnostics;

namespace FabioSoft.PrimeDirective;

public class Factorizer
{
    private readonly IPrimeDeterminator _primeDeterminator;

    public static Factorizer Default => new(new PrimeDeterminatorCollection(new DivisionRulesDeterminator(), new BruteForceDeterminator()));
    
    public Factorizer(params IPrimeDeterminator[] primeDeterminators) => _primeDeterminator = new PrimeDeterminatorCollection(primeDeterminators);

    public ulong[] Factorize(ulong number)
    {
        if(number < 2)
        {
            throw new InvalidOperationException("Input value must be at least 2!");
        }
        
        var upperLimit = Math.Sqrt(number);

        if (_primeDeterminator.IsPrime(number))
        {
            return new[] { number };
        }

        for (ulong i = 1; i <= upperLimit; i++)
        {
            if (!_primeDeterminator.IsPrime(i))
            {
                continue;
            }

            if (number % i != 0)
            {
                continue;
            }

            return new[] { i }.Concat(Factorize(number / i)).ToArray();
        }

        throw new UnreachableException($"The number {number} is no prime number and it could not be decomposed into prime factors. This should be impossible!");
    }
}