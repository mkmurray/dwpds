using System;
using System.Reflection;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure.container
{
  public class GreedyConstructorSelectorStrategy
  {
    public ConstructorInfo find_on(Type type)
    {
      return type.GetConstructors()
        .OrderByDescending(x => x.GetParameters().Count())
        .First();
    }
  }
}