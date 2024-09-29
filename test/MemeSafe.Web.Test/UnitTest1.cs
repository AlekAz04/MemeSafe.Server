namespace MemeSafe.Web.Test;

public class UnitTest1 : IClassFixture<MemeSafeWebApplicationFactory>
{
    private readonly MemeSafeWebApplicationFactory _memeSafeWebApplicationFactory;

    public UnitTest1(MemeSafeWebApplicationFactory memeSafeWebApplicationFactory)
    {
        _memeSafeWebApplicationFactory = memeSafeWebApplicationFactory;
    }

    [Fact]
    public void Test1()
    {

    }
}
