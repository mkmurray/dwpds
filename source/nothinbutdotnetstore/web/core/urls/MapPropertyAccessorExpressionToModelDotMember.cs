using System.Linq;
using System.Linq.Expressions;

namespace nothinbutdotnetstore.web.core.urls
{
  public class MapPropertyAccessorExpressionToModelDotMember : IMapAnPropertyExpressionToAMeaningfulUrlTokenKey
  {
    public const string token_format ="{0}.{1}";

    public string map(Expression input)
    {
      var lambda = (LambdaExpression) input;
      var objName = lambda.Parameters.First().Type.Name.ToLower();
      var body = (MemberExpression) lambda.Body;
      var member_name = body.Member.Name.ToLower();
      return string.Format(token_format,objName ,member_name);
    }
  }
}