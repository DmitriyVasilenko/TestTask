using Application.Stratrgy.Interface;
using Application.Stratrgy;

namespace xUnitTest.Stratrgy;

public class TotalStrategyFixture
{
    public ITotalStrategy _strategy;
    public TotalStrategyFixture()
    {
        _strategy = new TotalStrategy();
    }
}
