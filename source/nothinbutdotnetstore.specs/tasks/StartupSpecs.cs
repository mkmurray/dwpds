using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.infrastructure.container;
using nothinbutdotnetstore.tasks.startup;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.tasks
{
  [Subject(typeof(StartUp))]
  public class StartupSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_the_startup_process_has_completed : concern
    {
      Because b = () =>
        StartUp.run();

      It should_be_able_to_access_key_application_services = () =>
      {
        verify_can_retrieve_from_container<IProcessIncomingRequests>();
        verify_can_retrieve_from_container<ICreateRequests>();
      };

      static void verify_can_retrieve_from_container<ItemToFetch>()
      {
        Container.resolve.an<ItemToFetch>().ShouldNotBeNull();
      }
    }
  }
}
