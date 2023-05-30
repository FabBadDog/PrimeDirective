namespace FabioSoft.PrimeDirective;

public interface IPrimeDeterminator
{
    PrimeStatus Determinate(ulong number);
}

public static class PrimeDeterminatorExtensions
{
    public static bool IsPrime(this IPrimeDeterminator primeDeterminator, ulong number)
    {
        var result = primeDeterminator.Determinate(number);

        return result switch
        {
            PrimeStatus.IsPrime => true,
            PrimeStatus.IsNoPrime => false,
            PrimeStatus.Undetermined => throw new InvalidOperationException($"Could not determine prime status for {number}!"),
            var _ => throw new InvalidOperationException($"The prime status '{result}' is unknown!")
        };
    }
}