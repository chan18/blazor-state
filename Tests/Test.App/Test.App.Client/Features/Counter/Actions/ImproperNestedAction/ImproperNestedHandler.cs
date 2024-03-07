namespace Test.App.Client.Features.Counter;

using static WrongNesting;

public partial class CounterState
{
  internal class ImproperNestedHandler
  (
    IStore store
  ) : BaseActionHandler<ImproperNestedAction>(store)
  {

    public override Task<Unit> Handle
    (
      ImproperNestedAction action,
      CancellationToken cancellationToken
    ) => Unit.Task;
  }
}
