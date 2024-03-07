namespace BlazorState;

public interface IReduxDevToolsStore
{
  IDictionary<string, object> GetSerializableState();

  void LoadStatesFromJson(string jsonString);
}

public interface IStore
{
  Guid Guid { get; }

  TState GetState<TState>();

  object GetState(Type stateType);

  void SetState(IState newState);

  void Reset();
}
