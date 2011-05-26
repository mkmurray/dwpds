 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{  
  [Subject(typeof(MissingApplicationBehaviour))]  
  public class MissingApplicationBehaviourSpecs
  {
    public abstract class concern : Observes<IProcessRequestInformation,
                                      MissingApplicationBehaviour>
    {
        
    }

   
    public class when_told_to_process_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestInformation>();
      };

      Because b = () =>
        spec.catch_exception(() => sut.run(request));

      It should_throw_a_command_not_registered_exception_with_the_details_of_the_request = () =>
        spec.exception_thrown.ShouldBeAn<CommandNotRegisteredException>()
                              .request.ShouldEqual(request);

      static IContainRequestInformation request;
        
    }
  }
}
