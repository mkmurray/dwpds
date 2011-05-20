using System;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.container;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.urls;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
  public class CommandUrlSpecs
  {
    public abstract class concern : Observes
    {
    }

    [Subject(typeof(CommandUrlSpecs))]
    public class when_building_a_url_to_target_a_behaviour : concern
    {
      Establish c = () =>
      {
        UrlBuilderFactory factory = () => the_url_builder;

        the_url_builder = fake.an<IBuildUrls>();
        url_adorner = fake.an<IAddExtraInformationForABehaviourTarget>();


        the_url_builder.setup(x => x.target<OurCommand>()).Return(url_adorner);

        SharedBehaviours.scaffold_container_returned(factory, pipeline , fake);

      };

      Because b = () =>
        result = CommandUrl.to_run<OurCommand>();


      It should_return_the_url_adorner = () =>
        result.ShouldEqual(url_adorner);


      static IAddExtraInformationForABehaviourTarget result;
      static string expected_url;
      static IBuildUrls the_url_builder;
      static IAddExtraInformationForABehaviourTarget url_adorner;
      static IFetchDependencies container;
    }

    public class OurCommand : IProcessAnApplicationSpecificBehaviour
    {
      public void run(IContainRequestInformation request)
      {
        throw new NotImplementedException();
      }
    }
  }
}