using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.infrastructure.container;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(Container))]
  public class ContainerSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_accessing_container_services : concern
    {
      Establish c = () =>
      {
        the_container_gateway = fake.an<IFetchDependencies>(); 
        ContainerGatewayResolver resolver = () => the_container_gateway;

        spec.change(() => Container.gateway_resolver).to(resolver);

      };

      Because b = () =>
        result = Container.resolve;

      It should_provide_access_to_the_underlying_container_gateway = () =>
        result.ShouldEqual(the_container_gateway);


      static IFetchDependencies result;
      static IFetchDependencies the_container_gateway;
    }
  }
}
