using System.Collections.Generic;
using System.Linq;
using System.Text;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.specs
{
  public class UrlTransformingVisitorSpecs
  {
    public abstract class concern : Observes<ITransformStoreTokensToANiceUrl, UrlTransformingVisitor>
    {
      Establish c = () =>
      {
        builder = new StringBuilder();
        
        sut_setup.run(x => x.url_builder = builder);
      };

      protected static StringBuilder builder;
    }

    [Subject(typeof(UrlTransformingVisitor))]
    public class when_visiting_the_first_key_value_pair : concern
    {
      Establish c = () =>
      {
        first_pair = new KeyValuePair<string, object>("this_should_be_ignored", typeof(AnApplicationBehaviour));
        expectedResult = "{0}.denver".format_using(typeof(AnApplicationBehaviour).Name);
      };

      Because b = () =>
        sut.visit(first_pair);

      It should_generate_a_properly_formatted_url = () =>
        builder.ToString().ShouldEqual(expectedResult);

      static string expectedResult;
      static KeyValuePair<string, object> first_pair;
    }

    public class when_visiting_the_second_item   : concern
    {
      Establish c = () =>
      {
        first_pair = new KeyValuePair<string, object>("this_should_be_ignored", typeof(AnApplicationBehaviour));
        second_pair = new KeyValuePair<string, object>("second",2);
        expectedResult = "{0}.denver?{1}={2}".format_using(typeof(AnApplicationBehaviour).Name,
          second_pair.Key,second_pair.Value.ToString());

        sut_setup.run(x => x.visit(first_pair));
      };

      Because b = () =>
        sut.visit(second_pair);

      It should_append_the_second_pair_using_the_correct_prefix = () =>
        builder.ToString().ShouldEqual(expectedResult);

      static string result;
      static string expectedResult;
      static KeyValuePair<string, object> first_pair;
      static KeyValuePair<string, object> second_pair;
    }

    public class when_visiting_the_remaining_items   : concern
    {
      Establish c = () =>
      {
        first_pair = new KeyValuePair<string, object>("this_should_be_ignored", typeof(AnApplicationBehaviour));
        second_pair = new KeyValuePair<string, object>("second",2);
        remaining = Enumerable.Range(1, 100).Select(x => new KeyValuePair<string, object>(x.ToString(), x)).ToList();

        sut_setup.run(x =>
        {
          x.visit(first_pair);
          x.visit(second_pair);
        });
      };

      Because b = () =>
        remaining.each(x => sut.visit(x));

      It should_append_the_remaining_items_correctly = () =>
      {
        var result = builder.ToString();
        remaining.each(x => result.ShouldContain("&{0}={1}".format_using(x.Key, x.Value.ToString())));
      };

      static string result;
      static KeyValuePair<string, object> first_pair;
      static KeyValuePair<string, object> second_pair;
      static IEnumerable<KeyValuePair<string, object>> remaining;
    }

    public class AnApplicationBehaviour
    {
    }
  }
}