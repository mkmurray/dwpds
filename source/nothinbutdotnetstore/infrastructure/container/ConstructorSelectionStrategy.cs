using System;
using System.Reflection;

namespace nothinbutdotnetstore.infrastructure.container
{
  public delegate ConstructorInfo ConstructorSelectionStrategy(Type type_to_target);
}