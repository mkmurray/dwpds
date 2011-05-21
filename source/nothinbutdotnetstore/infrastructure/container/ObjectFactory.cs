using System;

namespace nothinbutdotnetstore.infrastructure.container
{
  public class ObjectFactory : IManageTheCreationOfOneSpecificType
  {
    private readonly Type type_to_create;

    public ObjectFactory(Type typeToCreate)
    {
      type_to_create = typeToCreate;
    }

    public object create()
    {
      return Activator.CreateInstance(type_to_create);
    }
  }
}