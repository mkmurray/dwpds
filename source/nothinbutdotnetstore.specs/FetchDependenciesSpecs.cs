 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.infrastructure.container;

namespace nothinbutdotnetstore.specs
{   
  public class FetchDependenciesSpecs
  {
    public abstract class concern : Observes<IFetchDependencies,
                                      FetchDependencies>
    {
        
    }

    [Subject(typeof(FetchDependencies))]
    public class when_asked_to_resolve_a_dependency : concern
    {
      private Establish c = () =>
      {
        type_registry = depends.on<ILookupTypesByContract>();
        type_registry.setup(x => x.get_concrete_type_registered_for<OurContract>()).Return(typeof(OurContract));
      };

      private Because b = () =>
        result = sut.an<OurContract>();
      
      private It should_it_get_the_dependency_from_the_type_registry = () => 
        type_registry.received(x => x.get_concrete_type_registered_for<OurContract>());
      
      private static ILookupTypesByContract type_registry;
      private static OurContract result;
    }
  }

  internal interface OurContract
  {
  }
}
