namespace ApiAggregator.Tests
{
    public class TestService : IDisposable
    {
        public TestService() 
        {
        }

        public void Dispose()
        {

        }
    }

    public class AggTests : IClassFixture<TestService>
    {
        public AggTests (TestService service) 
        {
        }

        [Fact]
        public void Test1()
        {

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Test2(int n) 
        { 
            Assert.IsType<int>(n);
        }        
    }
}