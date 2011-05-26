 using System;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.infrastructure.container;

namespace nothinbutdotnetstore.specs
{   
  public class ObjectFactorySpecs
  {
    public abstract class concern : Observes<IManageTheCreationOfOneSpecificType,
                                      ObjectFactory>
    {
        
    }

    [Subject(typeof(ObjectFactory))]
    public class when_called_to_create_an_object : concern
    {
      private Establish c = () =>
      {
        our_type = typeof (OurClass);
        depends.on(our_type);
      };
      
      private Because b = () =>
        result = sut.create();                           

      private It should_return_the_object = () =>
        result.downcast_to<OurClass>().ShouldBeOfType(our_type);


      private static object result;
      private static Type our_type;
    }
  }

  public class OurClass
  {
    
  }
}
