namespace FabioSoft.PrimeDirective;

public class BruteForceDeterminator : IPrimeDeterminator
{
    public PrimeStatus Determinate(ulong number)
    {
        if (number == 1)
        {
            return PrimeStatus.IsNoPrime;
        }

        if (number == 2)
        {
            return PrimeStatus.IsPrime;
        }

        for (ulong i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                return PrimeStatus.IsNoPrime;
            }
        }

        return PrimeStatus.IsPrime;
    }
}