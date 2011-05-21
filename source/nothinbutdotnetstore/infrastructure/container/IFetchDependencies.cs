using System;

namespace nothinbutdotnetstore.infrastructure.container
{
  public interface IFetchDependencies
  {
    Dependency an<Dependency>();
    object an(Type dependency);
  }
}