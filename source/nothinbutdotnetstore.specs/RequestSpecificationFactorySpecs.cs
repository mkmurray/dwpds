using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.routing;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(RequestSpecificationFactory))]
  public class RequestSpecificationFactorySpecs
  {
    public abstract class concern : Observes<ICreateRequestSpecifications,
                                      RequestSpecificationFactory>
    {
    }

    public class when_provided_the_type_of_a_command_to_match : concern
    {
      Establish c = () =>
      {
        the_request = fake.an<IContainRequestInformation>();
        the_request.setup(x => x.raw_url).Return("sdfsdfsdf/{0}.denver".format_using(typeof(ASingleCommand).Name));
      };

      Because b = () =>
        result = sut.is_for<ASingleCommand>();

      It should_create_a_criteria_that_will_match_requests_based_on_the_name_of_the_command = () =>
        result(the_request).ShouldBeTrue();

      static RequestCriteria result;
      static IContainRequestInformation the_request;
    }

    public class ASingleCommand : IProcessAnApplicationSpecificBehaviour
    {
      public void run(IContainRequestInformation request)
      {
      }
    }
  }
}