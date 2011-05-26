using System;

namespace nothinbutdotnetstore.infrastructure.container
{
  public class DependencyFactoryNotRegisteredException : Exception
  {
    public static string message_format = "There is no factory registered for type: {0}";
    public Type type_that_has_no_factory { get; private set; }

    public DependencyFactoryNotRegisteredException(Type type_without_factory)

      : base(string.Format(message_format, type_without_factory.FullName))
    {
      this.type_that_has_no_factory = type_without_factory;
    }
  }
}