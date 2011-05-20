 using System.Collections.Generic;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.core.urls;
using System.Linq;

namespace nothinbutdotnetstore.specs
{   
  public class UrlTransformingVisitorSpecs
  {
    public abstract class concern : Observes<ITransformStoreTokensToANiceUrl, UrlTransformingVisitor>                       
    {
        
    }

    [Subject(typeof(UrlTransformingVisitor))]
    public class when_visiting_the_store_tokens : concern
    {
      private Establish c = () =>
      {
        all_tokens = new List<KeyValuePair<string, object>>();
        all_tokens.Add(new KeyValuePair<string, object>("command", typeof(ViewMainDepartmentsInTheStore)));
        all_tokens.Add(new KeyValuePair<string, object>("department.id", 1));
        expectedResult = "ViewMainDepartmentsInTheStore.denver?department.id=1";
      };

      private Because b = () =>
      {
        all_tokens.each(t => sut.visit(t));
        result = sut.get_result();
      };

      private It should_generate_a_properly_formatted_url = () =>
      {
        result.ShouldEqual(expectedResult);
      };

      private static List<KeyValuePair<string, object>> all_tokens;
      private static string result;
      private static string expectedResult;
    }
  }
}
