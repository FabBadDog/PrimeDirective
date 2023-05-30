namespace FabioSoft.PrimeDirective;

public class PrimeDeterminatorCollection : IPrimeDeterminator
{
    private readonly IPrimeDeterminator[] _primeDeterminators;

    public PrimeDeterminatorCollection(params IPrimeDeterminator[] primeDeterminators) => _primeDeterminators = primeDeterminators;

    public PrimeStatus Determinate(ulong number)
    {
        foreach (var primeDeterminator in _primeDeterminators)
        {
            var result = primeDeterminator.Determinate(number);
            if(result != PrimeStatus.Undetermined)
            {
                return result;
            }
        }
        
        return PrimeStatus.Undetermined;
    }
}