using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(Routes))]
  public class RouteSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_registering_a_route_for_a_command : concern
    {
      Establish c = () =>
      {
        route_table = fake.an<IStoreRoutes>();
        SharedBehaviours.scaffold_container_returned(route_table,pipeline, fake);

      };

      Because b = () =>
        Routes.register<TheCommand>();

      It should_add_the_route_to_the_route_table = () =>
        route_table.received(x => x.register_route_to<TheCommand>());

      static IStoreRoutes route_table;
        
    }
  }

  public class TheCommand : IProcessAnApplicationSpecificBehaviour
  {
    public void run(IContainRequestInformation request)
    {
      throw new NotImplementedException();
    }
  }
}
