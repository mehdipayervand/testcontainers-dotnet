namespace Testcontainers.Lightstreamer;

/// <inheritdoc cref="DockerContainer" />
[PublicAPI]
public sealed class LightstreamerContainer : DockerContainer
{
  /// <summary>
  /// Initializes a new instance of the <see cref="LightstreamerContainer" /> class.
  /// </summary>
  /// <param name="configuration">The container configuration.</param>
  /// <param name="logger">The logger.</param>
  public LightstreamerContainer(LightstreamerConfiguration configuration, ILogger logger)
    : base(configuration, logger)
  {
  }

  /// <summary>
  /// Gets the Lightstreamer connection string.
  /// </summary>
  /// <returns>The Lightstreamer connection string.</returns>
  public string GetConnectionString()
  {
    return new UriBuilder("Lightstreamer", Hostname, GetMappedPublicPort(LightstreamerBuilder.HttpListenerPort)).Uri.Authority;
  }

  ///// <summary>
  ///// Executes the Lua script in the Lightstreamer container.
  ///// </summary>
  ///// <param name="scriptContent">The content of the Lua script to execute.</param>
  ///// <param name="ct">Cancellation token.</param>
  ///// <returns>Task that completes when the Lua script has been executed.</returns>
  //public async Task<ExecResult> ExecScriptAsync(string scriptContent, CancellationToken ct = default)
  //{
  //  var scriptFilePath = string.Join("/", string.Empty, "tmp", Guid.NewGuid().ToString("D"), Path.GetRandomFileName());

  //  await this.CopyFileAsync(scriptFilePath, Encoding.Default.GetBytes(scriptContent), 493, 0, 0, ct)
  //    .ConfigureAwait(false);

  //  return await this.ExecAsync(new[] { "Lightstreamer-cli", "--eval", scriptFilePath, "0" }, ct)
  //    .ConfigureAwait(false);
  //}

}
