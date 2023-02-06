namespace Solver.Tests;

public class SolverTests
{
    [Test]
    public void TestSummary()
    {
        var a = 1;
        var b = 1;
        var c = 1;
        
        var result = Summary.Solve(a, b, c);

        Assert.AreEqual(3, result);
    }
}