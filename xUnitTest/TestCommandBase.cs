using AutoMapper;
using Infrastructure.Data;
using xUnitTest.DBContext;

namespace xUnitTest;

public abstract class TestBase : IDisposable
{
    protected readonly ApplicationDbContext _context;
    protected readonly IMapper _mapper;

#pragma warning disable CS8618 
    public TestBase()
    {
        _context = ContextFactory.Create();
    }
#pragma warning restore CS8618
    public void Dispose()
    {
        ContextFactory.Destroy(_context);
    }
}
