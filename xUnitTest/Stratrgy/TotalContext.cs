using Application.Stratrgy;
using Domain.Enum;

namespace xUnitTest.Stratrgy;

public class TotalContextTests : IClassFixture<TotalStrategyFixture>
{
    private readonly TotalContext _contextTest;
    public TotalContextTests(TotalStrategyFixture strategyFixture)
    {
        _contextTest = new TotalContext(strategyFixture._strategy);
    }
    [Theory]
    [InlineData(Bank.VTB, 100, 300)]
    [InlineData(Bank.VTB, 100.22, 300.66)]
    [InlineData(Bank.Sberbank, 100, 50)]
    [InlineData(Bank.Tinkoff, 100, 0)]
    [InlineData(Bank.Tinkoff, 300, 50)]
    [InlineData(Bank.AlfaBank, 100, 100)]
    [InlineData(Bank.Promsvyazbank, 100, 100)]
    public void Test(Bank bank, decimal totalIn, decimal totalOut)
    {
        // Assert
        _contextTest.SetStrategy((int)bank);
        // Act
        var result = _contextTest.ExecuteStrategy(totalIn);
        // Assert
        Assert.Equal(totalOut, result);
    }
}
