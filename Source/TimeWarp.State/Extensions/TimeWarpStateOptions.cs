namespace TimeWarp.State;

/// <summary>
/// Options for configuring TimeWarp.State
/// </summary>
public class TimeWarpStateOptions
{
  /// <summary>
  /// Assemblies to be searched for MediatR Actions and Handlers
  /// </summary>
  public IEnumerable<Assembly> Assemblies { get; set; }

  /// <summary>
  /// Use the StateTransactionBehavior (default) or not
  /// </summary>
  public bool UseStateTransactionBehavior { get; set; } = true;

  public bool UseRouting { get; set; } = true;

  /// <summary>
  /// Use the FullName of the State in the ReduxDevTools
  /// </summary>
  public bool UseFullNameForStatesInDevTools { get; set; } = false;
  public JsonSerializerOptions JsonSerializerOptions { get; }
  
  public readonly IServiceCollection ServiceCollection;

  public TimeWarpStateOptions(IServiceCollection serviceCollection)
  {
    ServiceCollection = serviceCollection;
    Assemblies = Array.Empty<Assembly>();
    JsonSerializerOptions = new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
  }
}
