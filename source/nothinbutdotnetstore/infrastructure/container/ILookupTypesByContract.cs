using System;

namespace nothinbutdotnetstore.infrastructure.container
{
  public interface ILookupTypesByContract
  {
    Type get_concrete_type_registered_for<T>();
  }
}