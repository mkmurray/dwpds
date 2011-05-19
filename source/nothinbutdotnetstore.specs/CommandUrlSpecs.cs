using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.specs
{
  public class CommandUrlSpecs
  {
    public abstract class concern : Observes
    {

    }

    [Subject(typeof (CommandUrlSpecs))]
    public class when_asking_for_the_command_from_an_IProvideAUrlToRunACommand: concern
    {
      Establish c = () =>
      {
        expected_url = "/the/url/to/reach";
      };

      Because b = () =>
        url = CommandUrl.to_run<OurCommand>();

      It the_url_is_determined_by_the_command = () =>
        url.ShouldEqual(expected_url);

      static string url;
      static string expected_url;
    }

    public class OurCommand : IProvideAUrlToRunACommand
    {
      public string get_url()
      {
        return "/the/url/to/reach";
      }
    }
  }
}
