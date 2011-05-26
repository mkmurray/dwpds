using System;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure.container
{
  public class AutomaticDependencyFactory : IManageTheCreationOfOneSpecificType
  {
    Type type_to_create;
    IFetchDependencies container;
    ConstructorSelectionStrategy ctor_selector;

    public AutomaticDependencyFactory(Type type_to_create, IFetchDependencies container,
                                      ConstructorSelectionStrategy ctor_selector)
    {
      this.type_to_create = type_to_create;
      this.container = container;
      this.ctor_selector = ctor_selector;
    }

    public object create()
    {
      var ctor = ctor_selector(type_to_create);
      var dependencies = ctor.GetParameters()
        .Select(param => container.an(param.ParameterType));

      return ctor.Invoke(dependencies.ToArray());
    }
  }
}