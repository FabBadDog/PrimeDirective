using FluentAssertions;

using NUnit.Framework;

namespace FabioSoft.PrimeDirective.Test;

public class Tests
{
    private static IPrimeDeterminator[] PrimeDeterminators =
    {
        new BruteForceDeterminator(),
        new PrimeDeterminatorCollection(new DivisionRulesDeterminator(), new BruteForceDeterminator())
    };

    [TestCaseSource(nameof(PrimeDeterminators))]
    public void TestZero(IPrimeDeterminator primeDeterminator)
    {
        // Arrange
        var factorizer = new Factorizer(primeDeterminator);

        // Act
        var act = () => factorizer.Factorize(0);

        // Assert
        act.Should().Throw<Exception>();
    }

    [TestCaseSource(nameof(PrimeDeterminators))]
    public void TestOne(IPrimeDeterminator primeDeterminator)
    {
        // Arrange
        var factorizer = new Factorizer(primeDeterminator);

        // Act
        var act = () => factorizer.Factorize(1);

        // Assert
        act.Should().Throw<Exception>();
    }

    private static IEnumerable<object> TestCases()
    {
        foreach (var primeDeterminator in PrimeDeterminators)
        {
            yield return new object[] { primeDeterminator, 2u, new[] { 2u } };
            yield return new object[] { primeDeterminator, 3u, new[] { 3u } };
            yield return new object[] { primeDeterminator, 4u, new[] { 2u, 2u } };
            yield return new object[] { primeDeterminator, 5u, new[] { 5u } };
            yield return new object[] { primeDeterminator, 6u, new[] { 3u, 2u } };
            yield return new object[] { primeDeterminator, 7u, new[] { 7u } };
            yield return new object[] { primeDeterminator, 8u, new[] { 2u, 2u, 2u } };
            yield return new object[] { primeDeterminator, 9u, new[] { 3u, 3u } };
            yield return new object[] { primeDeterminator, 12u, new[] { 3u, 2u, 2u } };
            yield return new object[] { primeDeterminator, 100u, new[] { 5u, 5u, 2u, 2u } };
            yield return new object[] { primeDeterminator, 32057u, new[] { 32057u } };
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public void TestInputOutputWithBruteForce(IPrimeDeterminator primeDeterminator, uint input, IEnumerable<uint> expectedOutput)
    {
        // Arrange
        var factorizer = new Factorizer(primeDeterminator);

        // Act
        var result = factorizer.Factorize(input);

        // Assert
        result.Should().BeEquivalentTo(expectedOutput);
    }
}