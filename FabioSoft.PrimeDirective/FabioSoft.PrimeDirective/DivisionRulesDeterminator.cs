namespace FabioSoft.PrimeDirective;

public class DivisionRulesDeterminator : IPrimeDeterminator
{
    public PrimeStatus Determinate(ulong number)
    {
        if(number is 2 or 3 or 5)
        {
            return PrimeStatus.IsPrime;
        }
        
        var lastDigit = number % 10;
        if(lastDigit is 0 or 2 or 4 or 5 or 6 or 8)
        {
            return PrimeStatus.IsNoPrime;
        }

        return PrimeStatus.Undetermined;
    }
}