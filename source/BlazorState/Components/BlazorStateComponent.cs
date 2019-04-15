﻿namespace BlazorState
{
  using System;
  using System.Collections.Concurrent;
  using MediatR;
  using Microsoft.AspNetCore.Components;

  /// <summary>
  /// A non required Base Class that injects Mediator and Store.
  /// And exposes StateHasChanged
  /// </summary>
  /// <remarks>Implements IBlazorStateComponent by Injecting</remarks>
  public class BlazorStateComponent : ComponentBase,
     IBlazorStateComponent
  {
    static ConcurrentDictionary<string, int> s_InstanceCounts = new ConcurrentDictionary<string, int>();

    public BlazorStateComponent()
    {
      string name = GetType().Name;
      int count = s_InstanceCounts.AddOrUpdate(name, 1, (aKey, aValue) => aValue + 1);

      Id = $"{name}-{count}";
    }

    ~BlazorStateComponent()
    {
      string name = GetType().Name;
      Console.WriteLine($"Destroying a {name}");
    }

    /// <summary>
    /// A generated unique Id based on the Class name and number of times they have been created
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Allows for the Assigning of a value one can use to select an element during automated testing.
    /// </summary>
    [Parameter] protected string TestId { get; set; }

    [Inject] public IMediator Mediator { get; set; }
    [Inject] public IStore Store { get; set; }

    /// <summary>
    /// Maintains all components that subscribe to a State.
    /// Is updated by using the GetState method
    /// </summary>
    [Inject] public Subscriptions Subscriptions { get; set; }

    /// <summary>
    /// Exposes StateHasChanged
    /// </summary>
    public void ReRender() => StateHasChanged();

    protected T GetState<T>()
    {
      Type stateType = typeof(T);
      Subscriptions.Add(stateType, this);
      return Store.GetState<T>();
    }
  }
}