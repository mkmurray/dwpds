 using System;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.infrastructure.container;

namespace nothinbutdotnetstore.specs
{   
  public class DependencyFactoryNotRegisteredExceptionSpecs
  {
    public abstract class concern : Observes<DependencyFactoryNotRegisteredException>
    {
        
    }

    [Subject(typeof(DependencyFactoryNotRegisteredException))]
    public class when_displaying_its_message: concern
    {
      private Establish c = () => 
        depends.on(the_type);
      
      private Because b = () =>
        result = sut.Message;

      private It should_name_the_dependency_it_cannot_create = () =>
      {
        result.ShouldContain(the_type.Name);       
      };

      static string result;
      static Type the_type = typeof(OurDependency);
    }
  }

  internal class OurDependency
  {
  }
}
