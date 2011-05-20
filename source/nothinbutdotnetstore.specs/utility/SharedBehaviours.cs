using System;
using developwithpassion.specifications;
using developwithpassion.specifications.core;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.infrastructure.container;
using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.specs.utility
{
  public class SharedBehaviours
  {
    public static void scaffold_container_returned<Dependency>(Dependency dependency, IConfigureSetupPairs pipeline, ICreateFakes fake)
    {
      var container_fake = fake.an<IFetchDependencies>();
      container_fake.setup(x => x.an<Dependency>()).Return(dependency);
      pipeline.add_setup_teardown_pair(
        () =>
        {
          Container.gateway_resolver = () => container_fake;
        },
        () =>
        {
        });
    }
  }
}