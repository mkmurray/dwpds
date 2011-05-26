 using System;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.infrastructure.container;
 using nothinbutdotnetstore.web.core;
 using nothinbutdotnetstore.web.core.routing;

namespace nothinbutdotnetstore.specs
{  
  [Subject(typeof(RouteTable))]  
  public class RouteTableSpecs
  {
    public abstract class concern : Observes<IStoreRoutes,
                                        RouteTable>
    {
        
    }

   
    public class when_registering_a_route : concern
    {
      Establish c = () =>
      {
        the_criteria = x => true;
        behaviour = fake.an<TheBehaviour>();
        specification_builder = depends.on<ICreateRequestSpecifications>();
        container = depends.on<IFetchDependencies>();
        container.setup(x => x.an<TheBehaviour>()).Return(behaviour);

        specification_builder.setup(x => x.is_for<TheBehaviour>())
          .Return(the_criteria);

      };

      Because b = () =>
        sut.register_route_to<TheBehaviour>();
  

      It should_register_a_processing_comand_with_the_correct_specification = () =>
      {
        var item = concrete_sut[0].ShouldBeAn<RequestCommand>();
        item.application_behaviour.ShouldEqual(behaviour);
        item.request_criteria.ShouldEqual(the_criteria);
      };

      static TheBehaviour behaviour;
      static IFetchDependencies container;
      static ICreateRequestSpecifications specification_builder;
      static RequestCriteria the_criteria;
    }
  }

  public class TheBehaviour :IProcessAnApplicationSpecificBehaviour
  {
    public void run(IContainRequestInformation request)
    {
      throw new NotImplementedException();
    }
  }
}
