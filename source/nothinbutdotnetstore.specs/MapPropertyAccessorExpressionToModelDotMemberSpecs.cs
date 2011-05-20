 using System.Linq.Expressions;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
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
        url_token_key = "dummyclass.value";
        property_accessor_expression = x => x.value;
      };

      Because b = () =>
        result = sut.map(property_accessor_expression);

      It should_return_a_string_of_the_correct_format_and_values = () =>
        result.ShouldEqual(url_token_key);

      static string url_token_key;
      static string result;
      static Expression<PropertyAccessor<DummyClass,object>> property_accessor_expression;
    }

    private class DummyClass
    {
      public object value { get; set; }
    }
  }
}
