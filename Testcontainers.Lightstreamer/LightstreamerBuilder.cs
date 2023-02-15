namespace Testcontainers.Lightstreamer;

/// <inheritdoc cref="ContainerBuilder{TBuilderEntity, TContainerEntity, TConfigurationEntity}" />
[PublicAPI]
public sealed class LightstreamerBuilder : ContainerBuilder<LightstreamerBuilder, LightstreamerContainer, LightstreamerConfiguration>
{
  public const string LightstreamerImage = "Lightstreamer:7.3";

  /// <summary>
  /// Initializes a new instance of the <see cref="LightstreamerBuilder" /> class.
  /// </summary>
  public LightstreamerBuilder()
      : this(new LightstreamerConfiguration())
  {
    this.DockerResourceConfiguration = this.Init().DockerResourceConfiguration;
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="LightstreamerBuilder" /> class.
  /// </summary>
  /// <param name="resourceConfiguration">The Docker resource configuration.</param>
  private LightstreamerBuilder(LightstreamerConfiguration resourceConfiguration)
      : base(resourceConfiguration)
  {
    this.DockerResourceConfiguration = resourceConfiguration;
  }

  /// <inheritdoc />
  protected override LightstreamerConfiguration DockerResourceConfiguration { get; }

  /// <inheritdoc />
  public override LightstreamerContainer Build()
  {
    this.Validate();
    return new LightstreamerContainer(this.DockerResourceConfiguration, TestcontainersSettings.Logger);
  }

  /// <inheritdoc />
  protected override LightstreamerBuilder Init()
  {
    return base.Init()
        .WithImage(LightstreamerImage)
        .WithPortBinding(this.DockerResourceConfiguration.RequestReplyPort, true)
        .WithPortBinding(this.DockerResourceConfiguration.NotifyPort, true)
        .WithPortBinding(this.DockerResourceConfiguration.ListenerPort, true)
        .WithEnvironment("LS_MODE", this.DockerResourceConfiguration.LightstreamerMode)
        .WithEnvironment("LS_ADAPTER_NAME", this.DockerResourceConfiguration.LightstreamerAdapterName)
        .WithEnvironment("LS_ADAPTER_CLASS", this.DockerResourceConfiguration.LightstreamerAdapterClass)
        .WithEnvironment("LS_ADAPTER_REQUEST_REPLY_PORT", this.DockerResourceConfiguration.RequestReplyPort.ToString("D"))
        .WithEnvironment("LS_ADAPTER_NOTIFY_PORT", this.DockerResourceConfiguration.NotifyPort.ToString("D"))
        .WithEnvironment("LS_ADAPTER_HTTP_LISTENER_PORT", this.DockerResourceConfiguration.ListenerPort.ToString("D"))
        .WithWaitStrategy(Wait.ForUnixContainer().AddCustomWaitStrategy(new WaitUntil()));
  }

  /// <inheritdoc />
  protected override LightstreamerBuilder Clone(IResourceConfiguration<CreateContainerParameters> resourceConfiguration)
  {
    return this.Merge(this.DockerResourceConfiguration, new LightstreamerConfiguration(resourceConfiguration));
  }

  /// <inheritdoc />
  protected override LightstreamerBuilder Clone(IContainerConfiguration resourceConfiguration)
  {
    return this.Merge(this.DockerResourceConfiguration, new LightstreamerConfiguration(resourceConfiguration));
  }

  /// <inheritdoc />
  protected override LightstreamerBuilder Merge(LightstreamerConfiguration oldValue, LightstreamerConfiguration newValue)
  {
    return new LightstreamerBuilder(new LightstreamerConfiguration(oldValue, newValue));
  }

  /// <inheritdoc cref="IWaitUntil" />
  private sealed class WaitUntil : IWaitUntil
  {
    /// <inheritdoc />
    public async Task<bool> UntilAsync(IContainer container)
    {
      var execResult = await container.ExecAsync(new[] { "Lightstreamer-cli", "ping" })
          .ConfigureAwait(false);

      return 0L.Equals(execResult.ExitCode);
    }
  }
}
