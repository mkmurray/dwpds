using developwithpassion.specifications.core;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.infrastructure.container;

namespace nothinbutdotnetstore.specs.utility
{
  public class SharedBehaviours
  {
    public static void scaffold_container_returned<Dependency>(Dependency dependency, IConfigureSetupPairs pipeline,
                                                               ICreateFakes fake)
    {
      var container_fake = fake.an<IFetchDependencies>();
      var original_resolver = Container.gateway_resolver;
      container_fake.setup(x => x.an<Dependency>()).Return(dependency);

      pipeline.add_setup_teardown_pair(
        () =>
        {
          Container.gateway_resolver = () => container_fake;
        },
        () =>
        {
          Container.gateway_resolver = original_resolver;
        });
    }
  }
}