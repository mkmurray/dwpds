using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(PathRegistry))]
  public class PathRegistrySpecs
  {
    public abstract class concern : Observes<IFindAspxPagesForReportModels,
                                      PathRegistry>
    {
    }

    public class when_finding_the_path_to_a_registered_aspx_page : concern
    {
      Establish c = () =>
      {
        the_path = "sdfsdf";
        sut_setup.run(x => x.Add(typeof(TheItemToRender), the_path));
      };

      Because b = () =>
        result = sut.get_the_path_to_a_page_that_can_render<TheItemToRender>();

      It should_return_the_path_to_the_aspx_page = () =>
        result.ShouldEqual(the_path);

      static string result;
      static string the_path;
    }
  }

  public class TheItemToRender
  {
  }
}