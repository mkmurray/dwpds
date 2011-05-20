using System.Linq.Expressions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(MapPropertyAccessorExpressionToModelDotMember))]
  public class MapPropertyAccessorExpressionToModelDotMemberSpecs
  {
    public abstract class concern : Observes<IMapAnPropertyExpressionToAMeaningfulUrlTokenKey,
                                      MapPropertyAccessorExpressionToModelDotMember>
    {
    }

    public class when_mapping_a_property_accessor_to_model_dot_member : concern
    {
      Establish c = () =>
      {
        expected_token_key = string.Format(MapPropertyAccessorExpressionToModelDotMember.token_format,
                                           typeof(DummyClass).Name.ToLower(), "value");

        property_accessor_expression = x => x.value;
      };

      Because b = () =>
        result = sut.map(property_accessor_expression);

      It should_return_a_string_of_the_correct_format_and_values = () =>
        result.ShouldEqual(expected_token_key);

      static string expected_token_key;
      static string result;
      static Expression<PropertyAccessor<DummyClass, object>> property_accessor_expression;
    }

    class DummyClass
    {
      public object value { get; set; }
    }
  }
}