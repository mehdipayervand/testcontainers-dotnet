namespace Testcontainers.Lightstreamer.Tests
{
  using System.Threading.Tasks;

  public class LightstreamerContainerTest : IAsyncLifetime
  {
    private readonly LightstreamerContainer _lightstreamerContainer = new LightstreamerBuilder().Build();

    public Task InitializeAsync()
    {
      return this._lightstreamerContainer.StartAsync();
    }

    public Task DisposeAsync()
    {
      return this._lightstreamerContainer.DisposeAsync().AsTask();
    }

    [Fact]
    public void Test1()
    {

    }


  }
}
