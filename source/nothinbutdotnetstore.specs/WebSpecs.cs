using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.core.routing;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(Web))]
  public class WebSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_accessing_the_incoming_request_property : concern
    {
      Establish c = () =>
      {
        the_builder = fake.an<ICreateRequestSpecifications>();
        RequestCriteriaBuilderFactory factory = () => the_builder;
        spec.change(() => Web.request_criteria_factory).to(factory);
      };

      Because b = () =>
        result = Web.IncomingRequest;

      It should_provide_access_to_the_created_request_criteria_builder = () =>
        result.ShouldEqual(the_builder);


      static ICreateRequestSpecifications result;
      static ICreateRequestSpecifications the_builder;
    }
  }
}
