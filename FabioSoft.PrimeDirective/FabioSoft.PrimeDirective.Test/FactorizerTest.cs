using FluentAssertions;

using NUnit.Framework;

namespace FabioSoft.PrimeDirective.Test;

public class Tests
{
    [Test]
    public void TestZero()
    {
        var act = () => Factorizer.Factorize(0);
        
        act.Should().Throw<Exception>();
    }
    
    [Test]
    public void TestOne()
    {
        var act = () => Factorizer.Factorize(1);
        
        act.Should().Throw<Exception>();
    }   
    
    [TestCase(2u, new [] {2u})]
    [TestCase(3u, new [] {3u})]
    [TestCase(4u, new [] {2u,2u})]
    [TestCase(5u, new [] {5u})]
    [TestCase(6u, new [] {3u,2u})]
    [TestCase(7u, new [] {7u})]
    [TestCase(8u, new [] {2u,2u,2u})]
    [TestCase(9u, new [] {3u,3u})]
    [TestCase(12u, new [] {3u,2u,2u})]
    [TestCase(100u, new [] {5u,5u,2u,2u})]
    [TestCase(32057u, new [] {32057u})]
    public void TestInputOutput(uint input, IEnumerable<uint> expectedOutput)
    {
        var result = Factorizer.Factorize(input);

        result.Should().BeEquivalentTo(expectedOutput);
    }     
}