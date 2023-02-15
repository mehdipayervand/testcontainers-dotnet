namespace Testcontainers.Lightstreamer;

/// <inheritdoc cref="ContainerConfiguration" />
[PublicAPI]
public sealed class LightstreamerConfiguration : ContainerConfiguration
{

  public string LightstreamerMode { get; private set; }
  public string LightstreamerAdapterName { get; private set; }
  public string LightstreamerAdapterClass { get; private set; }

  public ushort RequestReplyPort { get; private set; }
  public ushort NotifyPort { get; private set; }
  public ushort ListenerPort { get; private set; }

  /// <summary>
  /// Initializes a new instance of the <see cref="LightstreamerConfiguration" /> class.
  /// </summary>
  public LightstreamerConfiguration()
  {
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="LightstreamerConfiguration" /> class.
  /// </summary>
  public LightstreamerConfiguration(
    string lightstreamerMode,
    string lightstreamerAdapterName,
    string lightstreamerAdapterClass,
    ushort requestReplyPort, ushort notifyPort, ushort listenerPort)
  {
    this.LightstreamerMode = lightstreamerMode;
    this.LightstreamerAdapterName = lightstreamerAdapterName;
    this.LightstreamerAdapterClass = lightstreamerAdapterClass;
    this.RequestReplyPort = requestReplyPort;
    this.NotifyPort = notifyPort;
    this.ListenerPort = listenerPort;
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="LightstreamerConfiguration" /> class.
  /// </summary>
  /// <param name="resourceConfiguration">The Docker resource configuration.</param>
  public LightstreamerConfiguration(IResourceConfiguration<CreateContainerParameters> resourceConfiguration)
      : base(resourceConfiguration)
  {
    // Passes the configuration upwards to the base implementations to create an updated immutable copy.
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="LightstreamerConfiguration" /> class.
  /// </summary>
  /// <param name="resourceConfiguration">The Docker resource configuration.</param>
  public LightstreamerConfiguration(IContainerConfiguration resourceConfiguration)
      : base(resourceConfiguration)
  {
    // Passes the configuration upwards to the base implementations to create an updated immutable copy.
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="LightstreamerConfiguration" /> class.
  /// </summary>
  /// <param name="resourceConfiguration">The Docker resource configuration.</param>
  public LightstreamerConfiguration(LightstreamerConfiguration resourceConfiguration)
      : this(new LightstreamerConfiguration(), resourceConfiguration)
  {
    // Passes the configuration upwards to the base implementations to create an updated immutable copy.
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="LightstreamerConfiguration" /> class.
  /// </summary>
  /// <param name="oldValue">The old Docker resource configuration.</param>
  /// <param name="newValue">The new Docker resource configuration.</param>
  public LightstreamerConfiguration(LightstreamerConfiguration oldValue, LightstreamerConfiguration newValue)
      : base(oldValue, newValue)
  {
  }
}
