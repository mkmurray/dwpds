using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.container
{
  public class DependencyContainer : IFetchDependencies
  {
    IDictionary<Type, IManageTheCreationOfOneSpecificType> factories;

    public DependencyContainer(IDictionary<Type, IManageTheCreationOfOneSpecificType> factories)
    {
      this.factories = factories;
    }

    public Dependency an<Dependency>()
    {
      return (Dependency) an(typeof(Dependency));
    }

    public object an(Type dependency)
    {
      ensure_factory_exists_for(dependency);
      try
      {
        return factories[dependency].create();
      }
      catch (Exception e)
      {
        throw new DependencyCreationException(dependency,e);
      }
    }

    void ensure_factory_exists_for(Type type)
    {
      if (factories.ContainsKey(type)) return;
      throw new DependencyFactoryNotRegisteredException(type);
    }
  }
}