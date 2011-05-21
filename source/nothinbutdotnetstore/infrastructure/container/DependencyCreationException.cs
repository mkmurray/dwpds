using System;

namespace nothinbutdotnetstore.infrastructure.container
{
  public class DependencyCreationException : Exception
  {
    public Type type_that_could_not_be_created { get; private set; }

    public DependencyCreationException(Type type_that_could_not_be_created,Exception inner_exception):base(string.Empty,inner_exception)
    {
      this.type_that_could_not_be_created = type_that_could_not_be_created;
    }
  }
}